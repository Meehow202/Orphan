using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Orphan
{
    class Collision
    {
        // Holds collision boxes for each world
        private static Dictionary<string, Rectangle[]> Worlds = new Dictionary<string, Rectangle[]>();

        // Adds world and collision boxes
        public static void AddWorld(string name,Rectangle[] bounds)
        {
            Worlds.Add(name,bounds);
        }

        //Does all the collision
        public static Boolean WorldCollision(string world, Vector2 playerxy)
        {
            Boolean move = true;
            foreach (Rectangle collide in Worlds[world])
            {
                if (collide.Intersects(new Rectangle((int)playerxy.X+6, (int)playerxy.Y+15, 20, 32)))
                    move=false;
            }
            foreach (Object obj in Object.objects)
            {
                if (obj.collision.Intersects(new Rectangle((int)playerxy.X + 6, (int)playerxy.Y + 15, 20, 32)))
                    move = false;
            }
            return move;
        }
        public static Vector2 InworldToScreen(Vector2 xy)
        {
            xy.X += 304;
            xy.Y += 156;
            xy.X -= (Player.X() - Player.ScreenX());
            xy.Y -= (Player.Y() - Player.ScreenY());
            return xy;
        }
        public static Rectangle InworldToScreen(Rectangle rect)
        {
            Rectangle ret = new Rectangle(0,0,rect.Width,rect.Height);
            ret.Offset(rect.X + 304 - (Player.X() - Player.ScreenX()), rect.Y + 156 - (Player.Y() - Player.ScreenY()));
            return ret;
        }
    }
}
