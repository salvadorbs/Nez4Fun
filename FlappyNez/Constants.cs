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
        public static readonly float ObstaclesSpeed = 50f;
        public static readonly float BackgroundSpeed = 100f;
        public static readonly float TerrainSpeed = 100f;

        public static readonly Vector2 PlayerInitialPos = Screen.center;
        public static readonly Vector2 PlayerSpeed = new Vector2(0, -6);
    }
}
