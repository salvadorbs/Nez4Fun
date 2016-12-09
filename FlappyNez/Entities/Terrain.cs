using System;
using FlappyNez.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace FlappyNez.Entities
{
    class Terrain : Entity
    {
        Collider[] colliderArray = new Collider[2];
        ScrollingSprite _sprite;

        public Terrain() : base("Terrain")
        { }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            // Load scrolling sprite
            var _texture = scene.content.Load<Texture2D>(Content.Terrain.groundGrass);
            _sprite = new ScrollingSprite(_texture)
            {
                scrollSpeedX = Constants.TerrainSpeed
            };
            addComponent(_sprite);

            // Two colliders
            for (int i = 0; i < colliderArray.Length; i++)
            {
                colliderArray[i] = new PolygonCollider(Utils.GetVerticesTexture(_texture));
                addComponent(colliderArray[i])
                    .isTrigger = true;
            }

            // Position
            transform.position = new Vector2((_sprite.width / 2), (Screen.height - (_sprite.height / 2)));
        }

        public override void update()
        {
            base.update();

            // Move colliders together with ScrollingSprite
            if ((scene as Level).State == LevelState.Play)
            {
                var x = Math.Abs((_sprite.scrollX) / _sprite.width);

                for (int i = 0; i < colliderArray.Length; i++)
                    colliderArray[i].setLocalOffset(new Vector2(-(_sprite.scrollX + 58 - ((x + i) * _sprite.width)), 4));
            }
            else
                _sprite.scrollSpeedX = 0;
        }
    }
}
