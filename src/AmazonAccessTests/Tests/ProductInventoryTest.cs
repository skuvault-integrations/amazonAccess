using System.IO;
using System.Linq;
using AmazonAccess.Misc;
using AmazonAccess.Services.FeedsReports.ReportModel;
using FluentAssertions;
using NUnit.Framework;

namespace AmazonAccessTests.Tests
{
    [ TestFixture ]
    internal sealed class ProductInventoryTest
    {
        [ Test ]
        public void ParseReport_WhenReceivingReportWithUppercaseHeader_ThenParseColumnsHeaderToLowerCase()
        {
            // Arrange
            var data = File.ReadAllText( @"..\..\Files\Product_inventory_uppercase_example.csv" );

            // Act
            var inventory = new AmazonCsvReader().ParseReport< ProductInventory >( data ).ToList();

            // Assert
            inventory.Count.Should().Be( 8 );
            inventory.Should().OnlyContain( x => x.Sku != null );
            inventory.Should().OnlyContain( x => x.Asin != null );

            inventory.First().Sku.Should().Be( "Guard175-testsku" );
            inventory.First().Asin.Should().Be( "B001F42LU2" );
            inventory.First().Price.Should().Be( 25 );
            inventory.First().Quantity.Should().Be( 7 );

            inventory.Last().Sku.Should().Be( "testSku5" );
            inventory.Last().Asin.Should().Be( "B00485FCF6" );
            inventory.Last().Price.Should().Be( 62.50M );
            inventory.Last().Quantity.Should().Be( 0 );
        }

        [ Test ]
        public void ParseReport_WhenReceivingReportWithLowercaseHeader_ThenParseColumnsHeaderToLowerCase()
        {
            // Arrange
            var data = File.ReadAllText( @"..\..\Files\Product_inventory_lowercase_example.csv" );

            // Act
            var inventory = new AmazonCsvReader().ParseReport< ProductInventory >( data ).ToList();

            // Assert
            inventory.Count.Should().Be( 8 );
            inventory.Should().OnlyContain( x => x.Sku != null );
            inventory.Should().OnlyContain( x => x.Asin != null );

            inventory.First().Sku.Should().Be( "Guard175-testsku" );
            inventory.First().Asin.Should().Be( "B001F42LU2" );
            inventory.First().Price.Should().Be( 25 );
            inventory.First().Quantity.Should().Be( 7 );

            inventory.Last().Sku.Should().Be( "testSku5" );
            inventory.Last().Asin.Should().Be( "B00485FCF6" );
            inventory.Last().Price.Should().Be( 62.50M );
            inventory.Last().Quantity.Should().Be( 0 );
        }
    }
}