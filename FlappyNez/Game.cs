using FlappyNez.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace FlappyNez
{
    public class Game : Core
    {
        public bool Paused { get; set; }
        static Game instance;
        private KeyboardState _currentKeyboardState;
        private KeyboardState _previousKeyboardState;

        public static Game Instance
        {
            get { return instance; }
        }

        public Game() : base(width: 320, height: 480, isFullScreen: false, enableEntitySystems: false)
        {
            instance = this;
        }

        protected override void Initialize()
        {
            base.Initialize();

            Window.AllowUserResizing = false;
            pauseOnFocusLost = true;
            Paused = false;

#if DEBUG
            debugRenderEnabled = true;
#else
            debugRenderEnabled = false;
#endif

            // Load up your initial scene here
            scene = new Level();
        }

        protected override void Update(GameTime gameTime)
        {
            // Before handling input
            _currentKeyboardState = Keyboard.GetState();

            if (_currentKeyboardState.IsKeyDown(Keys.Pause) &&
               _previousKeyboardState.IsKeyUp(Keys.Pause))
                Paused = !Paused;

            // After handling input
            _previousKeyboardState = _currentKeyboardState;

            if (Paused)
            {
                SuppressDraw();
                return;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (Paused)
                return;

            base.Draw(gameTime);
        }
    }
}