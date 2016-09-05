using LINQtoCSV;

namespace AmazonAccessTests.Misc
{
	internal class AppCredentialsConfig
	{
		[ CsvColumn( Name = "NaAccessKeyId", FieldIndex = 1 ) ]
		public string NaAccessKeyId{ get; set; }

		[ CsvColumn( Name = "NaSecretAccessKeyId", FieldIndex = 2 ) ]
		public string NaSecretAccessKeyId{ get; set; }

		[ CsvColumn( Name = "EuAccessKeyId", FieldIndex = 3 ) ]
		public string EuAccessKeyId{ get; set; }

		[ CsvColumn( Name = "EuSecretAccessKeyId", FieldIndex = 4 ) ]
		public string EuSecretAccessKeyId{ get; set; }

		[ CsvColumn( Name = "FeAccessKeyId", FieldIndex = 5 ) ]
		public string FeAccessKeyId{ get; set; }

		[ CsvColumn( Name = "FeSecretAccessKeyId", FieldIndex = 6 ) ]
		public string FeSecretAccessKeyId{ get; set; }

		[ CsvColumn( Name = "CnAccessKeyId", FieldIndex = 7 ) ]
		public string CnAccessKeyId{ get; set; }

		[ CsvColumn( Name = "CnSecretAccessKeyId", FieldIndex = 8 ) ]
		public string CnSecretAccessKeyId{ get; set; }
	}
}