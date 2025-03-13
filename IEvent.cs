using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// interface intended to be used for monster and item
    /// creates the type of event where something spawns in and it's details
    /// </summary>
    interface IEvent
    {
        string EventType();

        int GetStats();

    }
}
