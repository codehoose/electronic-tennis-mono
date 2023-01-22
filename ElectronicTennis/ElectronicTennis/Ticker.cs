using Microsoft.Xna.Framework;

namespace ElectronicTennis
{
    internal class Ticker
    {
        readonly float _flashTime;
        readonly int _intervalMs;

        float flashTimer;
        int msFlashCounter;

        public bool Draw { get; private set; }

        public bool Active => flashTimer > 0;

        public Ticker(float flashDuration, int flashIntervalMs)
        {
            Draw = true;
            _flashTime = flashDuration;
            _intervalMs = flashIntervalMs;
        }

        public void Tick()
        {
            flashTimer = _flashTime;
            msFlashCounter = _intervalMs;
        }

        public void Update(GameTime gameTime)
        {
            if (flashTimer <= 0) return;

            int ms = gameTime.ElapsedGameTime.Milliseconds;
            float delta = ms / 1000f;
            flashTimer -= delta;
            msFlashCounter -= ms;
            if (msFlashCounter < 0)
            {
                msFlashCounter += _intervalMs;
                Draw = !Draw;
            }

            if (flashTimer<=0)
            {
                Draw = true;
                flashTimer = 0;
            }
        }
    }
}
