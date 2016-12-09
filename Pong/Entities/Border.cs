using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace Pong_Clone_Nez.Entities
{
    enum TypeBorder
    {
        leftVertical,
        rightVertical,
        topHorizontal,
        downHorizontal
    }

    class Border : Entity
    {
        TypeBorder _border;

        public Border(TypeBorder border) : base()
        {
            _border = border;

            // Entity name
            switch (_border)
            {
                case TypeBorder.leftVertical:
                    this.name = "BorderLeft";
                    break;
                case TypeBorder.rightVertical:
                    this.name = "BorderRight";
                    break;
                case TypeBorder.topHorizontal:
                    this.name = "BorderTop";
                    break;
                case TypeBorder.downHorizontal:
                    this.name = "Borderdown";
                    break;
            }

            // Collider
            addComponent<BoxCollider>();
        }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            Texture2D spriteBar;
            var pos = Vector2.Zero;

            // Load sprite and set position
            switch (_border)
            {
                case TypeBorder.leftVertical:
                    spriteBar = scene.content.Load<Texture2D>(Content.Sprites.vertical);
                    pos = new Vector2((spriteBar.Width / 2), (spriteBar.Height / 2));
                    break;
                case TypeBorder.rightVertical:
                    spriteBar = scene.content.Load<Texture2D>(Content.Sprites.vertical);
                    pos = new Vector2(Screen.width - (spriteBar.Width / 2), (spriteBar.Height / 2));
                    break;
                case TypeBorder.topHorizontal:
                    spriteBar = scene.content.Load<Texture2D>(Content.Sprites.horizontal);
                    pos = new Vector2((spriteBar.Width / 2), (spriteBar.Height / 2));
                    break;
                case TypeBorder.downHorizontal:
                    spriteBar = scene.content.Load<Texture2D>(Content.Sprites.horizontal);
                    pos = new Vector2((spriteBar.Width / 2), Screen.height - (spriteBar.Height / 2));
                    break;
                default:
                    return;
            }

            // Add sprite and set position
            addComponent(new Sprite(spriteBar));
            transform.position = pos;
        }
    }
}
