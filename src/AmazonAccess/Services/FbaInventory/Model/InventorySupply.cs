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
 * Inventory Supply
 * API Version: 2010-10-01
 * Library Version: 2015-06-18
 * Generated: Thu Jun 18 19:30:05 GMT 2015
 */

using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.FbaInventory.Model
{
	[ XmlType ]
	[ XmlRoot( IsNullable = false ) ]
	public class InventorySupply: AbstractMwsObject
	{
		private decimal? _totalSupplyQuantity;
		private decimal? _inStockSupplyQuantity;

		/// <summary>
		/// Gets and sets the SellerSKU property.
		/// </summary>
		[ XmlElement( ElementName = "SellerSKU" ) ]
		public string SellerSKU{ get; set; }

		/// <summary>
		/// Sets the SellerSKU property.
		/// </summary>
		/// <param name="sellerSKU">SellerSKU property.</param>
		/// <returns>this instance.</returns>
		public InventorySupply WithSellerSKU( string sellerSKU )
		{
			this.SellerSKU = sellerSKU;
			return this;
		}

		/// <summary>
		/// Checks if SellerSKU property is set.
		/// </summary>
		/// <returns>true if SellerSKU property is set.</returns>
		public bool IsSetSellerSKU()
		{
			return this.SellerSKU != null;
		}

		/// <summary>
		/// Gets and sets the FNSKU property.
		/// </summary>
		[ XmlElement( ElementName = "FNSKU" ) ]
		public string FNSKU{ get; set; }

		/// <summary>
		/// Sets the FNSKU property.
		/// </summary>
		/// <param name="fnsku">FNSKU property.</param>
		/// <returns>this instance.</returns>
		public InventorySupply WithFNSKU( string fnsku )
		{
			this.FNSKU = fnsku;
			return this;
		}

		/// <summary>
		/// Checks if FNSKU property is set.
		/// </summary>
		/// <returns>true if FNSKU property is set.</returns>
		public bool IsSetFNSKU()
		{
			return this.FNSKU != null;
		}

		/// <summary>
		/// Gets and sets the ASIN property.
		/// </summary>
		[ XmlElement( ElementName = "ASIN" ) ]
		public string ASIN{ get; set; }

		/// <summary>
		/// Sets the ASIN property.
		/// </summary>
		/// <param name="asin">ASIN property.</param>
		/// <returns>this instance.</returns>
		public InventorySupply WithASIN( string asin )
		{
			this.ASIN = asin;
			return this;
		}

		/// <summary>
		/// Checks if ASIN property is set.
		/// </summary>
		/// <returns>true if ASIN property is set.</returns>
		public bool IsSetASIN()
		{
			return this.ASIN != null;
		}

		/// <summary>
		/// Gets and sets the Condition property.
		/// </summary>
		[ XmlElement( ElementName = "Condition" ) ]
		public string Condition{ get; set; }

		/// <summary>
		/// Sets the Condition property.
		/// </summary>
		/// <param name="condition">Condition property.</param>
		/// <returns>this instance.</returns>
		public InventorySupply WithCondition( string condition )
		{
			this.Condition = condition;
			return this;
		}

		/// <summary>
		/// Checks if Condition property is set.
		/// </summary>
		/// <returns>true if Condition property is set.</returns>
		public bool IsSetCondition()
		{
			return this.Condition != null;
		}

		/// <summary>
		/// Gets and sets the TotalSupplyQuantity property.
		/// </summary>
		[ XmlElement( ElementName = "TotalSupplyQuantity" ) ]
		public decimal TotalSupplyQuantity
		{
			get { return this._totalSupplyQuantity.GetValueOrDefault(); }
			set { this._totalSupplyQuantity = value; }
		}

		/// <summary>
		/// Sets the TotalSupplyQuantity property.
		/// </summary>
		/// <param name="totalSupplyQuantity">TotalSupplyQuantity property.</param>
		/// <returns>this instance.</returns>
		public InventorySupply WithTotalSupplyQuantity( decimal totalSupplyQuantity )
		{
			this._totalSupplyQuantity = totalSupplyQuantity;
			return this;
		}

		/// <summary>
		/// Checks if TotalSupplyQuantity property is set.
		/// </summary>
		/// <returns>true if TotalSupplyQuantity property is set.</returns>
		public bool IsSetTotalSupplyQuantity()
		{
			return this._totalSupplyQuantity != null;
		}

		/// <summary>
		/// Gets and sets the InStockSupplyQuantity property.
		/// </summary>
		[ XmlElement( ElementName = "InStockSupplyQuantity" ) ]
		public decimal InStockSupplyQuantity
		{
			get { return this._inStockSupplyQuantity.GetValueOrDefault(); }
			set { this._inStockSupplyQuantity = value; }
		}

		/// <summary>
		/// Sets the InStockSupplyQuantity property.
		/// </summary>
		/// <param name="inStockSupplyQuantity">InStockSupplyQuantity property.</param>
		/// <returns>this instance.</returns>
		public InventorySupply WithInStockSupplyQuantity( decimal inStockSupplyQuantity )
		{
			this._inStockSupplyQuantity = inStockSupplyQuantity;
			return this;
		}

		/// <summary>
		/// Checks if InStockSupplyQuantity property is set.
		/// </summary>
		/// <returns>true if InStockSupplyQuantity property is set.</returns>
		public bool IsSetInStockSupplyQuantity()
		{
			return this._inStockSupplyQuantity != null;
		}

		/// <summary>
		/// Gets and sets the EarliestAvailability property.
		/// </summary>
		[ XmlElement( ElementName = "EarliestAvailability" ) ]
		public Timepoint EarliestAvailability{ get; set; }

		/// <summary>
		/// Sets the EarliestAvailability property.
		/// </summary>
		/// <param name="earliestAvailability">EarliestAvailability property.</param>
		/// <returns>this instance.</returns>
		public InventorySupply WithEarliestAvailability( Timepoint earliestAvailability )
		{
			this.EarliestAvailability = earliestAvailability;
			return this;
		}

		/// <summary>
		/// Checks if EarliestAvailability property is set.
		/// </summary>
		/// <returns>true if EarliestAvailability property is set.</returns>
		public bool IsSetEarliestAvailability()
		{
			return this.EarliestAvailability != null;
		}

		/// <summary>
		/// Gets and sets the SupplyDetail property.
		/// </summary>
		[ XmlElement( ElementName = "SupplyDetail" ) ]
		public InventorySupplyDetailList SupplyDetail{ get; set; }

		/// <summary>
		/// Sets the SupplyDetail property.
		/// </summary>
		/// <param name="supplyDetail">SupplyDetail property.</param>
		/// <returns>this instance.</returns>
		public InventorySupply WithSupplyDetail( InventorySupplyDetailList supplyDetail )
		{
			this.SupplyDetail = supplyDetail;
			return this;
		}

		/// <summary>
		/// Checks if SupplyDetail property is set.
		/// </summary>
		/// <returns>true if SupplyDetail property is set.</returns>
		public bool IsSetSupplyDetail()
		{
			return this.SupplyDetail != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.SellerSKU = reader.Read< string >( "SellerSKU" );
			this.FNSKU = reader.Read< string >( "FNSKU" );
			this.ASIN = reader.Read< string >( "ASIN" );
			this.Condition = reader.Read< string >( "Condition" );
			this._totalSupplyQuantity = reader.Read< decimal? >( "TotalSupplyQuantity" );
			this._inStockSupplyQuantity = reader.Read< decimal? >( "InStockSupplyQuantity" );
			this.EarliestAvailability = reader.Read< Timepoint >( "EarliestAvailability" );
			this.SupplyDetail = reader.Read< InventorySupplyDetailList >( "SupplyDetail" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "SellerSKU", this.SellerSKU );
			writer.Write( "FNSKU", this.FNSKU );
			writer.Write( "ASIN", this.ASIN );
			writer.Write( "Condition", this.Condition );
			writer.Write( "TotalSupplyQuantity", this._totalSupplyQuantity );
			writer.Write( "InStockSupplyQuantity", this._inStockSupplyQuantity );
			writer.Write( "EarliestAvailability", this.EarliestAvailability );
			writer.Write( "SupplyDetail", this.SupplyDetail );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonaws.com/FulfillmentInventory/2010-10-01/", "InventorySupply", this );
		}

		public InventorySupply(): base()
		{
		}
	}
}