using CuttingEdge.Conditions;

namespace AmazonAccess.Models
{
	public sealed class AmazonAppCredentials
	{
		public string AccessKeyId{ get; private set; }
		public string SecretAccessKeyId{ get; private set; }

		public AmazonAppCredentials( string accessKeyId, string secretAccessKeyId )
		{
			Condition.Requires( accessKeyId, "accessKeyId" ).IsNotNullOrWhiteSpace();
			Condition.Requires( secretAccessKeyId, "secretAccessKeyId" ).IsNotNullOrWhiteSpace();

			this.AccessKeyId = accessKeyId;
			this.SecretAccessKeyId = secretAccessKeyId;
		}

		public static AmazonAppCredentials Create( string accessKeyId, string secretAccessKeyId )
		{
			return new AmazonAppCredentials( accessKeyId, secretAccessKeyId );
		}

		public static AmazonAppCredentials TryCreate( string accessKeyId, string secretAccessKeyId )
		{
			if( string.IsNullOrWhiteSpace( accessKeyId ) || string.IsNullOrWhiteSpace( secretAccessKeyId ) )
				return null;
			return new AmazonAppCredentials( accessKeyId, secretAccessKeyId );
		}
	}
}