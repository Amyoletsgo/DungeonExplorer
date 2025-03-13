using System;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonExplorer
{
    /// <summary>
    /// Room class
    /// used to define any room and all of it's attributes
    /// this is called in the map and game and also used recursively where there are connecting rooms
    /// </summary>
    public class Room
    {
        //sets up the parameters for the class
        private string roomName;
        private string roomDescription;
        private Room left;
        private Room right;
        private Item roomItem;
        public bool hasMonster;

        /// <summary>
        /// method to set up the Room class
        /// takes multiple variables to set up the room
        /// </summary>
        /// <param name="roomName"></param>
        /// <param name="roomItem"></param>
        /// <param name="description"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="hasMonster"></param>
        public Room(string roomName, Item roomItem, string description, Room left, Room right, bool hasMonster)
        {
            //takes the inputs from when the class is called to set up the variables for the class
            this.roomName = roomName;
            this.roomDescription = description;
            this.left = left;
            this.right = right;
            this.hasMonster = hasMonster;
            this.roomItem = roomItem;
        }


        /// <summary>
        /// encapsulates the room name
        /// </summary>
        public string RoomName
        {
            //gets and sets the name of the room  
            get { return roomName; }
            set { roomName = value; }
        }

        /// <summary>
        /// encapsulates the room item
        /// </summary>
        public Item RoomItem
        {
            //gets and sets the name of the room  
            get { return roomItem; }
            set { roomItem = value; }
        }

        /// <summary>
        /// method to get the room that the player will move to next
        /// takes the user input that chooses between the "left" room or the "right" room
        /// </summary>
        /// <returns></returns>
        public Room GetNextRoom()
        {
            //if the right and left rooms are the same, select left
            Room nextRoom;
            if (left.RoomName == right.roomName)
            {
                nextRoom = left;
            }
            //otherwise the user is given a choice whether to go left or right
            else
            {
                string roomChoice = "null";
                while (roomChoice != "L" && roomChoice != "R")
                {
                    Console.WriteLine("Do you go left (L) or right (R)? ");
                    try
                    {
                        roomChoice = Console.ReadLine().ToUpper();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please only write L or R: ");
                    }
                }


                if (roomChoice == "L")
                {
                    nextRoom = left;
                }
                else
                {
                    nextRoom = right;
                }
            }
            return nextRoom;
        }

        /// <summary>
        /// method that writes out the name and description of the room that the player is in
        /// </summary>
        public void WriteDescription()
        {
            //writes a description of the room including all of the variables passed in
            Console.WriteLine(
                $"\nYou enter {roomName}. \n" +
                $"{roomDescription}\n");

        }
    }
}