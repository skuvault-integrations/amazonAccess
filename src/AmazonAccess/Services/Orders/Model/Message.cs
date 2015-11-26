/*******************************************************************************
 * Copyright 2009-2015 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * Message
 * API Version: 2013-09-01
 * Library Version: 2015-09-24
 * Generated: Fri Sep 25 20:06:25 GMT 2015
 */

using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Orders.Model
{
	public class Message: AbstractMwsObject
	{
		/// <summary>
		/// Gets and sets the Locale property.
		/// </summary>
		public string Locale{ get; set; }

		/// <summary>
		/// Sets the Locale property.
		/// </summary>
		/// <param name="locale">Locale property.</param>
		/// <returns>this instance.</returns>
		public Message WithLocale( string locale )
		{
			this.Locale = locale;
			return this;
		}

		/// <summary>
		/// Checks if Locale property is set.
		/// </summary>
		/// <returns>true if Locale property is set.</returns>
		public bool IsSetLocale()
		{
			return this.Locale != null;
		}

		/// <summary>
		/// Gets and sets the Text property.
		/// </summary>
		public string Text{ get; set; }

		/// <summary>
		/// Sets the Text property.
		/// </summary>
		/// <param name="text">Text property.</param>
		/// <returns>this instance.</returns>
		public Message WithText( string text )
		{
			this.Text = text;
			return this;
		}

		/// <summary>
		/// Checks if Text property is set.
		/// </summary>
		/// <returns>true if Text property is set.</returns>
		public bool IsSetText()
		{
			return this.Text != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.Locale = reader.Read< string >( "Locale" );
			this.Text = reader.Read< string >( "Text" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "Locale", this.Locale );
			writer.Write( "Text", this.Text );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "https://mws.amazonservices.com/Orders/2013-09-01", "Message", this );
		}

		public Message(): base()
		{
		}
	}
}