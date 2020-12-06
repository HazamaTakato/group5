using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K018A1818_kojinseisaku01.Device;

namespace K018A1818_kojinseisaku01.Actor
{
    class BulletRight:Character
    {
        public BulletRight(Vector2 position, ICharacterMediator mediator)
            : base("Shoot", position, 20, mediator)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            position = position + new Vector2(1.5f, -10.0f);
            if (position.Y < (0.0f - radius))
            {
                isDead = true;
            }

        }

        public override void Hit(Character character)
        {
            if (character is Enemy)
            {
                isDead = true;
            }
            if (character is Boss)
            {
                isDead = true;
                var ePosition = new Vector2(position.X - radius, position.Y - (radius *2));
                mediator.AddCharacter(new Effect(ePosition, mediator));
            }
            if (character is BossZako)
            {
                isDead = true;
                
            }
        }
    }
}
