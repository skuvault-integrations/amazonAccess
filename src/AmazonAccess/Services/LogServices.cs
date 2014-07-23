using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CuttingEdge.Conditions;
using Netco.Logging;

namespace AmazonAccess.Services
{
	public static class LogServices
	{
		public static void LogStream( this ILogger logger, string contentType, string context, Stream stream )
		{
			Condition.Requires( logger, "logger" ).IsNotNull();
			Condition.Requires( stream, "stream" ).IsNotNull();

			if( ( !stream.CanSeek && stream.Position > 0 ) || !stream.CanRead )
				return;

			stream.Position = 0;
			var reader = new StreamReader( stream );
			var streamContent = reader.ReadToEnd();
			stream.Position = 0;

			logger.Trace( "'{0}' content for account '{1}':\n {2}", contentType, context, streamContent );
		}

		public static readonly ILogger Logger = NetcoLogger.GetLogger( "AmazonService" );
	}

	/// <summary>
	/// Logs write operations to be later retrieved for logging.
	/// </summary>
	public sealed class LoggingStream : MemoryStream
	{
		private readonly Stream _primaryStream;

		public LoggingStream( Stream primaryStream )
		{
			Condition.Requires( primaryStream, "streamToLog" ).IsNotNull();

			this._primaryStream = primaryStream;
		}

		public override void Flush()
		{
			this._primaryStream.Flush();
			base.Flush();
		}

		public override void SetLength( long value )
		{
			this._primaryStream.SetLength( value );
			base.SetLength( value );
		}

		public override void Write( byte[] buffer, int offset, int count )
		{
			this._primaryStream.Write( buffer, offset, count );
			base.Write( buffer, offset, count );
		}

		public override IAsyncResult BeginWrite( byte[] buffer, int offset, int count, AsyncCallback callback, object state )
		{
			base.Write( buffer, offset, count );
			return this._primaryStream.BeginWrite( buffer, offset, count, callback, state );
		}

		public override void EndWrite( IAsyncResult asyncResult )
		{
			this._primaryStream.EndWrite( asyncResult );
		}

		public override Task WriteAsync( byte[] buffer, int offset, int count, CancellationToken cancellationToken )
		{
			base.Write( buffer, offset, count );

			return this._primaryStream.WriteAsync( buffer, offset, count, cancellationToken );
		}

		public override void WriteByte( byte value )
		{
			this._primaryStream.WriteByte( value );
			base.WriteByte( value );
		}

		public override void Close()
		{
			this._primaryStream.Close();
			base.Close();
		}
	}
}