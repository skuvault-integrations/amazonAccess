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
 * Detailed Shipping Time Type
 * API Version: 2011-10-01
 * Library Version: 2015-09-01
 * Generated: Thu Sep 10 06:52:19 PDT 2015
 */

using System;
using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Products.Model
{
	[ XmlType( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01" ) ]
	[ XmlRoot( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01", IsNullable = false ) ]
	public class DetailedShippingTimeType: AbstractMwsObject
	{
		private decimal? _minimumHours;
		private decimal? _maximumHours;
		private DateTime? _availableDate;

		/// <summary>
		/// Gets and sets the minimumHours property.
		/// </summary>
		[ XmlAttribute( AttributeName = "minimumHours" ) ]
		public decimal minimumHours
		{
			get { return this._minimumHours.GetValueOrDefault(); }
			set { this._minimumHours = value; }
		}

		/// <summary>
		/// Sets the minimumHours property.
		/// </summary>
		/// <param name="minimumHours">minimumHours property.</param>
		/// <returns>this instance.</returns>
		public DetailedShippingTimeType WithminimumHours( decimal minimumHours )
		{
			this._minimumHours = minimumHours;
			return this;
		}

		/// <summary>
		/// Checks if minimumHours property is set.
		/// </summary>
		/// <returns>true if minimumHours property is set.</returns>
		public bool IsSetminimumHours()
		{
			return this._minimumHours != null;
		}

		/// <summary>
		/// Gets and sets the maximumHours property.
		/// </summary>
		[ XmlAttribute( AttributeName = "maximumHours" ) ]
		public decimal maximumHours
		{
			get { return this._maximumHours.GetValueOrDefault(); }
			set { this._maximumHours = value; }
		}

		/// <summary>
		/// Sets the maximumHours property.
		/// </summary>
		/// <param name="maximumHours">maximumHours property.</param>
		/// <returns>this instance.</returns>
		public DetailedShippingTimeType WithmaximumHours( decimal maximumHours )
		{
			this._maximumHours = maximumHours;
			return this;
		}

		/// <summary>
		/// Checks if maximumHours property is set.
		/// </summary>
		/// <returns>true if maximumHours property is set.</returns>
		public bool IsSetmaximumHours()
		{
			return this._maximumHours != null;
		}

		/// <summary>
		/// Gets and sets the availableDate property.
		/// </summary>
		[ XmlAttribute( AttributeName = "availableDate" ) ]
		public DateTime availableDate
		{
			get { return this._availableDate.GetValueOrDefault(); }
			set { this._availableDate = value; }
		}

		/// <summary>
		/// Sets the availableDate property.
		/// </summary>
		/// <param name="availableDate">availableDate property.</param>
		/// <returns>this instance.</returns>
		public DetailedShippingTimeType WithavailableDate( DateTime availableDate )
		{
			this._availableDate = availableDate;
			return this;
		}

		/// <summary>
		/// Checks if availableDate property is set.
		/// </summary>
		/// <returns>true if availableDate property is set.</returns>
		public bool IsSetavailableDate()
		{
			return this._availableDate != null;
		}

		/// <summary>
		/// Gets and sets the availabilityType property.
		/// </summary>
		[ XmlAttribute( AttributeName = "availabilityType" ) ]
		public string availabilityType{ get; set; }

		/// <summary>
		/// Sets the availabilityType property.
		/// </summary>
		/// <param name="availabilityType">availabilityType property.</param>
		/// <returns>this instance.</returns>
		public DetailedShippingTimeType WithavailabilityType( string availabilityType )
		{
			this.availabilityType = availabilityType;
			return this;
		}

		/// <summary>
		/// Checks if availabilityType property is set.
		/// </summary>
		/// <returns>true if availabilityType property is set.</returns>
		public bool IsSetavailabilityType()
		{
			return this.availabilityType != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this._minimumHours = reader.ReadAttribute< decimal? >( "minimumHours" );
			this._maximumHours = reader.ReadAttribute< decimal? >( "maximumHours" );
			this._availableDate = reader.ReadAttribute< DateTime? >( "availableDate" );
			this.availabilityType = reader.ReadAttribute< string >( "availabilityType" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.WriteAttribute( "minimumHours", this._minimumHours );
			writer.WriteAttribute( "maximumHours", this._maximumHours );
			writer.WriteAttribute( "availableDate", this._availableDate );
			writer.WriteAttribute( "availabilityType", this.availabilityType );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "DetailedShippingTimeType", this );
		}

		public DetailedShippingTimeType(): base()
		{
		}
	}
}