using System;
using System.Collections.Generic;
using System.Text;

namespace MarketplaceWebService.Attributes
{
    [AttributeUsage(
        AttributeTargets.Field |
        AttributeTargets.Method |
        AttributeTargets.Property,
        AllowMultiple = false)]

    public class MarketplaceWebServiceRequestHeaderAttribute : Attribute
    {
        string headerName;

        public MarketplaceWebServiceRequestHeaderAttribute(string headerName)
        {
            this.headerName = headerName;
        }

        public string HeaderName
        {
            get { return this.headerName; }
            set { this.headerName = value; }
        }
    
    }
}
