// STEP 4: Client Code (Uses only IPaymentProcessor)
// Explanation: Client doesn't know about Stripe or PayPal specifics
public class PaymentService
{
    private readonly IPaymentProcessor _paymentProcessor;

    public PaymentService(IPaymentProcessor paymentProcessor)
    {
        // Client works with interface, doesn't care about implementation
        _paymentProcessor = paymentProcessor;
    }

    public void ProcessOrder(decimal amount, string cardNumber)
    {
        Console.WriteLine($"\n[PaymentService] Processing order of ${amount}");

        // Step 1: Validate card
        if (!_paymentProcessor.ValidateCard(cardNumber))
        {
            Console.WriteLine("[PaymentService] ❌ Card validation failed");
            return;
        }

        // Step 2: Process payment
        var result = _paymentProcessor.ProcessPayment(amount, cardNumber, "123");

        if (result.Success)
        {
            Console.WriteLine($"[PaymentService] ✓ Payment successful!");
            Console.WriteLine($"[PaymentService] Transaction ID: {result.TransactionId}");
            Console.WriteLine($"[PaymentService] Amount: ${result.ProcessedAmount}");
        }
        else
        {
            Console.WriteLine($"[PaymentService] ❌ Payment failed: {result.Message}");
        }
    }

    public async Task ProcessRefund(string transactionId, decimal amount)
    {
        Console.WriteLine($"\n[PaymentService] Processing refund of ${amount}");

        var result = await _paymentProcessor.RefundPayment(transactionId, amount);

        if (result.Success)
        {
            Console.WriteLine($"[PaymentService] ✓ Refund successful!");
            Console.WriteLine($"[PaymentService] Refund ID: {result.RefundId}");
        }
        else
        {
            Console.WriteLine($"[PaymentService] ❌ Refund failed");
        }
    }
}
