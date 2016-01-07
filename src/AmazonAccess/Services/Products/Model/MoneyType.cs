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
 * Money Type
 * API Version: 2011-10-01
 * Library Version: 2015-09-01
 * Generated: Thu Sep 10 06:52:19 PDT 2015
 */

using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Products.Model
{
	[ XmlType( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01" ) ]
	[ XmlRoot( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01", IsNullable = false ) ]
	public class MoneyType: AbstractMwsObject
	{
		private decimal? _amount;

		/// <summary>
		/// Gets and sets the CurrencyCode property.
		/// </summary>
		[ XmlElement( ElementName = "CurrencyCode" ) ]
		public string CurrencyCode{ get; set; }

		/// <summary>
		/// Sets the CurrencyCode property.
		/// </summary>
		/// <param name="currencyCode">CurrencyCode property.</param>
		/// <returns>this instance.</returns>
		public MoneyType WithCurrencyCode( string currencyCode )
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
		[ XmlElement( ElementName = "Amount" ) ]
		public decimal Amount
		{
			get { return this._amount.GetValueOrDefault(); }
			set { this._amount = value; }
		}

		/// <summary>
		/// Sets the Amount property.
		/// </summary>
		/// <param name="amount">Amount property.</param>
		/// <returns>this instance.</returns>
		public MoneyType WithAmount( decimal amount )
		{
			this._amount = amount;
			return this;
		}

		/// <summary>
		/// Checks if Amount property is set.
		/// </summary>
		/// <returns>true if Amount property is set.</returns>
		public bool IsSetAmount()
		{
			return this._amount != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.CurrencyCode = reader.Read< string >( "CurrencyCode" );
			this._amount = reader.Read< decimal? >( "Amount" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "CurrencyCode", this.CurrencyCode );
			writer.Write( "Amount", this._amount );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "MoneyType", this );
		}

		public MoneyType(): base()
		{
		}
	}
}