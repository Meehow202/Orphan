using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Orphan
{
    class GUICheck : GUIElement
    {
        private string text;
        private Vector2 xy;
        private Boolean value;
        private int size;

        public GUICheck(string Passtext, Vector2 Passxy, Boolean Passval, int Passsize = 1)
        {
            this.text = Passtext;
            this.xy = Passxy;
            this.value = Passval;
            this.size = Passsize;
        }

        public override void Update()
        {
            Image.Add(this.xy, "checkbox" + this.size.ToString(), 4, null, null, false);
            if (this.value)
                Image.Add(this.xy, "check" + this.size.ToString(), 4, null, null, false);
            if (Input.LeftMouseClick(new Rectangle((int)this.xy.X, (int)this.xy.Y, 8 * this.size, 8 * this.size)))
                if (this.value)
                    this.value = false;
                else
                    this.value = true;

        }
        public override Boolean GetBool()
        {
            return this.value;
        }
        public override void SetBool(Boolean Passval)
        {
            this.value = Passval;
        }
    }
}
