using LINQtoCSV;

namespace AmazonAccessTests
{
	internal class TestConfig
	{
		[ CsvColumn( Name = "AccessKeyId", FieldIndex = 1 ) ]
		public string AccessKeyId{ get; set; }

		[ CsvColumn( Name = "SecretAccessKeyId", FieldIndex = 2 ) ]
		public string SecretAccessKeyId{ get; set; }

		[ CsvColumn( Name = "SellerId", FieldIndex = 3 ) ]
		public string SellerId{ get; set; }
	}
}