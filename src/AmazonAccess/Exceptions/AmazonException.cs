using System;

namespace AmazonAccess.Exceptions
{
	/// <summary>
	/// Exception thrown if Amazon returns an error.
	/// </summary>
	[ Serializable ]
	public class AmazonException : Exception
	{
		public AmazonException( string errorMessage )
			: base( ConstructMessage( errorMessage ) )
		{

		}

		private static string ConstructMessage( string errorMessage )
		{
			return string.Format( "Failed to execute Amazon API call. Error: {0}", errorMessage );
		}
	}
}