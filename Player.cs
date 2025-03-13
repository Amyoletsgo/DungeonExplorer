using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        private string playerName = "player"; // sets a default player name
        private int playerHealth; //sets up integer value for health
        private List<string> playerInventory = new List<string>(); //sets inventory as list of strings.

        public Player(string playerName, int playerHealth, List<string> playerInventory) 
        {
            //takes the inputs from when the class is called to set up the variables for the class
            Name =  playerName;
            Health = playerHealth;
            Inventory = playerInventory;
        }

        public string Name
        {
            //gets and sets player name
            //sets as "player" if the value is empty
            get { return playerName; }
            set { playerName = string.IsNullOrWhiteSpace(value) ? "player" : value; }
        }

        public int Health
        {
            //get and set for health
            get { return playerHealth; }
            set { playerHealth = value; }
        }

        public List<string> Inventory
        {
            // gets and sets an inventory
            // returns a new list if the value is not there
            get { return playerInventory; }
            set { playerInventory = value ?? new List<string>(); }
        }
        

        //method for setting the player name
        public void setPlayerName()
        {
            string playerNameInput; // empty string to start
            do
            {
                //asks user to input a name
                Console.WriteLine("What name do you wish to play under: ");
                playerNameInput = Console.ReadLine();
            }
            //loops again if the input is null or empty
            while (string.IsNullOrEmpty(playerNameInput));

            //sets the player as their username
            Name = playerNameInput;
            Console.WriteLine($"Hello, {Name}! You are starting with {Health} health points");

            //message displaying inventory (or that it is empty)
            if (playerInventory.Count == 0)
            {
                Console.WriteLine($"Your inventory contains is empty");
            }
            else
            {
                Console.WriteLine($"Your inventory contains: {InventoryContents()}");
            }
        }

        //method to give the option to pick up an item and add it to the inventory.
        public void PickUpItem(string roomItem)
        {
            string pickUpItem;
            do
            {
                Console.WriteLine($"There is {roomItem} in this room. Do you wish to pick it up? (Y/N): ");
                pickUpItem = Console.ReadLine().ToUpper();
            }
            while (pickUpItem != "Y" && pickUpItem != "N");

            if (pickUpItem == "Y")
            {
                //adds item to inventory
                playerInventory.Add(roomItem);
                //tells user what they have picked up and their current stats.
                Console.WriteLine($"Item {roomItem} picked up!");
                Console.WriteLine($"{Name}, your inventory contains: {InventoryContents()}, and your hp is {Health}");
            }
            else if (pickUpItem == "N")
            {
                Console.WriteLine($"{roomItem} not picked up");
                //message displaying inventory (or that it is empty)
                if (playerInventory.Count == 0)
                {
                    Console.WriteLine($"{Name}, your inventory contains is empty and your hp is {Health}");
                }
                else
                {
                    Console.WriteLine($"{Name}, your inventory contains: {InventoryContents()}, and your hp is {Health}");
                }
            }
        }

        // turns the list of inventory into a string 
        public string InventoryContents()
        {
            return string.Join(", ", Inventory);
        }
    }
}