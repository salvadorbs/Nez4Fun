using System;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Pong_Clone_Nez.Components
{
    class PlayerController : Component, IUpdatable
    {
        VirtualIntegerAxis _yAxisInput = new VirtualIntegerAxis();
        float _moveSpeed = 300f;
        Mover _mover;

        public override void onAddedToEntity()
        {
            _mover = entity.addComponent(new Mover());

            //Vertical input keyboard up/down and position
            if (entity.name == "player")
            {
                //First player - Up/Down
                entity.transform.position = new Vector2(40, Screen.height / 2);
                _yAxisInput.nodes.Add(new Nez.VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.W, Keys.S));
            }
            else
            {
                //Second player - W/S
                entity.transform.position = new Vector2(Screen.width - 40, Screen.height / 2);
                _yAxisInput.nodes.Add(new Nez.VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.Up, Keys.Down));
            }
        }

        void IUpdatable.update()
        {
            //Handle movement
            if (_yAxisInput != null)
            {
                var moveDir = new Vector2(0, _yAxisInput.value);

                if (moveDir != Vector2.Zero)
                {
                    var movement = moveDir * _moveSpeed * Time.deltaTime;

                    CollisionResult res;
                    _mover.move(movement, out res);
                }
            }
        }
    }
}
