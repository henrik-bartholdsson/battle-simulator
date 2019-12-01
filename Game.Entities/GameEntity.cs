using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Entities
{
    abstract public class GameEntity
    {
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Agility { get; set; }
        abstract public string Name { get; }
        public bool Dead => Health <= 0;

        public GameEntity(int health, int damage, int agility)
        {
            Health = health;
            Damage = damage;
            Agility = agility;
        }

        public abstract bool WeakAgainst(GameEntity entity);
        public abstract bool StrongAgainst(GameEntity entity);

    }
}
