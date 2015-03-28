/*******************************************************************************
 * Copyright 2009-2015 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * Payment Execution Detail Item
 * API Version: 2013-09-01
 * Library Version: 2015-03-05
 * Generated: Tue Mar 03 22:11:26 GMT 2015
 */

using System.Xml.Serialization;
using AmazonAccess.Services.Utils;

namespace AmazonAccess.Services.MarketplaceWebServiceOrders.Model
{
	[ XmlRoot( Namespace = "https://mws.amazonservices.com/Orders/2013-09-01", IsNullable = false ) ]
	public class PaymentExecutionDetailItem: AbstractMwsObject
	{

		private Money _payment;
		private string _paymentMethod;

		/// <summary>
		/// Gets and sets the Payment property.
		/// </summary>
		public Money Payment
		{
			get { return this._payment; }
			set { this._payment = value; }
		}

		/// <summary>
		/// Sets the Payment property.
		/// </summary>
		/// <param name="payment">Payment property.</param>
		/// <returns>this instance.</returns>
		public PaymentExecutionDetailItem WithPayment( Money payment )
		{
			this._payment = payment;
			return this;
		}

		/// <summary>
		/// Checks if Payment property is set.
		/// </summary>
		/// <returns>true if Payment property is set.</returns>
		public bool IsSetPayment()
		{
			return this._payment != null;
		}

		/// <summary>
		/// Gets and sets the PaymentMethod property.
		/// </summary>
		public string PaymentMethod
		{
			get { return this._paymentMethod; }
			set { this._paymentMethod = value; }
		}

		/// <summary>
		/// Sets the PaymentMethod property.
		/// </summary>
		/// <param name="paymentMethod">PaymentMethod property.</param>
		/// <returns>this instance.</returns>
		public PaymentExecutionDetailItem WithPaymentMethod( string paymentMethod )
		{
			this._paymentMethod = paymentMethod;
			return this;
		}

		/// <summary>
		/// Checks if PaymentMethod property is set.
		/// </summary>
		/// <returns>true if PaymentMethod property is set.</returns>
		public bool IsSetPaymentMethod()
		{
			return this._paymentMethod != null;
		}


		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this._payment = reader.Read< Money >( "Payment" );
			this._paymentMethod = reader.Read< string >( "PaymentMethod" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "Payment", this._payment );
			writer.Write( "PaymentMethod", this._paymentMethod );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "https://mws.amazonservices.com/Orders/2013-09-01", "PaymentExecutionDetailItem", this );
		}
	}
}