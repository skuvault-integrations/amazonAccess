using System.Collections.Generic;
using System.Linq;
using AmazonAccess.Models;
using AmazonAccess.Services.FbaInventory.Model;
using AmazonAccess.Services.FeedsReports.ReportModel;
using AmazonAccessTests.Misc;
using FluentAssertions;
using NUnit.Framework;

namespace AmazonAccessTests.Tests
{
	[ TestFixture ]
	internal sealed class FbaInventoryTests: TestsBase
	{
		[ SetUp ]
		public void Init()
		{
		}

		[ Test ]
		public void GetFbaInventory()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );
			List< InventorySupply > inventory = null;
			inventory = service.GetFbaInventory();
			this.SaveToFile( "FbaInventory.txt", inventory );
			//inventory = this.ReadFromFile< List< InventorySupply > >( "FbaInventory.txt" );
			var notEmpty = inventory.Where( x => this.IsNotEmpty( x ) ).ToList();

			inventory.Count().Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void GetFbaInventoryByOneMarketplace()
		{
			var inventoryList = new List< List< InventorySupply > >();
			var notEmptyInventoryList = new List< List< InventorySupply > >();
			var inventoryDic = new Dictionary< string, List< InventorySupply > >();
			var notEmptyDic = new Dictionary< string, List< InventorySupply > >();

			var marketplaces = this.ClientConfig.ParseMarketplaces();

			foreach( var amazonMarketplace in marketplaces.Marketplaces )
			{
				List< InventorySupply > inventory = null;
				var name = string.Format( "{0}-{1}", amazonMarketplace.CountryCode, amazonMarketplace.MarketplaceId );
				var fileName = string.Format( "FbaInventory_{0}.txt", name );
				var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, new AmazonMarketplaces( amazonMarketplace ) );

				inventory = service.GetFbaInventory();
				//this.SaveToFile( fileName, inventory.ToList() );

				//inventory = this.ReadFromFile< List< InventorySupply > >( fileName );
				inventoryList.Add( inventory );
				inventoryDic.Add( name, inventory );

				var notEmptyInventory = inventory.Where( x => this.IsNotEmpty( x ) ).ToList();
				notEmptyInventoryList.Add( notEmptyInventory );
				notEmptyDic.Add( name, notEmptyInventory );

				//inventory.Count().Should().BeGreaterThan( 0 );
			}

			var allinventory = this.ReadFromFile< List< InventorySupply > >( "FbaInventory.txt" );
			var notEmpty = allinventory.Where( x => this.IsNotEmpty( x ) ).ToList();

			var megaJoin = ( from marketplace0 in inventoryList[ 0 ]
				join marketplace1 in inventoryList[ 1 ] on marketplace0.SellerSKU equals marketplace1.SellerSKU
				join marketplace2 in inventoryList[ 2 ] on marketplace0.SellerSKU equals marketplace2.SellerSKU
				join marketplace3 in inventoryList[ 3 ] on marketplace0.SellerSKU equals marketplace3.SellerSKU
				join marketplace4 in inventoryList[ 4 ] on marketplace0.SellerSKU equals marketplace4.SellerSKU
				join marketplace5 in inventoryList[ 5 ] on marketplace0.SellerSKU equals marketplace5.SellerSKU
				join marketplace6 in inventoryList[ 6 ] on marketplace0.SellerSKU equals marketplace6.SellerSKU
				join marketplace7 in inventoryList[ 7 ] on marketplace0.SellerSKU equals marketplace7.SellerSKU
				select new { marketplace0, marketplace1, marketplace2, marketplace3, marketplace4, marketplace5, marketplace6, marketplace7 } ).ToList();

			var usDiff = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace0, sku.marketplace2, sku.marketplace6 ) ).ToList();
			//var usDiff2 = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace1, sku.marketplace2 ) ).ToList();
			//var usDiff3 = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace3, sku.marketplace4 ) ).ToList();
			//var usDiff4 = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace1, sku.marketplace3 ) ).ToList();
			//var usDiff5 = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace2, sku.marketplace3 ) ).ToList();
			//var usDiff6 = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace1, sku.marketplace4 ) ).ToList();

			var caDiff = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace3, sku.marketplace7 ) ).ToList();
			//var diff = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace1, sku.marketplace2, sku.marketplace3, sku.marketplace4, sku.marketplace5, sku.marketplace6 ) ).ToList();

			//var usDiff = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace1, sku.marketplace4 ) ).ToList();
			//var caDiff = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace3, sku.marketplace5 ) ).ToList();
			//var diff = megaJoin.Where( sku => this.IsNotEquals( sku.marketplace1, sku.marketplace2, sku.marketplace3, sku.marketplace4, sku.marketplace5 ) ).ToList();

			var mergedList = new List< InventorySupply >();
			mergedList.AddRange( inventoryList[ 0 ] );
			var forAdd = inventoryList[ 6 ].Where( x => !mergedList.Any( x2 => x2.SellerSKU.Equals( x.SellerSKU ) ) ).ToList();
			mergedList.AddRange( forAdd );

			var someItems0 = mergedList.Where( x => !allinventory.Any( x2 => x2.SellerSKU.Equals( x.SellerSKU ) ) ).ToList();
			var someItems00 = allinventory.Where( x => !mergedList.Any( x2 => x2.SellerSKU.Equals( x.SellerSKU ) ) ).ToList();

			var someItems = inventoryList[ 0 ].Where( x => !inventoryList[ 6 ].Any( x2 => x2.SellerSKU.Equals( x.SellerSKU ) ) ).ToList();
			var someItems2 = inventoryList[ 6 ].Where( x => !inventoryList[ 0 ].Any( x2 => x2.SellerSKU.Equals( x.SellerSKU ) ) ).ToList();

			var someItems3 = inventoryList[ 0 ].Where( x => !allinventory.Any( x2 => x2.SellerSKU.Equals( x.SellerSKU ) ) ).ToList();
			var someItems4 = allinventory.Where( x => !inventoryList[ 0 ].Any( x2 => x2.SellerSKU.Equals( x.SellerSKU ) ) ).ToList();

			var someItems5 = inventoryList[ 6 ].Where( x => !allinventory.Any( x2 => x2.SellerSKU.Equals( x.SellerSKU ) ) ).ToList();
			var someItems6 = allinventory.Where( x => !inventoryList[ 6 ].Any( x2 => x2.SellerSKU.Equals( x.SellerSKU ) ) ).ToList();

			//this.SaveToFile( "someItems.txt", someItems );
		}

		private void SelectSameSkusAsInReport( Dictionary< string, List< InventorySupply > > inventoryDic )
		{
			var inventoryByCountry = this.ReadFromFile< List< FbaMultiCountryInventory > >( "FbaMultiCountryInventory.txt" );
			var skus = inventoryByCountry.Where( x => x.CountryCode == AmazonCountryCodeEnum.Ca ).Select( x => x.SKU ).ToList();
			var inventoryWithCa = inventoryByCountry.Where( x => skus.Contains( x.SKU ) ).OrderBy( x => x.SKU ).ToList();
			this.SaveToFile( "FbaMultiCountryInventory_Filtered.txt", inventoryWithCa );

			var defaultInventory = this.ReadFromFile< List< InventorySupply > >( "FbaInventory.txt" );
			inventoryDic.Add( "Default", defaultInventory );

			foreach( var inventory in inventoryDic )
			{
				var filteredInventory = inventory.Value.Where( x => skus.Contains( x.SellerSKU ) ).OrderBy( x => x.SellerSKU ).ToList();
				var fileName = string.Format( "FbaInventory_{0}_Filtered.txt", inventory.Key );
				this.SaveToFile( fileName, filteredInventory );
			}
		}

		[ Test ]
		public void IsFbaInventoryReceived()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );

			var result = service.IsFbaInventoryReceived();
			result.Should().BeTrue();
		}

		[ Test ]
		public void GetDetailedFbaInventory()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );
			var inventory = service.GetDetailedFbaInventory( false );
			this.SaveToFile( "FbaManageInventory.txt", inventory );
			//var inventory = this.ReadFromFile< List< FbaManageInventory > >( "FbaManageInventory.txt" );

			inventory.Count.Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void GetDetailedFbaInventoryWithArchived()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );
			var inventory = service.GetDetailedFbaInventory();
			this.SaveToFile( "FbaManageInventoryArchived.txt", inventory );
			//var inventory = this.ReadFromFile< List< FbaManageInventory > >( "FbaManageInventoryArchived.txt" );

			inventory.Count.Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void GetDetailedFbaInventoryByMarketplaceWithArchived()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces( true ) );
			var inventory = service.GetDetailedFbaInventoryByMarketplace();

			inventory.Count.Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void GetFbaReservedInventory()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );
			var inventory = service.GetFbaReservedInventory();
			this.SaveToFile( "FbaReservedInventory.txt", inventory );
			//var inventory = this.ReadFromFile< List< FbaReservedInventory > >( "FbaReservedInventory.txt" );

			inventory.Count.Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void GetFbaReservedInventoryByMarketplace()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces( true ) );
			var inventory = service.GetFbaReservedInventoryByMarketplace();

			inventory.Count.Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void GetFbaMultiCountryInventory()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );
			var inventory = service.GetFbaMultiCountryInventory();
			this.SaveToFile( "FbaMultiCountryInventory.txt", inventory );
			//var inventory = this.ReadFromFile< List< FbaMultiCountryInventory > >( "FbaMultiCountryInventory.txt" );

			inventory.Count.Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void GetFbaFulfilledInventory()
		{
			var service = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );
			var inventory = service.GetFbaFulfilledInventory();
			this.SaveToFile( "FbaFulfilledInventory.txt", inventory );
			//var inventory = this.ReadFromFile< List< FbaFulfilledInventory > >( "FbaFulfilledInventory.txt" );

			inventory.Count.Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void ReportsDiff()
		{
			const string countryCode1 = "Us";
			const string countryCode2 = "Ca";

			//var manageInventoryServiceUs = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, new AmazonMarketplaces( countryCode1 ) );
			//var manageInventoryUs = manageInventoryServiceUs.GetDetailedFbaInventory();
			//this.SaveToFile( $"FbaManageInventoryArchived_{countryCode1}.txt", manageInventoryUs );

			//var manageInventoryServiceCa = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, new AmazonMarketplaces( countryCode2 ) );
			//var manageInventoryCa = manageInventoryServiceCa.GetDetailedFbaInventory();
			//this.SaveToFile( $"FbaManageInventoryArchived_{countryCode2}.txt", manageInventoryCa );

			//var reservedInventoryUsService = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, new AmazonMarketplaces( countryCode1 ) );
			//var reservedInventoryUs = reservedInventoryUsService.GetFbaReservedInventory();
			//this.SaveToFile( $"FbaReservedInventory_{countryCode1}.txt", reservedInventoryUs );

			//var reservedInventoryCaService = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, new AmazonMarketplaces( countryCode2 ) );
			//var reservedInventoryCa = reservedInventoryCaService.GetFbaReservedInventory();
			//this.SaveToFile( $"FbaReservedInventory_{countryCode2}.txt", reservedInventoryCa );

			//var multiCountryService = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );
			//var multiCountryInventory = multiCountryService.GetFbaMultiCountryInventory();
			//this.SaveToFile( "FbaMultiCountryInventory.txt", multiCountryInventory );

			//var fulfilledInventoryService = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );
			//var fulfilledInventory = fulfilledInventoryService.GetFbaFulfilledInventory();
			//this.SaveToFile( "FbaFulfilledInventory.txt", fulfilledInventory );

			//var apiInventoryServiceUs = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, new AmazonMarketplaces( countryCode1 ) );
			//var apiInventoryUs = apiInventoryServiceUs.GetFbaInventory();
			//this.SaveToFile( $"FbaInventory_{countryCode1}.txt", apiInventoryUs );

			//var apiInventoryServiceCa = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, new AmazonMarketplaces( countryCode2 ) );
			//var apiInventoryCa = apiInventoryServiceCa.GetFbaInventory();
			//this.SaveToFile( $"FbaInventory_{countryCode2}.txt", apiInventoryCa );

			var manageInventoryUs = this.ReadFromFile< List< FbaManageInventory > >( $"FbaManageInventoryArchived_{countryCode1}.txt" );
			var manageInventoryCa = this.ReadFromFile< List< FbaManageInventory > >( $"FbaManageInventoryArchived_{countryCode2}.txt" );
			var reservedInventoryUs = this.ReadFromFile< List< FbaReservedInventory > >( $"FbaReservedInventory_{countryCode1}.txt" );
			var reservedInventoryCa = this.ReadFromFile< List< FbaReservedInventory > >( $"FbaReservedInventory_{countryCode2}.txt" );
			var multiCountryInventory = this.ReadFromFile< List< FbaMultiCountryInventory > >( "FbaMultiCountryInventory.txt" );
			var fulfilledInventory = this.ReadFromFile< List< FbaFulfilledInventory > >( "FbaFulfilledInventory.txt" );
			var apiInventoryUs = this.ReadFromFile< List< InventorySupply > >( $"FbaInventory_{countryCode1}.txt" );
			var apiInventoryCa = this.ReadFromFile< List< InventorySupply > >( $"FbaInventory_{countryCode2}.txt" );

			var megaJoin = ( from manageUs in manageInventoryUs
				join manageCa in manageInventoryCa on manageUs.SKU equals manageCa.SKU
				//join manageCa in manageInventoryCA on manageUs.SKU equals manageCa.SKU into manageCa
				join reservedUs in reservedInventoryUs on manageUs.SKU equals reservedUs.SKU into reservedUs
				join reservedCa in reservedInventoryCa on manageUs.SKU equals reservedCa.SKU into reservedCa
				join multiCountry in multiCountryInventory on manageUs.SKU equals multiCountry.SKU into multiCountry
				join fulfilled in fulfilledInventory on manageUs.SKU equals fulfilled.SKU into fulfilled
				join apiUs in apiInventoryUs on manageUs.SKU equals apiUs.SellerSKU into apiUs
				join apiCa in apiInventoryCa on manageUs.SKU equals apiCa.SellerSKU into apiCa
				//where manageUs.AfnUnsellableQuantity > 0
				//where manageUs.AfnInboundWorkingQuantity > 0 && manageUs.AfnInboundShippedQuantity > 0 && manageUs.AfnInboundReceivingQuantity > 0
				select new ReportsDiffModel
				{
					ManageInventoryUs = manageUs,
					ManageInventoryCa = manageCa,
					//MarketplaceCa = manageCa.FirstOrDefault(),
					ReservedUs = reservedUs.FirstOrDefault(),
					ReservedCa = reservedCa.FirstOrDefault(),
					MultiCountry = multiCountry.ToList(),
					Fulfilled = fulfilled.ToList(),
					MultiCountryTotal = multiCountry.Sum( x2 => x2.QuantityForLocalFulfillment ),
					FulfilledSellableTotal = fulfilled.Where( x2 => x2.WarehouseConditionCode == "SELLABLE" ).Sum( x2 => x2.QuantityAvailable ),
					FulfilledUnsellableTotal = fulfilled.Where( x2 => x2.WarehouseConditionCode == "UNSELLABLE" ).Sum( x2 => x2.QuantityAvailable ),
					ApiInventoryUs = apiUs.FirstOrDefault(),
					ApiInventoryCa = apiCa.FirstOrDefault()
				} ).ToList();

			var diff = megaJoin.Where( x => x.ManageInventoryUs.AfnTotalQuantity != x.ManageInventoryCa.AfnTotalQuantity ||
			                                x.ManageInventoryUs.AfnFulfillableQuantity != x.ManageInventoryCa.AfnFulfillableQuantity ).ToList();
			var diffUs = diff.Where( x => x.ManageInventoryUs.AfnTotalQuantity > 0 ).ToList();
			var diffCa = diff.Where( x => x.ManageInventoryCa.AfnTotalQuantity > 0 ).ToList();
			var diffUsCa = diff.Where( x => x.ManageInventoryUs.AfnTotalQuantity > 0 && x.ManageInventoryCa.AfnTotalQuantity > 0 ).ToList();
			this.SaveToFile( "ReportsDiff.txt", diffUsCa );

			var diffUsCaShort = diffUsCa.Select( x => new ReportsDiffSummaryModel
			{
				SKU = x.ManageInventoryUs.SKU,
				FulfilledSellableTotal = x.FulfilledSellableTotal,
				FulfilledUnsellableTotal = x.FulfilledUnsellableTotal,
				MultiCountryUs = x.MultiCountry?.Where( x2 => x2.CountryCode == AmazonCountryCodeEnum.Us ).Sum( x2 => x2.QuantityForLocalFulfillment ) ?? 0,
				MultiCountryCa = x.MultiCountry?.Where( x2 => x2.CountryCode == AmazonCountryCodeEnum.Ca ).Sum( x2 => x2.QuantityForLocalFulfillment ) ?? 0,
				ManageInventoryUs = new FbaManageInventoryMain( x.ManageInventoryUs ),
				ManageInventoryCa = new FbaManageInventoryMain( x.ManageInventoryCa ),
				ApiInventoryUs = new InventorySupplyMain( x.ApiInventoryUs ),
				ApiInventoryCa = new InventorySupplyMain( x.ApiInventoryCa ),
				ReservedUs = new FbaReservedInventoryMain( x.ReservedUs ),
				ReservedCa = new FbaReservedInventoryMain( x.ReservedCa )
			} ).ToList();
			this.SaveToFile( "ReportsDiffSummary.txt", diffUsCaShort );

			var diffUsCaShort2 = diffUsCa.Select( x => new ReportsDiffSummaryShortModel
			{
				SKU = x.ManageInventoryUs.SKU,
				ReportsInventoryUs = new FbaReportsItemSummary( x.ManageInventoryUs, x.ReservedUs ),
				ReportsInventoryCa = new FbaReportsItemSummary( x.ManageInventoryCa, x.ReservedCa ),
				ApiInventoryUs = new InventorySupplyMain( x.ApiInventoryUs ),
				ApiInventoryCa = new InventorySupplyMain( x.ApiInventoryCa )
			} ).ToList();
			this.SaveToFile( "ReportsDiffShort.txt", diffUsCaShort2 );
		}

		[ Test ]
		public void ReportsDiff2()
		{
			const string countryCode1 = "Us";
			const string countryCode2 = "Ca";

			//var manageInventoryService = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );
			//var manageInventory = manageInventoryService.GetDetailedFbaInventory();
			//this.SaveToFile( "FbaManageInventoryArchived.txt", manageInventory );

			//var manageInventoryServiceUs = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, new AmazonMarketplaces( countryCode1 ) );
			//var manageInventoryUs = manageInventoryServiceUs.GetDetailedFbaInventory();
			//this.SaveToFile( $"FbaManageInventoryArchived_{countryCode1}.txt", manageInventoryUs );

			////var manageInventoryServiceUs2 = this.AmazonFactory.CreateService(this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, new AmazonMarketplaces(new AmazonMarketplace(countryCode1, "A2ZV50J4W1RKNI")));
			////var manageInventoryUs2 = manageInventoryServiceUs2.GetDetailedFbaInventory();
			////this.SaveToFile($"FbaManageInventoryArchived_{countryCode1}-A2ZV50J4W1RKNI.txt", manageInventoryUs2);

			//var manageInventoryServiceCa = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, new AmazonMarketplaces( countryCode2 ) );
			//var manageInventoryCa = manageInventoryServiceCa.GetDetailedFbaInventory();
			//this.SaveToFile( $"FbaManageInventoryArchived_{countryCode2}.txt", manageInventoryCa );

			//var reservedInventoryService = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, this.ClientConfig.ParseMarketplaces() );
			//var reservedInventory = reservedInventoryService.GetFbaReservedInventory();
			//this.SaveToFile( "FbaReservedInventory.txt", reservedInventory );

			//var reservedInventoryUsService = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, new AmazonMarketplaces( countryCode1 ) );
			//var reservedInventoryUs = reservedInventoryUsService.GetFbaReservedInventory();
			//this.SaveToFile( $"FbaReservedInventory_{countryCode1}.txt", reservedInventoryUs );

			//var reservedInventoryCaService = this.AmazonFactory.CreateService( this.ClientConfig.SellerId, this.ClientConfig.MwsAuthToken, new AmazonMarketplaces( countryCode2 ) );
			//var reservedInventoryCa = reservedInventoryCaService.GetFbaReservedInventory();
			//this.SaveToFile( $"FbaReservedInventory_{countryCode2}.txt", reservedInventoryCa );

			var manageInventory = this.ReadFromFile< List< FbaManageInventory > >( "FbaManageInventoryArchived.txt" );
			var manageInventoryUs = this.ReadFromFile< List< FbaManageInventory > >( $"FbaManageInventoryArchived_{countryCode1}.txt" );
			//var manageInventoryUs2 = this.ReadFromFile< List< FbaManageInventory > >( $"FbaManageInventoryArchived_{countryCode1}-A2ZV50J4W1RKNI.txt" );
			var manageInventoryCa = this.ReadFromFile< List< FbaManageInventory > >( $"FbaManageInventoryArchived_{countryCode2}.txt" );
			var reservedInventory = this.ReadFromFile< List< FbaReservedInventory > >( "FbaReservedInventory.txt" );
			var reservedInventoryUs = this.ReadFromFile< List< FbaReservedInventory > >( $"FbaReservedInventory_{countryCode1}.txt" );
			var reservedInventoryCa = this.ReadFromFile< List< FbaReservedInventory > >( $"FbaReservedInventory_{countryCode2}.txt" );

			var megaJoin = ( from manage in manageInventory
				join manageUs in manageInventoryUs on manage.SKU equals manageUs.SKU
				//join manageUs2 in manageInventoryUs2 on manage.SKU equals manageUs2.SKU
				join manageCa in manageInventoryCa on manage.SKU equals manageCa.SKU
				join reserved in reservedInventory on manage.SKU equals reserved.SKU into reserved
				join reservedUs in reservedInventoryUs on manage.SKU equals reservedUs.SKU into reservedUs
				join reservedCa in reservedInventoryCa on manage.SKU equals reservedCa.SKU into reservedCa
				select new ReportsDiffModel2
				{
					ManageInventory = manage,
					ManageInventoryUs = manageUs,
					//ManageInventoryUs2 = manageUs2,
					ManageInventoryCa = manageCa,
					Reserved = reserved.FirstOrDefault(),
					ReservedUs = reservedUs.FirstOrDefault(),
					ReservedCa = reservedCa.FirstOrDefault(),
				} ).ToList();

			var diff = megaJoin.Where( x => x.ManageInventoryUs.AfnTotalQuantity != x.ManageInventoryCa.AfnTotalQuantity ||
			                                x.ManageInventoryUs.AfnFulfillableQuantity != x.ManageInventoryCa.AfnFulfillableQuantity ).ToList();
			var diffUs = diff.Where( x => x.ManageInventoryUs.AfnTotalQuantity > 0 ).ToList();
			var diffCa = diff.Where( x => x.ManageInventoryCa.AfnTotalQuantity > 0 ).ToList();
			var diffUsCa = diff.Where( x => x.ManageInventoryUs.AfnTotalQuantity > 0 && x.ManageInventoryCa.AfnTotalQuantity > 0 ).ToList();
			this.SaveToFile( "ReportsDiff2.txt", diffUsCa );

			var diffUsCaShort2 = diffUsCa.Select( x => new ReportsDiffSummaryShortModel2
			{
				SKU = x.ManageInventoryUs.SKU,
				ReportsInventory = new FbaReportsItemSummary( x.ManageInventory, x.Reserved ),
				ReportsInventoryUs = new FbaReportsItemSummary( x.ManageInventoryUs, x.ReservedUs ),
				//ReportsInventoryUs2 = new FbaReportsItemSummary( x.ManageInventoryUs2, x.ReservedUs ),
				ReportsInventoryCa = new FbaReportsItemSummary( x.ManageInventoryCa, x.ReservedCa ),
			} ).ToList();
			this.SaveToFile( "ReportsDiffShort2.txt", diffUsCaShort2 );
		}

		#region Misc
		private bool IsNotEmpty( params InventorySupply[] objs )
		{
			return objs.Any( obj => obj.TotalSupplyQuantity > 0 || obj.InStockSupplyQuantity > 0 );
		}

		private bool IsNotEquals( params InventorySupply[] objs )
		{
			for( var i = 0; i < objs.Length; i++ )
			{
				for( var j = i + 1; j < objs.Length; j++ )
				{
					if( this.IsNotEquals( objs[ i ], objs[ j ] ) )
						return true;
				}
			}
			return false;
		}

		private bool IsNotEquals( InventorySupply obj1, InventorySupply obj2 )
		{
			return obj1.TotalSupplyQuantity != obj2.TotalSupplyQuantity || obj1.InStockSupplyQuantity != obj2.InStockSupplyQuantity;
		}
		#endregion
	}

	#region reports models	
	public class ReportsDiffModel
	{
		public FbaManageInventory ManageInventoryUs{ get; set; }
		public FbaManageInventory ManageInventoryCa{ get; set; }
		public FbaReservedInventory ReservedUs{ get; set; }
		public FbaReservedInventory ReservedCa{ get; set; }
		public int MultiCountryTotal{ get; set; }
		public List< FbaMultiCountryInventory > MultiCountry{ get; set; }
		public int FulfilledSellableTotal{ get; set; }
		public int FulfilledUnsellableTotal{ get; set; }
		public List< FbaFulfilledInventory > Fulfilled{ get; set; }
		public InventorySupply ApiInventoryUs{ get; set; }
		public InventorySupply ApiInventoryCa{ get; set; }
	}

	public class ReportsDiffModel2
	{
		public FbaManageInventory ManageInventory{ get; set; }
		public FbaManageInventory ManageInventoryUs{ get; set; }
		public FbaManageInventory ManageInventoryUs2{ get; set; }
		public FbaManageInventory ManageInventoryCa{ get; set; }
		public FbaReservedInventory Reserved{ get; set; }
		public FbaReservedInventory ReservedUs{ get; set; }
		public FbaReservedInventory ReservedCa{ get; set; }
	}

	public class ReportsDiffSummaryModel
	{
		public string SKU{ get; set; }
		public int FulfilledSellableTotal{ get; set; }
		public int FulfilledUnsellableTotal{ get; set; }
		public int MultiCountryUs{ get; set; }
		public int MultiCountryCa{ get; set; }
		public FbaManageInventoryMain ManageInventoryUs{ get; set; }
		public FbaManageInventoryMain ManageInventoryCa{ get; set; }
		public InventorySupplyMain ApiInventoryUs{ get; set; }
		public InventorySupplyMain ApiInventoryCa{ get; set; }
		public FbaReservedInventoryMain ReservedUs{ get; set; }
		public FbaReservedInventoryMain ReservedCa{ get; set; }
	}

	public class ReportsDiffSummaryShortModel
	{
		public string SKU{ get; set; }
		public FbaReportsItemSummary ReportsInventoryUs{ get; set; }
		public FbaReportsItemSummary ReportsInventoryCa{ get; set; }
		public InventorySupplyMain ApiInventoryUs{ get; set; }
		public InventorySupplyMain ApiInventoryCa{ get; set; }
	}

	public class ReportsDiffSummaryShortModel2
	{
		public string SKU{ get; set; }
		public FbaReportsItemSummary ReportsInventory{ get; set; }
		public FbaReportsItemSummary ReportsInventoryUs{ get; set; }
		public FbaReportsItemSummary ReportsInventoryUs2{ get; set; }
		public FbaReportsItemSummary ReportsInventoryCa{ get; set; }
	}

	public class FbaManageInventoryMain
	{
		public int MfnFulfillable{ get; set; }
		public int AfnWarehouse{ get; set; }
		public int AfnFulfillable{ get; set; }
		public int AfnUnsellable{ get; set; }
		public int AfnReserved{ get; set; }
		public int AfnTotal{ get; set; }
		public int AfnInboundWorking{ get; set; }
		public int AfnInboundShipped{ get; set; }
		public int AfnInboundReceiving{ get; set; }

		public FbaManageInventoryMain()
		{
		}

		public FbaManageInventoryMain( FbaManageInventory fbaManageInventory )
		{
			if( fbaManageInventory == null )
				return;
			this.MfnFulfillable = fbaManageInventory.MfnFulfillableQuantity;
			this.AfnWarehouse = fbaManageInventory.AfnWarehouseQuantity;
			this.AfnFulfillable = fbaManageInventory.AfnFulfillableQuantity;
			this.AfnUnsellable = fbaManageInventory.AfnUnsellableQuantity;
			this.AfnReserved = fbaManageInventory.AfnReservedQuantity;
			this.AfnTotal = fbaManageInventory.AfnTotalQuantity;
			this.AfnInboundWorking = fbaManageInventory.AfnInboundWorkingQuantity;
			this.AfnInboundShipped = fbaManageInventory.AfnInboundShippedQuantity;
			this.AfnInboundReceiving = fbaManageInventory.AfnInboundReceivingQuantity;
		}
	}

	public class FbaReservedInventoryMain
	{
		public int ReservedQty{ get; set; }
		public int ReservedCustomerOrders{ get; set; }
		public int ReservedFcTransfers{ get; set; }
		public int ReservedFcProcessing{ get; set; }

		public FbaReservedInventoryMain()
		{
		}

		public FbaReservedInventoryMain( FbaReservedInventory fbaReservedInventory )
		{
			if( fbaReservedInventory == null )
				return;
			this.ReservedQty = fbaReservedInventory.ReservedQty;
			this.ReservedCustomerOrders = fbaReservedInventory.ReservedCustomerOrders;
			this.ReservedFcTransfers = fbaReservedInventory.ReservedFcTransfers;
			this.ReservedFcProcessing = fbaReservedInventory.ReservedFcProcessing;
		}
	}

	public class InventorySupplyMain
	{
		public decimal Total{ get; set; }
		public decimal InStock{ get; set; }
		public decimal Inbound{ get; set; }
		public decimal Transfer{ get; set; }

		public InventorySupplyMain()
		{
		}

		public InventorySupplyMain( InventorySupply inventorySupply )
		{
			if( inventorySupply == null )
				return;
			this.Total = inventorySupply.TotalSupplyQuantity;
			this.InStock = inventorySupply.InStockSupplyQuantity;
			this.Inbound = inventorySupply.SupplyDetail.member.Where( x => x.SupplyType == "Inbound" ).Sum( x => x.Quantity );
			this.Transfer = inventorySupply.SupplyDetail.member.Where( x => x.SupplyType == "Transfer" ).Sum( x => x.Quantity );
		}
	}

	public class FbaReportsItemSummary
	{
		public int MfnFulfillable{ get; set; }
		public int AfnTotal{ get; set; }
		public int AfnWarehouse{ get; set; }
		public int AfnFulfillable{ get; set; }
		public int AfnUnsellable{ get; set; }
		public int AfnReservedTotal{ get; set; }
		public int AfnReservedCustomerOrders{ get; set; }
		public int AfnReservedFcTransfers{ get; set; }
		public int AfnReservedFcProcessing{ get; set; }
		public int AfnInboundTotal{ get; set; }
		public int AfnInboundWorking{ get; set; }
		public int AfnInboundShipped{ get; set; }
		public int AfnInboundReceiving{ get; set; }

		public FbaReportsItemSummary()
		{
		}

		public FbaReportsItemSummary( FbaManageInventory fbaManageInventory, FbaReservedInventory fbaReservedInventory )
		{
			if( fbaManageInventory != null )
			{
				this.MfnFulfillable = fbaManageInventory.MfnFulfillableQuantity;
				this.AfnWarehouse = fbaManageInventory.AfnWarehouseQuantity;
				this.AfnFulfillable = fbaManageInventory.AfnFulfillableQuantity;
				this.AfnUnsellable = fbaManageInventory.AfnUnsellableQuantity;
				this.AfnReservedTotal = fbaManageInventory.AfnReservedQuantity;
				this.AfnTotal = fbaManageInventory.AfnTotalQuantity;
				this.AfnInboundWorking = fbaManageInventory.AfnInboundWorkingQuantity;
				this.AfnInboundShipped = fbaManageInventory.AfnInboundShippedQuantity;
				this.AfnInboundReceiving = fbaManageInventory.AfnInboundReceivingQuantity;
				this.AfnInboundTotal = this.AfnInboundWorking + this.AfnInboundShipped + this.AfnInboundReceiving;
			}
			if( fbaReservedInventory != null )
			{
				this.AfnReservedCustomerOrders = fbaReservedInventory.ReservedCustomerOrders;
				this.AfnReservedFcTransfers = fbaReservedInventory.ReservedFcTransfers;
				this.AfnReservedFcProcessing = fbaReservedInventory.ReservedFcProcessing;
			}
		}
	}
	#endregion
}