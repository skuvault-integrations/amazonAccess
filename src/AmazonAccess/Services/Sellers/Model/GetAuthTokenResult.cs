using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Sellers.Model
{
	[ XmlType( Namespace = "https://mws.amazonservices.com/Sellers/2011-07-01" ) ]
	[ XmlRoot( Namespace = "https://mws.amazonservices.com/Sellers/2011-07-01", IsNullable = false ) ]
	public class GetAuthTokenResult: AbstractMwsObject
	{
		private string _sellerId;
		private string _mWSAuthToken;

		/// <summary>
		/// Gets and sets the MWSAuthToken property.
		/// </summary>
		[ XmlElement( ElementName = "MWSAuthToken" ) ]
		public string MWSAuthToken
		{
			get { return this._mWSAuthToken; }
			set { this._mWSAuthToken = value; }
		}

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
		/// Checks if SellerId property is set.
		/// </summary>
		/// <returns>true if SellerId property is set.</returns>
		public bool IsSetSellerId()
		{
			return this._sellerId != null;
		}

		/// <summary>
		/// Checks if MWSAuthToken property is set.
		/// </summary>
		/// <returns>true if MWSAuthToken property is set.</returns>
		public bool IsSetMWSAuthToken()
		{
			return this._mWSAuthToken != null;
		}

		public override void ReadFragmentFrom( IMwsReader r )
		{
			this._sellerId = r.Read< string >( "SellerId" );
			this._mWSAuthToken = r.Read< string >( "MWSAuthToken" );
		}

		public override void WriteFragmentTo( IMwsWriter w )
		{
			w.Write( "SellerId", this._sellerId );
			w.Write( "MWSAuthToken", this._mWSAuthToken );
		}

		public override void WriteTo( IMwsWriter w )
		{
			w.Write( "https://mws.amazonservices.com/Sellers/2011-07-01", "GetAuthTokenResult", this );
		}
	}
}