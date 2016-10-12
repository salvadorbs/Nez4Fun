using System;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using FlappyNez.Factories;

namespace FlappyNez.Entities
{
    class RockManager : Entity
    {
        float _previousRefreshTime = 0f;
        float _refreshTime;

        public RockManager() : base("RockManager")
        { }

        public override void onAddedToScene()
        {
            base.onAddedToScene();


        }

        public override void update()
        {
            base.update();

            //TODO: Add difficulty (faster or slower create obstacles)

            _refreshTime = (Screen.width / Constants.ObstaclesSpeed) - 1;

            if (Time.time - _previousRefreshTime > _refreshTime)
            {
                _previousRefreshTime = Time.time;

                scene.addEntity(EntityFactory.Instance.CreateEntity(EntityType.RockUp));
                scene.addEntity(EntityFactory.Instance.CreateEntity(EntityType.RockDown));
            }
        }
    }
}