using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K018A1818_kojinseisaku01.Scene;
using K018A1818_kojinseisaku01.Def;

namespace K018A1818_kojinseisaku01.Actor
{
    class Item : Character
    {

        public Item(Vector2 position, ICharacterMediator mediator)
            : base("Item", position, 20, mediator)
        {

        }

        public override void Update(GameTime gameTime)
        {
            position = position + new Vector2(0f, 4.0f);
            if (position.Y > (Screen.Height + radius))
            {
                isDead = true;
            }

        }

        public override void Hit(Character character)
        {
            if (character is Player)
            {
                isDead = true;
            }
        }
    }
}
