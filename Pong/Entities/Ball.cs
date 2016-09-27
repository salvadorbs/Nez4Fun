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
        ArcadeRigidbody rigidbody;

        public override void onAddedToEntity()
        {
            //Load ball sprite and add it in entity
            _ballSprite = entity.scene.content.Load<Texture2D>(Content.Sprites.ball);
            entity.addComponent(new Sprite(_ballSprite));

            //Collider and Mover components
            entity.colliders.add(new CircleCollider());

            //RigidBody
            rigidbody = new ArcadeRigidbody()
                        .setMass(0.0001f)
                        .setFriction(0f)
                        .setElasticity(1f);
            rigidbody.shouldUseGravity = false;
            entity.addComponent(rigidbody);

            //Position and
            Reset();
        }

        public void Reset()
        {
            this.transform.position = new Vector2(Screen.width / 2 - 75, Screen.height / 2);
            moveSpeed *= -1;
            rigidbody.setVelocity(moveSpeed);
        }

        void IUpdatable.update()
        {

        }

        void ITriggerListener.onTriggerEnter(Collider other, Collider self)
        {

        }


        void ITriggerListener.onTriggerExit(Collider other, Collider self)
        {

        }
    }
}
