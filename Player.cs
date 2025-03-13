using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// subclass of the creature class
    /// inherits attack, take damage and die
    /// is the player class and takes input for the players name
    /// stores all player stats including inventory, defense, damage etc
    /// </summary>
    public class Player: Creature
    {
        /// <summary>
        /// player stats set up
        /// </summary>
        private string playerName = "player"; // sets a default player name
        private int playerHealth; //sets up integer value for health
        public Inventory playerinventory = new Inventory(); //sets inventory as object "inventory".
        public int playerDamage = 5; //starting integer value for damage
        public int playerDefense = 0; //starting integer value for defense
        public int roomsVisited = 0; //starting integer value for the number of rooms the player visits

        /// <summary>
        /// creates instance of player
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="playerHealth"></param>
        public Player(string playerName, int playerHealth)
        {
            //takes the inputs from when the class is called to set up the variables for the class
            Name =  playerName;
            Health = playerHealth;
        }

        /// <summary>
        /// takes an input and if it is empty makes player name "player"
        /// </summary>
        public string Name
        {
            //gets and sets player name
            //sets as "player" if the value is empty
            get { return playerName; }
            set { playerName = string.IsNullOrWhiteSpace(value) ? "player" : value; }
        }

        /// <summary>
        /// gets and sets value for player health based on player instance being created
        /// </summary>
        public int Health
        {
            //get and set for health
            get { return playerHealth; }
            set { playerHealth = value; }
        }

        /// <summary>
        /// method for setting the player name
        /// takes player input
        /// </summary>
        public void setPlayerName()
        {
            string playerNameInput; // empty string to start
            do
            {
                //asks user to input a name
                Console.WriteLine("If you wish to not input a username please press space");
                Console.WriteLine("What name do you wish to play under: ");
                playerNameInput = Console.ReadLine();
            }
            //loops again if the input is null or empty
            while (string.IsNullOrEmpty(playerNameInput));

            //sets the player as their username
            Name = playerNameInput;
            Console.WriteLine($"\nHello, {Name}! You are starting with {Health} health points");

            //message displaying inventory (or that it is empty)
            playerinventory.check();
        }

        /// <summary>
        /// adds one to rooms visited for each room visited
        /// </summary>
        public void VisitRoom()
        {
            roomsVisited += 1;
        }

        /// <summary>
        /// inherited from creature
        /// method which changes player health depending on their defense and the damage done by the enemy
        /// </summary>
        /// <param name="damage"></param>
        public override void TakeDamage(int damage)
        {
            playerHealth -= damage;
            Console.WriteLine($"\nYou took {damage} hp in damage");
            if (playerDefense > 0)
            {
                playerHealth += playerDefense;
                Console.WriteLine($"\nYour defense is {playerDefense}");
                Console.WriteLine($"This meant you only took {damage - playerDefense} hp in damage");
            }
        }

        /// <summary>
        /// inherited from creature
        /// method to show the attack and how much damage the player does
        /// </summary>
        /// <param name="damage"></param>
        public override void Attack(int damage)
        {
            Console.WriteLine("\nYou attack");
            Console.WriteLine($"\nYour damage is {playerDamage}");
        }

        /// <summary>
        /// inherited from creature
        /// method to inform the player of their loss
        /// </summary>
        public override void Die()
        {
            Console.WriteLine("\nYou have died and the game is lost");
        }

        /// <summary>
        /// method to give the option to pick up an item and add it to the inventory.
        /// </summary>
        /// <param name="roomItem"></param>
        public void PickUpItem(Item roomItem)
        {
            //string is to take user input
            string pickUpItem = "query";
            //loops until an answer is given as either "Y" or "N"
            do
            {
                //catches any inputs that cannot be made "to.upper"
                try
                {
                    Console.WriteLine($"There is {roomItem.name} in this room. Do you wish to pick it up? (Y/N): ");
                    pickUpItem = Console.ReadLine().ToUpper();
                }
                catch(FormatException)
                {
                    Console.WriteLine("please only enter Y or N");
                }
            }
            while (pickUpItem != "Y" && pickUpItem != "N");

            if (pickUpItem == "Y")
            {
                playerinventory.AddItem(roomItem);
                playerinventory.check();
                if (roomItem.type == "weapon")
                {
                    //adds to damage done by player when they pick weapons up
                    playerDamage += roomItem.stat;
                    Console.WriteLine("\nYou picked up a weapon");
                    Console.WriteLine($"{roomItem.name} increases your damage by {roomItem.stat} hp");
                }
                if (roomItem.type == "defense")
                {
                    //decreases from damage taken by adding to defense stat
                    playerDamage += roomItem.stat;
                    Console.WriteLine("\nYou picked up a defense");
                    Console.WriteLine($"{roomItem.name} decreases the damage you take by {roomItem.stat} hp");

                }
                if (roomItem.name == "potion")
                {
                    //adds to player health when they pick potions up
                    playerHealth += roomItem.stat;
                    Console.WriteLine("\nYou picked up a potion");
                    Console.WriteLine($"{roomItem.name} increases your health by {roomItem.stat} hp");
                }
                if ((roomItem.name == "key" || roomItem.name == "chest") && playerinventory.chestAndKey.Count == 2 )
                {
                    playerDefense += 5;
                    Console.WriteLine("\nYou have found the chest and key, your defence increases by an extra 5");
                }
            }
            else if (pickUpItem == "N")
            {
                //tells player they did not pick the item up
                Console.WriteLine($"\n{roomItem.name} not picked up");
                playerinventory.check();
            }

        }
    }
}