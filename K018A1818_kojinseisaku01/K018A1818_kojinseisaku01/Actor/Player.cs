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
    class Player : Character
    {
        private PlayerState playerState;
        private WeaponState weaponState;
        int direction;
        private bool weaponFlag;
        private int weaponCount;
        private Sound sound;

        enum PlayerState
        {
            None,
            Right,
            Left,
        }

        enum WeaponState
        {
            Normal,
            Dual,
        }

        public Player(Vector2 position,ICharacterMediator mediator)
            : base("player", new Vector2(190, 550),20, mediator)
        {
            SetState("none");
            weaponState = WeaponState.Normal;
            this.position = position;
            var gameDevice = GameDevice.Instance();
            sound = gameDevice.GetSound();
            Initialize();
        }

        public void Initialize()
        {
            
            SetState("none");
            weaponState = WeaponState.Normal;
            weaponFlag = false;
            weaponCount = 0;
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            
            if (position.X > Screen.Width + 25)
            {
                position.X = 0;
            }
            if (position.X < -25)
            {
                position.X = Screen.Width; 
            }
            
            if (playerState == PlayerState.None && Input.GetKeyTrigger(Keys.Space))
            {
                SetState("right");
            }
            else if (playerState == PlayerState.Right && Input.GetKeyTrigger(Keys.Space))
            {
                SetState("left");
            }
            else if (playerState == PlayerState.Left && Input.GetKeyTrigger(Keys.Space))
            {
                SetState("right");
            }

            
            

            if (playerState==PlayerState.Right||playerState == PlayerState.Left)
            {
                position.X += direction;
            }
            
            if (weaponState == WeaponState.Normal && Input.GetKeyTrigger(Keys.Space))
            {
                mediator.AddCharacter(new Bullet(position + new Vector2(0.0f, -radius), mediator));
                sound.PlaySE("shot5");
            }

            if (weaponState == WeaponState.Dual && Input.GetKeyTrigger(Keys.Space))
            {
                mediator.AddCharacter(new BulletLeft(position + new Vector2(0.0f, -radius), mediator));
                mediator.AddCharacter(new BulletRight(position + new Vector2(0.0f, -radius), mediator));
                sound.PlaySE("shot5");
            }

            if (weaponFlag == true)
            {
                weaponCount++;
            }

            if (weaponCount >= 400)
            {
                weaponState = WeaponState.Normal;
                weaponCount = 0;
                weaponFlag = false;

            }


        }

        public override void Hit(Character character)
        {
            if (character is Enemy||character is BossZako)
            {
                isDead = true;
                
            }

            if (character is Item)
            {
                weaponState = WeaponState.Dual;
                weaponFlag = true;
                weaponCount = 0;
                sound.PlaySE("powerup05");
            }
        }

        

        public Vector2 GetPosition()
        {
            return position;
        }

        public void SetState(string mode)
        {
            if (mode == "none")
            {
                playerState = PlayerState.None;
            }
            else if (mode == "right")
            {
                playerState = PlayerState.Right;
                direction = 7;
            }
            else if (mode == "left")
            {
                playerState = PlayerState.Left;
                direction = -7;
            }
        }
               
        public void Shutdown()
        {

        }
    }
}
