using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace Orphan
{
    class Image
    {
        //Constructor, called by Image.Add and added to Images list
        public Image(Vector2 xy, string image, Rectangle drawrect, Color color, int angle, int size = 8, Boolean isimage = true)
        {
            this.angle = angle;
            this.xy=xy;
            this.fontsize = size;
            this.drawrect=drawrect;
            this.imagename = image;
            this.isimage = isimage;
            this.color=color;

        }
        public int angle;
        public int fontsize;
        public Vector2 xy;
        public Rectangle drawrect;
        public Boolean isimage = true;
        public string imagename;
        public Color color;
        //List of images that needs to be drawn this frame
        public static List<Image>[] Images = { new List<Image>(), new List<Image>(), new List<Image>(), new List<Image>(), new List<Image>() };

        // Add image 
        public static Boolean Add(Vector2 xy, string image, int layer, Rectangle? drawrect = null, Color? color=null, Boolean inworld = true, int angle = 0)
        {
            if (!color.HasValue)
                color = Color.White;
            if (!drawrect.HasValue)
                drawrect = new Rectangle(0, 0, ImageDict[image].Width, ImageDict[image].Height);
            if (inworld) { xy.X += 304; xy.Y += 156; xy.X -= (Player.X() - Player.ScreenX()); xy.Y -= (Player.Y() - Player.ScreenY()); }
            if (Image.ImageDict.ContainsKey(image))
                if (new Rectangle(0, 0, 640, 360).Intersects(new Rectangle((int)xy.X, (int)xy.Y, ImageDict[image].Height, ImageDict[image].Width)))
                {
                    Image.Images[layer].Add(new Image(xy, image, drawrect.Value, color.Value, angle));
                    return true;
                }
                return false;
        }
        //Adds text maybe
        public static Boolean AddText(Vector2 xy, string image, int layer, int size, Color? color = null, Boolean inworld = true)
        {
            if (!color.HasValue)
                color = Color.Black;
            if (inworld) { xy.X += 304; xy.Y += 156; xy.X -= (Player.X() - Player.ScreenX()); xy.Y -= (Player.Y() - Player.ScreenY()); }
            Image.Images[layer].Add(new Image(xy, image, new Rectangle(), color.Value, 0, size, false));
            return true;
        }

        public static void Clear()
        {
            for (int i = 0; i < 5; i++ )
                Image.Images[i] = new List<Image>();
        }
        // Holds all images, added in Game/LoadContent
        public static Dictionary<string, Texture2D> ImageDict = new Dictionary<string, Texture2D>(){};

    }
}
