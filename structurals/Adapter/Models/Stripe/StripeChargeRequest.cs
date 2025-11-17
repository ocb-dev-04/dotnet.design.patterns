public class StripeChargeRequest
{
    public int AmountInCents { get; set; }
    public string Currency { get; set; }
    public string Source { get; set; } // Card token
}
