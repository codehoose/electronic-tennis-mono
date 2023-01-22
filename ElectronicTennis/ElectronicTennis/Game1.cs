using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ElectronicTennis
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Playfield _playfield;
        private Ball _ball;
        private Player _player1;
        private Player _player2;
        private PlayerController _player1Controller;
        private PlayerController _player2Controller;
        private ScoreDisplay _player1Score;
        private ScoreDisplay _player2Score;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _playfield = new Playfield(this, _spriteBatch);
            Components.Add(_playfield);

            _player1Score = new ScoreDisplay(this, _spriteBatch, new Vector2((GraphicsDevice.Viewport.Width / 2) - 112, 28));
            _player1 = new Player(this, _spriteBatch, new Vector2(28, GraphicsDevice.Viewport.Height / 2), _player1Score);
            _player1Controller = new PlayerController(this, _player1, Keys.Q, Keys.A);
            
            Components.Add(_player1Controller);
            Components.Add(_player1);
            Components.Add(_player1Score);

            _player2Score = new ScoreDisplay(this, _spriteBatch, new Vector2((GraphicsDevice.Viewport.Width / 2) + 14, 28));
            _player2 = new Player(this, _spriteBatch, new Vector2(GraphicsDevice.Viewport.Width - 42, GraphicsDevice.Viewport.Height / 2), _player2Score);
            _player2Controller = new PlayerController(this, _player2, Keys.P, Keys.L);
            
            Components.Add(_player2Controller);
            Components.Add(_player2);
            Components.Add(_player2Score);

            _ball = new Ball(this, _spriteBatch);
            Components.Add(_ball);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            base.Draw(gameTime);
            _spriteBatch.End();
        }
    }
}