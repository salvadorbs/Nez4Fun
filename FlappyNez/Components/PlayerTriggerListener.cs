using FlappyNez.Entities;
using FlappyNez.Scenes;
using Nez;

namespace FlappyNez.Components
{
    class PlayerTriggerListener : Component, ITriggerListener
    {
        readonly IScore _score;

        Player _player;

        public PlayerTriggerListener(IScore score)
        {
            _score = score;
        }

        public override void onAddedToEntity()
        {
            _player = (Player)entity;
        }

        void ITriggerListener.onTriggerEnter(Collider other, Collider self)
        {
            var _level = (Level)_player.scene;

            if (other != self)
            {

                // Check LevelState
                if (_level.State == LevelState.Play)
                {
                    // Check if other.entity is Star
                    if (other.entity is Star)
                    {
                        // Destroy star and increment score
                        other.entity.destroy();
                        if (((Star)(other.entity)).FirstCollision)
                        {
                            _score.IncrementScore();

                            // Workaround for double collisions with stars (why!?)
                            ((Star)(other.entity)).FirstCollision = false;
                        }
                    }
                    else
                    {
                        // Else it is Terrain or Rocks and it is GameOver
                        _level.State = LevelState.GameOver;
                    }
                }
            }
        }

        void ITriggerListener.onTriggerExit(Collider other, Collider self)
        { }
    }
}