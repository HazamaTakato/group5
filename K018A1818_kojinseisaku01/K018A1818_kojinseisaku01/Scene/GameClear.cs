using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using K018A1818_kojinseisaku01.Device;
using Microsoft.Xna.Framework;
using K018A1818_kojinseisaku01.Def;
using Microsoft.Xna.Framework.Input;
using K018A1818_kojinseisaku01.Actor;

namespace K018A1818_kojinseisaku01.Scene
{
    class GameClear : IScene
    {
        private bool isEndFlag;
        IScene backGroundScene;
        private Sound sound;
        int end;
        int endCounter;
        private ClearBoss boss;
        private ICharacterMediator mediator;

        public GameClear()
        {
            isEndFlag = false;
            
        }


        public void Draw(Renderer renderer)
        {

            renderer.Begin();
            renderer.DrawTexture("Clear", Vector2.Zero);
            boss.Draw(renderer);
            renderer.End();
        }

        public void Initialize()
        {
            var gameDevice = GameDevice.Instance();
            sound = gameDevice.GetSound();
            isEndFlag = false;
            end = 25;
            endCounter = 0;
            boss = new ClearBoss(new Vector2(190, 300), mediator);
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
            sound.PlayBGM("Clear");
            boss.Update(gameTime);


            if (Input.GetKeyTrigger(Keys.Space))
            {
                EnemyFlag.clearBossDead = true;
                
            }
            if (EnemyFlag.clearBossDead == true)
            {
                endCounter++;
            }
            if (endCounter > end)
            {
                isEndFlag = true;
                endCounter = 0;
            }
        }
    }
}
