/*******************************************************************************
 * Copyright 2009-2014 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * List Marketplaces
 * API Version: 2011-07-01
 * Library Version: 2014-09-30
 * Generated: Mon Sep 15 19:38:40 GMT 2014
 */

using System.Collections.Generic;
using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.MarketplaceWebServiceSellers.Model
{
    [XmlType(Namespace = "https://mws.amazonservices.com/Sellers/2011-07-01")]
    [XmlRoot(Namespace = "https://mws.amazonservices.com/Sellers/2011-07-01", IsNullable = false)]
    public class ListMarketplaces : AbstractMwsObject
    {

        private List<Marketplace> _marketplace;

        /// <summary>
        /// Gets and sets the Marketplace property.
        /// </summary>
        [XmlElement(ElementName = "Marketplace")]
        public List<Marketplace> Marketplace
        {
            get
            {
                if(this._marketplace == null)
                {
                    this._marketplace = new List<Marketplace>();
                }
                return this._marketplace;
            }
            set { this._marketplace = value; }
        }

        /// <summary>
        /// Sets the Marketplace property.
        /// </summary>
        /// <param name="marketplace">Marketplace property.</param>
        /// <returns>this instance.</returns>
        public ListMarketplaces WithMarketplace(Marketplace[] marketplace)
        {
            this._marketplace.AddRange(marketplace);
            return this;
        }

        /// <summary>
        /// Checks if Marketplace property is set.
        /// </summary>
        /// <returns>true if Marketplace property is set.</returns>
        public bool IsSetMarketplace()
        {
            return this.Marketplace.Count > 0;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            this._marketplace = reader.ReadList<Marketplace>("Marketplace");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.WriteList("Marketplace", this._marketplace);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Sellers/2011-07-01", "ListMarketplaces", this);
        }

        public ListMarketplaces() : base()
        {
        }
    }
}
