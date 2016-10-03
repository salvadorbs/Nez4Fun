using System;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyNez
{
    class Rock : Component, ITriggerListener, IUpdatable
    {
        public override void onAddedToEntity()
        {

        }

        void IUpdatable.update()
        {

        }

        void ITriggerListener.onTriggerEnter(Collider other, Collider self)
        {

        }


        void ITriggerListener.onTriggerExit(Collider other, Collider self)
        {

        }
    }
}
