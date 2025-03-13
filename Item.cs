using System;
using System.Collections.Generic;
using System.Media;

namespace DungeonExplorer
{
    /// <summary>
    /// Item with the event interface
    /// it is picked up as an event and carries certain stats which benefit the player
    /// </summary>
    public class Item : IEvent
    {
        public string name;
        public string type;
        public int stat;

        /// <summary>
        /// separates the item into different types based on its name, desegnating it statistics.
        /// intended to be random but I did not give myself enough time
        /// </summary>
        /// <param name="itemName"></param>
        public Item(string itemName)
        {
            name = itemName;
            if (name == "key")
            {
                type = "object";
                stat = 1;
            }
            else if (name == "chest")
            {
                type = "object";
                stat = 1;
            }
            else if (name == "sword")
            {
                type = "weapon";
                stat = 10;
            }
            else if (name == "axe")
            {
                type = "weapon";
                stat = 5;
            }
            else if (name == "potion")
            {
                type = "object";
                stat = 10;
            }
            else if (name == "empty potion bottle")
            {
                type = "object";
                stat = 10;
            }
            else if (name == "gold")
            {
                type = "object";
                stat = 1;
            }
            else if (name == "shield")
            {
                type = "defense";
                stat = 5;
            }
            else
            {
                name = "item";
                type = "object";
                stat = 0;
            }
        }

        /// <summary>
        /// returns name
        /// </summary>
        /// <returns></returns>
        public string EventType()
        {
            return name;
        }

        /// <summary>
        /// returns stat
        /// </summary>
        /// <returns></returns>
        public int GetStats()
        {
            return stat;
        }
    }

}