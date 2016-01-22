using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Orphan
{
    class ChestTable : Object
    {
        private Item[] inventory;
        public ChestTable(Vector2 xy, Item[] inv, int state = 0)
        {
            this.collision = new Rectangle((int)xy.X, (int)xy.Y, 32, 16);
            this.interaction = new Interact(new string[]{"Open","Close","Inventory"},new Vector2(collision.Center.X,collision.Center.Y));
            this.xy = xy;
            this.state = state;
            if (this.state == 0)
                this.texture = "chesttable";
            else
                this.texture = "chesttableopen";
            this.inventory = inv;
        }
        public override void Update()
        {
            if (Input.LeftMouseClick(this.collision, true))
            {
                if (this.selected)
                    this.selected = false;
                else
                    this.selected = true;
            }
            if (this.selected)
                this.interaction.Update();
            else
                this.interaction.Reset();
            if (interaction.selected == 0)
                this.texture = "chesttableopen";
            if (interaction.selected == 1)
                this.texture = "chesttable";
            Console.WriteLine(this.interaction.selected);
            Image.Add(this.xy,this.texture,1);
        }
    }
}
