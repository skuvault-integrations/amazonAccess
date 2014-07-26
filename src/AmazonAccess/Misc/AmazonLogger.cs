using Netco.Logging;

namespace AmazonAccess.Misc
{
	public static class AmazonLogger
	{
		public static ILogger Log { get; private set; }

		static AmazonLogger()
		{
			Log = NetcoLogger.GetLogger( "AmazonLogger" );
		}
	}
}