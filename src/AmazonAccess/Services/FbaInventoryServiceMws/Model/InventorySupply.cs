/******************************************************************************* 
 *  Copyright 2009 Amazon Services. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * ***************************************************************************** 
 * 
 *  FBA Inventory Service MWS CSharp Library
 *  API Version: 2010-10-01
 *  Generated: Fri Oct 22 09:53:30 UTC 2010 
 * 
 */

using System;
using System.Xml.Serialization;
using System.Text;

namespace AmazonAccess.Services.FbaInventoryServiceMws.Model
{
	[ XmlType( Namespace = "http://mws.amazonaws.com/FulfillmentInventory/2010-10-01/" ) ]
	[ XmlRoot( Namespace = "http://mws.amazonaws.com/FulfillmentInventory/2010-10-01/", IsNullable = false ) ]
	public class InventorySupply
	{

		private String sellerSKUField;

		private String FNSKUField;

		private String ASINField;

		private String conditionField;

		private int? totalSupplyQuantityField;

		private int? inStockSupplyQuantityField;

		private Timepoint earliestAvailabilityField;
		private InventorySupplyDetailList supplyDetailField;

		/// <summary>
		/// Gets and sets the SellerSKU property.
		/// </summary>
		[ XmlElement( ElementName = "SellerSKU" ) ]
		public String SellerSKU
		{
			get { return this.sellerSKUField; }
			set { this.sellerSKUField = value; }
		}



		/// <summary>
		/// Sets the SellerSKU property
		/// </summary>
		/// <param name="sellerSku">SellerSKU property</param>
		/// <returns>this instance</returns>
		public InventorySupply WithSellerSKU( String sellerSku )
		{
			this.sellerSKUField = sellerSku;
			return this;
		}



		/// <summary>
		/// Checks if SellerSKU property is set
		/// </summary>
		/// <returns>true if SellerSKU property is set</returns>
		public Boolean IsSetSellerSKU()
		{
			return this.sellerSKUField != null;

		}


		/// <summary>
		/// Gets and sets the FNSKU property.
		/// </summary>
		[ XmlElement( ElementName = "FNSKU" ) ]
		public String FNSKU
		{
			get { return this.FNSKUField; }
			set { this.FNSKUField = value; }
		}



		/// <summary>
		/// Sets the FNSKU property
		/// </summary>
		/// <param name="fnsku">FNSKU property</param>
		/// <returns>this instance</returns>
		public InventorySupply WithFNSKU( String fnsku )
		{
			this.FNSKUField = fnsku;
			return this;
		}



		/// <summary>
		/// Checks if FNSKU property is set
		/// </summary>
		/// <returns>true if FNSKU property is set</returns>
		public Boolean IsSetFNSKU()
		{
			return this.FNSKUField != null;

		}


		/// <summary>
		/// Gets and sets the ASIN property.
		/// </summary>
		[ XmlElement( ElementName = "ASIN" ) ]
		public String ASIN
		{
			get { return this.ASINField; }
			set { this.ASINField = value; }
		}



		/// <summary>
		/// Sets the ASIN property
		/// </summary>
		/// <param name="asin">ASIN property</param>
		/// <returns>this instance</returns>
		public InventorySupply WithASIN( String asin )
		{
			this.ASINField = asin;
			return this;
		}



		/// <summary>
		/// Checks if ASIN property is set
		/// </summary>
		/// <returns>true if ASIN property is set</returns>
		public Boolean IsSetASIN()
		{
			return this.ASINField != null;

		}


		/// <summary>
		/// Gets and sets the Condition property.
		/// </summary>
		[ XmlElement( ElementName = "Condition" ) ]
		public String Condition
		{
			get { return this.conditionField; }
			set { this.conditionField = value; }
		}



		/// <summary>
		/// Sets the Condition property
		/// </summary>
		/// <param name="condition">Condition property</param>
		/// <returns>this instance</returns>
		public InventorySupply WithCondition( String condition )
		{
			this.conditionField = condition;
			return this;
		}



		/// <summary>
		/// Checks if Condition property is set
		/// </summary>
		/// <returns>true if Condition property is set</returns>
		public Boolean IsSetCondition()
		{
			return this.conditionField != null;

		}


		/// <summary>
		/// Gets and sets the TotalSupplyQuantity property.
		/// </summary>
		[ XmlElement( ElementName = "TotalSupplyQuantity" ) ]
		public int TotalSupplyQuantity
		{
			get { return this.totalSupplyQuantityField.GetValueOrDefault(); }
			set { this.totalSupplyQuantityField = value; }
		}



		/// <summary>
		/// Sets the TotalSupplyQuantity property
		/// </summary>
		/// <param name="totalSupplyQuantity">TotalSupplyQuantity property</param>
		/// <returns>this instance</returns>
		public InventorySupply WithTotalSupplyQuantity( int totalSupplyQuantity )
		{
			this.totalSupplyQuantityField = totalSupplyQuantity;
			return this;
		}



		/// <summary>
		/// Checks if TotalSupplyQuantity property is set
		/// </summary>
		/// <returns>true if TotalSupplyQuantity property is set</returns>
		public Boolean IsSetTotalSupplyQuantity()
		{
			return this.totalSupplyQuantityField.HasValue;

		}


		/// <summary>
		/// Gets and sets the InStockSupplyQuantity property.
		/// </summary>
		[ XmlElement( ElementName = "InStockSupplyQuantity" ) ]
		public int InStockSupplyQuantity
		{
			get { return this.inStockSupplyQuantityField.GetValueOrDefault(); }
			set { this.inStockSupplyQuantityField = value; }
		}



		/// <summary>
		/// Sets the InStockSupplyQuantity property
		/// </summary>
		/// <param name="inStockSupplyQuantity">InStockSupplyQuantity property</param>
		/// <returns>this instance</returns>
		public InventorySupply WithInStockSupplyQuantity( int inStockSupplyQuantity )
		{
			this.inStockSupplyQuantityField = inStockSupplyQuantity;
			return this;
		}



		/// <summary>
		/// Checks if InStockSupplyQuantity property is set
		/// </summary>
		/// <returns>true if InStockSupplyQuantity property is set</returns>
		public Boolean IsSetInStockSupplyQuantity()
		{
			return this.inStockSupplyQuantityField.HasValue;

		}


		/// <summary>
		/// Gets and sets the EarliestAvailability property.
		/// </summary>
		[ XmlElement( ElementName = "EarliestAvailability" ) ]
		public Timepoint EarliestAvailability
		{
			get { return this.earliestAvailabilityField; }
			set { this.earliestAvailabilityField = value; }
		}



		/// <summary>
		/// Sets the EarliestAvailability property
		/// </summary>
		/// <param name="earliestAvailability">EarliestAvailability property</param>
		/// <returns>this instance</returns>
		public InventorySupply WithEarliestAvailability( Timepoint earliestAvailability )
		{
			this.earliestAvailabilityField = earliestAvailability;
			return this;
		}



		/// <summary>
		/// Checks if EarliestAvailability property is set
		/// </summary>
		/// <returns>true if EarliestAvailability property is set</returns>
		public Boolean IsSetEarliestAvailability()
		{
			return this.earliestAvailabilityField != null;
		}




		/// <summary>
		/// Gets and sets the SupplyDetail property.
		/// </summary>
		[ XmlElement( ElementName = "SupplyDetail" ) ]
		public InventorySupplyDetailList SupplyDetail
		{
			get { return this.supplyDetailField; }
			set { this.supplyDetailField = value; }
		}



		/// <summary>
		/// Sets the SupplyDetail property
		/// </summary>
		/// <param name="supplyDetail">SupplyDetail property</param>
		/// <returns>this instance</returns>
		public InventorySupply WithSupplyDetail( InventorySupplyDetailList supplyDetail )
		{
			this.supplyDetailField = supplyDetail;
			return this;
		}



		/// <summary>
		/// Checks if SupplyDetail property is set
		/// </summary>
		/// <returns>true if SupplyDetail property is set</returns>
		public Boolean IsSetSupplyDetail()
		{
			return this.supplyDetailField != null;
		}






		/// <summary>
		/// XML fragment representation of this object
		/// </summary>
		/// <returns>XML fragment for this object.</returns>
		/// <remarks>
		/// Name for outer tag expected to be set by calling method. 
		/// This fragment returns inner properties representation only
		/// </remarks>


		protected internal String ToXMLFragment()
		{
			var xml = new StringBuilder();
			if( this.IsSetSellerSKU() )
			{
				xml.Append( "<SellerSKU>" );
				xml.Append( this.EscapeXML( this.SellerSKU ) );
				xml.Append( "</SellerSKU>" );
			}
			if( this.IsSetFNSKU() )
			{
				xml.Append( "<FNSKU>" );
				xml.Append( this.EscapeXML( this.FNSKU ) );
				xml.Append( "</FNSKU>" );
			}
			if( this.IsSetASIN() )
			{
				xml.Append( "<ASIN>" );
				xml.Append( this.EscapeXML( this.ASIN ) );
				xml.Append( "</ASIN>" );
			}
			if( this.IsSetCondition() )
			{
				xml.Append( "<Condition>" );
				xml.Append( this.EscapeXML( this.Condition ) );
				xml.Append( "</Condition>" );
			}
			if( this.IsSetTotalSupplyQuantity() )
			{
				xml.Append( "<TotalSupplyQuantity>" );
				xml.Append( this.TotalSupplyQuantity );
				xml.Append( "</TotalSupplyQuantity>" );
			}
			if( this.IsSetInStockSupplyQuantity() )
			{
				xml.Append( "<InStockSupplyQuantity>" );
				xml.Append( this.InStockSupplyQuantity );
				xml.Append( "</InStockSupplyQuantity>" );
			}
			if( this.IsSetEarliestAvailability() )
			{
				Timepoint earliestAvailabilityObj = this.EarliestAvailability;
				xml.Append( "<EarliestAvailability>" );
				xml.Append( earliestAvailabilityObj.ToXMLFragment() );
				xml.Append( "</EarliestAvailability>" );
			}
			if( this.IsSetSupplyDetail() )
			{
				InventorySupplyDetailList supplyDetailObj = this.SupplyDetail;
				xml.Append( "<SupplyDetail>" );
				xml.Append( supplyDetailObj.ToXMLFragment() );
				xml.Append( "</SupplyDetail>" );
			}
			return xml.ToString();
		}

		/**
		 * 
		 * Escape XML special characters
		 */

		private String EscapeXML( String str )
		{
			var sb = new StringBuilder();
			foreach( Char c in str )
			{
				switch( c )
				{
					case '&':
						sb.Append( "&amp;" );
						break;
					case '<':
						sb.Append( "&lt;" );
						break;
					case '>':
						sb.Append( "&gt;" );
						break;
					case '\'':
						sb.Append( "&#039;" );
						break;
					case '"':
						sb.Append( "&quot;" );
						break;
					default:
						sb.Append( c );
						break;
				}
			}
			return sb.ToString();
		}

	}
}