using System.Xml.Serialization;
using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Products.Model
{
	[ XmlType( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01" ) ]
	[ XmlRoot( Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01", IsNullable = false ) ]
	public class ItemAttributes: AbstractMwsObject
	{
		public string Binding{ get; set; }
		public string Brand{ get; set; }
		public string Color{ get; set; }
		public string Department{ get; set; }
		public Dimensions ItemDimensions{ get; set; }
		public string ItemPartNumber{ get; set; }
		public string Label{ get; set; }
		public Price ListPrice{ get; set; }
		public string Manufacturer{ get; set; }
		public string Model{ get; set; }
		public string NumberOfItems{ get; set; }
		public Dimensions PackageDimensions{ get; set; }
		public string PackageQuantity{ get; set; }
		public string PartNumber{ get; set; }
		public string ProductGroup{ get; set; }
		public string ProductTypeName{ get; set; }
		public string PublicationDate{ get; set; }
		public string Publisher{ get; set; }
		public string Size{ get; set; }
		public ProductImage SmallImage{ get; set; }
		public string Studio{ get; set; }
		public string Title{ get; set; }

		//public string Actor{ get; set; }
		//public string Artist{ get; set; }
		//public string AspectRatio{ get; set; }
		//public string AudienceRating{ get; set; }
		//public string Author{ get; set; }
		//public string BackFinding{ get; set; }
		//public string BandMaterialType{ get; set; }
		//public string BlurayRegion{ get; set; }
		//public string CEROAgeRating{ get; set; }
		//public string ChainType{ get; set; }
		//public string ClaspType{ get; set; }
		//public string CPUManufacturer{ get; set; }
		//public string CPUSpeed{ get; set; }
		//public string CPUType{ get; set; }
		//public string Creator{ get; set; }
		//public string Director{ get; set; }
		//public string DisplaySize{ get; set; }
		//public string Edition{ get; set; }
		//public string EpisodeSequence{ get; set; }
		//public string ESRBAgeRating{ get; set; }
		//public string Feature{ get; set; }
		//public string Flavor{ get; set; }
		//public string Format{ get; set; }
		//public string GemType{ get; set; }
		//public string Genre{ get; set; }
		//public string GolfClubFlex{ get; set; }
		//public string GolfClubLoft{ get; set; }
		//public string HandOrientation{ get; set; }
		//public string HardDiskInterface{ get; set; }
		//public string HardDiskSize{ get; set; }
		//public string HardwarePlatform{ get; set; }
		//public string HazardousMaterialType{ get; set; }
		//public string IsAdultProduct{ get; set; }
		//public string IsAutographed{ get; set; }
		//public string IsEligibleForTradeIn{ get; set; }
		//public string IsMemorabilia{ get; set; }
		//public string IssuesPerYear{ get; set; }
		//public string Languages{ get; set; }
		//public string LegalDisclaimer{ get; set; }
		//public string ManufacturerMaximumAge{ get; set; }
		//public string ManufacturerMinimumAge{ get; set; }
		//public string ManufacturerPartsWarrantyDescription{ get; set; }
		//public string MaterialType{ get; set; }
		//public string MaximumResolution{ get; set; }
		//public string MediaType{ get; set; }
		//public string MetalStamp{ get; set; }
		//public string MetalType{ get; set; }
		//public string NumberOfDiscs{ get; set; }
		//public string NumberOfIssues{ get; set; }
		//public string NumberOfPages{ get; set; }
		//public string NumberOfTracks{ get; set; }
		//public string OperatingSystem{ get; set; }
		//public string OpticalZoom{ get; set; }
		//public string PegiRating{ get; set; }
		//public string Platform{ get; set; }
		//public string ProcessorCount{ get; set; }
		//public string ProductTypeSubcategory{ get; set; }
		//public string RegionCode{ get; set; }
		//public string ReleaseDate{ get; set; }
		//public string RingSize{ get; set; }
		//public string RunningTime{ get; set; }
		//public string ShaftMaterial{ get; set; }
		//public string Scent{ get; set; }
		//public string SeasonSequence{ get; set; }
		//public string SeikodoProductCode{ get; set; }
		//public string SizePerPearl{ get; set; }
		//public string SubscriptionLength{ get; set; }
		//public string SystemMemorySize{ get; set; }
		//public string SystemMemoryType{ get; set; }
		//public string TheatricalReleaseDate{ get; set; }
		//public string TotalDiamondWeight{ get; set; }
		//public string TotalGemWeight{ get; set; }
		//public string Warranty{ get; set; }
		//public string WEEETaxValue{ get; set; }

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.Binding = reader.Read< string >( "ns2:Binding" );
			this.Brand = reader.Read< string >( "ns2:Brand" );
			this.Color = reader.Read< string >( "ns2:Color" );
			this.Department = reader.Read< string >( "ns2:Department" );
			this.ItemDimensions = reader.Read< Dimensions >( "ns2:ItemDimensions" );
			this.ItemPartNumber = reader.Read< string >( "ns2:ItemPartNumber" );
			this.Label = reader.Read< string >( "ns2:Label" );
			this.ListPrice = reader.Read< Price >( "ns2:ListPrice" );
			this.Manufacturer = reader.Read< string >( "ns2:Manufacturer" );
			this.Model = reader.Read< string >( "ns2:Model" );
			this.NumberOfItems = reader.Read< string >( "ns2:NumberOfItems" );
			this.PackageDimensions = reader.Read< Dimensions >( "ns2:PackageDimensions" );
			this.PackageQuantity = reader.Read< string >( "ns2:PackageQuantity" );
			this.PartNumber = reader.Read< string >( "ns2:PartNumber" );
			this.ProductGroup = reader.Read< string >( "ns2:ProductGroup" );
			this.ProductTypeName = reader.Read< string >( "ns2:ProductTypeName" );
			this.PublicationDate = reader.Read< string >( "ns2:PublicationDate" );
			this.Publisher = reader.Read< string >( "ns2:Publisher" );
			this.Size = reader.Read< string >( "ns2:Size" );
			this.SmallImage = reader.Read< ProductImage >( "ns2:SmallImage" );
			this.Studio = reader.Read< string >( "ns2:Studio" );
			this.Title = reader.Read< string >( "ns2:Title" );
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