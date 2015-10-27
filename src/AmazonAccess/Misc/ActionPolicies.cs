using System;
using System.Threading.Tasks;
using Netco.ActionPolicyServices;
using Netco.Logging;
using Netco.Utils;

namespace AmazonAccess.Misc
{
	public static class ActionPolicies
	{
		public static readonly ActionPolicy AmazonThrottlerGetPolicy = ActionPolicy.Handle< NotThrottlerException >().Retry( 10, ( ex, i ) =>
		{
			typeof( ActionPolicies ).Log().Trace( ex, "Retrying Amazon API get call for the {0} time", i );
			SystemUtil.Sleep( TimeSpan.FromSeconds( 5 + 20 * i ) );
		} );

		public static readonly ActionPolicy AmazonGetPolicy = ActionPolicy.Handle< Exception >().Retry( 10, ( ex, i ) =>
		{
			typeof( ActionPolicies ).Log().Trace( ex, "Retrying Amazon API get call for the {0} time", i );
			SystemUtil.Sleep( TimeSpan.FromSeconds( 5 + 20 * i ) );
		} );

		public static readonly ActionPolicy AmazonSubmitPolicy = ActionPolicy.Handle< Exception >().Retry( 10, ( ex, i ) =>
		{
			typeof( ActionPolicies ).Log().Trace( ex, "Retrying Amazon API submit call for the {0} time", i );
			SystemUtil.Sleep( TimeSpan.FromSeconds( 5 + 20 * i ) );
		} );

		public static Task CreateApiDelay( double seconds )
		{
			var delay = TimeSpan.FromSeconds( seconds );
			return Task.Delay( delay );
		}
	}
}