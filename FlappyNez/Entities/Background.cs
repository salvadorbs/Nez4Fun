using FlappyNez.Scenes;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace FlappyNez.Entities
{
    class Background : Entity
    {
        ScrollingSprite _sprite;

        public Background() : base("Background")
        {
            // Position in screen center (important for y coordinate)
            transform.position = Screen.center;
        }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            // Load background sprite (scrolling background with a specific speed)
            _sprite = new ScrollingSprite(scene.content.Load<Texture2D>(Content.Terrain.background))
            {
                scrollSpeedX = Constants.BackgroundSpeed
            };

            // Add sprite component with renderLayer to 2 (in this way, background renders are in the back of screen)
            addComponent(_sprite)
                .renderLayer = 2;
        }

        public override void update()
        {
            base.update();

            // If it is GameOver, stop background scrolling
            if ((scene as Level).State == LevelState.GameOver)
                _sprite.scrollSpeedX = 0;
        }
    }
}
