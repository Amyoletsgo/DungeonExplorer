using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DungeonExplorer
{
    /// <summary>
    /// class which contains the inventories for the player
    /// intended to allow the player to view their weapons, defences and other items
    /// </summary>
    public class Inventory
    {   
        public List<Item> inventory = new List<Item>();
        public List<Item> weapons = new List<Item>();
        public List<Item> defense = new List<Item>();
        public List<Item> chestAndKey = new List<Item>();

        /// <summary>
        /// method which returns all of the items in the inventory and their stats
        /// if the inventory is empty the player is informed
        /// </summary>
        public void check()
        {
            // checks that the inventory is not empty
            if (inventory.Count == 0)
            {
                Console.WriteLine("\nInventory is empty");
            }
            else
            {
                Console.WriteLine("\nInventory contains:");
                foreach (Item i in inventory)
                {
                    //separates objects (no necessary stats) and weapons/defences
                    if (i.type == "object")
                    {
                        Console.WriteLine($"{i.name}");
                    }
                    else
                    {
                        Console.WriteLine($"{i.name}, {i.type} power {i.stat}");
                    }
                }    

            }

        }

        /// <summary>
        /// linq query to filter items that are weapons into a separate list
        /// </summary>
        /// <param name="inventory"></param>
        public void GetWeapons(List<Item> inventory)
        {
            //fluent syntax for linq using lambda (=>)
            weapons =
                (inventory.Where(item => item.type == "weapon").ToList());
        }

        /// <summary>
        /// linq query to filter items that are defenses into a separate list
        /// </summary>
        /// <param name="inventory"></param>
        public void GetDefense(List<Item> inventory)
        {
            defense =
                (inventory.Where(item => item.type == "defense").ToList());
        }

        public void unlock(List<Item> inventory)
        {
            chestAndKey =
                (inventory.Where(item => item.name == "key" || item.name == "chest").ToList());
        }

        /// <summary>
        /// Method to add an item that is not already in the inventory when it is picked up
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Item item)
        {
            if (item.name == "potion")
            {
                item = new Item("empty potion bottle");
            }
            if (inventory.Contains(item))
            {
                Console.WriteLine($"You already have {item.name} in your inventory");
            }
            else
            {
                Console.WriteLine($"Added {item.name} to your inventory");
                inventory.Add(item);
            }
            GetWeapons(inventory);
            GetDefense(inventory);
            unlock(inventory);
        }
    }
}