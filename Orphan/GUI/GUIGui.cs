using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Orphan
{
    class GUIGui : GUIElement
    {
        private GUI gui;

        public GUIGui(GUI Passgui)
        {
            this.gui = Passgui;
        }

        public override void Update()
        {
            gui.Update();
        }
        public override GUI GetGUI()
        {
            return this.gui;
        }
    }
}
