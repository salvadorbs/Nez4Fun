using FlappyNez.Entities;
using FlappyNez.Factories;
using Nez;

namespace FlappyNez.Scenes
{
    enum LevelState
    {
        Play,
        GameOver
    }

    class Level : Scene
    {
        private RockFactory _rockManager;
        private TimedEvent _timedEvent;
        public LevelState State = LevelState.Play;

        public override void initialize()
        {
            _rockManager = new RockFactory(this);

            // TimedEvent to create rocks and star every tot seconds
            _timedEvent = new TimedEvent((Screen.width / Constants.ObstaclesSpeed) / 2);
            _timedEvent.Interval += _rockManager.CreateRocks;

            // Entities
            addEntity(EntityFactory.CreateEntity(EntityType.Background));
            addEntity(EntityFactory.CreateEntity(EntityType.Terrain));
            var player = (Player)addEntity(EntityFactory.CreateEntity(EntityType.Player));
            player.Score = (IScore)addEntity(EntityFactory.CreateEntity(EntityType.Score));
            addEntity(_timedEvent);
        }
    }
}
