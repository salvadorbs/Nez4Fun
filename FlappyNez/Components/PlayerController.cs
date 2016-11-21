using FlappyNez.Entities;
using FlappyNez.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace FlappyNez.Components
{
    class PlayerController : Component, IUpdatable
    {
        readonly VirtualButton _input = new VirtualButton();
        readonly VirtualButton _inputReset = new VirtualButton();

        public override void onAddedToEntity()
        {
            // Touch
            Input.touch.enableTouchSupport();

            // Keyboard/Mouse/Joystick
            _input.addKeyboardKey(Keys.Space);
            _input.addMouseLeftButton();
            _input.addGamePadButton(0, Buttons.A);

            _inputReset.addKeyboardKey(Keys.F1);
        }

        void IUpdatable.update()
        {
            // Jump (velocity to 0 and addforce in up)
            if (((entity.scene as Level).State == LevelState.Play) && _input.isPressed)
            {
                ((Player)entity).Velocity = Vector2.Zero;
                ((Player)entity).addForce(Constants.PlayerSpeed);
            }

            if (_inputReset.isPressed)
                Core.scene = Scene.createWithDefaultRenderer<Level>(Color.MonoGameOrange);
        }
    }
}
