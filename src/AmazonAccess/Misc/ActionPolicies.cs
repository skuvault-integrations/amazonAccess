using System;
using System.Threading.Tasks;
using Netco.ActionPolicyServices;
using Netco.Utils;

namespace AmazonAccess.Misc
{
	public static class ActionPolicies
	{
#if DEBUG
		private const int RetryCount = 1;
#else
		private const int RetryCount = 10;
#endif

		public static readonly ActionPolicy Get = ActionPolicy.From( ex => !( ex is ThrottlerException ) ).Retry( RetryCount, ( ex, i ) =>
		{
			AmazonLogger.Log.Trace( ex, "Retrying Amazon API get call for the {0} time", i );
			SystemUtil.Sleep( TimeSpan.FromSeconds( 5 + 20 * i ) );
		} );

		public static readonly ActionPolicy Submit = ActionPolicy.From( ex => !( ex is ThrottlerException ) ).Retry( RetryCount, ( ex, i ) =>
		{
			AmazonLogger.Log.Trace( ex, "Retrying Amazon API submit call for the {0} time", i );
			SystemUtil.Sleep( TimeSpan.FromSeconds( 5 + 20 * i ) );
		} );

		public static Task CreateApiDelay( double seconds )
		{
			var delay = TimeSpan.FromSeconds( seconds );
			return Task.Delay( delay );
		}
	}
}