// STEP 3: Adapters (Make third-party libraries compatible)
// Adapter for PayPal
public class PayPalPaymentAdapter : IPaymentProcessor
{
    private readonly PayPalPaymentGateway _paypalGateway;
    private readonly string _merchantEmail;

    public PayPalPaymentAdapter(PayPalPaymentGateway paypalGateway, string merchantEmail)
    {
        _paypalGateway = paypalGateway;
        _merchantEmail = merchantEmail;
        Console.WriteLine("[Adapter] PayPal adapter initialized");
    }

    public PaymentResult ProcessPayment(decimal amount, string cardNumber, string cvv)
    {
        Console.WriteLine("[Adapter] Adapting PayPal API...");

        // Step 1: Convert to PayPal format
        var details = new PayPalPaymentDetails
        {
            PayerEmail = _merchantEmail,
            Total = (double)amount,
            CardToken = cardNumber
        };

        // Step 2: Call PayPal API
        var transaction = _paypalGateway.ExecutePayment(details);

        // Step 3: Convert to our format
        return new PaymentResult
        {
            Success = transaction.State == "approved",
            TransactionId = transaction.TransactionId,
            Message = $"PayPal: {transaction.State}",
            ProcessedAmount = (decimal)transaction.Amount
        };
    }

    public bool ValidateCard(string cardNumber)
    {
        Console.WriteLine("[Adapter] Adapting PayPal validation...");
        var result = _paypalGateway.ValidatePayment(_merchantEmail, cardNumber);
        return result.IsValid;
    }

    public async Task<RefundResult> RefundPayment(string transactionId, decimal amount)
    {
        Console.WriteLine("[Adapter] Adapting PayPal refund...");

        var response = _paypalGateway.IssueRefund(transactionId, (double)amount);

        return new RefundResult
        {
            Success = response.Success,
            RefundId = response.RefundTransactionId
        };
    }
}
