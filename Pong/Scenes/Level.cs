using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace Pong_Clone_Nez
{
    public class Level : Scene
    {
        enum TypeBorder
        {
            leftVertical,
            rightVertical,
            topHorizontal,
            downHorizontal
        }

        public override void initialize()
        {
            base.initialize();

            //Create level entities
            //Bounds
            //createBorder("leftBorder", TypeBorder.leftVertical);
            //createBorder("rightBorder", TypeBorder.rightVertical);
            createBorder("topBorder", TypeBorder.topHorizontal);
            createBorder("downBorder", TypeBorder.downHorizontal);

            //Net
            var net = content.Load<Texture2D>(Content.Sprites.net);
            var midBorder = createEntity("midBorder", new Vector2(Screen.width / 2 - net.Width / 2, Screen.height / 2));
            midBorder.addComponent(new Sprite(net));

            //Player
            var playerEntity = createEntity("player");
            playerEntity.addComponent(new Player());

            //Player2
            var player2Entity = createEntity("player2");
            player2Entity.addComponent(new Player());

            //Ball
            var ballEntity = createEntity("ball");
            ballEntity.addComponent(new Ball());

            //Score
            var scoreEntity = createEntity("score");
            scoreEntity.addComponent(new Score());
        }

        private void createBorder(string entName, TypeBorder border)
        {
            Texture2D spriteBar;
            var pos = Vector2.Zero;
            switch (border)
            {
                case TypeBorder.leftVertical:
                    spriteBar = content.Load<Texture2D>(Content.Sprites.vertical);
                    pos = new Vector2((spriteBar.Width / 2), (spriteBar.Height / 2));
                    break;
                case TypeBorder.rightVertical:
                    spriteBar = content.Load<Texture2D>(Content.Sprites.vertical);
                    pos = new Vector2(Screen.width - (spriteBar.Width / 2), (spriteBar.Height / 2));
                    break;
                case TypeBorder.topHorizontal:
                    spriteBar = content.Load<Texture2D>(Content.Sprites.horizontal);
                    pos = new Vector2((spriteBar.Width / 2), (spriteBar.Height / 2));
                    break;
                case TypeBorder.downHorizontal:
                    spriteBar = content.Load<Texture2D>(Content.Sprites.horizontal);
                    pos = new Vector2((spriteBar.Width / 2), Screen.height - (spriteBar.Height / 2));
                    break;
                default:
                    return;
            }
            var Border = createEntity(entName, pos);
            Border.addComponent(new Sprite(spriteBar));
            Border.colliders.add(new BoxCollider());
        }
    }
}
