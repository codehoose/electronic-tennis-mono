using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ElectronicTennis
{
    public class Playfield : DrawableGameComponent
    {
        readonly Texture2D _playfield;
        readonly SpriteBatch _spriteBatch;

        public Playfield(Game game, SpriteBatch spriteBatch) : base(game)
        {
            _playfield = game.GraphicsDevice.CreatePlayfield();
            _spriteBatch = spriteBatch;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            _spriteBatch.Draw(_playfield, Vector2.Zero, Color.White);
        }
    }
}
