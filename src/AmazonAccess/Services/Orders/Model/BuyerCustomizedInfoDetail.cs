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
 * Buyer Customized Info Detail
 * API Version: 2013-09-01
 * Library Version: 2015-09-24
 * Generated: Fri Sep 25 20:06:25 GMT 2015
 */

using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Orders.Model
{
	public class BuyerCustomizedInfoDetail: AbstractMwsObject
	{
		/// <summary>
		/// Gets and sets the CustomizedURL property.
		/// </summary>
		public string CustomizedURL{ get; set; }

		/// <summary>
		/// Sets the CustomizedURL property.
		/// </summary>
		/// <param name="customizedURL">CustomizedURL property.</param>
		/// <returns>this instance.</returns>
		public BuyerCustomizedInfoDetail WithCustomizedURL( string customizedURL )
		{
			this.CustomizedURL = customizedURL;
			return this;
		}

		/// <summary>
		/// Checks if CustomizedURL property is set.
		/// </summary>
		/// <returns>true if CustomizedURL property is set.</returns>
		public bool IsSetCustomizedURL()
		{
			return this.CustomizedURL != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.CustomizedURL = reader.Read< string >( "CustomizedURL" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "CustomizedURL", this.CustomizedURL );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "https://mws.amazonservices.com/Orders/2013-09-01", "BuyerCustomizedInfoDetail", this );
		}

		public BuyerCustomizedInfoDetail(): base()
		{
		}
	}
}