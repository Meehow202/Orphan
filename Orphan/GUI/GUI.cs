using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Orphan
{
    class GUI
    {
        private Rectangle bound;
        public GUIElement[] elements;
        private Vector2 size;
        private Boolean background;
        public GUI(GUIElement[] elementlist, Rectangle rectbounds, Boolean hasBackground = true)
        {
            this.elements = elementlist;
            this.bound = rectbounds;
            this.size = new Vector2((rectbounds.Bottom - rectbounds.Top) / 16 -1, (rectbounds.Right - rectbounds.Left) / 16 -1);
            this.background = hasBackground;
        }
        public void Update()
        {
            if (this.background)
                this.Draw();
            foreach (GUIElement element in this.elements)
            {
                element.Update();
            }
        }
        private void Draw()
        {
            for (int i = 1; i < size.Y; i++)
            {
                Image.Add(new Vector2(bound.Left + (i * 16), bound.Top), "guiside", 4, null, null, false);
                Image.Add(new Vector2(bound.Left + (i * 16), bound.Top + (size.X * 16)), "guiside", 4, null, null, false, 180);
            }
            for (int i = 1; i < size.X; i++)
            {
                Image.Add(new Vector2(bound.Left, bound.Top + (i * 16)), "guiside", 4, null, null, false, 270);
                Image.Add(new Vector2(bound.Left + (size.Y * 16), bound.Top + (i * 16)), "guiside", 4, null, null, false, 90);
            }
            Image.Add(new Vector2(bound.Left, bound.Top), "guicorner", 4, null, null, false, 0);
            Image.Add(new Vector2(bound.Left, bound.Top + size.X * 16), "guicorner", 4, null, null, false, 270);
            Image.Add(new Vector2(bound.Left + size.Y * 16, bound.Top + size.X * 16), "guicorner", 4, null, null, false, 180);
            Image.Add(new Vector2(bound.Left + size.Y * 16, bound.Top), "guicorner", 4, null, null, false, 90);
            for (int i = 1; i < size.X; i++)
                for (int j = 1; j < size.Y; j++)
                    Image.Add(new Vector2(bound.Left + j*16, bound.Top +i*16), "guicenter", 4, null, null, false);
        }
    }
}
