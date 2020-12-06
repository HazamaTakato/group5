using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K018A1818_kojinseisaku01.Def;
using K018A1818_kojinseisaku01.Device;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace K018A1818_kojinseisaku01.Scene
{
    class Title : IScene
    {
        private bool isEndFlag;
        IScene backGroundScene;
        private Sound sound;

        public Title()
        {
            isEndFlag = false;

        }

        public bool IsEnd()
        {
            return isEndFlag;
        }

        public void Draw(Renderer renderer)
        {

            renderer.Begin();
            renderer.DrawTexture("Title", Vector2.Zero);
            
            renderer.End();
        }

        public Scene Next()
        {
            return Scene.Tutorial;
        }

        public void Update(GameTime gameTime)
        {
            sound.PlayBGM("Title");
            if (Input.GetKeyTrigger(Keys.Space))
            {
                sound.PlaySE("titlese");
                isEndFlag = true;
            }

        }

        public void Initialize()
        {
            isEndFlag = false;
            var gameDevice = GameDevice.Instance();
            sound = gameDevice.GetSound();
            EnemyFlag.Reset();
        }

        public void Shutdown()
        {

        }


        
    }
}
