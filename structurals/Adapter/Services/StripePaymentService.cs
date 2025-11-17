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


// STEP 2: Adaptees (Third-party classes with incompatible interfaces)
// Explanation: These are external libraries you cannot modify




// Third-party Library 1: Stripe
public class StripePaymentService
{
    // Different method names and parameters
    public StripeResponse Charge(StripeChargeRequest request)
    {
        Console.WriteLine($"[Stripe] Charging ${request.AmountInCents / 100.0}");
        Console.WriteLine($"[Stripe] Card: {request.Source.Substring(0, 4)}****");

        // Simulate Stripe API call
        return new StripeResponse
        {
            Id = $"ch_{Guid.NewGuid():N}",
            Status = "succeeded",
            AmountCharged = request.AmountInCents
        };
    }

    public bool VerifyCard(string token)
    {
        Console.WriteLine($"[Stripe] Verifying card token: {token}");
        return token.Length >= 16;
    }

    public StripeRefund CreateRefund(string chargeId, int amountInCents)
    {
        Console.WriteLine($"[Stripe] Creating refund for {chargeId}");
        return new StripeRefund
        {
            Id = $"re_{Guid.NewGuid():N}",
            Status = "succeeded"
        };
    }
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