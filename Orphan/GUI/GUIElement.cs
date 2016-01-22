using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Orphan
{
    abstract class GUIElement
    {

        // Base For Update Method
        public virtual void Update(){}

        //Acessors for different GUI elements, good code m8
        public virtual string GetString() { return null; }
        public virtual GUI[] GetGUIArray() { return null; }
        public virtual GUI GetGUI() { return null; }
        public virtual Boolean GetBool() { return false; }
        public virtual int GetInt() { return 0; }
        public virtual Item GetItem() { return null; }
        public virtual void SetInt(int Passint) { }
        public virtual void SetString(string Passstring) { }
        public virtual void SetItem(Item Passitem) { }
        public virtual void SetBool(Boolean Passbool) { }
    }
}
