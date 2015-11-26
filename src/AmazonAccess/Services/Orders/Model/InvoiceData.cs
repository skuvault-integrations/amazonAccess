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
 * Invoice Data
 * API Version: 2013-09-01
 * Library Version: 2015-09-24
 * Generated: Fri Sep 25 20:06:25 GMT 2015
 */

using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Orders.Model
{
	public class InvoiceData: AbstractMwsObject
	{
		/// <summary>
		/// Gets and sets the InvoiceRequirement property.
		/// </summary>
		public string InvoiceRequirement{ get; set; }

		/// <summary>
		/// Sets the InvoiceRequirement property.
		/// </summary>
		/// <param name="invoiceRequirement">InvoiceRequirement property.</param>
		/// <returns>this instance.</returns>
		public InvoiceData WithInvoiceRequirement( string invoiceRequirement )
		{
			this.InvoiceRequirement = invoiceRequirement;
			return this;
		}

		/// <summary>
		/// Checks if InvoiceRequirement property is set.
		/// </summary>
		/// <returns>true if InvoiceRequirement property is set.</returns>
		public bool IsSetInvoiceRequirement()
		{
			return this.InvoiceRequirement != null;
		}

		/// <summary>
		/// Gets and sets the BuyerSelectedInvoiceCategory property.
		/// </summary>
		public string BuyerSelectedInvoiceCategory{ get; set; }

		/// <summary>
		/// Sets the BuyerSelectedInvoiceCategory property.
		/// </summary>
		/// <param name="buyerSelectedInvoiceCategory">BuyerSelectedInvoiceCategory property.</param>
		/// <returns>this instance.</returns>
		public InvoiceData WithBuyerSelectedInvoiceCategory( string buyerSelectedInvoiceCategory )
		{
			this.BuyerSelectedInvoiceCategory = buyerSelectedInvoiceCategory;
			return this;
		}

		/// <summary>
		/// Checks if BuyerSelectedInvoiceCategory property is set.
		/// </summary>
		/// <returns>true if BuyerSelectedInvoiceCategory property is set.</returns>
		public bool IsSetBuyerSelectedInvoiceCategory()
		{
			return this.BuyerSelectedInvoiceCategory != null;
		}

		/// <summary>
		/// Gets and sets the InvoiceTitle property.
		/// </summary>
		public string InvoiceTitle{ get; set; }

		/// <summary>
		/// Sets the InvoiceTitle property.
		/// </summary>
		/// <param name="invoiceTitle">InvoiceTitle property.</param>
		/// <returns>this instance.</returns>
		public InvoiceData WithInvoiceTitle( string invoiceTitle )
		{
			this.InvoiceTitle = invoiceTitle;
			return this;
		}

		/// <summary>
		/// Checks if InvoiceTitle property is set.
		/// </summary>
		/// <returns>true if InvoiceTitle property is set.</returns>
		public bool IsSetInvoiceTitle()
		{
			return this.InvoiceTitle != null;
		}

		/// <summary>
		/// Gets and sets the InvoiceInformation property.
		/// </summary>
		public string InvoiceInformation{ get; set; }

		/// <summary>
		/// Sets the InvoiceInformation property.
		/// </summary>
		/// <param name="invoiceInformation">InvoiceInformation property.</param>
		/// <returns>this instance.</returns>
		public InvoiceData WithInvoiceInformation( string invoiceInformation )
		{
			this.InvoiceInformation = invoiceInformation;
			return this;
		}

		/// <summary>
		/// Checks if InvoiceInformation property is set.
		/// </summary>
		/// <returns>true if InvoiceInformation property is set.</returns>
		public bool IsSetInvoiceInformation()
		{
			return this.InvoiceInformation != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.InvoiceRequirement = reader.Read< string >( "InvoiceRequirement" );
			this.BuyerSelectedInvoiceCategory = reader.Read< string >( "BuyerSelectedInvoiceCategory" );
			this.InvoiceTitle = reader.Read< string >( "InvoiceTitle" );
			this.InvoiceInformation = reader.Read< string >( "InvoiceInformation" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "InvoiceRequirement", this.InvoiceRequirement );
			writer.Write( "BuyerSelectedInvoiceCategory", this.BuyerSelectedInvoiceCategory );
			writer.Write( "InvoiceTitle", this.InvoiceTitle );
			writer.Write( "InvoiceInformation", this.InvoiceInformation );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "https://mws.amazonservices.com/Orders/2013-09-01", "InvoiceData", this );
		}

		public InvoiceData(): base()
		{
		}
	}
}