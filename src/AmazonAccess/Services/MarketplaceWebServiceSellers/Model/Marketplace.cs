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
 * Marketplace
 * API Version: 2011-07-01
 * Library Version: 2014-09-30
 * Generated: Mon Sep 15 19:38:40 GMT 2014
 */

using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.MarketplaceWebServiceSellers.Model
{
    [XmlType(Namespace = "https://mws.amazonservices.com/Sellers/2011-07-01")]
    [XmlRoot(Namespace = "https://mws.amazonservices.com/Sellers/2011-07-01", IsNullable = false)]
    public class Marketplace : AbstractMwsObject
    {

        private string _marketplaceId;
        private string _name;
        private string _defaultCountryCode;
        private string _defaultCurrencyCode;
        private string _defaultLanguageCode;
        private string _domainName;

        /// <summary>
        /// Gets and sets the MarketplaceId property.
        /// </summary>
        [XmlElement(ElementName = "MarketplaceId")]
        public string MarketplaceId
        {
            get { return this._marketplaceId; }
            set { this._marketplaceId = value; }
        }

        /// <summary>
        /// Sets the MarketplaceId property.
        /// </summary>
        /// <param name="marketplaceId">MarketplaceId property.</param>
        /// <returns>this instance.</returns>
        public Marketplace WithMarketplaceId(string marketplaceId)
        {
            this._marketplaceId = marketplaceId;
            return this;
        }

        /// <summary>
        /// Checks if MarketplaceId property is set.
        /// </summary>
        /// <returns>true if MarketplaceId property is set.</returns>
        public bool IsSetMarketplaceId()
        {
            return this._marketplaceId != null;
        }

        /// <summary>
        /// Gets and sets the Name property.
        /// </summary>
        [XmlElement(ElementName = "Name")]
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        /// <summary>
        /// Sets the Name property.
        /// </summary>
        /// <param name="name">Name property.</param>
        /// <returns>this instance.</returns>
        public Marketplace WithName(string name)
        {
            this._name = name;
            return this;
        }

        /// <summary>
        /// Checks if Name property is set.
        /// </summary>
        /// <returns>true if Name property is set.</returns>
        public bool IsSetName()
        {
            return this._name != null;
        }

        /// <summary>
        /// Gets and sets the DefaultCountryCode property.
        /// </summary>
        [XmlElement(ElementName = "DefaultCountryCode")]
        public string DefaultCountryCode
        {
            get { return this._defaultCountryCode; }
            set { this._defaultCountryCode = value; }
        }

        /// <summary>
        /// Sets the DefaultCountryCode property.
        /// </summary>
        /// <param name="defaultCountryCode">DefaultCountryCode property.</param>
        /// <returns>this instance.</returns>
        public Marketplace WithDefaultCountryCode(string defaultCountryCode)
        {
            this._defaultCountryCode = defaultCountryCode;
            return this;
        }

        /// <summary>
        /// Checks if DefaultCountryCode property is set.
        /// </summary>
        /// <returns>true if DefaultCountryCode property is set.</returns>
        public bool IsSetDefaultCountryCode()
        {
            return this._defaultCountryCode != null;
        }

        /// <summary>
        /// Gets and sets the DefaultCurrencyCode property.
        /// </summary>
        [XmlElement(ElementName = "DefaultCurrencyCode")]
        public string DefaultCurrencyCode
        {
            get { return this._defaultCurrencyCode; }
            set { this._defaultCurrencyCode = value; }
        }

        /// <summary>
        /// Sets the DefaultCurrencyCode property.
        /// </summary>
        /// <param name="defaultCurrencyCode">DefaultCurrencyCode property.</param>
        /// <returns>this instance.</returns>
        public Marketplace WithDefaultCurrencyCode(string defaultCurrencyCode)
        {
            this._defaultCurrencyCode = defaultCurrencyCode;
            return this;
        }

        /// <summary>
        /// Checks if DefaultCurrencyCode property is set.
        /// </summary>
        /// <returns>true if DefaultCurrencyCode property is set.</returns>
        public bool IsSetDefaultCurrencyCode()
        {
            return this._defaultCurrencyCode != null;
        }

        /// <summary>
        /// Gets and sets the DefaultLanguageCode property.
        /// </summary>
        [XmlElement(ElementName = "DefaultLanguageCode")]
        public string DefaultLanguageCode
        {
            get { return this._defaultLanguageCode; }
            set { this._defaultLanguageCode = value; }
        }

        /// <summary>
        /// Sets the DefaultLanguageCode property.
        /// </summary>
        /// <param name="defaultLanguageCode">DefaultLanguageCode property.</param>
        /// <returns>this instance.</returns>
        public Marketplace WithDefaultLanguageCode(string defaultLanguageCode)
        {
            this._defaultLanguageCode = defaultLanguageCode;
            return this;
        }

        /// <summary>
        /// Checks if DefaultLanguageCode property is set.
        /// </summary>
        /// <returns>true if DefaultLanguageCode property is set.</returns>
        public bool IsSetDefaultLanguageCode()
        {
            return this._defaultLanguageCode != null;
        }

        /// <summary>
        /// Gets and sets the DomainName property.
        /// </summary>
        [XmlElement(ElementName = "DomainName")]
        public string DomainName
        {
            get { return this._domainName; }
            set { this._domainName = value; }
        }

        /// <summary>
        /// Sets the DomainName property.
        /// </summary>
        /// <param name="domainName">DomainName property.</param>
        /// <returns>this instance.</returns>
        public Marketplace WithDomainName(string domainName)
        {
            this._domainName = domainName;
            return this;
        }

        /// <summary>
        /// Checks if DomainName property is set.
        /// </summary>
        /// <returns>true if DomainName property is set.</returns>
        public bool IsSetDomainName()
        {
            return this._domainName != null;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            this._marketplaceId = reader.Read<string>("MarketplaceId");
            this._name = reader.Read<string>("Name");
            this._defaultCountryCode = reader.Read<string>("DefaultCountryCode");
            this._defaultCurrencyCode = reader.Read<string>("DefaultCurrencyCode");
            this._defaultLanguageCode = reader.Read<string>("DefaultLanguageCode");
            this._domainName = reader.Read<string>("DomainName");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("MarketplaceId", this._marketplaceId);
            writer.Write("Name", this._name);
            writer.Write("DefaultCountryCode", this._defaultCountryCode);
            writer.Write("DefaultCurrencyCode", this._defaultCurrencyCode);
            writer.Write("DefaultLanguageCode", this._defaultLanguageCode);
            writer.Write("DomainName", this._domainName);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Sellers/2011-07-01", "Marketplace", this);
        }

        public Marketplace() : base()
        {
        }
    }
}
