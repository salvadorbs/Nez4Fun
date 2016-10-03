using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using FlappyNez.Entities;

namespace FlappyNez.Scenes
{
    class Level : Scene
    {
        public override void initialize()
        {
            //Player
            var planeEntity = createEntity("player");
            planeEntity.addComponent(new Entities.Plane());
        }
    }
}
