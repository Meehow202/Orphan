using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Orphan
{
    class GUIText : GUIElement
    {
        private string text;
        private Vector2 xy;

        public GUIText(string Passtext, Vector2 Passxy)
        {
            this.text = Passtext;
            this.xy = Passxy;
        }

        public override void Update()
        {
            Image.AddText(this.xy,this.text,4, 8,null,false);
        }
        public override void SetString(string Passtext)
        {
            this.text = Passtext;
        }
    }
}
