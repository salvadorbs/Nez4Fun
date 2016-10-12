using System;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyNez.Entities
{
    class Background : Entity
    {
        public Background() : base("Background")
        {
            //Position in screen center (important for y coordinate)
            transform.position = Screen.center;
        }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            //Load background sprite (scrolling background with a specific speed)
            var sprite = new ScrollingSprite(scene.content.Load<Texture2D>(Content.Terrain.background))
            {
                scrollSpeedX = Constants.BackgroundSpeed
            };
            //Add sprite component with renderLayer to 2 (in this way, background renders are in the back)
            addComponent(sprite)
                .renderLayer = 2;
        }
    }
}
