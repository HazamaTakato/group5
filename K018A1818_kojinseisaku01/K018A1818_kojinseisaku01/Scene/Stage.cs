using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using K018A1818_kojinseisaku01.Device;

namespace K018A1818_kojinseisaku01.Scene
{
    class Stage
    {
        private Vector2 position;
        float scrollSpeed = 5.0f;

        public void Update(GameTime gameTime)
        {
            position.Y += scrollSpeed;

            if (position.Y >= 700)
            {
                position.Y = 0;
            }
        }

        public void Draw(Renderer renderer)
        {
            renderer.DrawTexture("stage", position);
            renderer.DrawTexture("stage", position - new Vector2(0,700));
        }
    }
}
