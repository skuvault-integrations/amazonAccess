using Netco.Logging;

namespace AmazonAccess.Misc
{
	public static class AmazonLogger
	{
		public static ILogger Log{ get; private set; }

		static AmazonLogger()
		{
			Log = NetcoLogger.GetLogger( "AmazonLogger" );
		}

		public static void Trace( string operationName, string sellerId, string marker, string format, params object[] args )
		{
			var message = string.Format( "[{0}] SellerId:'{1}' Marker:'{2}' ", operationName, sellerId, marker ) + string.Format( format, args );
			Log.Trace( message );
		}
	}
}