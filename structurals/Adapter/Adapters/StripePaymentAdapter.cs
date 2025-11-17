// STEP 3: Adapters (Make third-party libraries compatible)
// Adapter for Stripe
public class StripePaymentAdapter : IPaymentProcessor
{
    private readonly StripePaymentService _stripeService;

    public StripePaymentAdapter(StripePaymentService stripeService)
    {
        _stripeService = stripeService;
        Console.WriteLine("[Adapter] Stripe adapter initialized");
    }

    // Adapt Stripe's interface to our IPaymentProcessor interface
    public PaymentResult ProcessPayment(decimal amount, string cardNumber, string cvv)
    {
        Console.WriteLine("[Adapter] Adapting Stripe API...");

        // Step 1: Convert our parameters to Stripe's format
        var request = new StripeChargeRequest
        {
            AmountInCents = (int)(amount * 100), // Stripe uses cents
            Currency = "usd",
            Source = cardNumber // In real app, this would be tokenized
        };

        // Step 2: Call Stripe's API
        var stripeResponse = _stripeService.Charge(request);

        // Step 3: Convert Stripe's response to our format
        return new PaymentResult
        {
            Success = stripeResponse.Status == "succeeded",
            TransactionId = stripeResponse.Id,
            Message = $"Stripe: {stripeResponse.Status}",
            ProcessedAmount = stripeResponse.AmountCharged / 100m
        };
    }

    public bool ValidateCard(string cardNumber)
    {
        Console.WriteLine("[Adapter] Adapting Stripe validation...");
        return _stripeService.VerifyCard(cardNumber);
    }

    public async Task<RefundResult> RefundPayment(string transactionId, decimal amount)
    {
        Console.WriteLine("[Adapter] Adapting Stripe refund...");

        // Convert to Stripe format
        var refund = _stripeService.CreateRefund(transactionId, (int)(amount * 100));

        // Convert back to our format
        return new RefundResult
        {
            Success = refund.Status == "succeeded",
            RefundId = refund.Id
        };
    }
}
