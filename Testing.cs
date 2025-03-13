using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// class for running the game making sure nothing crashes
    /// </summary>
    class Testing
    {
        public void test(Game game)
        {
            try
            {
                game.Start();
            }
            catch(Exception exception)
            {
                Console.WriteLine("Something went wrong");
                Console.WriteLine($"There was {exception} exception.");
            }
        }
    }
}
