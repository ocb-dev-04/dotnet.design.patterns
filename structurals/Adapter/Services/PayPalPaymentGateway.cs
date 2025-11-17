// STEP 2: Adaptees (Third-party classes with incompatible interfaces)
// Explanation: These are external libraries you cannot modify

// Third-party Library 2: PayPal
public class PayPalPaymentGateway
{
    // Completely different interface
    public PayPalTransaction ExecutePayment(PayPalPaymentDetails details)
    {
        Console.WriteLine($"[PayPal] Processing payment of ${details.Total}");
        Console.WriteLine($"[PayPal] Payer: {details.PayerEmail}");

        return new PayPalTransaction
        {
            TransactionId = $"PAYPAL-{Guid.NewGuid():N}",
            State = "approved",
            Amount = details.Total
        };
    }

    public PayPalValidationResult ValidatePayment(string email, string cardInfo)
    {
        Console.WriteLine($"[PayPal] Validating payment for {email}");
        return new PayPalValidationResult { IsValid = true };
    }

    public PayPalRefundResponse IssueRefund(string txnId, double refundAmount)
    {
        Console.WriteLine($"[PayPal] Issuing refund of ${refundAmount}");
        return new PayPalRefundResponse
        {
            RefundTransactionId = $"REFUND-{Guid.NewGuid():N}",
            Success = true
        };
    }
}
