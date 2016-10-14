using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using FlappyNez.Entities;
using FlappyNez.Factories;

namespace FlappyNez.Scenes
{
    class Level : Scene
    {
        private RockFactory _rockManager;
        private TimedEvent _timedEvent;

        public override void initialize()
        {
            _rockManager = new RockFactory(this);
            _timedEvent = new TimedEvent((Screen.width / Constants.ObstaclesSpeed) - 1);
            _timedEvent.Interval += _rockManager.CreateRocks;
            

            //Entities
            addEntity(EntityFactory.Instance.CreateEntity(EntityType.Background));
            //addEntity(EntityFactory.Instance.CreateEntity(EntityType.Player));
            addEntity(EntityFactory.Instance.CreateEntity(EntityType.Terrain));
            addEntity(_timedEvent);
        }
    }
}
