using System;
using FlappyNez.Entities;
using FlappyNez.Scenes;

namespace FlappyNez.Factories
{
    class RockFactory
    {
        readonly Level _level;

        public RockFactory(Level scene)
        {
            _level = scene;
        }

        public void CreateRocks(object sender, EventArgs e)
        {
            //if (_level.State == LevelState.Play)
            //{
                var _offset = Nez.Random.range(Constants.RockRangeMin, Constants.RockRangeMax);

                // Rocks
                _level.addEntity(new Rock(_offset));
                _level.addEntity(new Rock(_offset, false));

                // Star (between rocks)
                _level.addEntity(new Star(_offset));
            //}
        }
    }
}