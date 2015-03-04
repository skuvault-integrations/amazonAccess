using System.Xml.Serialization;
using AmazonAccess.Services.Utils;

namespace AmazonAccess.Services.MarketplaceWebServiceSellers.Model
{
	[ XmlType( Namespace = "https://mws.amazonservices.com/Sellers/2011-07-01" ) ]
	[ XmlRoot( Namespace = "https://mws.amazonservices.com/Sellers/2011-07-01", IsNullable = false ) ]
	public class GetAuthTokenResponse: AbstractMwsObject, IMWSResponse
	{
		private GetAuthTokenResult _getAuthTokenResult;
		private ResponseMetadata _responseMetadata;
		private ResponseHeaderMetadata _responseHeaderMetadata;

		/// <summary>
		/// Gets and sets the GetServiceStatusResult property.
		/// </summary>
		[ XmlElement( ElementName = "GetAuthTokenResponse" ) ]
		public GetAuthTokenResult GetAuthTokenResult
		{
			get { return this._getAuthTokenResult; }
			set { this._getAuthTokenResult = value; }
		}

		/// <summary>
		/// Sets the GetAuthTokenResult property.
		/// </summary>
		/// <param name="getAuthTokenResult">GetAuthTokenResult property.</param>
		/// <returns>this instance.</returns>
		public GetAuthTokenResponse WithGetServiceStatusResult( GetAuthTokenResult getAuthTokenResult )
		{
			this._getAuthTokenResult = getAuthTokenResult;
			return this;
		}

		/// <summary>
		/// Checks if GetAuthTokenResult property is set.
		/// </summary>
		/// <returns>true if GetAuthTokenResult property is set.</returns>
		public bool IsSetGetAuthTokenResult()
		{
			return this._getAuthTokenResult != null;
		}

		/// <summary>
		/// Gets and sets the ResponseMetadata property.
		/// </summary>
		[ XmlElement( ElementName = "ResponseMetadata" ) ]
		public ResponseMetadata ResponseMetadata
		{
			get { return this._responseMetadata; }
			set { this._responseMetadata = value; }
		}

		/// <summary>
		/// Sets the ResponseMetadata property.
		/// </summary>
		/// <param name="responseMetadata">ResponseMetadata property.</param>
		/// <returns>this instance.</returns>
		public GetAuthTokenResponse WithResponseMetadata( ResponseMetadata responseMetadata )
		{
			this._responseMetadata = responseMetadata;
			return this;
		}

		/// <summary>
		/// Checks if ResponseMetadata property is set.
		/// </summary>
		/// <returns>true if ResponseMetadata property is set.</returns>
		public bool IsSetResponseMetadata()
		{
			return this._responseMetadata != null;
		}

		/// <summary>
		/// Gets and sets the ResponseHeaderMetadata property.
		/// </summary>
		[ XmlElement( ElementName = "ResponseHeaderMetadata" ) ]
		public ResponseHeaderMetadata ResponseHeaderMetadata
		{
			get { return this._responseHeaderMetadata; }
			set { this._responseHeaderMetadata = value; }
		}

		/// <summary>
		/// Sets the ResponseHeaderMetadata property.
		/// </summary>
		/// <param name="responseHeaderMetadata">ResponseHeaderMetadata property.</param>
		/// <returns>this instance.</returns>
		public GetAuthTokenResponse WithResponseHeaderMetadata( ResponseHeaderMetadata responseHeaderMetadata )
		{
			this._responseHeaderMetadata = responseHeaderMetadata;
			return this;
		}

		/// <summary>
		/// Checks if ResponseHeaderMetadata property is set.
		/// </summary>
		/// <returns>true if ResponseHeaderMetadata property is set.</returns>
		public bool IsSetResponseHeaderMetadata()
		{
			return this._responseHeaderMetadata != null;
		}


		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this._getAuthTokenResult = reader.Read< GetAuthTokenResult >( "GetAuthTokenResult" );
			this._responseMetadata = reader.Read< ResponseMetadata >( "ResponseMetadata" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "GetAuthTokenResult", this._getAuthTokenResult );
			writer.Write( "ResponseMetadata", this._responseMetadata );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "https://mws.amazonservices.com/Sellers/2011-07-01", "GetAuthTokenResponse", this );
		}
	}
}