using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Creature
    {

        //contains the player and the monsters
        //sets up the methods used for anything that may fight

        public abstract void TakeDamage(int damage);

        public abstract void Attack(int damage);

        public abstract void Die();
    }
}
