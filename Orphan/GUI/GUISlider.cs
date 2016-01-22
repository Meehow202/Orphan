using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Orphan
{
    class GUISlider : GUIElement
    {
        private int optionsmin;
        private int optionsmax;
        private int var;
        private Vector3 xy;

        public GUISlider(int Passoptionsmin, int Passoptionsmax, Vector3 Passxy, int Passvar = 0)
        {
            this.optionsmin = Passoptionsmin;
            this.optionsmax = Passoptionsmax;
            this.xy = Passxy;
            this.var = Passvar;
        }

        public override void Update()
        {
            
        }
        public override int GetInt()
        {
            return this.var;
        }
    }
}
