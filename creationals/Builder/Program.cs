/*
BUILDER PATTERN
🎯 Purpose
"Separar la construcción de un objeto complejo de su representación, permitiendo crear diferentes representaciones usando el mismo proceso de construcción"
📊 When to Use

✅ Many optional parameters (telescoping constructors)
✅ Complex object initialization
✅ Step-by-step construction
✅ Different representations of same object

⚠️ When NOT to Use

❌ Simple objects with few parameters
❌ When immutability isn't needed
 */

using Builder.ApiClient;
using Builder.EmailSender;

ApiClient.MakeRequests();
EmailEntry.SendEmails();