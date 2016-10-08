using System;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Pong_Clone_Nez.Components;

namespace Pong_Clone_Nez.Entities
{
    public class Player : Entity
    {
        public Player(bool IsPlayer1 = true) : base(IsPlayer1 ? "player" : "player2")
        {
            addComponent(new PlayerController());
            addCollider(new BoxCollider());
        }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            //Load paddle sprite and add it in entity
            addComponent(new Sprite(scene.content.Load<Texture2D>(Content.Sprites.paddle)));
        }
    }
}
