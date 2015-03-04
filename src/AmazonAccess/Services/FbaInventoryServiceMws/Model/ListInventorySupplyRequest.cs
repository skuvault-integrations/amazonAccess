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
 * List Inventory Supply Request
 * API Version: 2010-10-01
 * Library Version: 2014-09-30
 * Generated: Fri Sep 26 16:01:24 GMT 2014
 */

using System;
using System.Xml.Serialization;
using AmazonAccess.Services.Utils;

namespace AmazonAccess.Services.FbaInventoryServiceMws.Model
{
    [XmlType(Namespace = "http://mws.amazonaws.com/FulfillmentInventory/2010-10-01/")]
    [XmlRoot(Namespace = "http://mws.amazonaws.com/FulfillmentInventory/2010-10-01/", IsNullable = false)]
    public class ListInventorySupplyRequest : AbstractMwsObject
    {

        private string _sellerId;
        private string _mwsAuthToken;
        private string _marketplace;
        private string _supplyRegion;
        private SellerSkuList _sellerSkus;
        private DateTime? _queryStartDateTime;
        private string _responseGroup;

        /// <summary>
        /// Gets and sets the SellerId property.
        /// </summary>
        [XmlElement(ElementName = "SellerId")]
        public string SellerId
        {
            get { return this._sellerId; }
            set { this._sellerId = value; }
        }

        /// <summary>
        /// Sets the SellerId property.
        /// </summary>
        /// <param name="sellerId">SellerId property.</param>
        /// <returns>this instance.</returns>
        public ListInventorySupplyRequest WithSellerId(string sellerId)
        {
            this._sellerId = sellerId;
            return this;
        }

        /// <summary>
        /// Checks if SellerId property is set.
        /// </summary>
        /// <returns>true if SellerId property is set.</returns>
        public bool IsSetSellerId()
        {
            return this._sellerId != null;
        }

        /// <summary>
        /// Gets and sets the MWSAuthToken property.
        /// </summary>
        [XmlElement(ElementName = "MWSAuthToken")]
        public string MWSAuthToken
        {
            get { return this._mwsAuthToken; }
            set { this._mwsAuthToken = value; }
        }

        /// <summary>
        /// Sets the MWSAuthToken property.
        /// </summary>
        /// <param name="mwsAuthToken">MWSAuthToken property.</param>
        /// <returns>this instance.</returns>
        public ListInventorySupplyRequest WithMWSAuthToken(string mwsAuthToken)
        {
            this._mwsAuthToken = mwsAuthToken;
            return this;
        }

        /// <summary>
        /// Checks if MWSAuthToken property is set.
        /// </summary>
        /// <returns>true if MWSAuthToken property is set.</returns>
        public bool IsSetMWSAuthToken()
        {
            return this._mwsAuthToken != null;
        }

        /// <summary>
        /// Gets and sets the Marketplace property.
        /// </summary>
        [XmlElement(ElementName = "Marketplace")]
        public string Marketplace
        {
            get { return this._marketplace; }
            set { this._marketplace = value; }
        }

        /// <summary>
        /// Sets the Marketplace property.
        /// </summary>
        /// <param name="marketplace">Marketplace property.</param>
        /// <returns>this instance.</returns>
        public ListInventorySupplyRequest WithMarketplace(string marketplace)
        {
            this._marketplace = marketplace;
            return this;
        }

        /// <summary>
        /// Checks if Marketplace property is set.
        /// </summary>
        /// <returns>true if Marketplace property is set.</returns>
        public bool IsSetMarketplace()
        {
            return this._marketplace != null;
        }

        /// <summary>
        /// Gets and sets the SupplyRegion property.
        /// </summary>
        [XmlElement(ElementName = "SupplyRegion")]
        public string SupplyRegion
        {
            get { return this._supplyRegion; }
            set { this._supplyRegion = value; }
        }

        /// <summary>
        /// Sets the SupplyRegion property.
        /// </summary>
        /// <param name="supplyRegion">SupplyRegion property.</param>
        /// <returns>this instance.</returns>
        public ListInventorySupplyRequest WithSupplyRegion(string supplyRegion)
        {
            this._supplyRegion = supplyRegion;
            return this;
        }

        /// <summary>
        /// Checks if SupplyRegion property is set.
        /// </summary>
        /// <returns>true if SupplyRegion property is set.</returns>
        public bool IsSetSupplyRegion()
        {
            return this._supplyRegion != null;
        }

        /// <summary>
        /// Gets and sets the SellerSkus property.
        /// </summary>
        [XmlElement(ElementName = "SellerSkus")]
        public SellerSkuList SellerSkus
        {
            get { return this._sellerSkus; }
            set { this._sellerSkus = value; }
        }

        /// <summary>
        /// Sets the SellerSkus property.
        /// </summary>
        /// <param name="sellerSkus">SellerSkus property.</param>
        /// <returns>this instance.</returns>
        public ListInventorySupplyRequest WithSellerSkus(SellerSkuList sellerSkus)
        {
            this._sellerSkus = sellerSkus;
            return this;
        }

        /// <summary>
        /// Checks if SellerSkus property is set.
        /// </summary>
        /// <returns>true if SellerSkus property is set.</returns>
        public bool IsSetSellerSkus()
        {
            return this._sellerSkus != null;
        }

        /// <summary>
        /// Gets and sets the QueryStartDateTime property.
        /// </summary>
        [XmlElement(ElementName = "QueryStartDateTime")]
        public DateTime QueryStartDateTime
        {
            get { return this._queryStartDateTime.GetValueOrDefault(); }
            set { this._queryStartDateTime = value; }
        }

        /// <summary>
        /// Sets the QueryStartDateTime property.
        /// </summary>
        /// <param name="queryStartDateTime">QueryStartDateTime property.</param>
        /// <returns>this instance.</returns>
        public ListInventorySupplyRequest WithQueryStartDateTime(DateTime queryStartDateTime)
        {
            this._queryStartDateTime = queryStartDateTime;
            return this;
        }

        /// <summary>
        /// Checks if QueryStartDateTime property is set.
        /// </summary>
        /// <returns>true if QueryStartDateTime property is set.</returns>
        public bool IsSetQueryStartDateTime()
        {
            return this._queryStartDateTime != null;
        }

        /// <summary>
        /// Gets and sets the ResponseGroup property.
        /// </summary>
        [XmlElement(ElementName = "ResponseGroup")]
        public string ResponseGroup
        {
            get { return this._responseGroup; }
            set { this._responseGroup = value; }
        }

        /// <summary>
        /// Sets the ResponseGroup property.
        /// </summary>
        /// <param name="responseGroup">ResponseGroup property.</param>
        /// <returns>this instance.</returns>
        public ListInventorySupplyRequest WithResponseGroup(string responseGroup)
        {
            this._responseGroup = responseGroup;
            return this;
        }

        /// <summary>
        /// Checks if ResponseGroup property is set.
        /// </summary>
        /// <returns>true if ResponseGroup property is set.</returns>
        public bool IsSetResponseGroup()
        {
            return this._responseGroup != null;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            this._sellerId = reader.Read<string>("SellerId");
            this._mwsAuthToken = reader.Read<string>("MWSAuthToken");
            this._marketplace = reader.Read<string>("Marketplace");
            this._supplyRegion = reader.Read<string>("SupplyRegion");
            this._sellerSkus = reader.Read<SellerSkuList>("SellerSkus");
            this._queryStartDateTime = reader.Read<DateTime?>("QueryStartDateTime");
            this._responseGroup = reader.Read<string>("ResponseGroup");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("SellerId", this._sellerId);
            writer.Write("MWSAuthToken", this._mwsAuthToken);
            writer.Write("Marketplace", this._marketplace);
            writer.Write("SupplyRegion", this._supplyRegion);
            writer.Write("SellerSkus", this._sellerSkus);
            writer.Write("QueryStartDateTime", this._queryStartDateTime);
            writer.Write("ResponseGroup", this._responseGroup);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("http://mws.amazonaws.com/FulfillmentInventory/2010-10-01/", "ListInventorySupplyRequest", this);
        }

        public ListInventorySupplyRequest() : base()
        {
        }
    }
}
