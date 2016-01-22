using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Orphan
{
    class Inventory
    {
        public static Item inhand = new Item("none");
        private Item[,] inventory;
        public GUI gui;
        private Vector2 xy = new Vector2(0,0);
        private Vector2 demension = new Vector2(0, 0);
        public Inventory(Item[,] inventory, Vector2 demension, Vector2 place)
        {
            this.inventory = inventory;
            this.xy = place;
            this.demension = demension;
            this.gui = new GUI(new GUIElement[inventory.Length],new Rectangle(0,0,0,0),false);
            for (int i = 0; i < inventory.Length; i++)
            {
                gui.elements[i] = new GUIItem(inventory[(int)IntToVector(i).X, (int)IntToVector(i).Y], new Vector2((IntToVector(i).X*36)+this.xy.X, (IntToVector(i).Y*36)+this.xy.Y));
            }
        }
        public void Update()
        {
            Image.Add(Input.GetMousePos(), "itemsheet", 4, new Rectangle((int)Item.itemLocation[Inventory.inhand.GetID()].X * 32, (int)Item.itemLocation[Inventory.inhand.GetID()].Y * 32, 32, 32), null, false);
            for (int i = 0; i < inventory.Length; i++)
            {
                if (Input.LeftMouseClick(new Rectangle((int)((IntToVector(i).X * 36) + this.xy.X), (int)((IntToVector(i).Y * 36) + this.xy.Y), 32, 32)))
                {
                    Item place = Inventory.inhand;
                    Inventory.inhand = this.inventory[(int)IntToVector(i).X, (int)IntToVector(i).Y];
                    this.inventory[(int)IntToVector(i).X, (int)IntToVector(i).Y] = place;
                }
                gui.elements[i] = new GUIItem(inventory[(int)IntToVector(i).X, (int)IntToVector(i).Y], new Vector2((IntToVector(i).X * 36) + this.xy.X, (IntToVector(i).Y * 36) + this.xy.Y));
            }

        }
        public Item GetItem(int x, int y = -1)
        {
            if (y != -1)
            {
                return this.inventory[x,y];
            }
            else
            {
                return this.inventory[x % (int)demension.X, (int)Math.Floor((float)x/demension.X)];
            }
        }
        public Vector2 IntToVector(int x)
        {
            return new Vector2(x % (int)demension.X, (int)Math.Floor((float)x / demension.X));
        }
    }
}
