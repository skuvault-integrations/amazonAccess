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
 * Library Version: 2015-09-24
 * Generated: Fri Sep 25 20:06:25 GMT 2015
 */

using AmazonAccess.Services.Common;

namespace AmazonAccess.Services.Orders.Model
{
	public class PaymentExecutionDetailItem: AbstractMwsObject
	{
		/// <summary>
		/// Gets and sets the Payment property.
		/// </summary>
		public Money Payment{ get; set; }

		/// <summary>
		/// Sets the Payment property.
		/// </summary>
		/// <param name="payment">Payment property.</param>
		/// <returns>this instance.</returns>
		public PaymentExecutionDetailItem WithPayment( Money payment )
		{
			this.Payment = payment;
			return this;
		}

		/// <summary>
		/// Checks if Payment property is set.
		/// </summary>
		/// <returns>true if Payment property is set.</returns>
		public bool IsSetPayment()
		{
			return this.Payment != null;
		}

		/// <summary>
		/// Gets and sets the PaymentMethod property.
		/// </summary>
		public string PaymentMethod{ get; set; }

		/// <summary>
		/// Sets the PaymentMethod property.
		/// </summary>
		/// <param name="paymentMethod">PaymentMethod property.</param>
		/// <returns>this instance.</returns>
		public PaymentExecutionDetailItem WithPaymentMethod( string paymentMethod )
		{
			this.PaymentMethod = paymentMethod;
			return this;
		}

		/// <summary>
		/// Checks if PaymentMethod property is set.
		/// </summary>
		/// <returns>true if PaymentMethod property is set.</returns>
		public bool IsSetPaymentMethod()
		{
			return this.PaymentMethod != null;
		}

		public override void ReadFragmentFrom( IMwsReader reader )
		{
			this.Payment = reader.Read< Money >( "Payment" );
			this.PaymentMethod = reader.Read< string >( "PaymentMethod" );
		}

		public override void WriteFragmentTo( IMwsWriter writer )
		{
			writer.Write( "Payment", this.Payment );
			writer.Write( "PaymentMethod", this.PaymentMethod );
		}

		public override void WriteTo( IMwsWriter writer )
		{
			writer.Write( "https://mws.amazonservices.com/Orders/2013-09-01", "PaymentExecutionDetailItem", this );
		}

		public PaymentExecutionDetailItem(): base()
		{
		}
	}
}