using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Products.Model
{
	[ XmlType( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01" ) ]
	[ XmlRoot( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01", IsNullable = false ) ]
	public class Dimensions: AbstractMwsObject
	{
		public string Height{ get; set; }
		public string Length{ get; set; }
		public string Width{ get; set; }
		public string Weight{ get; set; }

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.Height = reader.Read< string >( "ns2:Height" );
			this.Length = reader.Read< string >( "ns2:Length" );
			this.Width = reader.Read< string >( "ns2:Width" );
			this.Weight = reader.Read< string >( "ns2:Weight" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "Dimensions", this );
		}
	}
}