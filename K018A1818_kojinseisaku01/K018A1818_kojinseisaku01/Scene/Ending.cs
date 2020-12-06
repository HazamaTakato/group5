using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using K018A1818_kojinseisaku01.Device;
using Microsoft.Xna.Framework;
using K018A1818_kojinseisaku01.Def;
using Microsoft.Xna.Framework.Input;

namespace K018A1818_kojinseisaku01.Scene
{
    class Ending : IScene
    {
        private bool isEndFlag;
        IScene backGroundScene;
        private Sound sound;

        public Ending()
        {
            isEndFlag = false;
           
        }

        public void Draw(Renderer renderer)
        {

            renderer.Begin();
            renderer.DrawTexture("Over", Vector2.Zero);
            renderer.End();
        }

        public void Initialize()
        {
            isEndFlag = false;
            var gameDevice = GameDevice.Instance();
            sound = gameDevice.GetSound();
        }

        public bool IsEnd()
        {
            return isEndFlag;
        }

        public Scene Next()
        {
            return Scene.Title;
        }

        public void Shutdown()
        {

        }

        public void Update(GameTime gameTime)
        {
            sound.PlayBGM("Over");

            if (Input.GetKeyTrigger(Keys.Space))
            {
                sound.PlaySE("titlese");
                isEndFlag = true;
            }
        }
    }
}
