using System;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using FlappyNez.Entities;

namespace FlappyNez.Factories
{
    class RockFactory
    {
        Scene _scene;

        public RockFactory(Scene scene)
        {
            _scene = scene;
        }

        public void CreateRocks(object sender, EventArgs e)
        {
            _scene.addEntity(new Rock());
            _scene.addEntity(new Rock(false));
        }
    }
}