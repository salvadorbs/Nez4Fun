using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using FlappyNez.Entities;

namespace FlappyNez.Factories
{
    public enum EntityType
    {
        Background,
        Player,
        RockUp,
        RockDown,
        RockManager,
        Terrain
    }

    class EntityFactory
    {
        private static EntityFactory _instance = new EntityFactory();

        public static EntityFactory Instance
        {
            get { return _instance; }
        }

        public Entity CreateEntity(EntityType Type)
        {
            switch (Type)
            {
                case EntityType.Background:
                    return new Background();
                case EntityType.Player:
                    return new Player();
                case EntityType.RockUp:
                    return new Rock();
                case EntityType.RockDown:
                    return new Rock(false);
                case EntityType.RockManager:
                    return new RockManager();
                case EntityType.Terrain:
                    return new Terrain();
                default:
                    throw new ArgumentException("type");
            }
        }
    }
}
