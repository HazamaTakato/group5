using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using K018A1818_kojinseisaku01.Device;
using Microsoft.Xna.Framework.Input;
using K018A1818_kojinseisaku01.Actor;
using K018A1818_kojinseisaku01.Utill;
using Microsoft.Xna.Framework.Content;
using K018A1818_kojinseisaku01.Def;
using System.Security.Cryptography;
using Microsoft.Xna.Framework.Graphics;


namespace K018A1818_kojinseisaku01.Scene
{
    class Tutorial : IScene
    {
        private bool isEndFlag;
        private string name;
        private bool flag1;
        private bool flag2;
        private bool flag3;
        private bool flag4;
        private Sound sound;
        public Tutorial()
        {

        }

        public void Initialize()
        {
            var gameDevice = GameDevice.Instance();
            sound = gameDevice.GetSound();
            isEndFlag = false;
            name = "tutorial1";
            flag1 = false;
            flag2 = false;
            flag3 = false;
            flag4 = true;
            
        }

        public void Update(GameTime gameTime)
        {
            if (flag4 == true && Input.GetKeyTrigger(Keys.Space))
            {
                sound.PlaySE("titlese");
                name = "tutorial2";
                flag4 = false;
                flag1 = true;
                
            }
            else if (flag1 == true && Input.GetKeyTrigger(Keys.Space))
            {
                sound.PlaySE("titlese");
                name = "tutorial3";
                flag1 = false;
                flag2 = true;
            }
            else if (flag2 == true && Input.GetKeyTrigger(Keys.Space))
            {
                sound.PlaySE("titlese");
                name = "tutorial4";
                flag2 = false;
                flag3 = true;
            }
            else if (flag3 == true && Input.GetKeyTrigger(Keys.Space))
            {
                sound.PlaySE("titlese");
                isEndFlag = true;
            }
            
        }

        public bool IsEnd()
        {
            return isEndFlag;
        }

        public void Draw(Renderer renderer)
        {
            renderer.Begin();
            renderer.DrawTexture(name, Vector2.Zero);
            renderer.End();
        }

        public Scene Next()
        {
            return Scene.GamePlay;
        }

        public void Shutdown()
        {

        }

        
    }
}
