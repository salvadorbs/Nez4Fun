using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace Pong_Clone_Nez
{
    class Score : Component, ITriggerListener, IUpdatable
    {
        int _p1Score = 0;
        int _p2Score = 0;
        Text _score1;
        Text _score2;

        public override void onAddedToEntity()
        {
            //Load scoreFont and put it in a NezSpriteFont (it needs in Text() component)
            var scoreFont = new NezSpriteFont(entity.scene.content.Load<SpriteFont>(Content.Font.scoreFont));

            //Components to draw text score
            _score1 = new Text(scoreFont, "", new Vector2(Screen.width / 2 - 100, 20), Color.White);
            entity.addComponent(_score1);
            _score2 = new Text(scoreFont, "", new Vector2(Screen.width / 2 + 100, 20), Color.White);
            entity.addComponent(_score2);
        }

        void IUpdatable.update()
        {
            var ball = entity.scene.findEntity("ball");

            //Check if ball is out of screen
            if (ball != null)
            {
                //Player 1
                if (ball.transform.position.X <= 0)
                {
                    _p1Score++;
                    ball.getComponent<Ball>().Reset();
                }

                //Player 2
                if (ball.transform.position.X >= (Screen.width - ball.getComponent<Sprite>().width))
                {
                    _p2Score++;
                    ball.getComponent<Ball>().Reset();
                }
            }

            //Update score text
            _score1.text = _p1Score.ToString();
            _score2.text = _p2Score.ToString();
        }

        void ITriggerListener.onTriggerEnter(Collider other, Collider self)
        {

        }


        void ITriggerListener.onTriggerExit(Collider other, Collider self)
        {

        }
    }
}
