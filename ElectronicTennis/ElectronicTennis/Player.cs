using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ElectronicTennis
{
    public partial class Player : DrawableGameComponent
    {
        readonly Texture2D _texture;
        readonly SpriteBatch _spriteBatch;
        readonly ScoreDisplay _scoreDisplay;
        Vector2 _position;

        public ScoreDisplay ScoreDisplay => _scoreDisplay;

        public Vector2 Position { get { return _position; } set { _position = value; } }

        public Player(Game game, SpriteBatch spriteBatch, Vector2 position, ScoreDisplay score) : base(game)
        {
            _texture = game.GraphicsDevice.CreateTexture(14, 48, Color.White);
            _spriteBatch = spriteBatch;
            _position = position;
            _scoreDisplay = score;
        }

        public bool Intersects(Vector2 position, int width, int height)
        {
            var thisRect = new Rectangle((int)Position.X, (int)Position.Y, 14, 48);
            var thatRect = new Rectangle((int)position.X, (int)position.Y, width, height);
            return thisRect.Intersects(thatRect);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            _spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}
