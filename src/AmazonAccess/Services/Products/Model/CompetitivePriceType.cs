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
 * Competitive Price Type
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
	public class CompetitivePriceType: AbstractMwsObject
	{
		private bool? _belongsToRequester;

		/// <summary>
		/// Gets and sets the CompetitivePriceId property.
		/// </summary>
		[ XmlElement( ElementName = "CompetitivePriceId" ) ]
		public string CompetitivePriceId{ get; set; }

		/// <summary>
		/// Sets the CompetitivePriceId property.
		/// </summary>
		/// <param name="competitivePriceId">CompetitivePriceId property.</param>
		/// <returns>this instance.</returns>
		public CompetitivePriceType WithCompetitivePriceId( string competitivePriceId )
		{
			this.CompetitivePriceId = competitivePriceId;
			return this;
		}

		/// <summary>
		/// Checks if CompetitivePriceId property is set.
		/// </summary>
		/// <returns>true if CompetitivePriceId property is set.</returns>
		public bool IsSetCompetitivePriceId()
		{
			return this.CompetitivePriceId != null;
		}

		/// <summary>
		/// Gets and sets the Price property.
		/// </summary>
		[ XmlElement( ElementName = "Price" ) ]
		public PriceType Price{ get; set; }

		/// <summary>
		/// Sets the Price property.
		/// </summary>
		/// <param name="price">Price property.</param>
		/// <returns>this instance.</returns>
		public CompetitivePriceType WithPrice( PriceType price )
		{
			this.Price = price;
			return this;
		}

		/// <summary>
		/// Checks if Price property is set.
		/// </summary>
		/// <returns>true if Price property is set.</returns>
		public bool IsSetPrice()
		{
			return this.Price != null;
		}

		/// <summary>
		/// Gets and sets the condition property.
		/// </summary>
		[ XmlAttribute( AttributeName = "condition" ) ]
		public string condition{ get; set; }

		/// <summary>
		/// Sets the condition property.
		/// </summary>
		/// <param name="condition">condition property.</param>
		/// <returns>this instance.</returns>
		public CompetitivePriceType Withcondition( string condition )
		{
			this.condition = condition;
			return this;
		}

		/// <summary>
		/// Checks if condition property is set.
		/// </summary>
		/// <returns>true if condition property is set.</returns>
		public bool IsSetcondition()
		{
			return this.condition != null;
		}

		/// <summary>
		/// Gets and sets the subcondition property.
		/// </summary>
		[ XmlAttribute( AttributeName = "subcondition" ) ]
		public string subcondition{ get; set; }

		/// <summary>
		/// Sets the subcondition property.
		/// </summary>
		/// <param name="subcondition">subcondition property.</param>
		/// <returns>this instance.</returns>
		public CompetitivePriceType Withsubcondition( string subcondition )
		{
			this.subcondition = subcondition;
			return this;
		}

		/// <summary>
		/// Checks if subcondition property is set.
		/// </summary>
		/// <returns>true if subcondition property is set.</returns>
		public bool IsSetsubcondition()
		{
			return this.subcondition != null;
		}

		/// <summary>
		/// Gets and sets the belongsToRequester property.
		/// </summary>
		[ XmlAttribute( AttributeName = "belongsToRequester" ) ]
		public bool belongsToRequester
		{
			get { return this._belongsToRequester.GetValueOrDefault(); }
			set { this._belongsToRequester = value; }
		}

		/// <summary>
		/// Sets the belongsToRequester property.
		/// </summary>
		/// <param name="belongsToRequester">belongsToRequester property.</param>
		/// <returns>this instance.</returns>
		public CompetitivePriceType WithbelongsToRequester( bool belongsToRequester )
		{
			this._belongsToRequester = belongsToRequester;
			return this;
		}

		/// <summary>
		/// Checks if belongsToRequester property is set.
		/// </summary>
		/// <returns>true if belongsToRequester property is set.</returns>
		public bool IsSetbelongsToRequester()
		{
			return this._belongsToRequester != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.condition = reader.ReadAttribute< string >( "condition" );
			this.subcondition = reader.ReadAttribute< string >( "subcondition" );
			this._belongsToRequester = reader.ReadAttribute< bool? >( "belongsToRequester" );
			this.CompetitivePriceId = reader.Read< string >( "CompetitivePriceId" );
			this.Price = reader.Read< PriceType >( "Price" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.WriteAttribute( "condition", this.condition );
			writer.WriteAttribute( "subcondition", this.subcondition );
			writer.WriteAttribute( "belongsToRequester", this._belongsToRequester );
			writer.Write( "CompetitivePriceId", this.CompetitivePriceId );
			writer.Write( "Price", this.Price );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "CompetitivePriceType", this );
		}

		public CompetitivePriceType(): base()
		{
		}
	}
}