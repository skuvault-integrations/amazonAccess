using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Sellers.Model
{
	[ XmlType( Namespace = "https://mws.amazonservices.com/Sellers/2011-07-01" ) ]
	[ XmlRoot( Namespace = "https://mws.amazonservices.com/Sellers/2011-07-01", IsNullable = false ) ]
	public class GetAuthTokenResponse: AbstractMwsObject, IMwsResponse
	{
		/// <summary>
		/// Gets and sets the GetServiceStatusResult property.
		/// </summary>
		[ XmlElement( ElementName = "GetAuthTokenResponse" ) ]
		public GetAuthTokenResult GetAuthTokenResult{ get; set; }

		/// <summary>
		/// Sets the GetAuthTokenResult property.
		/// </summary>
		/// <param name="getAuthTokenResult">GetAuthTokenResult property.</param>
		/// <returns>this instance.</returns>
		public GetAuthTokenResponse WithGetServiceStatusResult( GetAuthTokenResult getAuthTokenResult )
		{
			this.GetAuthTokenResult = getAuthTokenResult;
			return this;
		}

		/// <summary>
		/// Checks if GetAuthTokenResult property is set.
		/// </summary>
		/// <returns>true if GetAuthTokenResult property is set.</returns>
		public bool IsSetGetAuthTokenResult()
		{
			return this.GetAuthTokenResult != null;
		}

		/// <summary>
		/// Gets and sets the ResponseMetadata property.
		/// </summary>
		[ XmlElement( ElementName = "ResponseMetadata" ) ]
		public ResponseMetadata ResponseMetadata{ get; set; }

		/// <summary>
		/// Sets the ResponseMetadata property.
		/// </summary>
		/// <param name="responseMetadata">ResponseMetadata property.</param>
		/// <returns>this instance.</returns>
		public GetAuthTokenResponse WithResponseMetadata( ResponseMetadata responseMetadata )
		{
			this.ResponseMetadata = responseMetadata;
			return this;
		}

		/// <summary>
		/// Checks if ResponseMetadata property is set.
		/// </summary>
		/// <returns>true if ResponseMetadata property is set.</returns>
		public bool IsSetResponseMetadata()
		{
			return this.ResponseMetadata != null;
		}

		/// <summary>
		/// Gets and sets the ResponseHeaderMetadata property.
		/// </summary>
		[ XmlElement( ElementName = "ResponseHeaderMetadata" ) ]
		public MwsResponseHeaderMetadata ResponseHeaderMetadata{ get; set; }

		/// <summary>
		/// Sets the ResponseHeaderMetadata property.
		/// </summary>
		/// <param name="responseHeaderMetadata">ResponseHeaderMetadata property.</param>
		/// <returns>this instance.</returns>
		public GetAuthTokenResponse WithResponseHeaderMetadata( MwsResponseHeaderMetadata responseHeaderMetadata )
		{
			this.ResponseHeaderMetadata = responseHeaderMetadata;
			return this;
		}

		/// <summary>
		/// Checks if ResponseHeaderMetadata property is set.
		/// </summary>
		/// <returns>true if ResponseHeaderMetadata property is set.</returns>
		public bool IsSetResponseHeaderMetadata()
		{
			return this.ResponseHeaderMetadata != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.GetAuthTokenResult = reader.Read< GetAuthTokenResult >( "GetAuthTokenResult" );
			this.ResponseMetadata = reader.Read< ResponseMetadata >( "ResponseMetadata" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "GetAuthTokenResult", this.GetAuthTokenResult );
			writer.Write( "ResponseMetadata", this.ResponseMetadata );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "https://mws.amazonservices.com/Sellers/2011-07-01", "GetAuthTokenResponse", this );
		}
	}
}