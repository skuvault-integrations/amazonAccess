using System;
using System.Diagnostics;
using System.Threading;
using AmazonAccess.Misc;
using NUnit.Framework;

namespace AmazonAccessTests.Misc
{
	internal class ThrottlerTests
	{
		private Throttler _throttler;
		private int _callCounter;
		private Func< int > _callCounterFunc;

		[ SetUp ]
		public void Init()
		{
			_throttler = new Throttler( 5, 2 );
			_callCounter = 0;
			_callCounterFunc = () => _callCounter++;
		}

		[ Test ]
		public void NoDelayUntilLimitHit()
		{
			//------------ Arrange
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			//------------ Act
			for( var i = 0; i < 5; i++ )
			{
				Assert.AreEqual( _callCounter, _throttler.ExecuteWithTrottling( _callCounterFunc ) );
			}

			//------------ Assert
			stopwatch.Stop();
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds < 1f );
		}

		[ Test ]
		public void DelayWhenLimitHit()
		{
			//------------ Arrange
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			//------------ Act
			for( var i = 0; i < 6; i++ )
			{
				Assert.AreEqual( _callCounter, _throttler.ExecuteWithTrottling( _callCounterFunc ) );
			}

			//------------ Assert
			stopwatch.Stop();
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds > 1f );
		}

		[ Test ]
		public void ReleaseAutomaticallyIfTimePasses()
		{
			//------------ Arrange
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			for( var i = 0; i < 6; i++ )
			{
				Assert.AreEqual( _callCounter, _throttler.ExecuteWithTrottling( _callCounterFunc ) );
			}

			//------------ Act
			Assert.AreEqual( _callCounter, _throttler.ExecuteWithTrottling( _callCounterFunc ) );

			//------------ Assert
			stopwatch.Stop();
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds < 3f );
		}

		[ Test ]
		public void ReleaseAutomaticallyIfTimePasses2()
		{
			//------------ Arrange
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			for( var i = 0; i < 5; i++ )
			{
				Assert.AreEqual( _callCounter, _throttler.ExecuteWithTrottling( _callCounterFunc ) );
			}
			Thread.Sleep( 2000 );

			//------------ Act
			Assert.AreEqual( _callCounter, _throttler.ExecuteWithTrottling( _callCounterFunc ) );

			//------------ Assert
			stopwatch.Stop();
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds < 3f );
		}
	}
}