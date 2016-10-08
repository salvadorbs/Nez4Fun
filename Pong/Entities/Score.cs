using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace Pong_Clone_Nez.Entities
{
    class Score : Entity
    {
        int _p1Score = 0;
        int _p2Score = 0;
        Text _score1;
        Text _score2;

        public Score() : base("Score")
        { }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            //Load scoreFont and put it in a NezSpriteFont (it needs in Text() component)
            var scoreFont = new NezSpriteFont(scene.content.Load<SpriteFont>(Content.Font.scoreFont));

            //Components to draw text score
            _score1 = new Text(scoreFont, "", new Vector2(Screen.width / 2 - 100, 20), Color.White);
            addComponent(_score1);
            _score2 = new Text(scoreFont, "", new Vector2(Screen.width / 2 + 100, 20), Color.White);
            addComponent(_score2);
        }

        public override void update()
        {
            base.update();

            var List = scene.entitiesOfType<Ball>();

            if (List.Count >= 1)
            {
                var ball = (Ball)List[0];

                //Check if ball is out of screen
                if (ball != null)
                {
                    //Player 1
                    if (ball.transform.position.X <= 0)
                    {
                        _p2Score++;
                        ball.Reset();
                    }

                    //Player 2
                    if (ball.transform.position.X >= (Screen.width - ball.getComponent<Sprite>().width))
                    {
                        _p1Score++;
                        ball.Reset(false);
                    }
                }
            }

            //Update score text
            _score1.text = _p1Score.ToString();
            _score2.text = _p2Score.ToString();
        }
    }
}
