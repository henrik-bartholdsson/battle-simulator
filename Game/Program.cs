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
            var game = new GameEngine();
            var bf = new Battlefield();
            


            
            bf.AddPlayer(new Human());
            bf.AddPlayer(new Human());
            bf.AddPlayer(new Human());
            bf.AddPlayer(new Human());
            bf.AddPlayer(new Monster());
            bf.AddPlayer(new Monster());
            bf.AddPlayer(new Monster());
            bf.AddPlayer(new Dragon());
            bf.AddPlayer(new Human());
            bf.AddPlayer(new Human());
            bf.AddPlayer(new Human());
            bf.AddPlayer(new Human());
            bf.AddPlayer(new Monster());
            bf.AddPlayer(new Monster());
            bf.AddPlayer(new Monster());

            var result = bf.Battle();

            while(result == null)
            {
                result = bf.Battle();

                    if(result !=  null)
                    Console.WriteLine("Winner is " + result);
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
    }
}
