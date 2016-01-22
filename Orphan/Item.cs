using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace Orphan
{
    class Item
    {
        // What item it is
        private string id;
        public string GetID()
        {
            return this.id;
        }
        //[0]= current durability, [1] = max durability
        private int[] durability = new int[2];
        //Holds boolean for if item breaks when out of durability
        public static Dictionary<string, Boolean> canBreak =new Dictionary<string, Boolean>();
        //Holds defult durability of each item
        public static Dictionary<string, int> defultDurability = new Dictionary<string, int>();
        //Holds location of item texture in itemsheet
        public static Dictionary<string, Vector2> itemLocation = new Dictionary<string, Vector2>();
        // Holds the description of the item
        public static Dictionary<string, string> itemDescription = new Dictionary<string, string>();

        public static void Add(string id, string descript, int durability, Vector2 location, Boolean canbreak = true)
        {
            itemLocation.Add(id, location);
            defultDurability.Add(id,durability);
            canBreak.Add(id, canbreak);
            itemDescription.Add(id, descript);
        }

        //Constructor, takes id, max durability, current durability defulting to max
        public Item(string id, int? durability = null, int? current = null)
        {
            this.id = id;
            int dur;
            if (!durability.HasValue)
                dur = Item.defultDurability[id];
            else
                dur = durability.Value;
            if (!current.HasValue)
                current = dur;
            this.durability[0]=current.Value;
            this.durability[1] = dur;
        }
        // Takes int durability off item, returns true if it has broken
        public Boolean TakeDurability(int amount = 1)
        {
            durability[0] = durability[0] - amount;
            if (durability[0] <= 0 && Item.canBreak[this.id])
                return true;
            else
                return false;
        }

    }

}
