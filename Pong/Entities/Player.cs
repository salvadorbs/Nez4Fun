using System;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Pong_Clone_Nez
{
    public class Player : Component, ITriggerListener, IUpdatable
    {
        VirtualIntegerAxis _yAxisInput;
        float _moveSpeed = 300f;
        Mover _mover;
        Texture2D _paddleSprite;

        public override void onAddedToEntity()
        {
            //Load paddle sprite and add it in entity
            _paddleSprite = entity.scene.content.Load<Texture2D>(Content.Sprites.paddle);
            entity.addComponent(new Sprite(_paddleSprite));

            //Collider and Mover components
            entity.colliders.add(new BoxCollider());
            _mover = entity.addComponent(new Mover());

            //Vertical input keyboard up/down and position
            _yAxisInput = new VirtualIntegerAxis();
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

        void ITriggerListener.onTriggerEnter(Collider other, Collider self)
        {

        }


        void ITriggerListener.onTriggerExit(Collider other, Collider self)
        {

        }
    }
}
