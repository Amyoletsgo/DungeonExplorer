using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(); //calls an object of the game class (where the main program is)
            game.Start(); //starts the game using start method
            Console.WriteLine("Press any key to exit..."); 
            Console.ReadKey(); // reads key before it closes the program 
        }
    }
}
