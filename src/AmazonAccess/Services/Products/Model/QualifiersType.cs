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
 * Qualifiers Type
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
	public class QualifiersType: AbstractMwsObject
	{
		/// <summary>
		/// Gets and sets the ItemCondition property.
		/// </summary>
		[ XmlElement( ElementName = "ItemCondition" ) ]
		public string ItemCondition{ get; set; }

		/// <summary>
		/// Sets the ItemCondition property.
		/// </summary>
		/// <param name="itemCondition">ItemCondition property.</param>
		/// <returns>this instance.</returns>
		public QualifiersType WithItemCondition( string itemCondition )
		{
			this.ItemCondition = itemCondition;
			return this;
		}

		/// <summary>
		/// Checks if ItemCondition property is set.
		/// </summary>
		/// <returns>true if ItemCondition property is set.</returns>
		public bool IsSetItemCondition()
		{
			return this.ItemCondition != null;
		}

		/// <summary>
		/// Gets and sets the ItemSubcondition property.
		/// </summary>
		[ XmlElement( ElementName = "ItemSubcondition" ) ]
		public string ItemSubcondition{ get; set; }

		/// <summary>
		/// Sets the ItemSubcondition property.
		/// </summary>
		/// <param name="itemSubcondition">ItemSubcondition property.</param>
		/// <returns>this instance.</returns>
		public QualifiersType WithItemSubcondition( string itemSubcondition )
		{
			this.ItemSubcondition = itemSubcondition;
			return this;
		}

		/// <summary>
		/// Checks if ItemSubcondition property is set.
		/// </summary>
		/// <returns>true if ItemSubcondition property is set.</returns>
		public bool IsSetItemSubcondition()
		{
			return this.ItemSubcondition != null;
		}

		/// <summary>
		/// Gets and sets the FulfillmentChannel property.
		/// </summary>
		[ XmlElement( ElementName = "FulfillmentChannel" ) ]
		public string FulfillmentChannel{ get; set; }

		/// <summary>
		/// Sets the FulfillmentChannel property.
		/// </summary>
		/// <param name="fulfillmentChannel">FulfillmentChannel property.</param>
		/// <returns>this instance.</returns>
		public QualifiersType WithFulfillmentChannel( string fulfillmentChannel )
		{
			this.FulfillmentChannel = fulfillmentChannel;
			return this;
		}

		/// <summary>
		/// Checks if FulfillmentChannel property is set.
		/// </summary>
		/// <returns>true if FulfillmentChannel property is set.</returns>
		public bool IsSetFulfillmentChannel()
		{
			return this.FulfillmentChannel != null;
		}

		/// <summary>
		/// Gets and sets the ShipsDomestically property.
		/// </summary>
		[ XmlElement( ElementName = "ShipsDomestically" ) ]
		public string ShipsDomestically{ get; set; }

		/// <summary>
		/// Sets the ShipsDomestically property.
		/// </summary>
		/// <param name="shipsDomestically">ShipsDomestically property.</param>
		/// <returns>this instance.</returns>
		public QualifiersType WithShipsDomestically( string shipsDomestically )
		{
			this.ShipsDomestically = shipsDomestically;
			return this;
		}

		/// <summary>
		/// Checks if ShipsDomestically property is set.
		/// </summary>
		/// <returns>true if ShipsDomestically property is set.</returns>
		public bool IsSetShipsDomestically()
		{
			return this.ShipsDomestically != null;
		}

		/// <summary>
		/// Gets and sets the ShippingTime property.
		/// </summary>
		[ XmlElement( ElementName = "ShippingTime" ) ]
		public ShippingTimeType ShippingTime{ get; set; }

		/// <summary>
		/// Sets the ShippingTime property.
		/// </summary>
		/// <param name="shippingTime">ShippingTime property.</param>
		/// <returns>this instance.</returns>
		public QualifiersType WithShippingTime( ShippingTimeType shippingTime )
		{
			this.ShippingTime = shippingTime;
			return this;
		}

		/// <summary>
		/// Checks if ShippingTime property is set.
		/// </summary>
		/// <returns>true if ShippingTime property is set.</returns>
		public bool IsSetShippingTime()
		{
			return this.ShippingTime != null;
		}

		/// <summary>
		/// Gets and sets the SellerPositiveFeedbackRating property.
		/// </summary>
		[ XmlElement( ElementName = "SellerPositiveFeedbackRating" ) ]
		public string SellerPositiveFeedbackRating{ get; set; }

		/// <summary>
		/// Sets the SellerPositiveFeedbackRating property.
		/// </summary>
		/// <param name="sellerPositiveFeedbackRating">SellerPositiveFeedbackRating property.</param>
		/// <returns>this instance.</returns>
		public QualifiersType WithSellerPositiveFeedbackRating( string sellerPositiveFeedbackRating )
		{
			this.SellerPositiveFeedbackRating = sellerPositiveFeedbackRating;
			return this;
		}

		/// <summary>
		/// Checks if SellerPositiveFeedbackRating property is set.
		/// </summary>
		/// <returns>true if SellerPositiveFeedbackRating property is set.</returns>
		public bool IsSetSellerPositiveFeedbackRating()
		{
			return this.SellerPositiveFeedbackRating != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.ItemCondition = reader.Read< string >( "ItemCondition" );
			this.ItemSubcondition = reader.Read< string >( "ItemSubcondition" );
			this.FulfillmentChannel = reader.Read< string >( "FulfillmentChannel" );
			this.ShipsDomestically = reader.Read< string >( "ShipsDomestically" );
			this.ShippingTime = reader.Read< ShippingTimeType >( "ShippingTime" );
			this.SellerPositiveFeedbackRating = reader.Read< string >( "SellerPositiveFeedbackRating" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "ItemCondition", this.ItemCondition );
			writer.Write( "ItemSubcondition", this.ItemSubcondition );
			writer.Write( "FulfillmentChannel", this.FulfillmentChannel );
			writer.Write( "ShipsDomestically", this.ShipsDomestically );
			writer.Write( "ShippingTime", this.ShippingTime );
			writer.Write( "SellerPositiveFeedbackRating", this.SellerPositiveFeedbackRating );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "QualifiersType", this );
		}

		public QualifiersType(): base()
		{
		}
	}
}