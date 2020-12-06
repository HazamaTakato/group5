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
    class GamePlay : IScene
    {
        private bool isEndflag;
        
        private Random rnd;
        private CharacterControl characterControl;

        private Stage stage;
        private Scene next;
        private ICharacterMediator mediator;

        private float enemyInterval;
        private float enemyIntervalCount;
        private float enemyCountNumber;
        private int enemyDeadCount;
        private Sound sound;

        private bool bossFlag;



        public GamePlay()
        {
        }

        public void Draw(Renderer renderer)
        {
            renderer.Begin();
           
            stage.Draw(renderer);
            
            characterControl.Draw(renderer);

            renderer.End();
        }

        public void Initialize()
        {
            EnemyFlag.Reset();
            isEndflag = false;
            stage = new Stage();
            rnd = new Random();
            
            var gameDevice = GameDevice.Instance();
            sound = gameDevice.GetSound();
            bossFlag = false;

            characterControl = new CharacterControl();
            characterControl.Initialize();
            characterControl.Add(new Player(new Vector2(190, 550), characterControl));
            
            
            rnd = new Random();
            enemyCountNumber = 2.0f;
            enemyInterval = 100.0f;
            enemyIntervalCount = 0.0f;

            enemyDeadCount = 0;

            
        }

        public bool IsEnd()
        {
            return isEndflag;
        }



        public void Update(GameTime gameTime)
        {
            stage.Update(gameTime);
            
            characterControl.Update(gameTime);

            sound.PlayBGM("loop");

            enemyIntervalCount += enemyCountNumber;

            if (bossFlag == false && EnemyFlag.enemyDead == true)
            {
                enemyDeadCount += 1;
                EnemyFlag.enemyDead = false;
            }

            if (bossFlag == false)
            {
                if (enemyIntervalCount >= enemyInterval)
                {
                    var position = new Vector2(((float)rnd.Next(0 + 20, Screen.Width - 20)), (-Screen.Height - 20.0f));
                    characterControl.Add(new Enemy(position, characterControl));
                    enemyIntervalCount = 0;
                }

                if (rnd.Next(300) == 0)
                {
                    var position = new Vector2(((float)rnd.Next(0 + 20, Screen.Width - 20)), (-Screen.Height - 20.0f));
                    characterControl.Add(new Enemy(position, characterControl));
                }
            }

            if (enemyDeadCount > 10)
            {
                enemyCountNumber = 2.5f;
            }
            if (enemyDeadCount > 20)
            {
                enemyCountNumber = 3.5f;
            }
            if (enemyDeadCount > 40)
            {
                enemyCountNumber = 4.5f;
            }
            if (enemyDeadCount > 60)
            {
                enemyCountNumber =5.5f;
            }


            if (enemyDeadCount == 80)
            {
                bossFlag = true;
                enemyDeadCount = 0;
                var bossPosition = new Vector2(210, -400);
                characterControl.Add(new Boss(bossPosition, characterControl));
                
            }

            if (EnemyFlag.bossDead == true)
            {
                next = Scene.GameClear;
                isEndflag = true;
            }


            if (characterControl.IsPlayerDead())
            {
                next = Scene.Ending;
                isEndflag = true;
            }

            if (rnd.Next(900) == 0)
            {
                var position = new Vector2(((float)rnd.Next(0 + 20, Screen.Width - 20)), (-Screen.Height - 20.0f));
                characterControl.Add(new Item(position, characterControl));
            }

            
            

        }

        


        public void Shutdown()
        {

        }

        public Scene Next()
        {
            return next;
            
        }

        
    }
}
