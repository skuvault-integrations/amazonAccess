using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AmazonAccess.Misc;
using NUnit.Framework;

namespace AmazonAccessTests.Tests
{
	internal abstract class ThrottlerTestsBase
	{
		private int _callCounter;
		private Func< int > _callCounterFunc;
		private Func< Func< int >, int > _throttlerExecute;
		protected Throttler _throttler;
		protected ThrottlerAsync _throttlerAsync;

		[ SetUp ]
		public virtual void Init()
		{
			this._callCounter = 0;
			this._callCounterFunc = () => this._callCounter++;
			//this._throttlerExecute = x => this._throttler.Execute( x );
			this._throttlerExecute = x => this._throttlerAsync.ExecuteAsync( () => Task.FromResult( x() ) ).GetAwaiter().GetResult();
		}

		protected void MakeRequests( int requestsCount )
		{
			for( var i = 1; i <= requestsCount; i++ )
			{
				Debug.WriteLine( "Request=" + i );
				Assert.AreEqual( this._callCounter, this._throttlerExecute( this._callCounterFunc ) );
			}
		}
	}

	internal class ThrottlerTests1: ThrottlerTestsBase
	{
		[ SetUp ]
		public override void Init()
		{
			this._throttler = new Throttler( 5, 2, 1 );
			this._throttlerAsync = new ThrottlerAsync( 5, 2, 1 );
			base.Init();
		}

		[ Test ]
		public void NoDelayUntilLimitHit()
		{
			//------------ Arrange
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			//------------ Act
			this.MakeRequests( 5 );

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
			this.MakeRequests( 6 );

			//------------ Assert
			stopwatch.Stop();
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds >= 2.0 );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds <= 2.5 );
		}

		[ Test ]
		public void ReleaseAutomaticallyIfTimePasses()
		{
			//------------ Arrange
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			Debug.WriteLine( "Not throttlered requests" );
			this.MakeRequests( 5 );

			//------------ Act
			Debug.WriteLine( "Throttlered requests" );
			this.MakeRequests( 2 );

			//------------ Assert
			stopwatch.Stop();
			Debug.WriteLine( "TotalSeconds=" + stopwatch.Elapsed.TotalSeconds );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds >= 4.0 );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds <= 4.5 );
		}

		[ Test ]
		public void ReleaseAutomaticallyIfTimePasses2()
		{
			//------------ Arrange
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			Debug.WriteLine( "Not throttlered requests" );
			this.MakeRequests( 5 );

			Task.Delay( 4000 ).Wait();

			//------------ Act
			Debug.WriteLine( "Not throttlered requests" );
			this.MakeRequests( 2 );

			//------------ Assert
			stopwatch.Stop();
			Debug.WriteLine( "TotalSeconds=" + stopwatch.Elapsed.TotalSeconds );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds >= 4.0 );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds <= 4.5 );
		}

		[ Test ]
		public void ReleaseAutomaticallyIfTimePasses3()
		{
			//------------ Arrange
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			Debug.WriteLine( "Not throttlered requests" );
			this.MakeRequests( 5 );

			Task.Delay( 2000 ).Wait();

			//------------ Act
			Debug.WriteLine( "1 not throttlered and 1 throttlered requests" );
			this.MakeRequests( 2 );

			//------------ Assert
			stopwatch.Stop();
			Debug.WriteLine( "TotalSeconds=" + stopwatch.Elapsed.TotalSeconds );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds >= 4.0 );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds <= 4.5 );
		}

		[ Test ]
		public void ReleaseAutomaticallyIfTimePasses4()
		{
			//------------ Arrange
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			Debug.WriteLine( "Not throttlered requests" );
			this.MakeRequests( 5 );

			Task.Delay( 10000 ).Wait();

			//------------ Act
			Debug.WriteLine( "Not throttlered requests" );
			this.MakeRequests( 5 );

			//------------ Assert
			stopwatch.Stop();
			Debug.WriteLine( "TotalSeconds=" + stopwatch.Elapsed.TotalSeconds );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds >= 10.0 );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds <= 10.5 );
		}

		[ Test ]
		public void ReleaseAutomaticallyIfTimePasses5()
		{
			//------------ Arrange
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			Debug.WriteLine( "Not throttlered requests" );
			this.MakeRequests( 5 );

			Task.Delay( 12000 ).Wait();

			//------------ Act
			Debug.WriteLine( "5 not throttlered and 1 throttlered requests" );
			this.MakeRequests( 6 );

			//------------ Assert
			stopwatch.Stop();
			Debug.WriteLine( "TotalSeconds=" + stopwatch.Elapsed.TotalSeconds );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds >= 14.0 );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds <= 14.5 );
		}

		[ Test ]
		public void ReleaseAutomaticallyIfTimePasses6()
		{
			//------------ Arrange
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			//------------ Act
			Debug.WriteLine( "5 not throttlered and 9 throttlered requests" );
			this.MakeRequests( 14 );

			//------------ Assert
			stopwatch.Stop();
			Debug.WriteLine( "TotalSeconds=" + stopwatch.Elapsed.TotalSeconds );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds >= 18.0 );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds <= 18.5 );
		}
	}

	internal class ThrottlerTests2: ThrottlerTestsBase
	{
		[ SetUp ]
		public override void Init()
		{
			this._throttler = new Throttler( 5, 10, 5 );
			this._throttlerAsync = new ThrottlerAsync( 5, 10, 5 );
			base.Init();
		}

		[ Test ]
		public void NoDelayUntilLimitHit()
		{
			//------------ Arrange
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			//------------ Act
			this.MakeRequests( 5 );

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
			this.MakeRequests( 6 );

			//------------ Assert
			stopwatch.Stop();
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds >= 10.0 );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds <= 10.5 );
		}

		[ Test ]
		public void ReleaseAutomaticallyIfTimePasses()
		{
			//------------ Arrange
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			Debug.WriteLine( "Not throttlered requests" );
			this.MakeRequests( 5 );

			//------------ Act
			Debug.WriteLine( "Throttlered requests" );
			this.MakeRequests( 2 );

			//------------ Assert
			stopwatch.Stop();
			Debug.WriteLine( "TotalSeconds=" + stopwatch.Elapsed.TotalSeconds );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds >= 10.0 );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds <= 10.5 );
		}

		[ Test ]
		public void ReleaseAutomaticallyIfTimePasses2()
		{
			//------------ Arrange
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			Debug.WriteLine( "Not throttlered requests" );
			this.MakeRequests( 5 );

			Task.Delay( 10000 ).Wait();

			//------------ Act
			Debug.WriteLine( "Not throttlered requests" );
			this.MakeRequests( 2 );

			//------------ Assert
			stopwatch.Stop();
			Debug.WriteLine( "TotalSeconds=" + stopwatch.Elapsed.TotalSeconds );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds >= 10.0 );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds <= 10.5 );
		}

		[ Test ]
		public void ReleaseAutomaticallyIfTimePasses3()
		{
			//------------ Arrange
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			Debug.WriteLine( "Not throttlered requests" );
			this.MakeRequests( 5 );

			Task.Delay( 5000 ).Wait();

			//------------ Act
			Debug.WriteLine( "Throttlered requests on remaining 5 sec" );
			this.MakeRequests( 2 );

			//------------ Assert
			stopwatch.Stop();
			Debug.WriteLine( "TotalSeconds=" + stopwatch.Elapsed.TotalSeconds );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds >= 10.0 );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds <= 10.5 );
		}

		[ Test ]
		public void ReleaseAutomaticallyIfTimePasses4()
		{
			//------------ Arrange
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			Debug.WriteLine( "Not throttlered requests" );
			this.MakeRequests( 5 );

			Task.Delay( 10000 ).Wait();

			//------------ Act
			Debug.WriteLine( "Not throttlered requests" );
			this.MakeRequests( 5 );

			//------------ Assert
			stopwatch.Stop();
			Debug.WriteLine( "TotalSeconds=" + stopwatch.Elapsed.TotalSeconds );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds >= 10.0 );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds <= 10.5 );
		}

		[ Test ]
		public void ReleaseAutomaticallyIfTimePasses5()
		{
			//------------ Arrange
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			Debug.WriteLine( "Not throttlered requests" );
			this.MakeRequests( 5 );

			Task.Delay( 12000 ).Wait();

			//------------ Act
			Debug.WriteLine( "5 not throttlered and 1 throttlered requests" );
			this.MakeRequests( 6 );

			//------------ Assert
			stopwatch.Stop();
			Debug.WriteLine( "TotalSeconds=" + stopwatch.Elapsed.TotalSeconds );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds >= 22.0 );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds <= 22.5 );
		}

		[ Test ]
		public void ReleaseAutomaticallyIfTimePasses6()
		{
			//------------ Arrange
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			//------------ Act
			Debug.WriteLine( "5 not throttlered and 9 throttlered requests" );
			this.MakeRequests( 14 );

			//------------ Assert
			stopwatch.Stop();
			Debug.WriteLine( "TotalSeconds=" + stopwatch.Elapsed.TotalSeconds );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds >= 20.0 );
			Assert.IsTrue( stopwatch.Elapsed.TotalSeconds <= 20.5 );
		}
	}
}