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

using System.Text;
using System.Xml;

namespace AmazonAccess.Services.Common
{
	public class MwsXmlBuilder: MwsXmlWriter
	{
		private readonly StringBuilder builder;

		public MwsXmlBuilder(): this( false )
		{
		}

		public MwsXmlBuilder( bool toWrap )
		{
			this.builder = new StringBuilder();
			XmlWriterSettings settings = new XmlWriterSettings { OmitXmlDeclaration = !toWrap };
			this.writer = XmlWriter.Create( this.builder, settings );
		}

		public MwsXmlBuilder( bool toWrap, ConformanceLevel conformanceLevel )
		{
			this.builder = new StringBuilder();
			XmlWriterSettings settings = new XmlWriterSettings
			{
				OmitXmlDeclaration = !toWrap,
				ConformanceLevel = conformanceLevel
			};
			this.writer = XmlWriter.Create( this.builder, settings );
		}

		public override string ToString()
		{
			this.writer.Flush();
			return this.builder.ToString( 0, this.builder.Length );
		}

		#region IDisposable Members
		protected override void Dispose( bool disposing )
		{
			if( this._disposed )
				return;

			if( disposing )
			{
				if( this.builder != null )
					this.builder.Clear();
			}

			this._disposed = true;
			base.Dispose( disposing );
		}

		~MwsXmlBuilder()
		{
			this.Dispose( false );
		}

		private bool _disposed;
		#endregion IDisposable Members
	}
}