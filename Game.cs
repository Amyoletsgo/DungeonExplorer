using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;

namespace DungeonExplorer
{
    /// <summary>
    /// Game class
    /// Sets up the main gameplay
    /// </summary>internal
    internal class Game
    {   
        // defining all of the objects to be used in the game class
        private Player player;// sets up an instance of "player" for the user
        private Room currentRoom;// sets up an instance of "room" for the player to interact with
        private Room nextRoom;// sets up the room to move on to
        private GameMap map = new GameMap(); // sets up the map for the player to move between rooms

        /// <summary>
        /// Sets up game 
        /// Created an inventory for the player and sets up new instance of player
        /// </summary>
        public Game()
        {
            // setting up the argyuments for the objects
            currentRoom = map.Entrance;
            // sets up an empty list of strings for the player inventory
            List<string> playerInventory = new List<string>();
            player = new Player("player", 100);
        }

        /// <summary>
        /// The main game loop
        /// gets player details and runs through each room and any interaction with monsters
        /// </summary>
        public void Start()
        {
            bool playing = true;
            while (playing)
            {   
                //gets the player to input a username
                player.setPlayerName();
                while (currentRoom != map.End && player.Health > 0)
                {
                    //check player health
                    Console.WriteLine($"\nYou have {player.Health} hp");
                    player.playerinventory.check();
                    //writes the description for the current room
                    currentRoom.WriteDescription();
                    //creates and encounter using the details of the room and player stats
                    if(currentRoom.hasMonster == true)
                    {
                        encounter(player, currentRoom);
                    }
                    //gives the user an option to pick up an item from the room
                    player.PickUpItem(currentRoom.RoomItem);
                    // if the game is still running (not in last room or player dead) finds next room details
                    if (currentRoom != map.End && player.Health > 0)
                    {
                        nextRoom = currentRoom.GetNextRoom();
                        //set next room to current room and run the next room description
                        currentRoom = nextRoom;
                        player.VisitRoom();
                    }
                }
                //if the player is alive at the end of the game, informs them they have won
                if (player.Health>0)
                {
                    Console.WriteLine($"\nCongratulations, {player.Name}, you beat the game");
                }
                //tells player stats
                Console.WriteLine($"\nYou finish the game with {player.Health} hp\n");
                Console.WriteLine($"\nYou visited {player.roomsVisited} rooms\n");
                player.playerinventory.check();
                Console.WriteLine($"\nThank you for playing, {player.Name}\n");
                //sets playing to false to finish the game
                playing = false;
            }
        } 
        
        /// <summary>
        /// method to handle encounters
        /// creates different instances of monsters depending on the room name
        /// player will hit a key to attack and the monster will attack after the next key press
        /// </summary>
        /// <param name="player"></param>
        /// <param name="room"></param>
        public void encounter(Player player, Room room)
        {
            //creates an instance of monster to be tailored to each room
            Monster monster = new Monster("monster", 0, 0);

            //monster values changed depending on room name
            string roomName = room.RoomName;
            if (roomName == "Passage")
            {
                monster = new Monster("Snake", 10, 5);
            }
            else if (roomName == "Small Dungeon")
            {
                monster = new Monster("Skeleton", 50, 10);
            }
            else if (roomName == "Courtyard")
            {
                monster = new Monster("Wolf", 20, 10);
            }
            else if (roomName == "Large Dungeon")
            {
                monster = new Monster("Dragon", 100, 15);
            }

            //tells player about the encounter
            monster.Appear();
            //tells player how to fight
            Console.WriteLine("You engage in battle, press any key to fight");
            Console.ReadKey();
            //while neither player or monster has died
            while (monster.Health > 0 && player.Health > 0)
            {
                Console.WriteLine($"\nYou have {player.Health} hp remaining");
                Console.WriteLine($"\nThe {monster.Name} has {monster.Health} hp remaining\n");
                player.Attack(player.playerDamage);
                monster.TakeDamage(player.playerDamage);
                Console.ReadKey();
                //if neither the player or monster has died continue
                if (monster.Health > 0 && player.Health > 0)
                {
                    Console.WriteLine($"\nThe {monster.Name} retaliates\n");
                    monster.Attack(monster.monsterDamage);
                    player.TakeDamage(monster.monsterDamage);
                    Console.ReadKey();
                }
            }
            //runs the creature.die for whichever creature loses
            if (monster.Health <= 0)
            {
                monster.Die();
            }
            if (player.Health <= 0)
            {
                player.Die();
            }

        }
    }
}