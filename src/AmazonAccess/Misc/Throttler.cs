using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AmazonAccess.Misc
{
	public sealed class Throttler
	{
		private readonly int _maxQuota;
		private int _remainingQuota;
		private readonly Func< int, int > _releasedQuotaCalculator;
		private readonly Action _delay;
		private readonly int _maxRetryCount;

		//TODO: Update delayInSeconds to milliseconds or change type to decimal
		public Throttler( int maxQuota, int delayInSeconds ):
			this( maxQuota, el => el / delayInSeconds, () => Task.Delay( delayInSeconds * 1000 ).Wait(), 10 )
		{
		}

		public Throttler( int maxQuota, Func< int, int > releasedQuotaCalculator, Action delay, int maxRetryCount )
		{
			this._maxQuota = this._remainingQuota = maxQuota;
			this._releasedQuotaCalculator = releasedQuotaCalculator;
			this._delay = delay;
			this._maxRetryCount = maxRetryCount;
		}

		public TResult Execute< TResult >( Func< TResult > funcToThrottle )
		{
			var retryCount = 0;
			while( true )
			{
				try
				{
					return this.TryExecute( funcToThrottle );
				}
				catch( Exception ex )
				{
					if( !this.IsExceptionFromThrottling( ex ) )
						throw;

					if( retryCount >= this._maxRetryCount )
						throw new ThrottlerException( "Throttle max retry count reached", ex );

					this._remainingQuota = 0;
					this._requestTimer.Restart();
					this._delay();
					retryCount++;
					// try again through loop
				}
			}
		}

		private TResult TryExecute< TResult >( Func< TResult > funcToThrottle )
		{
			this.WaitIfNeeded();
			var result = funcToThrottle();
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

		private void WaitIfNeeded()
		{
			this.UpdateRequestQuoteFromTimer();

			if( this._remainingQuota != 0 )
				return;

			this._delay();
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

	public class ThrottlerException: Exception
	{
		public ThrottlerException()
		{
		}

		public ThrottlerException( string message ): base( message )
		{
		}

		public ThrottlerException( string message, Exception innerException ): base( message, innerException )
		{
		}
	}
}