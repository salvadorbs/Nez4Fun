using System;
using Nez;
using FlappyNez.Scenes;

namespace FlappyNez.Entities
{
    class TimedEvent : Entity
    {
        readonly float _refreshTime;
        float _previousRefreshTime;

        public event EventHandler Interval;

        public TimedEvent(float refreshTime) : base("TimedEvent")
        {
            _refreshTime = refreshTime;
        }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            _previousRefreshTime = Time.time;
            OnInterval(new EventArgs());
        }

    public override void update()
        {
            base.update();

            if ((scene as Level).State == LevelState.Play)
                if (Time.time - _previousRefreshTime > _refreshTime)
                {
                    _previousRefreshTime = Time.time;

                    OnInterval(new EventArgs());
                }
        }

        protected virtual void OnInterval(EventArgs e)
        {
            Interval?.Invoke(this, e);
        }
    }
}
