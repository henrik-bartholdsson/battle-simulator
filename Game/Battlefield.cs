using Game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Battlefield
    {
        readonly GameEngine gameEngone = new GameEngine();
        List<GameEntity> combatants = new List<GameEntity>();
        readonly Random random = new Random();

        string winner;

        public Battlefield()
        {
        }

        public string Battle()
        {
            int randomIndexOfDefender;
            GameEntity defender;

            if (winner != null)
                return winner;


            foreach (var attacker in combatants)
            {
                randomIndexOfDefender = random.Next(0, combatants.Count);
                defender = combatants.ElementAt(randomIndexOfDefender);
                if (!attacker.Dead)
                {
                    while (attacker.Name == defender.Name || defender.Dead)
                    {
                        if (randomIndexOfDefender + 1 >= combatants.Count)
                            randomIndexOfDefender = 0;
                        else
                            randomIndexOfDefender++;

                        defender = combatants.ElementAt(randomIndexOfDefender);

                        winner = HasWinner(combatants);
                        if (winner != null)
                            return winner;
                    }
                    Console.WriteLine($"{attacker.Name} attacks {defender.Name} by {gameEngone.Attack(attacker, defender)} damage");
                }
            }

            return null;
        }

        public string HasWinner(List<GameEntity> l)
        {
            GameEntity returningWinner = combatants.ElementAt(0);

            foreach (var combatantA in l)
            {
                if(!combatantA.Dead)
                returningWinner = combatantA;

                foreach (var combatantB in l)
                {
                    if (!combatantA.Dead && !combatantB.Dead)
                        if (!combatantA.Name.Equals(combatantB.Name))
                            return null;
                }
            }

            return returningWinner.Name;
        }

        public void AddPlayer(GameEntity player)
        {
            combatants.Add(player);
            combatants = ShuffleTheBattlefield(combatants);
            Console.Clear();
            Console.WriteLine("---- Line-up ----");
            foreach (var com in combatants)
                Console.WriteLine(com.Name);
        }

        public void RemovePlayer(GameEntity player)
        {
            combatants.Remove(player);
        }

        public List<GameEntity> ShuffleTheBattlefield(List<GameEntity> combatants)
        {
            var tempCombatants = new List<GameEntity>();
            int tempIndex;

            while (combatants.Count > 0)
            {
                tempIndex = random.Next(0, combatants.Count);
                tempCombatants.Add(combatants.ElementAt(tempIndex));
                combatants.RemoveAt(tempIndex);
            }
            return tempCombatants;
        }

        public void ListAll()
        {
            foreach (var entity in combatants)
            {
                Console.Write($"{entity.Name} ");
                if (entity.Dead)
                    Console.WriteLine("┼");
                else
                    Console.WriteLine(entity.Health);
            }
        }

    }
}
