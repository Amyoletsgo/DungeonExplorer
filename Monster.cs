using System;
using System.Collections.Generic;
using System.Media;
using System.Net.Mail;
using System.Xml.Linq;

namespace DungeonExplorer
{
    /// <summary>
    /// subclass of the creature class
    /// inherits attack, take damage and die
    /// also has its own name, health and damage, all defined when it is created
    /// </summary>
    public class Monster: Creature
    {
        private string monsterName = "monster"; // sets a default meonster name
        private int monsterHealth; //sets up integer value for health
        public int monsterDamage; // sets up integer value for damage

        /// <summary>
        /// creates a new monster
        /// </summary>
        /// <param name="monsterName"></param>
        /// <param name="monsterHealth"></param>
        /// <param name="monsterDamage"></param>
        public Monster(string monsterName, int monsterHealth, int monsterDamage)
        {
            Name = monsterName;
            Health = monsterHealth;
            Damage = monsterDamage;
        }

        /// <summary>
        /// get and sets name, to monster if it is null
        /// </summary>
        public string Name
        {
            //gets and sets monster name
            get { return monsterName; }
            set { monsterName = string.IsNullOrWhiteSpace(value) ? "monster" : value; }
        }

        /// <summary>
        /// get and sets health, used in battles
        /// </summary>
        public int Health
        {
            //get and set for health
            get { return monsterHealth; }
            set { monsterHealth = value; }
        }
         
        /// <summary>
        /// get and sets damage, used in battles
        /// </summary>
        public int Damage
        {
            //get and set for health
            get { return monsterDamage; }
            set { monsterDamage = value; }
        }

        /// <summary>
        /// method which informs player of the monster appearing
        /// </summary>
        public void Appear()
        {
            Console.WriteLine("There is a monster in this room");
            Console.WriteLine("You must defeat it to pass through");
            Console.WriteLine($"It is a {monsterName} and it has {monsterHealth} hp");
        }

        /// <summary>
        /// inherited from creature
        /// takes damage from health and informs that damage was taken
        /// </summary>
        /// <param name="damage"></param>
        public override void TakeDamage(int damage)
        {
            monsterHealth -= damage;
            Console.WriteLine($"\nThe {monsterName} took {damage} hp in damage");
        }

        /// <summary>
        /// inherited from creature
        /// informs player that the monster attacks
        /// </summary>
        /// <param name="damage"></param>
        public override void Attack(int damage)
        {
            Console.WriteLine($"\nThe {monsterName} attacked for {damage}");
        }

        /// <summary>
        /// inherited from creature
        /// informs player of monster death
        /// </summary>
        public override void Die()
        {
            Console.WriteLine($"\nYou have slain the {monsterName}");
            
        }
    }
}