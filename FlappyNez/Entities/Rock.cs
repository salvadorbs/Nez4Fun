using FarseerPhysics;
using FarseerPhysics.Dynamics;
using FlappyNez.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Farseer;
using Nez.Sprites;
using Nez.Textures;

namespace FlappyNez.Entities
{
    class Rock : Entity
    {
        readonly int _offset;
        readonly Mover _mover;
        string _spritePath = string.Empty;
        Sprite _sprite;
        float _rockHeight;

        public bool IsUp;

        public Rock(int offset = 0, bool isUp = true) : base()
        {
            this.IsUp = isUp;
            _offset = offset;

            if (isUp)
            {
                name = "Rock_Down";
                _spritePath = Content.Terrain.rockGrassDown;
            }
            else
            {
                name = "Rock_Up";
                _spritePath = Content.Terrain.rockGrass;
            }

            // Mover component
            _mover = addComponent(new Mover());
        }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            // Load sprite and add it in entity
            var _texture = scene.content.Load<Texture2D>(_spritePath);
            _sprite = addComponent(new Sprite(_texture));

            // Polygon Collider - isTrigger to true because use of TriggerListeners
            addComponent(new PolygonCollider(Utils.GetVerticesTexture(_texture)))
                .isTrigger = true;

            // RenderLayer to 1 because monogame must draws rock behind terrain
            _sprite.renderLayer = 1;

            ResetPosition();
        }

        private void ResetPosition()
        {
            var _gapHeight = MathHelper.Clamp(Constants.GapHeight, (_sprite.height / 2), _sprite.height);
            var realRockHeight = (Screen.height - _gapHeight) / 2;
            var nominalRockHeight = (_sprite.height / 2) - (_sprite.height - realRockHeight);
            _rockHeight = IsUp ? (_offset + nominalRockHeight) : (_offset + Screen.height - nominalRockHeight);

            transform.position = new Vector2((Screen.width), IsUp ? (-_sprite.height / 2) : (Screen.height + _sprite.height / 2));
        }

        public override void update()
        {
            base.update();

            CollisionResult res;
            int vertical;

            if ((scene as Level).State == LevelState.Play)
            {
                // Move rock in Y or not?
                if (IsUp)
                    vertical = (transform.position.Y < (_rockHeight)) ? 5 : 0;
                else
                    vertical = (transform.position.Y > (_rockHeight)) ? -5 : 0;

                // Move rock in two coords - X forever - Y until _RockHeight
                _mover.move(new Vector2(-1, vertical) * Constants.ObstaclesSpeed * Time.deltaTime, out res);

                // Destroy entity when it goes out of screen
                if (transform.position.X <= -(_sprite.width / 2))
                    this.destroy();
            }
        }
    }
}
