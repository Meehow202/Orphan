using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace Orphan
{
    class Player
    {
        // GUI
        GUI intentory = new GUI(new GUIElement[] { }, new Rectangle(62, 32, 576, 264));
        //Skills
        static private byte intelligence;
        static private byte cleverness;
        static private byte social;
        static private byte creativity;
        static private byte strength;
        //Skills Acssessors
        static public byte Intellegence()
        {
            return Player.intelligence;
        }
        static public byte Cleverness()
        {
            return Player.cleverness;
        }
        static public byte Social()
        {
            return Player.social;
        }
        static public byte Creativity()
        {
            return Player.creativity;
        }
        static public byte Strength()
        {
            return Player.strength;
        }
        //Stats
        static private byte happiness;
        static private decimal happymultiplier;
        static private int money;
        static private int energy;
        static private decimal energymultiplier;
        static private int energymax;
        //Custom Character
        static private Color eyecolor = new Color(100, 100, 100);
        static private Color haircolor = new Color(50, 150, 50);
        static public Color[] skincolors = { new Color(255, 255, 255), new Color(237, 220, 204), new Color(225, 196,178),new Color(220, 171, 141), new Color(173,140,119),new Color(164,133,113), new Color(142,103,78),new Color(102,77,59),new Color(86,63,48)};
        static private Color skincolor = Player.skincolors[4];
        static private string hairtype = "hair7";
        static private string[] clothes = {"kavin shirt", "jeans"};
        //Walking
        public static Boolean canmove = true;
        static private Direction dir = Direction.Up;
        static private int frame = -1;
        static private float counter = 0;
        static private Vector2 XY = new Vector2(0, 0);
        //XY and ScreenXY Accessors
        static public float X()
        {
            return Player.XY.X;
        }
        static public float Y()
        {
            return Player.XY.Y;
        }
        static private Vector2 screen = new Vector2(0, 0);
        static public float ScreenX()
        {
            return Player.screen.X;
        }
        static public float ScreenY()
        {
            return Player.screen.Y;
        }
        //Directions enum
        public enum Direction { Down, Left, Right, Up };
        static public Vector2[] DirectionToXY = { new Vector2(0, 1), new Vector2(-1, 0), new Vector2(1, 0), new Vector2(0, -1) };

        //Draws the different parts of the player
        static public void DrawPlayer()
        {
            int frame = Player.frame;
            if (frame == -1)
                frame = 0;
            Image.Add(new Vector2(Player.screen.X+304, Player.screen.Y+156), "defchar", 2, new Rectangle(frame * 32, 48 * (int)Player.dir, 32, 48),Player.skincolor,false);
            //Underclothes
            if (Player.clothes[0] == "none" || Player.clothes[1] == "none")
                Image.Add(new Vector2(Player.screen.X + 304, Player.screen.Y + 156), "underwear", 2, new Rectangle(frame * 32, 48 * (int)Player.dir, 32, 48), null, false);
            Image.Add(new Vector2(Player.screen.X + 304, Player.screen.Y + 156), Player.clothes[1], 2, new Rectangle(frame * 32, 48 * (int)Player.dir, 32, 48), null, false);
            Image.Add(new Vector2(Player.screen.X + 304, Player.screen.Y + 156), Player.clothes[0], 2, new Rectangle(frame * 32, 48 * (int)Player.dir, 32, 48), null, false);
            Image.Add(new Vector2(Player.screen.X + 304, Player.screen.Y + 156), "eyes", 2, new Rectangle(frame * 32, 48 * (int)Player.dir, 32, 48), Player.eyecolor, false);
            Image.Add(new Vector2(Player.screen.X + 304, Player.screen.Y + 156), "eyewhites", 2, new Rectangle(frame * 32, 48 * (int)Player.dir, 32, 48), null, false);
            Image.Add(new Vector2(Player.screen.X + 304, Player.screen.Y + 156), Player.hairtype, 2, new Rectangle(frame * 32, 48 * (int)Player.dir, 32, 48), Player.haircolor, false);
        }
        //Handles walking
        static public void Walk(Direction? dir = null, float speed = 0)
        {
            //Test collision if player is walking
            if (dir != null)
                if (!Collision.WorldCollision("defult", new Vector2(Player.XY.X + (DirectionToXY[(int)dir].X * speed), Player.XY.Y + (DirectionToXY[(int)dir].Y * speed))))
                {
                    Player.dir = dir.Value;
                    dir = null;
                }
            //If player stops walking
            if (dir == null)
            {
                Player.frame = -1;
                Player.DrawPlayer();
            }
            else
            {
                if (Player.counter > 10)
                {
                    Player.frame = Player.frame + 1;
                    Player.counter=0;
                }
                if (Player.frame == 4 || Player.frame == -1)
                    frame = 0;
                if (Player.dir != dir)
                {
                    Player.frame = 0;
                    Player.dir = dir.Value;
                }
                //Handles the inner screen box
                Player.counter = Player.counter + speed;
                Player.screen.Y+=DirectionToXY[(int)Player.dir].Y*speed;
                Player.screen.X += DirectionToXY[(int)Player.dir].X*speed;
                Player.XY.X += DirectionToXY[(int)Player.dir].X * speed;
                Player.XY.Y += DirectionToXY[(int)Player.dir].Y * speed;
                int boxsize = 65;
                if (Player.screen.X >= boxsize - 32)
                    Player.screen.X = boxsize - 32;
                if (Player.screen.X <= boxsize*-1)
                    Player.screen.X = boxsize * -1;
                if (Player.screen.Y >= boxsize - 48)
                    Player.screen.Y = boxsize - 48;
                if (Player.screen.Y <= boxsize * -1)
                    Player.screen.Y = boxsize * -1;
                Player.DrawPlayer();

            }

        }
    }
}
