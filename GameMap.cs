using System;
using System.Collections.Generic;
using System.Media;

namespace DungeonExplorer
{
    /// <summary>
    /// Creates an instance of each room and their description and the rooms they connect to
    /// also creates an item for each room
    /// </summary>
    internal class GameMap
    {   
        //names of the rooms defined in the order the player may come across them
        //there is also a description of the room (string) and an item that they will come across
        public Room Entrance;
        public Item EntranceItem = new Item("key");
        public string EntranceDescription = "The Entrance is dark and dimly lit by a torch." +
            "\nIt smells damp and you are cold. You see two doors ahead of you." +
            "\nMake sure to look out for potions, weapons and defences, they will help you in your journey.";
        public Room FrontRoom;
        public Item FrontRoomItem = new Item("sword");
        public string FrontRoomDescription = "The front room has large windows and torn curtains" +
            "\nThere is old furniture covered in a thick layer of dust." +
            "\nYou feel a familar feeling, like something is welcoming you forward.";
        public Room Armory;
        public Item ArmoryItem = new Item("shield");
        public string ArmoryDescription = "The armory has been deserted for decades." +
            "\nThere is a feeling of protection in here.";
        public Room Passage;
        public Item PassageItem = new Item("axe");
        public string PassageDescription = "The passage has low ceilings and is barely lit from the end." +
            "\nIt leads somewhere secret...";
        public Room SmallDungeon;
        public Item SmallDungeonItem = new Item("gold");
        public string SmallDungeonDescription = "This dungeon has it's windows barred and smashed." +
            "\nIt is a dangerous room to be in. You realise you might not be the only one in here...";
        public Room Treasury;
        public Item TreasuryItem = new Item("chest");
        public string TreasuryDescription = "The treasury feels like a safe haven, you take a minute to rest.";
        public Room Infirmary;
        public Item InfirmaryItem = new Item("potion");
        public string InfirmaryDescription = "The infirmary is a place of healing, however deserted it may be." +
            "\nIt has not been touched in years, yet every surface is clean, the moon gleams through the windows.";
        public Room Courtyard;
        public Item CourtyardItem = new Item("potion");
        public string CourtyardDescription = "The courtyard is a vast garden with winding paths." +
            "\nThere is both danger and help here.";
        public Room LargeDungeon;
        public Item LargeDungeonItem = new Item("gold");
        public string LargeDungeonDescription = "This is where your journey comes to an end, one way or another." +
            "\nThe Large Dungeon is the home of something powerful and evil, I hope you brough backup...";
        public Room End;
        public Item EndItem = new Item("key");

        /// <summary>
        /// method for creating each room with the variables needed
        /// sets up the map for the game
        /// </summary>
        public GameMap()
        {
            //each room has a left or right option, sometimes they lead to the same room
            //the rooms are written in reverse order so the rooms they lead to are already defined
            End = new Room("end", EndItem, "finit", null, null, false);
            LargeDungeon = new Room("Large Dungeon", LargeDungeonItem, LargeDungeonDescription, End, End, true);
            Courtyard = new Room("Courtyard", CourtyardItem, CourtyardDescription, LargeDungeon, LargeDungeon, true);
            Treasury = new Room("Treasury", TreasuryItem, TreasuryDescription, Courtyard, LargeDungeon, false);
            Infirmary = new Room("Infirmary", InfirmaryItem, InfirmaryDescription, Treasury, LargeDungeon, false);
            SmallDungeon = new Room("Small Dungeon", SmallDungeonItem, SmallDungeonDescription, Treasury, Infirmary, true);
            Armory = new Room("Armory", ArmoryItem, ArmoryDescription, SmallDungeon, SmallDungeon, false);
            Passage = new Room("Passage", PassageItem, PassageDescription, SmallDungeon, Armory, true);
            FrontRoom = new Room("Front Room",FrontRoomItem, FrontRoomDescription, Passage, Armory, false);
            Entrance = new Room("Entrance", EntranceItem, EntranceDescription, FrontRoom, Armory, false);
            
        }
    }
}