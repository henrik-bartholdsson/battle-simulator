using Game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameEngine
    {
        readonly Random random = new Random();
        public GameEngine()
        {

        }

        public void Battle(GameEntity a, GameEntity b)
        {
            (GameEntity, GameEntity) order;
            int damageDone;

            do
            {
                order = RollForInitiative(a, b);

                damageDone = Attack(order.Item1, order.Item2);
                Console.WriteLine($"{order.Item1.Name} attacks {order.Item2.Name} with {damageDone} damage.");

                if (order.Item2.Dead)
                {
                    Console.WriteLine($"{order.Item2.Name} is dead.");
                    break;
                }

                damageDone = Attack(order.Item2, order.Item1);
                Console.WriteLine($"{order.Item2.Name} attacks {order.Item1.Name} with {damageDone} damage.");

                if (order.Item1.Dead)
                {
                    Console.WriteLine($"{order.Item1.Name} is dead.");
                    break;
                }

            } while (true);
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

        public (GameEntity First, GameEntity Second) RollForInitiative(GameEntity a, GameEntity b)
        {
            int entityRollValueA = 0;
            int entityRollValueB = 0;

            while (entityRollValueA == entityRollValueB)
            {
                entityRollValueA = random.Next(0, a.Agility);
                entityRollValueB = random.Next(0, b.Agility);
            }

            if (entityRollValueA > entityRollValueB)
                return (a,b);
            else
                return (b,a);
        }
    }
}
