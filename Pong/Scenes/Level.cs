using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Pong_Clone_Nez.Entities;

namespace Pong_Clone_Nez.Scenes
{
    public class Level : Scene
    {

        public override void initialize()
        {
            base.initialize();

            //Create level entities
            //Bounds
            //addEntity(new Border(TypeBorder.leftVertical));
            //addEntity(new Border(TypeBorder.rightVertical));
            addEntity(new Border(TypeBorder.topHorizontal));
            addEntity(new Border(TypeBorder.downHorizontal));

            //Net
            var netSprite = content.Load<Texture2D>(Content.Sprites.net);
            var midBorder = createEntity("net", new Vector2(Screen.width / 2 - netSprite.Width / 2, Screen.height / 2));
            midBorder.addComponent(new Sprite(netSprite));

            //Entities
            addEntity(new Player());
            addEntity(new Player(false));
            addEntity(new Ball());
            addEntity(new Score());
        }
    }
}
