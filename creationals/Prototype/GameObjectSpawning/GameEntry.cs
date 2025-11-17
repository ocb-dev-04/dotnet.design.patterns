using Prototype.GameObjectSpawning.Implementaions;
using Prototype.GameObjectSpawning.Models;
using Prototype.GameObjectSpawning.Registry;

namespace Prototype.GameObjectSpawning;

public sealed class GameEntry
{
    public static void SpawnObjects()
    {
        PrefabManager prefabManager = new ();

        Console.WriteLine("\n=== Spawning Player Characters ===\n");

        GameObject warrior = prefabManager.Instantiate("warrior", new Vector3(0, 0, 0));
        GameObject mage = prefabManager.Instantiate("mage", new Vector3(2, 0, 0));

        Console.WriteLine(warrior);
        Console.WriteLine(mage);

        Console.WriteLine("\n=== Spawning Enemy Wave ===\n");

        List<GameObject> goblins = prefabManager.SpawnWave("goblin", 5, 3.0f);

        Console.WriteLine($"\nSpawned {goblins.Count} goblins:");
        foreach (var goblin in goblins)
        {
            Console.WriteLine($"  {goblin}");
        }

        Console.WriteLine("\n=== Spawning Boss ===\n");

        GameObject dragon = prefabManager.Instantiate("dragon", new Vector3(50, 0, 50));
        Console.WriteLine(dragon);

        // Modify one goblin - doesn't affect others
        Console.WriteLine("\n=== Damaging One Goblin ===\n");

        goblins[0].Stats.Health -= 20;

        Console.WriteLine("Goblin states after damage:");
        foreach (var goblin in goblins)
        {
            Console.WriteLine($"  {goblin}");
        }
    }
}

// OUTPUT:
/*
[PrefabManager] Loaded 4 prefabs

=== Spawning Player Characters ===

[PrefabManager] Instantiated warrior at (0, 0, 0)
[PrefabManager] Instantiated mage at (2, 0, 0)
[warrior] Warrior at (0, 0, 0) - HP: 150/150
[mage] Mage at (2, 0, 0) - HP: 80/80

=== Spawning Enemy Wave ===

[PrefabManager] Instantiated goblin at (0, 0, 0)
[PrefabManager] Instantiated goblin at (3, 0, 0)
[PrefabManager] Instantiated goblin at (6, 0, 0)
[PrefabManager] Instantiated goblin at (9, 0, 0)
[PrefabManager] Instantiated goblin at (12, 0, 0)

Spawned 5 goblins:
  [goblin] Goblin at (0, 0, 0) - HP: 50/50
  [goblin] Goblin at (3, 0, 0) - HP: 50/50
  [goblin] Goblin at (6, 0, 0) - HP: 50/50
  [goblin] Goblin at (9, 0, 0) - HP: 50/50
  [goblin] Goblin at (12, 0, 0) - HP: 50/50

=== Spawning Boss ===

[PrefabManager] Instantiated dragon at (50, 0, 50)
[dragon] Dragon at (50, 0, 50) - HP: 500/500

=== Damaging One Goblin ===

Goblin states after damage:
  [goblin] Goblin at (0, 0, 0) - HP: 30/50
  [goblin] Goblin at (3, 0, 0) - HP: 50/50
  [goblin] Goblin at (6, 0, 0) - HP: 50/50
  [goblin] Goblin at (9, 0, 0) - HP: 50/50
  [goblin] Goblin at (12, 0, 0) - HP: 50/50
*/