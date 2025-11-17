namespace Abstract.Factory.Abstractions;

// STEP 1: Abstract Products
// Explanation: Interfaces for each product type in the family
public interface ITextBox
{
    void Render();
    void SetText(string text);
}
