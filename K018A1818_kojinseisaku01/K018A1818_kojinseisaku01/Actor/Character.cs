using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using K018A1818_kojinseisaku01.Device;

namespace K018A1818_kojinseisaku01.Actor
{
    abstract class Character
    {
        protected string name;
        protected Vector2 position;
        protected float radius;
        protected bool isDead = false;

        protected ICharacterMediator mediator;


        public abstract void Update(GameTime gameTime);
        public abstract void Hit(Character character);

        public Character(string name, Vector2 position, float radius, ICharacterMediator mediator)
        {
            this.name = name;
            this.position = position;
            this.radius = radius;
            this.mediator = mediator;
        }
       

        public virtual void Draw(Renderer renderer)
        {
            renderer.DrawTexture(name, position - new Vector2(radius, radius));
        }
        public bool IsDead()
        {
            return isDead;
        }
        public bool Collision(Character character)
        {
            if (Vector2.Distance(this.position, character.position) <= (this.radius + character.radius))
            {
                return true;
            }
            return false;
        }
    }
}
