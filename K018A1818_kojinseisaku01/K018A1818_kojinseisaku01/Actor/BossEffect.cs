using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using K018A1818_kojinseisaku01.Def;
using K018A1818_kojinseisaku01.Device;
using K018A1818_kojinseisaku01.Scene;
using K018A1818_kojinseisaku01.Utill;

namespace K018A1818_kojinseisaku01.Actor
{
    class BossEffect : Character
    {
        private Timer timer;
        private int counter;
        private readonly int pictureNum = 7;
        private ICharacterMediator mediator;
        private Sound sound;

        public BossEffect(Vector2 position, ICharacterMediator mediator)
            : base("animationbig", position, 20, mediator)
        {
            this.position = position;
            this.mediator = mediator;
            var gameDevice = GameDevice.Instance();
            sound = gameDevice.GetSound();

            sound.PlaySE("bomb2");

            Initialize();
        }

        public void Initialize()
        {
            counter = 0;
            isDead = false;
            timer = new CountDownTimer(0.1f);
        }

        public override void Update(GameTime gameTime)
        {

            timer.Update(gameTime);

            if (timer.IsTime())
            {
                counter += 1;
                timer.Initialize();
                if (counter >= pictureNum)
                {
                    isDead = true;
                }
            }
        }

        public override void Hit(Character character)
        {
        }

        public override void Draw(Renderer renderer)
        {
            renderer.DrawTexture(name, position, new Rectangle(counter * 128, 0,
                128, 128));
        }
    }
}
