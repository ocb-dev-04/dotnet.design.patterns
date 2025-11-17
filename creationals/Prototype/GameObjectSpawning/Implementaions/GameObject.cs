using Prototype.Abstractions;
using Prototype.GameObjectSpawning.Models;

namespace Prototype.GameObjectSpawning.Implementaions;

// STEP 1: Game Object Prototype
public class GameObject : IPrototype<GameObject>
{
    public string Name { get; set; }
    public Vector3 Position { get; set; }
    public Vector3 Scale { get; set; }
    public GameObjectStats Stats { get; set; }
    public List<string> Tags { get; set; }
    public string PrefabId { get; set; }

    public GameObject()
    {
        Position = new Vector3(0, 0, 0);
        Scale = new Vector3(1, 1, 1);
        Stats = new GameObjectStats();
        Tags = new List<string>();
    }

    public GameObject Clone()
    {
        return (GameObject)this.MemberwiseClone();
    }

    public GameObject DeepClone()
    {
        return new GameObject
        {
            Name = this.Name,
            Position = new Vector3(this.Position.X, this.Position.Y, this.Position.Z),
            Scale = new Vector3(this.Scale.X, this.Scale.Y, this.Scale.Z),
            Stats = this.Stats.Clone(),
            Tags = new List<string>(this.Tags),
            PrefabId = this.PrefabId
        };
    }

    public override string ToString()
    {
        return $"[{PrefabId}] {Name} at ({Position.X}, {Position.Y}, {Position.Z}) - HP: {Stats.Health}/{Stats.MaxHealth}";
    }
}
