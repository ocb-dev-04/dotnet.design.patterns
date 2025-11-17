/*
ADAPTER PATTERN
🎯 Purpose
"To convert a class's interface into another interface that clients expect. Allows classes with incompatible interfaces to work together."
📊 When to Use

✅ Integrate third-party libraries with incompatible interfaces
✅ Work with legacy code
✅ Make existing classes work without modifying their source code
✅ Create an abstraction layer over external systems

⚠️ When NOT to Use

❌ If you can modify the original class
❌ If the interfaces are too different (consider Facade)
❌ Over-engineering for simple cases
 */

// SCENARIO: Your application expects IPaymentProcessor interface,
// but you need to integrate third-party payment libraries with different interfaces

// STEP 1: Target Interface (What your application expects)
// Explanation: This is YOUR application's interface

public class PaymentResult
{
    public bool Success { get; set; }
    public string TransactionId { get; set; }
    public string Message { get; set; }
    public decimal ProcessedAmount { get; set; }
}

// OUTPUT:
/*
=== Using Stripe (via Adapter) ===
[Adapter] Stripe adapter initialized

[PaymentService] Processing order of $99.99
[Adapter] Adapting Stripe validation...
[Stripe] Verifying card token: 4242424242424242
[Adapter] Adapting Stripe API...
[Stripe] Charging $99.99
[Stripe] Card: 4242****
[PaymentService] ✓ Payment successful!
[PaymentService] Transaction ID: ch_abc123xyz789
[PaymentService] Amount: $99.99

[PaymentService] Processing refund of $50.00
[Adapter] Adapting Stripe refund...
[Stripe] Creating refund for ch_123
[PaymentService] ✓ Refund successful!
[PaymentService] Refund ID: re_def456uvw

==================================================

=== Using PayPal (via Adapter) ===
[Adapter] PayPal adapter initialized

[PaymentService] Processing order of $149.99
[Adapter] Adapting PayPal validation...
[PayPal] Validating payment for merchant@example.com
[Adapter] Adapting PayPal API...
[PayPal] Processing payment of $149.99
[PayPal] Payer: merchant@example.com
[PaymentService] ✓ Payment successful!
[PaymentService] Transaction ID: PAYPAL-abc123xyz789
[PaymentService] Amount: $149.99

[PaymentService] Processing refund of $75.00
[Adapter] Adapting PayPal refund...
[PayPal] Issuing refund of $75.00
[PaymentService] ✓ Refund successful!
[PaymentService] Refund ID: REFUND-ghi789rst
*/