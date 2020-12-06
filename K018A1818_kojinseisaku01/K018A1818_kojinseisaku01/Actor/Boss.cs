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
    class Boss : Character
    {
        private Vector2 velocity;
        int hp = 20;
        int yokoidou;
        private Random rnd;
        int end;
        int endCounter;

        public Boss(Vector2 position,ICharacterMediator mediator)
            : base("boss", position, 64, mediator)
        {
            velocity = new Vector2(0.0f, 2.0f);
            hp = 50;
            yokoidou = 2;
            rnd = new Random();
            end = 25;
            endCounter = 0;
        }

        public override void Update(GameTime gameTime)
        {
            position = position + velocity;

            if (position.Y >= 100)
            {
                velocity = new Vector2(yokoidou, 0);
            }
            if (position.X >= Screen.Width - radius)
            {
                yokoidou = -2;
            }
            if (position.X <= 0 + radius)
            {
                yokoidou = 2;
            }

            if (rnd.Next(25) == 0)
            {
                var zakoposition = new Vector2(position.X,position.Y + radius);
                mediator.AddCharacter(new BossZako(zakoposition, mediator));
            }



            if (hp <1)
            {
                hp = 51;
                radius = 0;
                name = "toumei";
                var bakuhaposition = new Vector2(position.X-radius, position.Y-radius);
                mediator.AddCharacter(new BossEffect(bakuhaposition, mediator));
            }

            if (hp > 50)
                endCounter++;

            if (endCounter >= end)
            {
                endCounter = 0;
                
                EnemyFlag.bossDead = true;

                isDead = true;
            }
        }

        public override void Hit(Character character)
        {
            if (character is Bullet)
            {
                hp -= 1;
                
            }
            if (character is BulletLeft || character is BulletRight)
            {
                hp -= 1;
                
            }
        }
    }
}
