using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace K018A1818_kojinseisaku01.Device
{
    class Input
    {

        private static Vector2 velocity = Vector2.Zero;

        private static KeyboardState currentKey;
        private static KeyboardState previousKey;

        private static MouseState currentMouse;
        private static MouseState previousMouse;

        public static void Update()
        {
            previousKey = currentKey;
            currentKey = Keyboard.GetState();

            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            UpdateVelocity();
        }

        public static Vector2 Velocity()
        {
            return velocity;
        }

        private static void UpdateVelocity()
        {
            velocity = Vector2.Zero;

            if (currentKey.IsKeyDown(Keys.Right))
            {
                velocity.X = 1f;
            }

            if (currentKey.IsKeyDown(Keys.Left))
            {
                velocity.X = -1f;
            }

            if (currentKey.IsKeyDown(Keys.Up))
            {
                velocity.Y = -1f;
            }

            if (currentKey.IsKeyDown(Keys.Down))
            {
                velocity.Y = 1f;
            }

            if (velocity.Length() != 0)
            {
                velocity.Normalize();
            }
        }

        public static bool IsKeyDown(Keys key)
        {
            return currentKey.IsKeyDown(key) && !previousKey.IsKeyDown(key);
        }

        public static bool GetKeyTrigger(Keys key)
        {
            return IsKeyDown(key);
        }

        public static bool GetKeyState(Keys key)
        {
            return currentKey.IsKeyDown(key);
        }

        public static bool IsMouseLButtonDown()
        {
            return currentMouse.LeftButton == ButtonState.Pressed &&
                previousMouse.LeftButton == ButtonState.Released;
        }

        public static bool IsMouseLBottonUp()
        {
            return currentMouse.LeftButton == ButtonState.Released &&
                previousMouse.LeftButton == ButtonState.Pressed;
        }

        public static bool IsMouseButton()
        {
            return currentMouse.LeftButton == ButtonState.Pressed;
        }

        public static bool IsMouseRButtonDown()
        {
            return currentMouse.LeftButton == ButtonState.Pressed &&
                previousMouse.LeftButton == ButtonState.Released;
        }

        public static bool IsMouseRButtonUp()
        {
            return currentMouse.LeftButton == ButtonState.Pressed &&
                previousMouse.LeftButton == ButtonState.Released;
        }

        public static bool IsMouseRButton()
        {
            return currentMouse.LeftButton == ButtonState.Pressed &&
                previousMouse.LeftButton == ButtonState.Released;
        }

        public static Vector2 MousePosition
        {
            get
            {
                return new Vector2(currentMouse.X, currentMouse.Y);
            }
        }

        public static int GetMouseWheel()
        {
            return previousMouse.ScrollWheelValue -
                currentMouse.ScrollWheelValue;
        }
    }
}
