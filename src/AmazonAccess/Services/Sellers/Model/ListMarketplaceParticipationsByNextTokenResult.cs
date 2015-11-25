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
 * List Marketplace Participations By Next Token Result
 * API Version: 2011-07-01
 * Library Version: 2014-09-30
 * Generated: Mon Sep 15 19:38:40 GMT 2014
 */

using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Sellers.Model
{
    [XmlType(Namespace = "https://mws.amazonservices.com/Sellers/2011-07-01")]
    [XmlRoot(Namespace = "https://mws.amazonservices.com/Sellers/2011-07-01", IsNullable = false)]
    public class ListMarketplaceParticipationsByNextTokenResult : AbstractMwsObject
    {

        private string _nextToken;
        private ListParticipations _listParticipations;
        private ListMarketplaces _listMarketplaces;

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
        public ListMarketplaceParticipationsByNextTokenResult WithNextToken(string nextToken)
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

        /// <summary>
        /// Gets and sets the ListParticipations property.
        /// </summary>
        [XmlElement(ElementName = "ListParticipations")]
        public ListParticipations ListParticipations
        {
            get { return this._listParticipations; }
            set { this._listParticipations = value; }
        }

        /// <summary>
        /// Sets the ListParticipations property.
        /// </summary>
        /// <param name="listParticipations">ListParticipations property.</param>
        /// <returns>this instance.</returns>
        public ListMarketplaceParticipationsByNextTokenResult WithListParticipations(ListParticipations listParticipations)
        {
            this._listParticipations = listParticipations;
            return this;
        }

        /// <summary>
        /// Checks if ListParticipations property is set.
        /// </summary>
        /// <returns>true if ListParticipations property is set.</returns>
        public bool IsSetListParticipations()
        {
            return this._listParticipations != null;
        }

        /// <summary>
        /// Gets and sets the ListMarketplaces property.
        /// </summary>
        [XmlElement(ElementName = "ListMarketplaces")]
        public ListMarketplaces ListMarketplaces
        {
            get { return this._listMarketplaces; }
            set { this._listMarketplaces = value; }
        }

        /// <summary>
        /// Sets the ListMarketplaces property.
        /// </summary>
        /// <param name="listMarketplaces">ListMarketplaces property.</param>
        /// <returns>this instance.</returns>
        public ListMarketplaceParticipationsByNextTokenResult WithListMarketplaces(ListMarketplaces listMarketplaces)
        {
            this._listMarketplaces = listMarketplaces;
            return this;
        }

        /// <summary>
        /// Checks if ListMarketplaces property is set.
        /// </summary>
        /// <returns>true if ListMarketplaces property is set.</returns>
        public bool IsSetListMarketplaces()
        {
            return this._listMarketplaces != null;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            this._nextToken = reader.Read<string>("NextToken");
            this._listParticipations = reader.Read<ListParticipations>("ListParticipations");
            this._listMarketplaces = reader.Read<ListMarketplaces>("ListMarketplaces");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("NextToken", this._nextToken);
            writer.Write("ListParticipations", this._listParticipations);
            writer.Write("ListMarketplaces", this._listMarketplaces);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Sellers/2011-07-01", "ListMarketplaceParticipationsByNextTokenResult", this);
        }

        public ListMarketplaceParticipationsByNextTokenResult() : base()
        {
        }
    }
}
