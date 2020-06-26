using GoL.Game;
using System;
using System.Threading.Tasks;

namespace GoL.Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            uint width = 14;
            uint height = 9;

            var gameManager = new GameManager(width, height);

            for (var iter = 0; iter < 30; iter++)
            {            
                var field = gameManager.PrintGeneration();
                Console.Clear();

                for (var j = 0; j < height; j++)
                {
                    for (var i = 0; i < width; i++)
                    {
                        Console.Write(field[j * (int)width + i]);
                    }

                    Console.WriteLine();
                }
            }

            Console.WriteLine("All done");
            Console.ReadKey();
        }
    }
}