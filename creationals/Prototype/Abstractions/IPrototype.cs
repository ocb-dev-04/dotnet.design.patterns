namespace Prototype.Abstractions;

// STEP 1: Prototype Interface
// Explanation: Declares cloning method
public interface IPrototype<T>
{
    T Clone();
    T DeepClone();
}