using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Orphan
{
    class Input
    {
        public static KeyboardState newkeyboard;
        public static KeyboardState oldkeyboard;
        public static MouseState mouse;
        public static Boolean clickcool = false;
        public static void Update()
        {
            if (Input.clickcool)
                if (mouse.LeftButton != ButtonState.Pressed)
                    Input.clickcool = false;
            Input.oldkeyboard = Input.newkeyboard;
            Input.newkeyboard = Keyboard.GetState();
            Input.mouse = Mouse.GetState();
        }
        public static Player.Direction? GetDirection()
        {
            Player.Direction? direct = null;
            if (Player.canmove)
            {
                if (Input.newkeyboard.IsKeyDown(Keys.A))
                    direct = Player.Direction.Left;
                if (Input.newkeyboard.IsKeyDown(Keys.W))
                    direct = Player.Direction.Up;
                if (Input.newkeyboard.IsKeyDown(Keys.S))
                    direct = Player.Direction.Down;
                if (Input.newkeyboard.IsKeyDown(Keys.D))
                    direct = Player.Direction.Right;
            }
            return direct; 
        }
        public static Vector2 GetMousePos()
        {
            return new Vector2(mouse.X / Options.ratio, mouse.Y / Options.ratio);
        }
        public static int GetMouseX()
        {
            return mouse.X / Options.ratio;
        }
        public static int GetMouseY()
        {
            return mouse.Y / Options.ratio;
        }
        public static Boolean MouseInBox(Rectangle box)
        {
            if (Input.mouse.X / Options.ratio > box.Left && Input.mouse.X / Options.ratio < box.Right && Input.mouse.Y / Options.ratio > box.Top && Input.mouse.Y / Options.ratio < box.Bottom)
                return true;
            else
                return false;
        }
        public static Boolean LeftMouseClick(Rectangle? rect = null, Boolean inworld = false)
        {
            if (rect.HasValue)
            {
                if (inworld)
                {
                    if (!MouseInBox(Collision.InworldToScreen(rect.Value)))
                        return false;
                }
                else
                {
                    if (!MouseInBox(rect.Value))
                        return false;
                }
            }
            if (mouse.LeftButton == ButtonState.Pressed && !Input.clickcool)
                {
                    clickcool = true;
                    return true;
                }
                else
                    return false;

        }
    }
}
