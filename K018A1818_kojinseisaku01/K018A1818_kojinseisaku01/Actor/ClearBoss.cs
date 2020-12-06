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
    
    class ClearBoss : Character
    {
        private BossEffect BossEffect;
        private bool cbeFlag;
        public ClearBoss(Vector2 position, ICharacterMediator mediator)
            :base("boss",position, 64, mediator)
        {
            this.position = position;
            this.mediator = mediator;
            var bakuhaposition = new Vector2(position.X - radius, position.Y - radius);
            BossEffect = new BossEffect(bakuhaposition, mediator);
            cbeFlag = false;
        }

        public override void Update(GameTime gameTime)
        {
            if (EnemyFlag.clearBossDead == true)
            {
                name = "toumei";
                BossEffect.Update(gameTime);
                cbeFlag = true;
                isDead = true;
            }
        }

        public override void Hit(Character character)
        {

        }

        public override void Draw(Renderer renderer)
        {
            base.Draw(renderer);
            if (cbeFlag == true)
            {
                BossEffect.Draw(renderer);
            }
        }


    }
}
