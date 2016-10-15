using FlappyNez.Entities;
using FlappyNez.Factories;
using Nez;

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

            // Entities
            addEntity(EntityFactory.CreateEntity(EntityType.Background));
            ///addEntity(EntityFactory.CreateEntity(EntityType.Player));
            addEntity(EntityFactory.CreateEntity(EntityType.Terrain));
            addEntity(_timedEvent);
        }
    }
}
