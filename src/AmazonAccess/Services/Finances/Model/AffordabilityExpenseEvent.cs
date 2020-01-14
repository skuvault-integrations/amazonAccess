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
 * Affordability Expense Event
 * API Version: 2015-05-01
 * Library Version: 2019-02-25
 * Generated: Wed Mar 13 08:17:08 PDT 2019
 */

using AmazonAccess.Services.Common;
using System;

namespace AmazonAccess.Services.Finances.Model
{
	public class AffordabilityExpenseEvent : AbstractMwsObject
	{
		private string _amazonOrderId;
		private DateTime? _postedDate;
		private string _marketplaceId;
		private string _transactionType;
		private Currency _baseExpense;
		private Currency _taxTypeCGST;
		private Currency _taxTypeSGST;
		private Currency _taxTypeIGST;
		private Currency _totalExpense;

		/// <summary>
		/// Gets and sets the AmazonOrderId property.
		/// </summary>
		public string AmazonOrderId
		{
			get { return this._amazonOrderId; }
			set { this._amazonOrderId = value; }
		}

		/// <summary>
		/// Sets the AmazonOrderId property.
		/// </summary>
		/// <param name="amazonOrderId">AmazonOrderId property.</param>
		/// <returns>this instance.</returns>
		public AffordabilityExpenseEvent WithAmazonOrderId( string amazonOrderId )
		{
			this._amazonOrderId = amazonOrderId;
			return this;
		}

		/// <summary>
		/// Checks if AmazonOrderId property is set.
		/// </summary>
		/// <returns>true if AmazonOrderId property is set.</returns>
		public bool IsSetAmazonOrderId()
		{
			return this._amazonOrderId != null;
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
		public AffordabilityExpenseEvent WithPostedDate( DateTime postedDate )
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
		public AffordabilityExpenseEvent WithMarketplaceId( string marketplaceId )
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
		public AffordabilityExpenseEvent WithTransactionType( string transactionType )
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
		/// Gets and sets the BaseExpense property.
		/// </summary>
		public Currency BaseExpense
		{
			get { return this._baseExpense; }
			set { this._baseExpense = value; }
		}

		/// <summary>
		/// Sets the BaseExpense property.
		/// </summary>
		/// <param name="baseExpense">BaseExpense property.</param>
		/// <returns>this instance.</returns>
		public AffordabilityExpenseEvent WithBaseExpense( Currency baseExpense )
		{
			this._baseExpense = baseExpense;
			return this;
		}

		/// <summary>
		/// Checks if BaseExpense property is set.
		/// </summary>
		/// <returns>true if BaseExpense property is set.</returns>
		public bool IsSetBaseExpense()
		{
			return this._baseExpense != null;
		}

		/// <summary>
		/// Gets and sets the TaxTypeCGST property.
		/// </summary>
		public Currency TaxTypeCGST
		{
			get { return this._taxTypeCGST; }
			set { this._taxTypeCGST = value; }
		}

		/// <summary>
		/// Sets the TaxTypeCGST property.
		/// </summary>
		/// <param name="taxTypeCGST">TaxTypeCGST property.</param>
		/// <returns>this instance.</returns>
		public AffordabilityExpenseEvent WithTaxTypeCGST( Currency taxTypeCGST )
		{
			this._taxTypeCGST = taxTypeCGST;
			return this;
		}

		/// <summary>
		/// Checks if TaxTypeCGST property is set.
		/// </summary>
		/// <returns>true if TaxTypeCGST property is set.</returns>
		public bool IsSetTaxTypeCGST()
		{
			return this._taxTypeCGST != null;
		}

		/// <summary>
		/// Gets and sets the TaxTypeSGST property.
		/// </summary>
		public Currency TaxTypeSGST
		{
			get { return this._taxTypeSGST; }
			set { this._taxTypeSGST = value; }
		}

		/// <summary>
		/// Sets the TaxTypeSGST property.
		/// </summary>
		/// <param name="taxTypeSGST">TaxTypeSGST property.</param>
		/// <returns>this instance.</returns>
		public AffordabilityExpenseEvent WithTaxTypeSGST( Currency taxTypeSGST )
		{
			this._taxTypeSGST = taxTypeSGST;
			return this;
		}

		/// <summary>
		/// Checks if TaxTypeSGST property is set.
		/// </summary>
		/// <returns>true if TaxTypeSGST property is set.</returns>
		public bool IsSetTaxTypeSGST()
		{
			return this._taxTypeSGST != null;
		}

		/// <summary>
		/// Gets and sets the TaxTypeIGST property.
		/// </summary>
		public Currency TaxTypeIGST
		{
			get { return this._taxTypeIGST; }
			set { this._taxTypeIGST = value; }
		}

		/// <summary>
		/// Sets the TaxTypeIGST property.
		/// </summary>
		/// <param name="taxTypeIGST">TaxTypeIGST property.</param>
		/// <returns>this instance.</returns>
		public AffordabilityExpenseEvent WithTaxTypeIGST( Currency taxTypeIGST )
		{
			this._taxTypeIGST = taxTypeIGST;
			return this;
		}

		/// <summary>
		/// Checks if TaxTypeIGST property is set.
		/// </summary>
		/// <returns>true if TaxTypeIGST property is set.</returns>
		public bool IsSetTaxTypeIGST()
		{
			return this._taxTypeIGST != null;
		}

		/// <summary>
		/// Gets and sets the TotalExpense property.
		/// </summary>
		public Currency TotalExpense
		{
			get { return this._totalExpense; }
			set { this._totalExpense = value; }
		}

		/// <summary>
		/// Sets the TotalExpense property.
		/// </summary>
		/// <param name="totalExpense">TotalExpense property.</param>
		/// <returns>this instance.</returns>
		public AffordabilityExpenseEvent WithTotalExpense( Currency totalExpense )
		{
			this._totalExpense = totalExpense;
			return this;
		}

		/// <summary>
		/// Checks if TotalExpense property is set.
		/// </summary>
		/// <returns>true if TotalExpense property is set.</returns>
		public bool IsSetTotalExpense()
		{
			return this._totalExpense != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			_amazonOrderId = reader.Read< string >( "AmazonOrderId" );
			_postedDate = reader.Read< DateTime? >( "PostedDate" );
			_marketplaceId = reader.Read< string >( "MarketplaceId" );
			_transactionType = reader.Read< string >( "TransactionType" );
			_baseExpense = reader.Read< Currency >( "BaseExpense" );
			_taxTypeCGST = reader.Read< Currency >( "TaxTypeCGST" );
			_taxTypeSGST = reader.Read< Currency >( "TaxTypeSGST" );
			_taxTypeIGST = reader.Read< Currency >( "TaxTypeIGST" );
			_totalExpense = reader.Read< Currency >( "TotalExpense" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "AmazonOrderId", _amazonOrderId );
			writer.Write( "PostedDate", _postedDate );
			writer.Write( "MarketplaceId", _marketplaceId );
			writer.Write( "TransactionType", _transactionType );
			writer.Write( "BaseExpense", _baseExpense );
			writer.Write( "TaxTypeCGST", _taxTypeCGST );
			writer.Write( "TaxTypeSGST", _taxTypeSGST );
			writer.Write( "TaxTypeIGST", _taxTypeIGST );
			writer.Write( "TotalExpense", _totalExpense );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/Finances/2015-05-01", "AffordabilityExpenseEvent", this );
		}

		public AffordabilityExpenseEvent() : base()
		{
		}
	}
}