using FlappyNez.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace FlappyNez.Entities
{
    class Player : Entity
    {
        public Player() : base("Plane")
        {
            // Collider component
            addCollider(new BoxCollider());

            // RigidBody component
            // No need to set a velocity because gravity does all the work
            var rigidbody = new ArcadeRigidbody()
                        .setMass(1f)
                        .setVelocity(Vector2.Zero);
            addComponent(rigidbody);
            addComponent(new PlayerController());

            // Position
            transform.position = Constants.PlayerInitialPos;
        }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            // Load sprite and add it in entity
            // TODO: Simple plane animation and rotation (down and up)
            addComponent(new Sprite(scene.content.Load<Texture2D>(Content.Planes.planeBlue1)));
        }
    }
}
