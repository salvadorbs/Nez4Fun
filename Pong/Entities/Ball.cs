using System;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Pong_Clone_Nez
{
    public class Ball : Component, ITriggerListener, IUpdatable
    {
        public Vector2 moveSpeed = new Vector2(300, 300);
        Texture2D _ballSprite;
        ArcadeRigidbody _rigidbody;

        public override void onAddedToEntity()
        {
            //Load ball sprite and add it in entity
            _ballSprite = entity.scene.content.Load<Texture2D>(Content.Sprites.ball);
            entity.addComponent(new Sprite(_ballSprite));

            //Collider component
            entity.colliders.add(new CircleCollider());

            //RigidBody component
            _rigidbody = new ArcadeRigidbody()
                        .setMass(0.0001f)
                        .setFriction(0f)
                        .setElasticity(1f);
            _rigidbody.shouldUseGravity = false;
            entity.addComponent(_rigidbody);

            //Position and
            Reset();
        }

        public void Reset(bool fromPlayer1 = true)
        {
            transform.position = new Vector2(Screen.width / 2 + 75 * (fromPlayer1 ? -1 : 1), Screen.height / 2);
            _rigidbody.setVelocity(moveSpeed * (fromPlayer1 ? 1 : -1));
        }

        void IUpdatable.update()
        {

        }

        void ITriggerListener.onTriggerEnter(Collider other, Collider self)
        {
            //TODO: Modifier ball's speed
        }


        void ITriggerListener.onTriggerExit(Collider other, Collider self)
        {

        }
    }
}
