using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Orphan
{
    class GUITab : GUIElement
    {
        public GUI[] tab;
        private Vector2 xy;
        private int active;

        public GUITab(GUI[] Passtab, Vector2 Passxy, int Passactive = 0)
        {
            this.tab = Passtab;
            this.xy = Passxy;
            this.active = Passactive;
        }

        public override void Update()
        {
            for (int i = 0; i < this.tab.Length; i++)
            {
                if (i != this.active)
                    Image.Add(new Vector2(this.xy.X,this.xy.Y+(i*32)), "guitab", 4, null, new Color(125,125,175), false);
            }
            tab[this.active].Update();
            Image.Add(new Vector2(this.xy.X, this.xy.Y + (this.active * 32)), "guitab", 4, null, null, false);
            for (int i = 0; i < this.tab.Length; i++)
                if (Input.LeftMouseClick(new Rectangle((int)this.xy.X, (int)this.xy.Y + (i * 32), 32, 32)))
                    this.active = i;
        }
        public override GUI[] GetGUIArray()
        {
            return this.tab;
        }
        public override void SetInt(int Passactive)
        {
            this.active = Passactive;
        }

    }
}
