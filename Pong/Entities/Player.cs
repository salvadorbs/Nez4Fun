using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Pong_Clone_Nez.Components;

namespace Pong_Clone_Nez.Entities
{
    public class Player : Entity
    {
        public Player(bool isPlayer1 = true) : base(isPlayer1 ? "player" : "player2")
        {
            addComponent(new PlayerController());
            addCollider(new BoxCollider());
        }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            // Load paddle sprite and add it in entity
            addComponent(new Sprite(scene.content.Load<Texture2D>(Content.Sprites.paddle)));
        }
    }
}
