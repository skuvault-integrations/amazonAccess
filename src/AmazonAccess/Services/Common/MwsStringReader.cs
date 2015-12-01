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

using System;
using System.Collections.Generic;
using System.Xml;

namespace AmazonAccess.Services.Common
{
	public class MwsStringReader: IMwsReader
	{
		private readonly string doc;

		/// <summary>
		/// Load the file as string
		/// </summary>
		/// <param name="value">content as string</param>
		public MwsStringReader( string value )
		{
			this.doc = value;
		}

		public T ReadAttribute< T >( string name )
		{
			throw new NotImplementedException();
		}

		public T ReadValue< T >()
		{
			throw new NotImplementedException();
		}

		public T Read< T >( string name )
		{
			throw new NotImplementedException();
		}

		public List< T > ReadList< T >( string memberName )
		{
			throw new NotImplementedException();
		}

		public List< T > ReadList< T >( string name, string memberName )
		{
			throw new NotImplementedException();
		}

		public List< XmlElement > ReadAny()
		{
			throw new NotImplementedException();
		}

		public string ReadAll()
		{
			return this.doc;
		}
	}
}