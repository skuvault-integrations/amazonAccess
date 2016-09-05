using System;
using System.Diagnostics;
using System.Threading;
using AmazonAccess.Misc;
using NUnit.Framework;

namespace AmazonAccessTests.Tests
{
	internal class ThrottlerTests
	{
		private int _callCounter;
		private Func< int > _callCounterFunc;
		private Throttler _throttler;

		[ SetUp ]
		public void Init()
		{
			this._throttler = new Throttler( 5, 2 );
			this._callCounter = 0;
			this._callCounterFunc = () => this._callCounter++;
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
				Assert.AreEqual( this._callCounter, this._throttler.Execute( this._callCounterFunc ) );
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
				Assert.AreEqual( this._callCounter, this._throttler.Execute( this._callCounterFunc ) );
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
				Assert.AreEqual( this._callCounter, this._throttler.Execute( this._callCounterFunc ) );
			}

			//------------ Act
			Assert.AreEqual( this._callCounter, this._throttler.Execute( this._callCounterFunc ) );

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
				Assert.AreEqual( this._callCounter, this._throttler.Execute( this._callCounterFunc ) );
			}
			Thread.Sleep( 2000 );

			//------------ Act
			Assert.AreEqual( this._callCounter, this._throttler.Execute( this._callCounterFunc ) );

			//------------ Assert
			stopwatch.Stop();
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds < 3f );
		}
	}
}