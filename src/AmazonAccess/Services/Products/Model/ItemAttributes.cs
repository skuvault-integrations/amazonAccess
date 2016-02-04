using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Products.Model
{
	[ XmlType( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01" ) ]
	[ XmlRoot( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01", IsNullable = false ) ]
	public class ItemAttributes: AbstractMwsObject
	{
		public string Author{ get; set; }
		public string Binding{ get; set; }
		public string Label{ get; set; }
		public string Languages{ get; set; }
		public string Manufacturer{ get; set; }
		public string NumberOfItems{ get; set; }
		public string NumberOfPages{ get; set; }
		public Dimensions ItemDimensions{ get; set; }
		public Dimensions PackageDimensions{ get; set; }
		public string ProductGroup{ get; set; }
		public string ProductTypeName{ get; set; }
		public string PublicationDate{ get; set; }
		public string Publisher{ get; set; }
		public ProductImage SmallImage{ get; set; }
		public string Studio{ get; set; }
		public string Title{ get; set; }
		public string Brand{ get; set; }
		public string DisplaySize{ get; set; }
		public string Model{ get; set; }
		public string PackageQuantity{ get; set; }
		public string ListPrice{ get; set; }
		public string PartNumber{ get; set; }

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.Author = reader.Read< string >( "ns2:Author" );
			this.Binding = reader.Read< string >( "ns2:Binding" );
			this.Label = reader.Read< string >( "ns2:Label" );
			this.Languages = reader.Read< string >( "ns2:Languages" );
			this.Manufacturer = reader.Read< string >( "ns2:Manufacturer" );
			this.NumberOfItems = reader.Read< string >( "ns2:NumberOfItems" );
			this.NumberOfPages = reader.Read< string >( "ns2:NumberOfPages" );
			this.ItemDimensions = reader.Read< Dimensions >( "ns2:ItemDimensions" );
			this.PackageDimensions = reader.Read< Dimensions >( "ns2:PackageDimensions" );
			this.ProductGroup = reader.Read< string >( "ns2:ProductGroup" );
			this.ProductTypeName = reader.Read< string >( "ns2:ProductTypeName" );
			this.PublicationDate = reader.Read< string >( "ns2:PublicationDate" );
			this.Publisher = reader.Read< string >( "ns2:Publisher" );
			this.SmallImage = reader.Read< ProductImage >( "ns2:SmallImage" );
			this.Studio = reader.Read< string >( "ns2:Studio" );
			this.Title = reader.Read< string >( "ns2:Title" );
			this.Brand = reader.Read< string >( "ns2:Brand" );
			this.DisplaySize = reader.Read< string >( "ns2:DisplaySize" );
			this.Model = reader.Read< string >( "ns2:Model" );
			this.PackageQuantity = reader.Read< string >( "ns2:PackageQuantity" );
			this.ListPrice = reader.Read< string >( "ns2:ListPrice" );
			this.PartNumber = reader.Read< string >( "ns2:PartNumber" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "http://mws.amazonservices.com/schema/Products/2011-10-01", "ItemAttributes", this );
		}
	}
}