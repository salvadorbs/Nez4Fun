using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Pong_Clone_Nez.Scenes;

namespace Pong_Clone_Nez
{
    public class Game : Core
    {
        public Game() : base(width: 800, height: 485, isFullScreen: false)
        {}

        protected override void Initialize()
        {
            base.Initialize();

            scene = Scene.createWithDefaultRenderer<Level>(Color.Coral);
            //TODO: Menu (or StartScreen)
            //TODO: Support pause
        }
    }
}
