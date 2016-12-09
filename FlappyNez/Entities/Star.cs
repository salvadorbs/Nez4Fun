using FlappyNez.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace FlappyNez.Entities
{
    class Star : Entity
    {
        readonly Mover _mover;
        readonly int _offset;
        Sprite _sprite;

        public bool FirstCollision { get; set; }

        public Star(int offset) : base("Star")
        {
            FirstCollision = true;

            // Collider component
            addComponent<BoxCollider>()
                .isTrigger = true;

            // Mover component
            _mover = addComponent(new Mover());

            _offset = offset;
        }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            // Load sprite and add it in entity
            var _texture = scene.content.Load<Texture2D>(Content.UI.starGold);
            _sprite = addComponent(new Sprite(_texture));

            transform.position = new Vector2(Screen.width + 12, (Screen.height / 2) + _offset);
        }

        public override void update()
        {
            base.update();

            if ((scene as Level).State == LevelState.Play)
            {
                // Move star with rocks in X
                CollisionResult res;
                _mover.move(new Vector2(-1, 0) * Constants.ObstaclesSpeed * Time.deltaTime, out res);

                // Very simple animation (rotation only)
                transform.rotationDegrees += 1;

                // Destroy entity when it goes out of screen
                if (transform.position.X <= -(_sprite.width / 2))
                    this.destroy();
            }
        }
    }
}