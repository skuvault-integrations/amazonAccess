using System;
using System.Threading.Tasks;
using Netco.ActionPolicyServices;
using Netco.Logging;
using Netco.Utils;

namespace AmazonAccess.Misc
{
	public static class ActionPolicies
	{
		public static ActionPolicy AmazonGetPolicy
		{
			get { return _amazonGetPolicy; }
		}

		private static readonly ActionPolicy _amazonGetPolicy = ActionPolicy.Handle< Exception >().Retry( 2, ( ex, i ) =>
			{
				typeof( ActionPolicies ).Log().Trace( ex, "Retrying Amazon API get call for the {0} time", i );
				SystemUtil.Sleep( TimeSpan.FromSeconds( 0.5 + i ) );
			} );

		public static ActionPolicy AmazonSubmitPolicy
		{
			get { return _amazonSumbitPolicy; }
		}

		private static readonly ActionPolicy _amazonSumbitPolicy = ActionPolicy.Handle< Exception >().Retry( 2, ( ex, i ) =>
			{
				typeof( ActionPolicies ).Log().Trace( ex, "Retrying Amazon API submit call for the {0} time", i );
				SystemUtil.Sleep( TimeSpan.FromSeconds( 0.5 + i ) );
			} );

		public static ActionPolicyAsync QueryAsync
		{
			get { return _queryAsync; }
		}

		private static readonly ActionPolicyAsync _queryAsync = ActionPolicyAsync.Handle< Exception >().RetryAsync( 10, async ( ex, i ) =>
			{
				typeof( ActionPolicies ).Log().Trace( ex, "Retrying Amazon API get call for the {0} time", i );
				await Task.Delay( TimeSpan.FromSeconds( 0.5 + i ) );
			} );
	}
}