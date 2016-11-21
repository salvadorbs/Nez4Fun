using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Nez;

namespace FlappyNez
{
    static class Constants
    {
        public const float ObstaclesSpeed = 50f;
        public const float BackgroundSpeed = 25f;
        public const float TerrainSpeed = 60f;
        public const int GapHeight = 150;

        public const int RockRangeMin = -60;
        public const int RockRangeMax = 60;

        public static readonly Vector2 PlayerInitialPos = Screen.center;
        public static readonly Vector2 PlayerSpeed = new Vector2(0, -6);
    }
}
