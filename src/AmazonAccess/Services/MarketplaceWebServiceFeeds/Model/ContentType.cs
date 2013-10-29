using System.Collections.Generic;
using System.Text;
using System.Reflection;
using AmazonAccess.Services.MarketplaceWebServiceFeeds.Model;

namespace AmazonAccess.Services.MarketplaceWebServiceFeeds.Model
{
    /// <summary>
    /// Defines the content type, encoding, and character set used to
    /// send a feed to MWS.
    /// </summary>
    public class ContentType
    {
        private MediaType _contentType = MediaType.OctetStream;
        private List<IContentTypeParameter> _parameters = new List<IContentTypeParameter>();
        
        private void AddParameter(IContentTypeParameter parameter)
        {
            this._parameters.Add(parameter);
        }

        /// <summary>
        /// Gets or sets the type of content.  This value defaults
        /// to "FeedContentType.OctetStream".
        /// </summary>
        public MediaType Type
        {
            get { return this._contentType; }
        }

        /// <summary>
        /// Creates a new instance of the ContentType object with the default values.
        /// </summary>
        private ContentType()
        {
        }

        /// <summary>
        /// Creates a new instance of the ContentType object with the specified values.
        /// </summary>
        public ContentType(MediaType contentType)
        {
            this._contentType = contentType;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            // Pick the "Description" attribute off the specified enum value.  This will throw an exception
            // if the attribute is not present or the enum value is not valid.
            System.ComponentModel.DescriptionAttribute descAttribute = (System.ComponentModel.DescriptionAttribute)
                typeof(MediaType).GetField(this._contentType.ToString(), BindingFlags.Static | BindingFlags.GetField | BindingFlags.Public)
                .GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false)[0];
            sb.Append(descAttribute.Description);
            foreach (IContentTypeParameter param in this._parameters)
            {
                sb.Append(";" + param.ToString());
            }
            return sb.ToString();
        }
    }
}
