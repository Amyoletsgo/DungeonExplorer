using System;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonExplorer
{
    public class Room
    {
        //sets up the parameters for the class
        private string roomName;
        private string roomItem;
        private int roomLength;
        private int roomWidth;
        private int roomDoors;


        public Room(string roomName, string roomItem, int roomLength, int roomWidth, int roomDoors)
        {
            //takes the inputs from when the class is called to set up the variables for the class
            this.roomName = roomName;
            this.roomItem = roomItem;
            this.roomLength = roomLength;
            this.roomWidth = roomWidth;
            this.roomDoors = roomDoors;
        }

        public string RoomName
        {
            //gets and sets the name of the room 
            get { return roomName; }
            set { roomName = value; }
        }

        public string RoomItem
        {
            //gets and sets the name of the item in the room 
            get { return roomItem; }
            set { roomItem = value; }
        }

        public void WriteDescription()
        {
            //writes a description of the room including all of the variables passed in
            Console.WriteLine(
                $"You enter {roomName}. This room goes back {roomLength} metres. \n" +
                $"It is {roomWidth} metres wide. The room has {roomDoors} Doors \n");
        }

    }
}