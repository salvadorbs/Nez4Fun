using System;
using FarseerPhysics.Common;
using FarseerPhysics.Common.TextureTools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.PhysicsShapes;

namespace FlappyNez
{
    static class Utils
    {
        public static Vector2[] GetVerticesTexture(Texture2D texture)
        {
            // Get vertices of Texture
            uint[] texData = new uint[texture.Width * texture.Height];
            texture.GetData<uint>(texData);
            Vertices verticesList = TextureConverter.DetectVertices(texData, texture.Width);
            Vector2[] verticesArray = verticesList.ToArray();

            // PolygonCollider has offset in center, so vertices does too
            for (int i = 0; i < verticesArray.Length; i++)
            {
                verticesArray[i].X -= texture.Width / 2;
                verticesArray[i].Y -= texture.Height / 2;
            }

            return verticesArray;
        }
    }
}
