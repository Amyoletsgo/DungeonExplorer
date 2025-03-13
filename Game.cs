using System;
using System.Collections.Generic;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {   
        // defining all of the objects to be used in the game class
        private Player player;// sets up an instance of "player" for the user
        private Room currentRoom;// sets up an instance of "room" for the player to interact with
        private Room nextRoom;// sets up the room to move on to
         

        
        public Game()
        {
            // setting up the argyuments for the objects
            currentRoom = new Room("room 1: entrance", "a torch", 2, 2, 1);
               nextRoom = new Room("room 2: passage", "a key", 5, 2, 4);
            // sets up an empty list of strings for the player inventory
            List<string> playerInventory = new List<string>();
            player = new Player("player", 100, playerInventory);
        }

        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                //gets the player to input a username 
                player.setPlayerName();
                //writes the description for the current room
                currentRoom.WriteDescription();
                //gives the user an option to pick up an item from the room
                player.PickUpItem(currentRoom.RoomItem);
                //set next room to current room and run the next room description
                currentRoom = nextRoom;
                player.PickUpItem(currentRoom.RoomItem);
                //sets playing to false to finish the game
                playing = false;
            }
        }
    }
}