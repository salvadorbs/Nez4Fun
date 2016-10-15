using System;
using FlappyNez.Entities;
using Nez;

namespace FlappyNez.Factories
{
    public enum EntityType
    {
        Background,
        Player,
        Terrain
    }

    class EntityFactory
    {
        public static Entity CreateEntity(EntityType type)
        {
            switch (type)
            {
                case EntityType.Background:
                    return new Background();
                case EntityType.Player:
                    return new Player();
                case EntityType.Terrain:
                    return new Terrain();
                default:
                    throw new ArgumentException("entity type not supported");
            }
        }
    }
}
