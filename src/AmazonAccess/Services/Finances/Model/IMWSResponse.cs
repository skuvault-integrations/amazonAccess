/*******************************************************************************
 * Copyright 2009-2019 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * Library Version: 2019-02-25
 * Generated: Wed Mar 13 08:17:08 PDT 2019
 */

using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Finances.Model
{
	public interface IMWSResponse : IMwsObject
	{
		ResponseHeaderMetadata ResponseHeaderMetadata
		{
			get;
			set;
		}
	}
}