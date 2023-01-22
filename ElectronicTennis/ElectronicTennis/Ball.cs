using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicTennis
{
    public class Ball : DrawableGameComponent
    {
        const int START_POS = 112;
        const int WINNING_SCORE = 5;
        const int LEFT_PLAYER = 0;
        const int RIGHT_PLAYER = 1;
        const int BORDER_HEIGHT = 14;

        readonly Texture2D _ball;
        readonly SpriteBatch _spriteBatch;
        readonly IList<Player> _players;

        bool _served;
        bool _resetScoresNextServe;
        float _speed;
        Vector2 _position;
        Vector2 _direction;

        public Ball(Game game, SpriteBatch spriteBatch) : base(game)
        {
            _spriteBatch = spriteBatch;
            _position = new Vector2(START_POS, START_POS);
            _ball = game.GraphicsDevice.CreateTexture(14, 14, Color.White);
            _direction = new Vector2(1, 1);
            _speed = game.GraphicsDevice.Viewport.Width / 32;
            _players = game.Components.GetComponents<Player>();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            _spriteBatch.Draw(_ball, _position, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            int left = 14;
            int right = Game.GraphicsDevice.Viewport.Width - BORDER_HEIGHT;
            int top = 14;
            int bottom = Game.GraphicsDevice.Viewport.Height - (BORDER_HEIGHT * 2); // Border + size of ball

            base.Update(gameTime);

            // Serve the ball, but only if the players are ready.
            bool playersReady = _players.Select(p => p.ScoreDisplay.Ready)
                                        .Where(ready => ready)
                                        .Count() == 2;

            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Space) && !_served && playersReady)
            {
                if (_resetScoresNextServe)
                {
                    foreach (Player p in _players) p.ScoreDisplay.Score = 0;
                }
                _resetScoresNextServe = false;
                _served = true;
            }

            if (_served)
            {
                float delta = gameTime.ElapsedGameTime.Milliseconds / 100f;
                _position += _direction * _speed * delta;

                _position.X = _position.X > right ? right : _position.X;
                _position.X = _position.X < left ? left : _position.X;

                _position.Y = _position.Y > bottom ? bottom : _position.Y;
                _position.Y = _position.Y < top ? top : _position.Y;

                if (_position.X == right || _position.X == left)
                {
                    if (_position.X == left)
                    {
                        PlayerWins(RIGHT_PLAYER);
                    }
                    else
                    {
                        PlayerWins(LEFT_PLAYER);
                    }
                }

                if (_position.Y == top || _position.Y == bottom)
                {
                    _direction.Y *= -1;
                }

                foreach (var player in _players)
                {
                    if (player.Intersects(_position, 14, 14))
                    {
                        _direction.X *= -1;
                    }
                }
            }
        }

        private void PlayerWins(int playerNumber)
        {
            _served = false;
            _position = new Vector2(START_POS, START_POS);
            _direction = new Vector2(1, 1);

            _players[playerNumber].ScoreDisplay.Score++;
            if (_players[playerNumber].ScoreDisplay.Score == WINNING_SCORE)
            {
                _players[playerNumber].ScoreDisplay.Flash();
                _resetScoresNextServe = true;
            }
        }
    }
}
