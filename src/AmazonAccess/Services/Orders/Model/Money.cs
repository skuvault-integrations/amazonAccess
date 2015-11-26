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
 * Money
 * API Version: 2013-09-01
 * Library Version: 2015-09-24
 * Generated: Fri Sep 25 20:06:25 GMT 2015
 */

using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Orders.Model
{
	public class Money: AbstractMwsObject
	{
		/// <summary>
		/// Gets and sets the CurrencyCode property.
		/// </summary>
		public string CurrencyCode{ get; set; }

		/// <summary>
		/// Sets the CurrencyCode property.
		/// </summary>
		/// <param name="currencyCode">CurrencyCode property.</param>
		/// <returns>this instance.</returns>
		public Money WithCurrencyCode( string currencyCode )
		{
			this.CurrencyCode = currencyCode;
			return this;
		}

		/// <summary>
		/// Checks if CurrencyCode property is set.
		/// </summary>
		/// <returns>true if CurrencyCode property is set.</returns>
		public bool IsSetCurrencyCode()
		{
			return this.CurrencyCode != null;
		}

		/// <summary>
		/// Gets and sets the Amount property.
		/// </summary>
		public string Amount{ get; set; }

		/// <summary>
		/// Sets the Amount property.
		/// </summary>
		/// <param name="amount">Amount property.</param>
		/// <returns>this instance.</returns>
		public Money WithAmount( string amount )
		{
			this.Amount = amount;
			return this;
		}

		/// <summary>
		/// Checks if Amount property is set.
		/// </summary>
		/// <returns>true if Amount property is set.</returns>
		public bool IsSetAmount()
		{
			return this.Amount != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.CurrencyCode = reader.Read< string >( "CurrencyCode" );
			this.Amount = reader.Read< string >( "Amount" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "CurrencyCode", this.CurrencyCode );
			writer.Write( "Amount", this.Amount );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "https://mws.amazonservices.com/Orders/2013-09-01", "Money", this );
		}

		public Money(): base()
		{
		}
	}
}