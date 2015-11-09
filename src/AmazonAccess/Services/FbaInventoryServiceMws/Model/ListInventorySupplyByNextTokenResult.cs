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
 * List Inventory Supply By Next Token Result
 * API Version: 2010-10-01
 * Library Version: 2014-09-30
 * Generated: Fri Sep 26 16:01:24 GMT 2014
 */

using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.FbaInventoryServiceMws.Model
{
    [XmlType(Namespace = "http://mws.amazonaws.com/FulfillmentInventory/2010-10-01/")]
    [XmlRoot(Namespace = "http://mws.amazonaws.com/FulfillmentInventory/2010-10-01/", IsNullable = false)]
    public class ListInventorySupplyByNextTokenResult : AbstractMwsObject
    {

        private InventorySupplyList _inventorySupplyList;
        private string _nextToken;

        /// <summary>
        /// Gets and sets the InventorySupplyList property.
        /// </summary>
        [XmlElement(ElementName = "InventorySupplyList")]
        public InventorySupplyList InventorySupplyList
        {
            get { return this._inventorySupplyList; }
            set { this._inventorySupplyList = value; }
        }

        /// <summary>
        /// Sets the InventorySupplyList property.
        /// </summary>
        /// <param name="inventorySupplyList">InventorySupplyList property.</param>
        /// <returns>this instance.</returns>
        public ListInventorySupplyByNextTokenResult WithInventorySupplyList(InventorySupplyList inventorySupplyList)
        {
            this._inventorySupplyList = inventorySupplyList;
            return this;
        }

        /// <summary>
        /// Checks if InventorySupplyList property is set.
        /// </summary>
        /// <returns>true if InventorySupplyList property is set.</returns>
        public bool IsSetInventorySupplyList()
        {
            return this._inventorySupplyList != null;
        }

        /// <summary>
        /// Gets and sets the NextToken property.
        /// </summary>
        [XmlElement(ElementName = "NextToken")]
        public string NextToken
        {
            get { return this._nextToken; }
            set { this._nextToken = value; }
        }

        /// <summary>
        /// Sets the NextToken property.
        /// </summary>
        /// <param name="nextToken">NextToken property.</param>
        /// <returns>this instance.</returns>
        public ListInventorySupplyByNextTokenResult WithNextToken(string nextToken)
        {
            this._nextToken = nextToken;
            return this;
        }

        /// <summary>
        /// Checks if NextToken property is set.
        /// </summary>
        /// <returns>true if NextToken property is set.</returns>
        public bool IsSetNextToken()
        {
            return this._nextToken != null;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            this._inventorySupplyList = reader.Read<InventorySupplyList>("InventorySupplyList");
            this._nextToken = reader.Read<string>("NextToken");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("InventorySupplyList", this._inventorySupplyList);
            writer.Write("NextToken", this._nextToken);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("http://mws.amazonaws.com/FulfillmentInventory/2010-10-01/", "ListInventorySupplyByNextTokenResult", this);
        }

        public ListInventorySupplyByNextTokenResult() : base()
        {
        }
    }
}
