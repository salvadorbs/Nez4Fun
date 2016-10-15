using System;
using FlappyNez.Entities;
using Nez;

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
            var _offset = Nez.Random.range(-60, 60);

            _scene.addEntity(new Rock(_offset));
            _scene.addEntity(new Rock(_offset, false));
        }
    }
}