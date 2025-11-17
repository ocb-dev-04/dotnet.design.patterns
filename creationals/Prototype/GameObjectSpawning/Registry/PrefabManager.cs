using Prototype.GameObjectSpawning.Models;
using Prototype.GameObjectSpawning.Implementaions;

namespace Prototype.GameObjectSpawning.Registry;

// STEP 2: Prefab Manager (Registry)
public class PrefabManager
{
    private readonly Dictionary<string, GameObject> _prefabs;

    public PrefabManager()
    {
        _prefabs = new Dictionary<string, GameObject>();
        LoadPrefabs();
    }

    private void LoadPrefabs()
    {
        // Warrior Prefab
        var warrior = new GameObject
        {
            Name = "Warrior",
            PrefabId = "warrior",
            Scale = new Vector3(1, 1, 1)
        };
        warrior.Stats.MaxHealth = 150;
        warrior.Stats.Health = 150;
        warrior.Stats.Attack = 25;
        warrior.Stats.Defense = 15;
        warrior.Stats.Speed = 5.0f;
        warrior.Tags.Add("Player");
        warrior.Tags.Add("Melee");

        // Mage Prefab
        var mage = new GameObject
        {
            Name = "Mage",
            PrefabId = "mage",
            Scale = new Vector3(0.9f, 0.9f, 0.9f)
        };
        mage.Stats.MaxHealth = 80;
        mage.Stats.Health = 80;
        mage.Stats.Attack = 40;
        mage.Stats.Defense = 5;
        mage.Stats.Speed = 6.0f;
        mage.Tags.Add("Player");
        mage.Tags.Add("Magic");

        // Goblin Prefab
        var goblin = new GameObject
        {
            Name = "Goblin",
            PrefabId = "goblin",
            Scale = new Vector3(0.7f, 0.7f, 0.7f)
        };
        goblin.Stats.MaxHealth = 50;
        goblin.Stats.Health = 50;
        goblin.Stats.Attack = 10;
        goblin.Stats.Defense = 5;
        goblin.Stats.Speed = 7.0f;
        goblin.Tags.Add("Enemy");
        goblin.Tags.Add("Weak");

        // Dragon Prefab
        var dragon = new GameObject
        {
            Name = "Dragon",
            PrefabId = "dragon",
            Scale = new Vector3(3, 3, 3)
        };
        dragon.Stats.MaxHealth = 500;
        dragon.Stats.Health = 500;
        dragon.Stats.Attack = 50;
        dragon.Stats.Defense = 30;
        dragon.Stats.Speed = 8.0f;
        dragon.Tags.Add("Enemy");
        dragon.Tags.Add("Boss");

        _prefabs["warrior"] = warrior;
        _prefabs["mage"] = mage;
        _prefabs["goblin"] = goblin;
        _prefabs["dragon"] = dragon;

        Console.WriteLine($"[PrefabManager] Loaded {_prefabs.Count} prefabs");
    }

    public GameObject Instantiate(string prefabId, Vector3 position)
    {
        if (!_prefabs.TryGetValue(prefabId, out var prefab))
        {
            throw new ArgumentException($"Prefab '{prefabId}' not found");
        }

        // Clone prefab and set position
        var instance = prefab.DeepClone();
        instance.Position = position;

        Console.WriteLine($"[PrefabManager] Instantiated {prefabId} at ({position.X}, {position.Y}, {position.Z})");

        return instance;
    }

    public List<GameObject> SpawnWave(string prefabId, int count, float spacing)
    {
        var objects = new List<GameObject>();

        for (int i = 0; i < count; i++)
        {
            var position = new Vector3(i * spacing, 0, 0);
            objects.Add(Instantiate(prefabId, position));
        }

        return objects;
    }
}