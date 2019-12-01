using Game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class GameEngine
    {
        Random random = new Random();
        public GameEngine()
        {

        }

        public int Attack(GameEntity attacker, GameEntity defender)
        {
            var damage = (double)random.Next(attacker.Damage / 10, attacker.Damage);

            if (attacker.StrongAgainst(defender))
                damage *= 1.2;

            if (defender.WeakAgainst(attacker))
                damage *= 1.2;

            defender.Health -= (int)damage;

            return (int)damage;
        }
    }
}
