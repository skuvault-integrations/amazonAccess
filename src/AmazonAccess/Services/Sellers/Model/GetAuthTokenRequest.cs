using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Sellers.Model
{
	[ XmlType( Namespace = "https://mws.amazonservices.com/Sellers/2011-07-01" ) ]
	[ XmlRoot( Namespace = "https://mws.amazonservices.com/Sellers/2011-07-01", IsNullable = false ) ]

	public class GetAuthTokenRequest: AbstractMwsObject
	{
		private string _sellerId;
		//private string _aWSAccessKeyId;

		/// <summary>
		/// Gets and sets the SellerId property.
		/// </summary>
		[ XmlElement( ElementName = "SellerId" ) ]
		public string SellerId
		{
			get { return this._sellerId; }
			set { this._sellerId = value; }
		}

		/// <summary>
		/// Gets and sets the AwsAccessKeyId property.
		/// </summary>
		//[ XmlElement( ElementName = "AWSAccessKeyId" ) ]
		//public string AwsAccessKeyId
		//{
		//	get { return this._aWSAccessKeyId; }
		//	set { this._aWSAccessKeyId = value; }
		//}

		/// <summary>
		/// Checks if SellerId property is set.
		/// </summary>
		/// <returns>true if SellerId property is set.</returns>
		public bool IsSetSellerId()
		{
			return this._sellerId != null;
		}

		/// <summary>
		/// Checks if AwsAccessKeyId property is set.
		/// </summary>
		/// <returns>true if AwsAccessKeyId property is set.</returns>
		//public bool IsSetAwsAccessKeyId()
		//{
		//	return this._aWSAccessKeyId != null;
		//}

		public override void ReadFragmentFrom( IMwsReader r )
		{
			this._sellerId = r.Read< string >( "SellerId" );
			//this._aWSAccessKeyId = r.Read< string >( "AWSAccessKeyId" );
		}

		public override void WriteFragmentTo( IMwsWriter w )
		{
			w.Write( "SellerId", this._sellerId );
			//w.Write( "AWSAccessKeyId", this._aWSAccessKeyId );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "https://mws.amazonservices.com/Sellers/2011-07-01", "GetAuthToken", this );
		}
	}
}