using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;

namespace FlappyNez.Entities
{
    interface IScore
    {
        void IncrementScore();
    }

    class Score : Entity, IScore
    {
        Text _textScore;
        int intScore;

        public Score() : base("Score")
        { }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            // Load scoreFont and put it in a NezSpriteFont (it needs in Text() component)
            var scoreFont = new NezSpriteFont(scene.content.Load<SpriteFont>(Content.Font.scoreFont));

            // Components to draw text score
            _textScore = new Text(scoreFont, "", new Vector2(Screen.width / 2, 30), Color.White);
            addComponent(_textScore);
        }

        public override void update()
        {
            base.update();

            // Update score text
            _textScore.text = intScore.ToString();
        }

        public void IncrementScore()
        {
            intScore++;
        }
    }
}