using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using K018A1818_kojinseisaku01.Device;

namespace K018A1818_kojinseisaku01.Scene
{
    interface IScene
    {
        void Initialize();

        void Update(GameTime gameTime);

        void Draw(Renderer renderer);

        void Shutdown();

        bool IsEnd();

        Scene Next();
    }
}
