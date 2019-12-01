using Game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var game = new GameEngine();
            var human = new Human();
            var monster = new Monster();
            int attackerA = 0;
            int attackerB = 0;

            while (attackerA == attackerB)
            {
                attackerA = random.Next(0, human.Agility);
                attackerB = random.Next(0, monster.Agility);
            }

            if(attackerA > attackerB)
            {
                Console.WriteLine("Human attacks Monster!");

                var damage = game.Attack(human, monster);

                Console.WriteLine($"{damage} points of damage, Monster has {monster.Health} health left!");
            }

            if (attackerB > attackerA)
            {
                Console.WriteLine("Monster attacks Human!");

                var damage = game.Attack(monster, human);

                Console.WriteLine($"{damage} points of damage, Human has {human.Health} health left!");
            }



            Console.Read();
        }
    }
}
