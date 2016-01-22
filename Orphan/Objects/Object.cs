using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Orphan
{
    class Object 
    {
        public static Object[] objects;
        public Boolean selected =false;
        protected Interact interaction;
        protected Vector2 xy;
        public Rectangle collision;
        protected string texture;
        public int state = 0;

        public virtual void Update() { }

    }
}
