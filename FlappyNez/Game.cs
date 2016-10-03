using Microsoft.Xna.Framework;
using Nez;
using FlappyNez.Scenes;


namespace FlappyNez
{
    public class Game : Core
    {
        public Game() : base(width: 600, height: 800, isFullScreen: false, enableEntitySystems: false)
        {}

        protected override void Initialize()
        {
            base.Initialize();

            //Window.AllowUserResizing = true;

            // load up your initial scene here
            scene = Scene.createWithDefaultRenderer<Level>(Color.MonoGameOrange);
        }
    }
}

