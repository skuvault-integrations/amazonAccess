/******************************************************************************* 
 *  Copyright 2009 Amazon Services.
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * ***************************************************************************** 
 * 
 *  Marketplace Web Service CSharp Library
 *  API Version: 2009-01-01
 *  Generated: Mon Mar 16 17:31:42 PDT 2009 
 * 
 */

using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;
using AmazonAccess.Services.MarketplaceWebServiceFeeds.Attributes;

namespace AmazonAccess.Services.MarketplaceWebServiceFeeds.Model
{
    [XmlTypeAttribute(Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
    [XmlRootAttribute(Namespace = "http://mws.amazonaws.com/doc/2009-01-01/", IsNullable = false)]
    [MarketplaceWebService(RequestType = RequestType.DEFAULT, ResponseType = ResponseType.DEFAULT)]
    public class ManageReportScheduleRequest
    {
    
        private String marketplaceField;

        private String merchantField;

        private String reportTypeField;

        private String scheduleField;

        private DateTime? scheduledDateField;


        /// <summary>
        /// Gets and sets the Marketplace property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Marketplace")]
        [System.Obsolete("Not used anymore. MWS ignores this parameter, but it is left in here for backwards compatibility.")]
        public String Marketplace
        {
            get { return this.marketplaceField ; }
            set { this.marketplaceField= value; }
        }



        /// <summary>
        /// Sets the Marketplace property
        /// </summary>
        /// <param name="marketplace">Marketplace property</param>
        /// <returns>this instance</returns>
        [System.Obsolete("Not used anymore. MWS ignores this parameter, but it is left in here for backwards compatibility.")]
        public ManageReportScheduleRequest WithMarketplace(String marketplace)
        {
            this.marketplaceField = marketplace;
            return this;
        }



        /// <summary>
        /// Checks if Marketplace property is set
        /// </summary>
        /// <returns>true if Marketplace property is set</returns>
        [System.Obsolete("Not used anymore. MWS ignores this parameter, but it is left in here for backwards compatibility.")]
        public Boolean IsSetMarketplace()
        {
            return  this.marketplaceField != null;

        }


        /// <summary>
        /// Gets and sets the Merchant property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Merchant")]
        public String Merchant
        {
            get { return this.merchantField ; }
            set { this.merchantField= value; }
        }



        /// <summary>
        /// Sets the Merchant property
        /// </summary>
        /// <param name="merchant">Merchant property</param>
        /// <returns>this instance</returns>
        public ManageReportScheduleRequest WithMerchant(String merchant)
        {
            this.merchantField = merchant;
            return this;
        }



        /// <summary>
        /// Checks if Merchant property is set
        /// </summary>
        /// <returns>true if Merchant property is set</returns>
        public Boolean IsSetMerchant()
        {
            return  this.merchantField != null;

        }


        /// <summary>
        /// Gets and sets the ReportType property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ReportType")]
        public String ReportType
        {
            get { return this.reportTypeField ; }
            set { this.reportTypeField= value; }
        }



        /// <summary>
        /// Sets the ReportType property
        /// </summary>
        /// <param name="reportType">ReportType property</param>
        /// <returns>this instance</returns>
        public ManageReportScheduleRequest WithReportType(String reportType)
        {
            this.reportTypeField = reportType;
            return this;
        }



        /// <summary>
        /// Checks if ReportType property is set
        /// </summary>
        /// <returns>true if ReportType property is set</returns>
        public Boolean IsSetReportType()
        {
            return  this.reportTypeField != null;

        }


        /// <summary>
        /// Gets and sets the Schedule property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Schedule")]
        public String Schedule
        {
            get { return this.scheduleField ; }
            set { this.scheduleField= value; }
        }



        /// <summary>
        /// Sets the Schedule property
        /// </summary>
        /// <param name="schedule">Schedule property</param>
        /// <returns>this instance</returns>
        public ManageReportScheduleRequest WithSchedule(String schedule)
        {
            this.scheduleField = schedule;
            return this;
        }



        /// <summary>
        /// Checks if Schedule property is set
        /// </summary>
        /// <returns>true if Schedule property is set</returns>
        public Boolean IsSetSchedule()
        {
            return  this.scheduleField != null;

        }


        /// <summary>
        /// Gets and sets the ScheduledDate property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ScheduledDate")]
        public DateTime ScheduledDate
        {
            get { return this.scheduledDateField.GetValueOrDefault() ; }
            set { this.scheduledDateField= value; }
        }



        /// <summary>
        /// Sets the ScheduledDate property
        /// </summary>
        /// <param name="scheduledDate">ScheduledDate property</param>
        /// <returns>this instance</returns>
        public ManageReportScheduleRequest WithScheduledDate(DateTime scheduledDate)
        {
            this.scheduledDateField = scheduledDate;
            return this;
        }



        /// <summary>
        /// Checks if ScheduledDate property is set
        /// </summary>
        /// <returns>true if ScheduledDate property is set</returns>
        public Boolean IsSetScheduledDate()
        {
            return  this.scheduledDateField.HasValue;

        }





    }

}
