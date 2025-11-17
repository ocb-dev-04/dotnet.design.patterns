/*
SINGLETON PATTERN
🎯Purpose
"Ensure that a class has ONE INSTANCE and provide a global access point to it"
📊 When to Use

✅ Configuration managers
✅Logging services
✅ Database connections (pool)
✅ Cache managers
✅ Thread pools

⚠️ When NOT to Use

❌ When you need multiple instances later
❌ When it makes unit testing difficult
❌ If it creates hidden dependencies
❌ Multi-threaded scenarios without proper locking
 */


// Step 1: Get instance (created on first access)
using Singleton;

var logger1 = Logger.Instance;
logger1.Log("Application started");

// Step 2: Get instance again (same instance returned)
var logger2 = Logger.Instance;
logger2.Log("Doing some work");

// Step 3: Verify both are same instance
Console.WriteLine($"Are same instance: {ReferenceEquals(logger1, logger2)}"); // True

// Cannot create new instance
// var logger3 = new Logger(); // Compiler error - constructor is private

// OUTPUT:
/*
[Singleton] Logger instance created
[2024-01-15 10:30:45] Application started
[2024-01-15 10:30:45] Doing some work
Are same instance: True
*/