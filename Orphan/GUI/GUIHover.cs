using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Orphan
{
    class GUIHover : GUIElement
    {
        private GUI hover;
        private Rectangle mousebox;

        public GUIHover(GUI Passhover,Rectangle Passmousebox)
        {
            this.hover = Passhover;
            this.mousebox = Passmousebox;
        }

        public override void Update()
        {
            if (Input.MouseInBox(this.mousebox))
                hover.Update();
        }
        public override GUI GetGUI()
        {
            return this.hover;
        }
    }
}
