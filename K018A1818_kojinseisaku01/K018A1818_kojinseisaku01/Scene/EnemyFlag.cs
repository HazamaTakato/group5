using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K018A1818_kojinseisaku01.Scene
{
    static class EnemyFlag
    {
        public static bool enemyDead = false;
        public static bool bossDead = false;
        public static bool clearBossDead = false;

        public static void Reset()
        {
            enemyDead = false;
            bossDead = false;
            clearBossDead = false;
        }
    }
}
