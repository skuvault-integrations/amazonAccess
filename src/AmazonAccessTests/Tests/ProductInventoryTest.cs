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
        public void ParseReport_WhenReceivingReport_ThenParseColumnsHeaderToLowerCase()
        {
            // Arrange
            var data = File.ReadAllText( @"..\..\Files\Product_inventory_example.csv" );

            // Act
            var inventory = new AmazonCsvReader().ParseReport< ProductInventory >( data ).ToList();

            // Assert
            inventory.Should().NotBeNull();
            inventory.Count.Should().BeGreaterThan( 1 );
            Assert.IsTrue( inventory.TrueForAll( i => i.Sku != null ) );
            Assert.IsTrue( inventory.TrueForAll( i => i.Asin != null ) );
        }
    }
}