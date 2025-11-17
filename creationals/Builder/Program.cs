/*
BUILDER PATTERN
🎯 Purpose
"To separate the construction of a complex object from its representation, allowing the creation of different representations using the same construction process"
📊 When to Use

✅ Many optional parameters (telescoping constructors)
✅ Complex object initialization
✅ Step-by-step construction
✅ Different representations of the same object

⚠️ When NOT to Use

❌ Simple objects with few parameters
❌ When immutability isn't needed
 */

using Builder.ApiClient;
using Builder.EmailSender;

ApiClient.MakeRequests();
EmailEntry.SendEmails();