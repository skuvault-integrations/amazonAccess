using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AmazonAccess.Misc
{
	public sealed class ThrottlerAsync
	{
		private readonly int _maxQuota;
		private int _remainingQuota;
		private readonly Func< int, int > _releasedQuotaCalculator;
		private readonly Func< Task > _delay;
		private readonly int _maxRetryCount;

		//TODO: Update delayInSeconds to milliseconds or change type to decimal
		public ThrottlerAsync( int maxQuota, int delayInSeconds ):
			this( maxQuota, el => el / delayInSeconds, () => Task.Delay( delayInSeconds * 1000 ), 10 )
		{
		}

		public ThrottlerAsync( int maxQuota, Func< int, int > releasedQuotaCalculator, Func< Task > delay, int maxRetryCount )
		{
			this._maxQuota = this._remainingQuota = maxQuota;
			this._releasedQuotaCalculator = releasedQuotaCalculator;
			this._delay = delay;
			this._maxRetryCount = maxRetryCount;
		}

		public async Task< TResult > ExecuteAsync< TResult >( Func< Task< TResult > > funcToThrottle )
		{
			var retryCount = 0;
			while( true )
			{
				try
				{
					return await this.TryExecuteAsync( funcToThrottle );
				}
				catch( Exception ex )
				{
					if( !this.IsExceptionFromThrottling( ex ) )
						throw;

					if( retryCount >= this._maxRetryCount )
						throw new ThrottlerException( "Throttle max retry count reached", ex );

					this._remainingQuota = 0;
					this._requestTimer.Restart();
					this._delay().Wait();
					retryCount++;
					// try again through loop
				}
			}
		}

		private async Task< TResult > TryExecuteAsync< TResult >( Func< Task< TResult > > funcToThrottle )
		{
			await this.WaitIfNeededAsync();
			var result = await funcToThrottle();
			this.SubtractQuota();
			return result;
		}

		private bool IsExceptionFromThrottling( Exception exception )
		{
			var x = exception;

			while( x != null )
			{
				if( !string.IsNullOrWhiteSpace( x.Message ) && x.Message.IndexOf( "throttle", StringComparison.OrdinalIgnoreCase ) >= 0 )
					return true;

				x = x.InnerException;
			}

			return false;
		}

		private async Task WaitIfNeededAsync()
		{
			this.UpdateRequestQuoteFromTimer();

			if( this._remainingQuota != 0 )
				return;

			await this._delay();
		}

		private void SubtractQuota()
		{
			this._remainingQuota--;
			if( this._remainingQuota < 0 )
				this._remainingQuota = 0;
			this._requestTimer.Start();
		}

		private void UpdateRequestQuoteFromTimer()
		{
			if( !this._requestTimer.IsRunning || this._remainingQuota == this._maxQuota )
				return;

			var totalSeconds = this._requestTimer.Elapsed.TotalSeconds;
			var elapsed = ( int )Math.Floor( totalSeconds );

			var quotaReleased = this._releasedQuotaCalculator( elapsed );

			if( quotaReleased == 0 )
				return;

			this._remainingQuota = Math.Min( this._remainingQuota + quotaReleased, this._maxQuota );
			this._requestTimer.Reset();
		}

		private readonly Stopwatch _requestTimer = new Stopwatch();
	}
}