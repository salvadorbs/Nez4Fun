using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace FlappyNez.Components
{
    class PlayerController : Component, IUpdatable
    {
        VirtualButton _input = new VirtualButton();

        public override void onAddedToEntity()
        {
            // Keyboard/Mouse/Touch/Joystick
            Input.touch.enableTouchSupport();
            _input.nodes.Add(new Nez.VirtualButton.KeyboardKey(Keys.Space));
            _input.nodes.Add(new Nez.VirtualButton.MouseLeftButton());
            _input.nodes.Add(new Nez.VirtualButton.GamePadButton(0, Buttons.A));
        }

        void IUpdatable.update()
        {
            var rigidbody = entity.getComponent<ArcadeRigidbody>();

            if (rigidbody != null)
            {
                if (_input.isPressed && (rigidbody.velocity.Y >= 0))
                {
                    rigidbody.setVelocity(Vector2.Zero);
                    rigidbody.addImpulse(Constants.PlayerSpeed);
                }
            }
        }
    }
}
