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
    class CharacterControl :ICharacterMediator
    {
        private LinkedList<Character> characters;
        private List<Character> newCharacters;
        public CharacterControl() { }
        public void Initialize()
        {
            if (characters != null)
            {
                characters.Clear();
            }
            characters = new LinkedList<Character>();
            newCharacters = new List<Character>();
        }
        public bool Add(Character character)
        {
            characters.AddLast(character);
            return true;
        }
        public void Update(GameTime gameTime)
        {
            foreach(Character c in characters)
            {
                c.Update(gameTime);
            }
            New();
            Hit();
            Remove();
        }
        private void New()
        {
            foreach (Character c in newCharacters)
            {
                Add(c);
            }
            newCharacters.Clear();
        }
        private void Hit()
        {
            foreach( Character c1 in characters)
            {
                foreach(Character c2 in characters)
                {
                    if (c1.Collision(c2))
                    {
                        c1.Hit(c2);
                        c2.Hit(c1);
                    }
                }
            }
        }
        private void Remove()
        {
            LinkedListNode<Character> node = characters.First;
            while(node != null)
            {
                LinkedListNode<Character> next = node.Next;
                if (node.Value.IsDead())
                {
                    characters.Remove(node);
                }
                node = next;
            }
        }
        public bool IsPlayerDead()
        {
            foreach(Character c in characters)
            {
                if (c is Player)
                {
                    return false;
                }
            }
            return true;
        }


        public void Draw(Renderer renderer)
        {
            foreach( Character c in characters)
            {
                c.Draw(renderer);
            }
        }
        public void AddCharacter(Character character)
        {
            newCharacters.Add(character);
        }
    }
}
