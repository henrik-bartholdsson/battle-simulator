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
            Dictionary<string, int> asdf = new Dictionary<string, int>();
            var game = new GameEngine();
            var bf = new Battlefield();
            string selectedCreature = null;
            string result = null;
            bool startGame = false;

            asdf.Add("human", 0);
            asdf.Add("monster", 0);
            asdf.Add("dragon", 0);
            asdf.Add("slime", 0);

            Console.WriteLine(" Battle configurator");
            Console.WriteLine(" --------------------");
            Console.WriteLine(" H for human");
            Console.WriteLine(" M for monster");
            Console.WriteLine(" D for dragon");
            Console.WriteLine(" S for slime (5x)");
            Console.WriteLine();
            Console.WriteLine(" Select creature and +/- to change the numbers.");
            Console.WriteLine(" Human: 0x - Mobster 0x - Slime 0x - Dragon 0x");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press enter to start the battle!");
            Console.SetCursorPosition(0, 17);


            while (!startGame)
            {
                var key = Console.ReadKey().Key;
                Console.SetCursorPosition(0, 17);
                Console.WriteLine("                                                                    ");
                Console.SetCursorPosition(0, 17);
                switch (key)
                {
                    case ConsoleKey.H:
                        SelectMenuItem(key);
                        selectedCreature = "human";
                        break;
                    case ConsoleKey.M:
                        SelectMenuItem(key);
                        selectedCreature = "monster";
                        break;
                    case ConsoleKey.D:
                        SelectMenuItem(key);
                        selectedCreature = "dragon";
                        break;
                    case ConsoleKey.S:
                        SelectMenuItem(key);
                        selectedCreature = "slime";
                        break;
                    case ConsoleKey.Add:
                        if (selectedCreature != null)
                            asdf[selectedCreature] += ChangeAmount(asdf[selectedCreature], key);
                        break;
                    case ConsoleKey.Subtract:
                        if (selectedCreature != null)
                            asdf[selectedCreature] -= ChangeAmount(asdf[selectedCreature], key);
                        break;
                    case ConsoleKey.Enter:
                        startGame = StartGame(asdf["human"], asdf["monster"], asdf["slime"], asdf["dragon"]);
                        break;

                }
                Console.SetCursorPosition(0, 8);
                Console.WriteLine($" Human: {asdf["human"]}x - Monster {asdf["monster"]}x - Slime {asdf["slime"]}x - Dragon {asdf["dragon"]}x...");

                Console.SetCursorPosition(0, 17);
            }

            for (int i = 0; i < asdf["human"]; i++)
                bf.AddPlayer(new Human());

            for (int i = 0; i < asdf["monster"]; i++)
                bf.AddPlayer(new Monster());

            for (int i = 0; i < asdf["slime"]; i++)
                bf.AddPlayer(new Slime());

            for (int i = 0; i < asdf["dragon"]; i++)
                bf.AddPlayer(new Dragon());



            Console.WriteLine("   ------- Battle log -------");
            while (result == null)
            {
                result = bf.Battle();

                if (result != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Winner is " + result);
                }
                else
                    Console.WriteLine();
            }
            Console.WriteLine("-----------------------");
            bf.ListAll();

            //game.Battle(human, monster);

            //Console.WriteLine(human.Dead);

            //var counter = 0;

            //while (!dragon.Dead)
            //{
            //    if (slime.Dead)
            //    {
            //        counter++;
            //        slime = new Slime();
            //    }

            //    game.Battle(slime, dragon);
            //}

            //Console.WriteLine($"Slime death counter: {counter}");

            Console.Read();
        }

        static public bool StartGame(int a, int b, int c, int d)
        {
            int e = a + b + c + d;

            if (e > a && e > b && e > c && e > d)
                return true;

            Console.WriteLine("Minimum requirement: one creature from atleast two types.");
            return false;
        }

        static public int ChangeAmount(int amount, ConsoleKey key)
        {
                if (amount <= 0 && key == ConsoleKey.Subtract)
                    return 0;

            return 1;
        }

        static public void SelectMenuItem(ConsoleKey key)
        {
            Console.SetCursorPosition(0, 2);
            Console.Write(" ");
            if (key == ConsoleKey.H)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("H for human");
            Console.ResetColor();
            Console.Write(" ");
            if (key == ConsoleKey.M)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("M for monster");
            Console.ResetColor();
            Console.Write(" ");
            if (key == ConsoleKey.D)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("D for dragon");
            Console.ResetColor();
            Console.Write(" ");
            if (key == ConsoleKey.S)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("S for slime (5x)");
            Console.ResetColor();

        }
    }
}
