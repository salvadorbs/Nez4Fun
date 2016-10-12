using System;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyNez.Entities
{
    class Rock : Entity
    {
        string _spriteName = string.Empty;
        Sprite _Sprite;
        public bool IsUp;
        Mover _mover;

        public Rock(bool IsUp = true) : base()
        {
            this.IsUp = IsUp;
            if (IsUp)
            {
                name = "Rock_Down";
                _spriteName = Content.Terrain.rockGrassDown;
            }
            else
            {
                name = "Rock_Up";
                _spriteName = Content.Terrain.rockGrass;
            }

            //Mover component
            _mover = addComponent(new Mover());
        }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            //Load sprite and add it in entity
            _Sprite = addComponent(new Sprite(scene.content.Load<Texture2D>(_spriteName)));
            //RenderLayer to 1 because need drawing rock behind terrain
            _Sprite.renderLayer = 1;

            //Polygon Collider
            var collider = addCollider(new PolygonCollider(GetRockVertices()));
            //Must colliders with only layer 0 (in other words with plane)
            Flags.setFlagExclusive(ref collider.collidesWithLayers, 0);

            ResetPosition();
        }

        private void ResetPosition()
        {
            transform.position = new Vector2((Screen.width + (_Sprite.width / 2)),
                IsUp ? (_Sprite.height / 4) : (Screen.height - (_Sprite.height / 4)));
        }

        private Vector2[] GetRockVertices()
        {
            //TODO: This code is dirty (and hard coded) solution. Rewrite this!
            //      Must extract vertices from Texture2 as Farseer Physics does
            var height = _Sprite.height * (IsUp ? -1 : 1);
            var width = _Sprite.width * (IsUp ? 1 : -1);

            var verts = new Vector2[4];
            verts[(IsUp ? 1 : 0)] = new Vector2(8, -(height / 2));
            verts[(IsUp ? 0 : 1)] = new Vector2(16, -(height / 2));
            verts[2] = new Vector2(-(width / 2), (height / 2));
            verts[3] = new Vector2((width / 2), (height / 2));

            return verts;
        }

        public override void update()
        {
            base.update();

            CollisionResult res;
            _mover.move(new Vector2(-1, 0) * Constants.ObstaclesSpeed * Time.deltaTime, out res);

            if (transform.position.X <= -(_Sprite.width / 2))
            {
                this.destroy();
            }
        }
    }
}
