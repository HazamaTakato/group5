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
    class BossZako : Character
    {
        private int time;
        private int cout;
        private Vector2 velocity;

        public BossZako(Vector2 position, ICharacterMediator mediator)
            : base("enemy", position, 20, mediator)
        {
            time = 30;
            cout = 0;
            velocity = new Vector2(0.0f, 3.0f);
           
        }

        public override void Update(GameTime gameTime)
        {
            position = position + velocity;
            


            if (position.Y >= 550)
            {
                velocity = new Vector2(0, 0);
                cout++;
            }
            if (cout >= time)
            {
                isDead = true;
                cout = 0;
                EnemyFlag.enemyDead = true;
                var ePosition = new Vector2(position.X - radius, position.Y - radius);
                mediator.AddCharacter(new Effect(ePosition, mediator));
            }

        }

        public override void Hit(Character character)
        {
            if (character is Bullet || character is Player)
            {
                isDead = true;
                EnemyFlag.enemyDead = true;
                var ePosition = new Vector2(position.X - radius, position.Y - radius);
                mediator.AddCharacter(new Effect(ePosition, mediator));
            }
            if (character is BulletLeft || character is BulletRight)
            {
                isDead = true;
                EnemyFlag.enemyDead = true;
                var ePosition = new Vector2(position.X - radius, position.Y - radius);
                mediator.AddCharacter(new Effect(ePosition, mediator));
            }

        }

        public Vector2 GetPosition()
        {
            return position;
        }
    }
}
