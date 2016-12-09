using FlappyNez.Scenes;
using Microsoft.Xna.Framework;
using Nez;

namespace FlappyNez
{
    public class Game : Core
    {
        public Game() : base(width: 320, height: 480, isFullScreen: false, enableEntitySystems: false)
        { }

        protected override void Initialize()
        {
            base.Initialize();

            Window.AllowUserResizing = false;

#if DEBUG
            debugRenderEnabled = true;
#else
            debugRenderEnabled = false;
#endif

            // Load up your initial scene here
            scene = new Level();
        }
    }
}