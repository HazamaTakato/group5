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
    
    class Bullet : Character
    {
        public Bullet(Vector2 position, ICharacterMediator mediator)
            : base("Shoot", position, 20, mediator)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            position = position + new Vector2(0f, -13.0f);
            if (position.Y < (0.0f - radius))
            {
                isDead = true;
            }

        }

        public override void Hit(Character character)
        {
            if (character is Boss)
            {
                isDead = true;
                var ePosition = new Vector2(position.X - radius, position.Y - radius*2);
                mediator.AddCharacter(new Effect(ePosition, mediator));
            }

            if (character is Enemy)
            {
                isDead = true;
                
            }

            if (character is BossZako)
            {
                isDead = true;
                
            }
        }
        
    }
}
