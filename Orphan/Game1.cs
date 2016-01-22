using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Orphan
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        //Most of this stuff needs to find a home
        Dictionary<string, SpriteFont> GameFont = new Dictionary<string, SpriteFont>();
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Interact worldInteract = null;
        GUI currentgui;
        Inventory chest;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //Sets game window to desired size
            this.graphics.PreferredBackBufferWidth = 640 * Options.ratio;
            this.graphics.PreferredBackBufferHeight = 360 * Options.ratio;
            //Toggles fullscreen
            this.graphics.IsFullScreen = Options.isFullScreen;
            //Toggles mouse visability
            this.IsMouseVisible = Options.customCursor;
            this.graphics.ApplyChanges();
            base.Initialize();
        }


        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Object.objects = new Object[]{new ChestTable(new Vector2(100,100),new Item[]{})};
            Item.Add("none","I am nothing.",0,new Vector2(0,0), false);
            Item.Add("cake shirt", "Are you still there?", 0, new Vector2(3, 0), false);
            Item.Add("psi shirt", "PK or PSI?", 0, new Vector2(7, 0), false);
            Item.Add("blue sweater", "blue blue blue.", 0, new Vector2(1, 0), false);
            chest = new Inventory(new Item[2, 2] { { new Item("blue sweater"), new Item("psi shirt") }, { new Item("none"), new Item("cake shirt") } }, new Vector2(2, 2), new Vector2(32, 0));
            currentgui = new GUI(new GUIElement[]{new GUIGui(chest.gui)},new Rectangle(32, 0, 0, 0), false);
            GameFont.Add("8", Content.Load<SpriteFont>("GameFont8"));
            GameFont.Add("16",Content.Load<SpriteFont>("GameFont16"));
            Collision.AddWorld("defult", new Rectangle[] {});
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Not so eligant file loading
            string path = Directory.GetCurrentDirectory().Substring(0,Directory.GetCurrentDirectory().LastIndexOf("Orphan"))+@"Orphan\Content\Art\";
            string[] addlist = Directory.GetFiles(path,"*.png",SearchOption.AllDirectories);
            foreach (string str in addlist)
            {
                //Formats file name to be just image name
                string newstr = "";
                newstr = str.Substring(str.LastIndexOf(@"\")+1);
                newstr = newstr.Replace(".png","");
                int place = 0;
                place = str.LastIndexOf(@"\");
                place = str.Substring(0,place).LastIndexOf(@"\") +1;
                string file = @"Art\"+str.Substring(place);
                file = file.Replace(".png", "");
                //Loads image into game
                Image.ImageDict.Add(newstr, Content.Load<Texture2D>(file));
            }

        }

        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            //Resets screen
            Image.Clear();
            //Updates current GUI
            currentgui.Update();
            //Updates changes made to the Update class
            Options.Update(graphics);
            //Updates the currently selected Interact window
            if (worldInteract != null)
            {
                worldInteract.Update();
            }
            //Updates inputs and keystrokes
            Input.Update();
            //Handles player movement, will be moved to player update
            Player.Walk(Input.GetDirection(),3.0f);
            //Updates inworld objects, in need of optimisation
            foreach (Object obj in Object.objects)
                obj.Update();
            //Game speed = 30FPS
            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 30.0f);
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Aqua);
            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend,SamplerState.PointClamp,DepthStencilState.Default,RasterizerState.CullNone);
            //Loops through each in game layer
            for (int i = 0; i < 5; i++)
            {
                //each image in layer
                foreach (Image image in Image.Images[i])
                {
                    //Renders, if image
                    if (image.isimage)
                    {
                        //TODO Fix to be one statement, GUI drawing is wrong
                        if (image.imagename != "guiside" && image.imagename != "guicorner")
                            spriteBatch.Draw(Image.ImageDict[image.imagename], new Vector2((image.xy.X + (Image.ImageDict[image.imagename].Width / 2f)) * Options.ratio, image.xy.Y * Options.ratio), image.drawrect, image.color, MathHelper.ToRadians(image.angle), new Vector2(Image.ImageDict[image.imagename].Width / 2f, 0), new Vector2(Options.ratio, Options.ratio), SpriteEffects.None, 0);
                        else
                            spriteBatch.Draw(Image.ImageDict[image.imagename], new Vector2((image.xy.X + (Image.ImageDict[image.imagename].Width / 2f)) * Options.ratio, (image.xy.Y + (Image.ImageDict[image.imagename].Height / 2f)) * Options.ratio), image.drawrect, image.color, MathHelper.ToRadians(image.angle), new Vector2(Image.ImageDict[image.imagename].Width / 2f, Image.ImageDict[image.imagename].Height / 2f), new Vector2(Options.ratio, Options.ratio), SpriteEffects.None, 0);
                    }
                    //Renders, if text
                    else
                        spriteBatch.DrawString(GameFont[image.fontsize.ToString()], image.imagename, new Vector2(image.xy.X * Options.ratio, image.xy.Y * Options.ratio), image.color, MathHelper.ToRadians(image.angle), new Vector2(0, 0), new Vector2(Options.ratio, Options.ratio), SpriteEffects.None, 0);
                }
            }
            spriteBatch.End();


            base.Draw(gameTime);
        }

    }
}
