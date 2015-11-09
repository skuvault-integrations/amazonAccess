/******************************************************************************* 
 * Copyright 2009-2012 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * Marketplace Web Service Runtime Client Library
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace AmazonAccess.Services.Common
{
	public class MwsXmlWriter: IMwsWriter
	{
		protected XmlWriter writer{ get; set; }

		// Chars that must be escaped for XML. 
		private static readonly string ESCAPED_CHARS = "&<>'\"";

		// Escape sequences for escaped chars, in order.
		private static readonly String[] ESCAPE_SEQ = new String[] { "&amp;", "&lt;", "&gt;", "&#039;", "&quot;" };

		private static readonly TypeCode[] numericTypes = { TypeCode.Double, TypeCode.Int16, TypeCode.Int32, TypeCode.Int64, TypeCode.Decimal };

		public MwsXmlWriter()
		{
		}

		public void close()
		{
			if( this.writer != null )
			{
				this.writer.WriteEndDocument();
				try
				{
					this.writer.Close();
				}
				catch( Exception ex )
				{
					throw new SystemException( "Error closing the writer", ex.InnerException );
				}
			}
		}

		public void BeginObject( string name )
		{
			this.BeginObject( name, false );
		}

		public void EndObject( string name )
		{
			this.EndObject( name, false );
		}

		private void BeginObject( string name, bool writingAttr )
		{
			if( writingAttr )
				this.writer.WriteStartAttribute( name );
			else
				this.writer.WriteStartElement( name );
		}

		private void BeginObject( string name, string namespc, bool writingAttr )
		{
			if( writingAttr )
				this.writer.WriteStartAttribute( name );
			else
				this.writer.WriteStartElement( name, namespc );
		}

		private void EndObject( string name, bool writingAttr )
		{
			if( writingAttr )
				this.writer.WriteEndAttribute();
			else
				this.writer.WriteEndElement();
		}

		public void WriteList< T >( string memberName, ICollection< T > list )
		{
			if( list != null )
			{
				foreach( object elem in list )
				{
					this.Write( memberName, elem );
				}
			}
		}

		public void WriteList< T >( string name, string memberName, ICollection< T > list )
		{
			if( list != null )
			{
				this.BeginObject( name );
				foreach( object elem in list )
				{
					this.Write( memberName, elem );
				}
				this.EndObject( name );
			}
		}

		public void WriteAny( ICollection< XmlElement > elements )
		{
			if( elements != null )
			{
				foreach( XmlElement element in elements )
				{
					string name = element.LocalName;
					if( name == null )
						name = element.Name;
					this.Write( name, element );
				}
			}
		}

		public void Write( string name, object value )
		{
			if( value != null )
			{
				Type type = value.GetType();
				if( Nullable.GetUnderlyingType( type ) != null )
					type = Nullable.GetUnderlyingType( type );

				if( typeof( string ).IsAssignableFrom( type ) )
				{
					this.BeginObject( name, false );
					this.EscapeAndWrite( ( String )value );
					this.EndObject( name, false );
				}
				else if( typeof( IConvertible ).IsAssignableFrom( type ) )
					this.writer.WriteElementString( name, ( string )Convert.ChangeType( value, typeof( string ), CultureInfo.InvariantCulture ) );
				else if( typeof( IMwsObject ).IsAssignableFrom( type ) )
				{
					this.BeginObject( name, false );
					( ( IMwsObject )value ).WriteFragmentTo( this );
					this.EndObject( name, false );
				}
				else if( typeof( ICollection ).IsAssignableFrom( type ) )
				{
					foreach( object v in ( ICollection )value )
					{
						this.Write( name, v );
					}
				}
				else if( typeof( XmlNode ).IsAssignableFrom( type ) )
					this.writer.WriteRaw( ( ( XmlNode )value ).OuterXml );
				else
					throw new ArgumentException( "Unexpected object type: " + type );
			}
		}

		public void WriteAttribute( string name, object value )
		{
			if( value != null )
			{
				this.BeginObject( name, true );
				this.EscapeAndWrite( value.ToString() );
				this.EndObject( name, true );
			}
		}

		public void WriteValue( object value )
		{
			if( value != null )
				this.writer.WriteString( value.ToString() );
		}

		private void EscapeAndWrite( string value )
		{
			int n = value.Length;
			int i = 0;
			for( int j = 0; j < n; ++j )
			{
				int k = ESCAPED_CHARS.IndexOf( value[ j ] );
				if( k >= 0 )
				{
					if( i < j )
						this.writer.WriteChars( value.ToCharArray(), i, j - i );
					this.writer.WriteString( ESCAPE_SEQ[ k ] );
					i = j + 1;
				}
			}
			if( i < n )
				this.writer.WriteChars( value.ToCharArray(), i, n - i );
		}

		private bool IsNumeric( Type type )
		{
			return numericTypes.Contains( Type.GetTypeCode( type ) );
		}

		public void Write( string namespc, string name, IMwsObject mwsObject )
		{
			if( mwsObject != null )
			{
				this.BeginObject( name, namespc, false );
				if( namespc == String.Empty )
					this.WriteAttribute( "xmlns", namespc );
				mwsObject.WriteFragmentTo( this );
				this.EndObject( name );
			}
		}
	}
}