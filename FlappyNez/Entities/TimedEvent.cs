using System;
using Nez;

namespace FlappyNez.Entities
{
    class TimedEvent : Entity
    {
        float _previousRefreshTime = -0f;
        float _refreshTime;

        public event EventHandler Interval;

        public TimedEvent(float refreshTime) : base("TimedEvent")
        {
            _refreshTime = refreshTime;
        }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            OnInterval(new EventArgs());
        }

    public override void update()
        {
            base.update();

            if (Time.time - _previousRefreshTime > _refreshTime)
            {
                _previousRefreshTime = Time.time;

                OnInterval(new EventArgs());
            }
        }

        protected virtual void OnInterval(EventArgs e)
        {
            var handler = Interval;

            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
