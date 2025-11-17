
// SCENARIO: Your application expects IPaymentProcessor interface,
// but you need to integrate third-party payment libraries with different interfaces

// STEP 1: Target Interface (What your application expects)
// Explanation: This is YOUR application's interface
public interface IPaymentProcessor
{
    PaymentResult ProcessPayment(decimal amount, string cardNumber, string cvv);
    bool ValidateCard(string cardNumber);
    Task<RefundResult> RefundPayment(string transactionId, decimal amount);
}
