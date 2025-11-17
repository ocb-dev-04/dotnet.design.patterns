/*
PROTOTYPE PATTERN
🎯Purpose
"Create new objects by cloning existing objects instead of creating from scratch"
📊 When to Use

✅ Object creation is expensive (database queries, complex initialization)
✅ Need to create many similar objects
✅ Avoid repetitive initialization code
✅ Object configuration is complex

⚠️ When NOT to Use

❌ Simple objects (just use 'new')
❌ When objects have circular references (deep copy issues)
❌ When cloning logic is complex
 */

using Prototype.DocumentTemplates;
using Prototype.GameObjectSpawning;

DocumentEntry.Run();
GameEntry.SpawnObjects();