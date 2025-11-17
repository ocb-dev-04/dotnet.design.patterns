namespace Abstract.Factory.Abstractions;

// STEP 1: Abstract Products
// Explanation: Interfaces for each product type in the family
public interface ICheckBox
{
    void Render();
    void Toggle();
}