/******************************************************************************* 
 * Copyright 2009-2012 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * Marketplace Web Service Runtime Client Library
 */

using System.Collections.Generic;

namespace AmazonAccess.Services.Common
{
	/// <summary>
	/// Wrapped response metadata
	/// </summary>
	public class MwsResponseMetadata: AbstractMwsObject
	{
		private readonly string name = "ResponseMetadata";
		public string RequestId;
		public List< string > ResponseContext;
		public string Timestamp;

		public MwsResponseMetadata()
		{
		}

		public MwsResponseMetadata( string requestId )
		{
			this.RequestId = requestId;
		}

		public override void ReadFragmentFrom( IMwsReader r )
		{
			this.RequestId = r.Read< string >( "RequestId" );
		}

		public override void WriteFragmentTo( IMwsWriter w )
		{
			w.Write( "RequestId", this.RequestId );
		}

		public override void WriteTo( IMwsWriter w )
		{
			w.BeginObject( this.name );
			this.WriteFragmentTo( w );
			w.EndObject( this.name );
		}
	}
}