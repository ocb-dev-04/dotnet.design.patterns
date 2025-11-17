using Prototype.Abstractions;

namespace Prototype.GameObjectSpawning.Implementaions;

public class GameObjectStats : IPrototype<GameObjectStats>
{
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public float Speed { get; set; }

    public GameObjectStats Clone()
    {
        return new GameObjectStats
        {
            Health = this.Health,
            MaxHealth = this.MaxHealth,
            Attack = this.Attack,
            Defense = this.Defense,
            Speed = this.Speed
        };
    }

    public GameObjectStats DeepClone() => Clone();
}