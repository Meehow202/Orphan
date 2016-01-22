using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Orphan
{
    class Interact
    {
        private int place = 0;
        private Vector2 location;
        public Rectangle[] textpoints;
        private string[] text;
        public int selected = -1;

        public void Reset()
        {
            place = 0;
        }

        public void Draw()
        {
            //angle inbetween each option
            int angle = (int)Math.Ceiling((360f / this.text.Length));
            for (int i = 0; i < 360; i = i + angle)
            {
                Image.Add(location, "connector", 3, new Rectangle(0,0,3,this.place), null, true, (-i));
            }
            //If Interact is fully open
            if (this.place == 36)
            {
                int j = 0;
                foreach (Rectangle point in textpoints)
                {
                    if (Input.LeftMouseClick(point,true))
                        this.selected = j;
                    Image.AddText(new Vector2(point.Left,point.Top), text[j], 3, 8, Color.White, true);
                    j++;
                }
            }
        }

        public void Update()
        {
            this.Draw();
            if (this.place < 36)
                this.place= this.place +4;
        }

        //Constructor, calculates the end points
        public Interact( string[] options, Vector2 location)
        {
            this.location = location;
            this.text = options;
            Rectangle[] ret = new Rectangle[options.Length];
            int angle = (int)Math.Ceiling((360f / options.Length));
            double x = 0;
            double y = 0;
            double slope = 0;
            for (int j = 0; j < options.Length; j++)
            {
                int i = j * angle + 90;
                try
                {
                    //Math for the end point of each option
                    slope = Math.Tan(MathHelper.ToRadians(i));
                    slope = Math.Round(slope, 2);
                    x = Math.Sqrt(1300 / (slope * slope + 1));
                    x = Math.Round(x, 1);
                    if (i >= 90 && i <= 270)
                        x = x * -1;
                    y = x * slope;
                    if (i >= 90 && i <= 270)
                        x = x - (int)(options[j].Length * 5) + -10;
                    else
                        x = x + 10;
                }
                catch { }
                if (i == 90)
                {
                    y = 45;
                    x = options[j].Length * -3.5;
                }
                if (i == 180)
                {
                    y = 0;
                    x = -45 - (options[j].Length * 7);
                }
                if (i == 270)
                {
                    x = options[j].Length * -3.5;
                    y = -45;
                }
                if (i == 0)
                {
                    x = 45;
                    y = 0;
                }
                ret[j] = new Rectangle((int)x + (int)location.X, (int)y + (int)location.Y - 10, (int)(options[j].Length * 6), 10);
            }
            this.textpoints = ret;
        }
    }
}
