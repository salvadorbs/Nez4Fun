using System;
using Microsoft.Xna.Framework.Input;
using FlappyNez.Scenes;
using Nez;

namespace FlappyNez.Components
{
    class LevelController : SceneComponent
    {
        readonly VirtualButton _inputReset = new VirtualButton();

        public LevelController()
        {
            _inputReset.addKeyboardKey(Keys.F1);
        }

        public override void update()
        {
            // Reset level
            if (_inputReset.isPressed)
                Core.scene = new Level();
        }
    }
}