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
        public const float BackgroundSpeed = 100f;
        public const float TerrainSpeed = 100f;
        public const int GapHeight = 0;

        public static readonly Vector2 PlayerInitialPos = Screen.center;
        public static readonly Vector2 PlayerSpeed = new Vector2(0, -6);
    }
}
