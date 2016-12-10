using FlappyNez.Entities;
using FlappyNez.Scenes;
using Nez;
using Nez.Sprites;

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
                        // Get star's sprite
                        var starSprite = other.getComponent<Sprite>();

                        // Hide star and increment score
                        if (starSprite != null)
                        {
                            if (starSprite.enabled)
                            {
                                _score.IncrementScore();
                                starSprite.enabled = false;
                            }
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