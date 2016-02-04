using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Products.Model
{
	[ XmlType( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01" ) ]
	[ XmlRoot( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01", IsNullable = false ) ]
	public class ProductImage: AbstractMwsObject
	{
		public string URL{ get; set; }
		public string Height{ get; set; }
		public string Width{ get; set; }

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.URL = reader.Read< string >( "ns2:URL" );
			this.Height = reader.Read< string >( "ns2:Height" );
			this.Width = reader.Read< string >( "ns2:Width" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "ProductImage", this );
		}
	}
}