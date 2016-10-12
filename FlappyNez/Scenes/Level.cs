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
        public override void initialize()
        {
            //Entities
            addEntity(EntityFactory.Instance.CreateEntity(EntityType.Background));
            //addEntity(EntityFactory.Instance.CreateEntity(EntityType.Player));
            addEntity(EntityFactory.Instance.CreateEntity(EntityType.Terrain));
            addEntity(EntityFactory.Instance.CreateEntity(EntityType.RockUp));
            addEntity(EntityFactory.Instance.CreateEntity(EntityType.RockDown));
            addEntity(EntityFactory.Instance.CreateEntity(EntityType.RockManager));
        }
    }
}
