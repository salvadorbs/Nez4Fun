using System.Collections.Generic;
using FlappyNez.Components;
using FlappyNez.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Textures;

namespace FlappyNez.Entities
{
    class Player : Entity
    {
        readonly Mover _mover;

        Sprite<Animations> _animation;

        public Vector2 Velocity;

        public IScore Score { get; set; }

        enum Animations
        {
            Idle,
            Run
        }

        public Player() : base("Plane")
        {
            // Collider component - isTrigger to true because use of TriggerListeners
            addCollider(new CircleCollider())
                .isTrigger = true;

            // Mover component
            // Set velocity to 0 and make gravity does all the work
            _mover = addComponent(new Mover());
            Velocity = Vector2.Zero;

            // Setup Input
            addComponent(new PlayerController());

            // Initial position
            transform.position = Constants.PlayerInitialPos;
        }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            // Add component for collision triggers
            addComponent(new PlayerTriggerListener(Score));

            // Create Subtexture list and add frames in it
            var frameList = new List<Subtexture>();
            frameList.Add(new Subtexture(scene.content.Load<Texture2D>(Content.Planes.planeBlue1)));
            frameList.Add(new Subtexture(scene.content.Load<Texture2D>(Content.Planes.planeBlue2)));
            frameList.Add(new Subtexture(scene.content.Load<Texture2D>(Content.Planes.planeBlue3)));

            // Add animation frames in entity and play Run animation
            _animation = addComponent(new Sprite<Animations>(frameList[0]));
            _animation.addAnimation(Animations.Run, new SpriteAnimation(frameList));
            _animation.addAnimation(Animations.Idle, new SpriteAnimation(frameList[0]));
            _animation.play(Animations.Run);
        }

        public void addForce(Vector2 force)
        {
            // Force is an acceleration in pixels per second per second. It is multiplied by
            // 100000 to make the values more reasonable to use
            Velocity += force * 100000 * (Time.deltaTime * Time.deltaTime);
        }

        public override void update()
        {
            base.update();

            // Move in vertical using Nez.Physics.gravity
            CollisionResult res;
            Velocity += Physics.gravity * Time.deltaTime;
            _mover.move((Velocity * Time.deltaTime), out res);

            // Check LevelState
            if ((scene as Level).State == LevelState.Play)
            {
                // Simple rotation based of velocity.Y
                transform.rotationDegrees = Mathf.clamp(Velocity.Y / 10, 0, 90);
            }
            else
            {
                // Simple rotation (and falling by gravity) as death animation
                transform.rotationDegrees += 5;
            }
        }
    }
}