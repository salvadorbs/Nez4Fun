using Microsoft.Xna.Framework;
using Nez;
using FlappyNez.Scenes;


namespace FlappyNez
{
    public class Game : Core
    {
        public Game() : base(width: 320, height: 480, isFullScreen: false, enableEntitySystems: false)
        {}

        protected override void Initialize()
        {
            base.Initialize();

            Window.AllowUserResizing = false;
            debugRenderEnabled = true;

            //Load up your initial scene here
            scene = Scene.createWithDefaultRenderer<Level>(Color.MonoGameOrange);
        }
    }
}

