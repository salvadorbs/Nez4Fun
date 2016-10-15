using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace FlappyNez.Entities
{
    class Terrain : Entity
    {
        public Terrain() : base("Terrain")
        {
            // Collider component
            var collider = addCollider(new BoxCollider());

            // Set physics layer to 1 - avoid check collision with rocks
            Flags.setFlagExclusive(ref collider.physicsLayer, 1);
        }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            // Load scrolling sprite
            var _sprite = new ScrollingSprite(scene.content.Load<Texture2D>(Content.Terrain.groundGrass))
            {
                scrollSpeedX = Constants.TerrainSpeed
        };
            addComponent(_sprite);

            // Position
            transform.position = new Vector2((_sprite.width / 2), (Screen.height - (_sprite.height / 2)));
        }
    }
}
