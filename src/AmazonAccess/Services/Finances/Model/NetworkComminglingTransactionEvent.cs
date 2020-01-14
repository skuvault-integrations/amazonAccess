/*******************************************************************************
 * Copyright 2009-2019 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * Network Commingling Transaction Event
 * API Version: 2015-05-01
 * Library Version: 2019-02-25
 * Generated: Wed Mar 13 08:17:08 PDT 2019
 */

using AmazonAccess.Services.Common;
using System;

namespace AmazonAccess.Services.Finances.Model
{
	public class NetworkComminglingTransactionEvent : AbstractMwsObject
	{
		private string _transactionType;
		private DateTime? _postedDate;
		private string _netCoTransactionID;
		private string _swapReason;
		private string _asin;
		private string _marketplaceId;
		private Currency _taxExclusiveAmount;
		private Currency _taxAmount;

		/// <summary>
		/// Gets and sets the TransactionType property.
		/// </summary>
		public string TransactionType
		{
			get { return this._transactionType; }
			set { this._transactionType = value; }
		}

		/// <summary>
		/// Sets the TransactionType property.
		/// </summary>
		/// <param name="transactionType">TransactionType property.</param>
		/// <returns>this instance.</returns>
		public NetworkComminglingTransactionEvent WithTransactionType( string transactionType )
		{
			this._transactionType = transactionType;
			return this;
		}

		/// <summary>
		/// Checks if TransactionType property is set.
		/// </summary>
		/// <returns>true if TransactionType property is set.</returns>
		public bool IsSetTransactionType()
		{
			return this._transactionType != null;
		}

		/// <summary>
		/// Gets and sets the PostedDate property.
		/// </summary>
		public DateTime PostedDate
		{
			get { return this._postedDate.GetValueOrDefault(); }
			set { this._postedDate = value; }
		}

		/// <summary>
		/// Sets the PostedDate property.
		/// </summary>
		/// <param name="postedDate">PostedDate property.</param>
		/// <returns>this instance.</returns>
		public NetworkComminglingTransactionEvent WithPostedDate( DateTime postedDate )
		{
			this._postedDate = postedDate;
			return this;
		}

		/// <summary>
		/// Checks if PostedDate property is set.
		/// </summary>
		/// <returns>true if PostedDate property is set.</returns>
		public bool IsSetPostedDate()
		{
			return this._postedDate != null;
		}

		/// <summary>
		/// Gets and sets the NetCoTransactionID property.
		/// </summary>
		public string NetCoTransactionID
		{
			get { return this._netCoTransactionID; }
			set { this._netCoTransactionID = value; }
		}

		/// <summary>
		/// Sets the NetCoTransactionID property.
		/// </summary>
		/// <param name="netCoTransactionID">NetCoTransactionID property.</param>
		/// <returns>this instance.</returns>
		public NetworkComminglingTransactionEvent WithNetCoTransactionID( string netCoTransactionID )
		{
			this._netCoTransactionID = netCoTransactionID;
			return this;
		}

		/// <summary>
		/// Checks if NetCoTransactionID property is set.
		/// </summary>
		/// <returns>true if NetCoTransactionID property is set.</returns>
		public bool IsSetNetCoTransactionID()
		{
			return this._netCoTransactionID != null;
		}

		/// <summary>
		/// Gets and sets the SwapReason property.
		/// </summary>
		public string SwapReason
		{
			get { return this._swapReason; }
			set { this._swapReason = value; }
		}

		/// <summary>
		/// Sets the SwapReason property.
		/// </summary>
		/// <param name="swapReason">SwapReason property.</param>
		/// <returns>this instance.</returns>
		public NetworkComminglingTransactionEvent WithSwapReason( string swapReason )
		{
			this._swapReason = swapReason;
			return this;
		}

		/// <summary>
		/// Checks if SwapReason property is set.
		/// </summary>
		/// <returns>true if SwapReason property is set.</returns>
		public bool IsSetSwapReason()
		{
			return this._swapReason != null;
		}

		/// <summary>
		/// Gets and sets the ASIN property.
		/// </summary>
		public string ASIN
		{
			get { return this._asin; }
			set { this._asin = value; }
		}

		/// <summary>
		/// Sets the ASIN property.
		/// </summary>
		/// <param name="asin">ASIN property.</param>
		/// <returns>this instance.</returns>
		public NetworkComminglingTransactionEvent WithASIN( string asin )
		{
			this._asin = asin;
			return this;
		}

		/// <summary>
		/// Checks if ASIN property is set.
		/// </summary>
		/// <returns>true if ASIN property is set.</returns>
		public bool IsSetASIN()
		{
			return this._asin != null;
		}

		/// <summary>
		/// Gets and sets the MarketplaceId property.
		/// </summary>
		public string MarketplaceId
		{
			get { return this._marketplaceId; }
			set { this._marketplaceId = value; }
		}

		/// <summary>
		/// Sets the MarketplaceId property.
		/// </summary>
		/// <param name="marketplaceId">MarketplaceId property.</param>
		/// <returns>this instance.</returns>
		public NetworkComminglingTransactionEvent WithMarketplaceId( string marketplaceId )
		{
			this._marketplaceId = marketplaceId;
			return this;
		}

		/// <summary>
		/// Checks if MarketplaceId property is set.
		/// </summary>
		/// <returns>true if MarketplaceId property is set.</returns>
		public bool IsSetMarketplaceId()
		{
			return this._marketplaceId != null;
		}

		/// <summary>
		/// Gets and sets the TaxExclusiveAmount property.
		/// </summary>
		public Currency TaxExclusiveAmount
		{
			get { return this._taxExclusiveAmount; }
			set { this._taxExclusiveAmount = value; }
		}

		/// <summary>
		/// Sets the TaxExclusiveAmount property.
		/// </summary>
		/// <param name="taxExclusiveAmount">TaxExclusiveAmount property.</param>
		/// <returns>this instance.</returns>
		public NetworkComminglingTransactionEvent WithTaxExclusiveAmount( Currency taxExclusiveAmount )
		{
			this._taxExclusiveAmount = taxExclusiveAmount;
			return this;
		}

		/// <summary>
		/// Checks if TaxExclusiveAmount property is set.
		/// </summary>
		/// <returns>true if TaxExclusiveAmount property is set.</returns>
		public bool IsSetTaxExclusiveAmount()
		{
			return this._taxExclusiveAmount != null;
		}

		/// <summary>
		/// Gets and sets the TaxAmount property.
		/// </summary>
		public Currency TaxAmount
		{
			get { return this._taxAmount; }
			set { this._taxAmount = value; }
		}

		/// <summary>
		/// Sets the TaxAmount property.
		/// </summary>
		/// <param name="taxAmount">TaxAmount property.</param>
		/// <returns>this instance.</returns>
		public NetworkComminglingTransactionEvent WithTaxAmount( Currency taxAmount )
		{
			this._taxAmount = taxAmount;
			return this;
		}

		/// <summary>
		/// Checks if TaxAmount property is set.
		/// </summary>
		/// <returns>true if TaxAmount property is set.</returns>
		public bool IsSetTaxAmount()
		{
			return this._taxAmount != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			_transactionType = reader.Read< string >( "TransactionType" );
			_postedDate = reader.Read< DateTime? >( "PostedDate" );
			_netCoTransactionID = reader.Read< string >( "NetCoTransactionID" );
			_swapReason = reader.Read< string >( "SwapReason" );
			_asin = reader.Read< string >( "ASIN" );
			_marketplaceId = reader.Read< string >( "MarketplaceId" );
			_taxExclusiveAmount = reader.Read< Currency >( "TaxExclusiveAmount" );
			_taxAmount = reader.Read< Currency >( "TaxAmount" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "TransactionType", _transactionType );
			writer.Write( "PostedDate", _postedDate );
			writer.Write( "NetCoTransactionID", _netCoTransactionID );
			writer.Write( "SwapReason", _swapReason );
			writer.Write( "ASIN", _asin );
			writer.Write( "MarketplaceId", _marketplaceId );
			writer.Write( "TaxExclusiveAmount", _taxExclusiveAmount );
			writer.Write( "TaxAmount", _taxAmount );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/Finances/2015-05-01", "NetworkComminglingTransactionEvent", this );
		}

		public NetworkComminglingTransactionEvent() : base()
		{
		}
	}
}