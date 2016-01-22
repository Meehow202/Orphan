using System;
using System.Collections.Generic; 
using Microsoft.Xna.Framework;                                                     
namespace Orphan
{
    class Options
    {
        public static int ratio = 2;
        public static int wantedratio = 1;
        public static Boolean customCursor = false;
        public static bool isFullScreen = false;
        public static GUI options = new GUI(new GUIElement[] { new GUITab(new GUI[] 
            { new GUI(new GUIElement[] { new GUICheck("Fullscreen?", new Vector2(), Options.isFullScreen,2) }, new Rectangle(62, 32, 576, 264), true), 
            new GUI(new GUIElement[] { }, new Rectangle(62, 32, 576, 264)), 
            new GUI(new GUIElement[] { }, new Rectangle(62, 32, 576, 264)) }, 
            new Vector2(32, 32)) }, new Rectangle(64, 32, 576, 264), false);
        public static void GUI()
        {
            Options.options.Update();
            if (options.elements[0].GetGUIArray()[0].elements[0].GetBool())
                Options.isFullScreen = true;
            else
                Options.isFullScreen = false;

        }

        public static void Update(GraphicsDeviceManager graphics)
        {
            if (graphics.PreferredBackBufferWidth != 640 * Options.ratio || graphics.PreferredBackBufferWidth != 640)
            {
                graphics.PreferredBackBufferWidth = 640 * Options.ratio;
                graphics.PreferredBackBufferHeight = 360 * Options.ratio;
            }
            if (graphics.IsFullScreen != Options.isFullScreen)
            {
                Options.ratio = 3;
                graphics.PreferredBackBufferWidth = 640 * Options.ratio;
                graphics.PreferredBackBufferHeight = 360 * Options.ratio;
                graphics.IsFullScreen = Options.isFullScreen;
                graphics.ApplyChanges();
            }
        }
    }
}
