using System;

namespace AmazonAccess.Services.MarketplaceWebServiceFeedsReports.Attributes
{
    [AttributeUsage(
        AttributeTargets.Field |
        AttributeTargets.Method |
        AttributeTargets.Property,
        AllowMultiple = false)]

    public class MarketplaceWebServiceStreamAttribute : Attribute
    {
        private StreamType streamType;

        public StreamType StreamType
        {
            get { return this.streamType; }
            set { this.streamType = value; }
        }
    }
}
