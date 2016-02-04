using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Products.Model
{
	[ XmlType( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01" ) ]
	[ XmlRoot( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01", IsNullable = false ) ]
	public class Price: AbstractMwsObject
	{
		public decimal Amount{ get; set; }
		public string CurrencyCode{ get; set; }

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.Amount = reader.Read< decimal >( "ns2:Amount" );
			this.CurrencyCode = reader.Read< string >( "ns2:CurrencyCode" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "Price", this );
		}
	}
}