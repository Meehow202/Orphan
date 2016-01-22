using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Orphan
{
    class GUIItem : GUIElement
    {
        private Item item;
        private Vector2 xy;


        public GUIItem(Item Passitem, Vector2 Passxy)
        {
            this.item = Passitem;
            this.xy = Passxy;
        }

        public override void Update()
        {
            Image.Add(this.xy, "itemholder", 4, null, null, false);
            Image.Add(this.xy, "itemsheet", 4, new Rectangle((int)Item.itemLocation[this.item.GetID()].X * 32, (int)Item.itemLocation[this.item.GetID()].Y * 32, 32, 32), null, false);
            if (Input.MouseInBox(new Rectangle((int)xy.X, (int)xy.Y, 32, 32)))
            {
                GUI gui = new GUI(new GUIElement[] { new GUIText(this.item.GetID(), new Vector2(this.xy.X + 38, this.xy.Y + 3)), new GUIText(Item.itemDescription[this.item.GetID()].ToUpper(), new Vector2(this.xy.X + 38, this.xy.Y + 20)) }, new Rectangle(0, 0, 0, 0), false);
                gui.Update();
            }
        }
        public override Item GetItem()
        {
            return this.item;
        }
        public override void SetItem(Item Passitem)
        {
            this.item = Passitem;
        }
    }
}
