using System;
using AmazonAccess.Models;
using AmazonAccess.Services.FeedsReports.ReportModel;
using LINQtoCSV;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace AmazonAccess.Misc
{
	public class AmazonCsvReader
	{
		public IEnumerable< T > ParseReport< T >( string reportString, AmazonCountryCodeEnum? countryCode = null ) where T : class, new()
		{
			reportString = WebUtility.HtmlDecode( reportString );
			// sku can contain quote
			reportString = reportString.Replace( @"""", "" );
			
			// sku and asin can be uppercase
			reportString = ParseColumnsHeaderToLowerCase(reportString);

			using( var ms = new MemoryStream( Encoding.UTF8.GetBytes( reportString ) ) )
			using( var reader = new StreamReader( ms ) )
			{
				var cc = new CsvContext();
				var csvOptions = new CsvFileDescription
				{
					FirstLineHasColumnNames = true, SeparatorChar = '\t', IgnoreUnknownColumns = true, FileCultureInfo = CultureInfo.InvariantCulture,
					QuoteAllFields = true, TextEncoding = Encoding.UTF8, UseFieldIndexForReadingData = false
				};

				var obj = new T();
				if( obj is ProductShort && countryCode == AmazonCountryCodeEnum.Jp )
				{
					var dataJp = this.ReadReport< ProductShortJp >( reader, cc, csvOptions );
					return ( IEnumerable< T > )dataJp.Select( ProductShort.FromProductShortJp ).ToList();
				}
				if( obj is ProductShort )
				{
					var dataEn = this.ReadReport< ProductShortEn >( reader, cc, csvOptions );
					return ( IEnumerable< T > )dataEn.Select( ProductShort.FromProductShortEn ).ToList();
				}

				return this.ReadReport< T >( reader, cc, csvOptions );
			}
		}

		private List< T > ReadReport< T >( StreamReader reader, CsvContext cc, CsvFileDescription csvOptions ) where T : class, new()
		{
			var report = cc.Read< T >( reader, csvOptions );
			return report.ToList();
		}
		
		private static string ParseColumnsHeaderToLowerCase(string reportString)
		{
			int locationOfFirstCharReturn = reportString.IndexOf( "\r", StringComparison.Ordinal );
			if( locationOfFirstCharReturn < 0 )
				return reportString;
			
			string headerString = reportString.Substring( 0, locationOfFirstCharReturn );
			
			string report = reportString.Substring( locationOfFirstCharReturn, reportString.Length - locationOfFirstCharReturn );
			
			return headerString.ToLowerInvariant() + report;
		}
	}
}