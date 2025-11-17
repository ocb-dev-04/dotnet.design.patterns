/*
FACTORY METHOD PATTERN
🎯Purpose
"Defines an interface for creating objects, but allows subclasses to decide which class to instantiate"
📊 When to Use

✅ When you don't know exact types beforehand
✅ When creation logic is complex
✅ When you want to delegate instantiation to subclasses
✅ When you need to support different product families

⚠️ When NOT to Use

❌ If creation is simple (just use 'new')
❌ If you only have one concrete class
❌ Over-engineering for simple scenarios
 */

using Factory.Services;

NotificationService service = new ();

await service.SendNotification("email", "user@example.com", "Welcome!");
Console.WriteLine();

await service.SendNotification("sms", "1234567890", "Your code: 123456");
Console.WriteLine();

await service.SendNotification("push", "device-token-123", "New message");

// OUTPUT:
/*
Using channel: Email
[Email] Sending to: user@example.com
[Email] Message: Welcome!
[Email] ✓ Sent successfully

Using channel: SMS
[SMS] Sending to: 1234567890
[SMS] Message: Your code: 123456
[SMS] ✓ Sent successfully

Using channel: Push
[Push] Sending to device: device-token-123
[Push] Message: New message
[Push] ✓ Sent successfully
*/