using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ElectronicTennis
{
    internal class PlayerController : GameComponent
    {
        const int BORDER_WIDTH = 14;
        const int BAT_HEIGHT = 48;
        const int BOTTOM_MARGIN = BORDER_WIDTH + BAT_HEIGHT;

        readonly Player _player;
        readonly Keys _up;
        readonly Keys _down;
        int _bottomBorder;
        int _topBorder;
        int _speed;

        public PlayerController(Game game, Player player, Keys upKey, Keys downKey) : base(game)
        {
            _player = player;
            _up = upKey;
            _down = downKey;
            _bottomBorder = Game.GraphicsDevice.Viewport.Height - BOTTOM_MARGIN; // border - height
            _topBorder = BORDER_WIDTH;
            _speed = Game.GraphicsDevice.Viewport.Height / 2;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            float delta = gameTime.ElapsedGameTime.Milliseconds / 1000f;
            
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(_up))
            {
                Vector2 newPos = _player.Position - Vector2.UnitY * _speed * delta;
                newPos.Y = newPos.Y > _topBorder ? newPos.Y : _topBorder;
                _player.Position = newPos;
            }
            else if (state.IsKeyDown(_down))
            {
                Vector2 newPos = _player.Position + Vector2.UnitY * _speed * delta;
                newPos.Y = newPos.Y < _bottomBorder ? newPos.Y : _bottomBorder;
                _player.Position = newPos;
            }
        }
    }
}
