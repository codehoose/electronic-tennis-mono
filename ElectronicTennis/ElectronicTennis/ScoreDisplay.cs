using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ElectronicTennis
{
    public class ScoreDisplay : DrawableGameComponent
    {
        const int CHAR_WIDTH = 3;
        const int CHAR_HEIGHT = 5;
        const int FLASH_RATE = 250;

        readonly Texture2D _font;
        readonly SpriteBatch _spriteBatch;
        readonly Vector2 _position;
        readonly Ticker _ticker;
        int _score;

        public int Score { get { return _score; } set { _score = value; } }

        public bool Ready { get; private set; }

        public ScoreDisplay(Game game, SpriteBatch spriteBatch, Vector2 position) : base(game)
        {
            _spriteBatch = spriteBatch;
            _position = position;
            _font = game.GraphicsDevice.CreateFontTexture();
            _score = 0;
            Ready = true;
            _ticker = new Ticker(3f, FLASH_RATE);
        }

        public void Flash()
        {
            Ready = false;
            _ticker.Tick();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _ticker.Update(gameTime);
            Ready = !_ticker.Active;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            if (!_ticker.Draw) return;

            int score = _score % 100; // Clamp to two digits
            // Split the digits into two separate numbers
            int[] scoreDigits = new int[] { _score / 10, _score % 10 };

            Vector2 pos = _position;
            foreach (var digit in scoreDigits)
            {
                int offset = CHAR_HEIGHT * digit;
                Rectangle sourceRect = new Rectangle(0, offset, CHAR_WIDTH, CHAR_HEIGHT);
                _spriteBatch.Draw(_font, pos, sourceRect, Color.White, 0, Vector2.Zero, 14, SpriteEffects.None, 0);
                pos += new Vector2((CHAR_WIDTH + 1) * 14, 0);
            }
        }
    }
}
