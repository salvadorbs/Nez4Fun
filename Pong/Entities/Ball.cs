using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace Pong_Clone_Nez.Entities
{
    public class Ball : Entity
    {
        Vector2 _moveSpeed = new Vector2(300, 300);
        Texture2D _ballSprite;
        ArcadeRigidbody _rigidbody;

        public Ball() : base("Ball")
        {
            // Collider component
            colliders.add(new CircleCollider());

            // RigidBody component
            _rigidbody = new ArcadeRigidbody()
                        .setMass(0.0001f)
                        .setFriction(0f)
                        .setElasticity(1f);
            _rigidbody.shouldUseGravity = false;
            addComponent(_rigidbody);
        }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            // Load ball sprite and add it in entity
            _ballSprite = scene.content.Load<Texture2D>(Content.Sprites.ball);
            addComponent(new Sprite(_ballSprite));

            // Reset position
            Reset();
        }

        public void Reset(bool fromPlayer1 = true)
        {
            transform.position = new Vector2(Screen.width / 2 + 75 * (fromPlayer1 ? -1 : 1), Screen.height / 2);
            _rigidbody.setVelocity(_moveSpeed * (fromPlayer1 ? 1 : -1));
        }
    }
}
