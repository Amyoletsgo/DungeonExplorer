using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        /// <summary>
        /// Main game program
        /// Creates an instance of the game class and test class
        /// Calls the test function which runs the game in a try catch loop 
        /// Allows any errors in the game to be caught
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Game game = new Game(); //calls an object of the game class (where the main program is)
            Testing test = new Testing(); // calls the test function
            test.test(game); //tests the game file
            Console.WriteLine("\nPress any key to exit..."); 
            Console.ReadKey(); // reads key before it closes the program 
        }
    }
}
