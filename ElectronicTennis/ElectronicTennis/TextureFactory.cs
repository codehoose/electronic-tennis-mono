using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ElectronicTennis
{
    internal static class TextureFactory
    {
        const int CHAR_WIDTH = 3;
        const int CHAR_HEIGHT = 5;

        static int[] chars = new int[] // digits 0..9 inclusive
        {
            1,1,1,
            1,0,1,
            1,0,1,
            1,0,1,
            1,1,1,

            0,0,1,
            0,0,1,
            0,0,1,
            0,0,1,
            0,0,1,

            1,1,1,
            0,0,1,
            1,1,1,
            1,0,0,
            1,1,1,

            1,1,1,
            0,0,1,
            1,1,1,
            0,0,1,
            1,1,1,

            1,0,1,
            1,0,1,
            1,1,1,
            0,0,1,
            0,0,1,

            1,1,1,
            1,0,0,
            1,1,1,
            0,0,1,
            1,1,1,

            1,1,1,
            1,0,0,
            1,1,1,
            1,0,1,
            1,1,1,

            1,1,1,
            0,0,1,
            0,0,1,
            0,0,1,
            0,0,1,

            1,1,1,
            1,0,1,
            1,1,1,
            1,0,1,
            1,1,1,

            1,1,1,
            1,0,1,
            1,1,1,
            0,0,1,
            0,0,1
        };

        public static Texture2D CreateTexture(this GraphicsDevice graphicsDevice, int width, int height, Color color)
        {
            Texture2D texture = new Texture2D(graphicsDevice, width, height);
            Color[] colors = new Color[width * height];
            Array.Fill(colors, color);

            texture.SetData(colors);
            return texture;
        }

        public static Texture2D CreateFontTexture(this GraphicsDevice graphicsDevice)
        {
            int numChars = chars.Length / (CHAR_WIDTH * CHAR_HEIGHT);
            Texture2D texture = new Texture2D(graphicsDevice, CHAR_WIDTH, CHAR_HEIGHT * numChars);
            Color[] colors = new Color[CHAR_WIDTH * 10 * CHAR_HEIGHT];
            for (int i = 0; i < numChars; i++)
            {
                int yOffset = i * CHAR_HEIGHT * CHAR_WIDTH;
                
                for (int y = 0; y < CHAR_HEIGHT; y++)
                {
                    for(int x = 0; x < CHAR_WIDTH; x++)
                    {
                        int pos = yOffset + (y * CHAR_WIDTH) + x;
                        colors[pos] = chars[pos] == 1 ? Color.White : Color.Black;
                    }
                }
            }

            texture.SetData(colors);
            return texture;
        }

        public static Texture2D CreatePlayfield(this GraphicsDevice graphicsDevice)
        {
            int w = graphicsDevice.Viewport.Width;
            int h = graphicsDevice.Viewport.Height;

            Texture2D texture = new Texture2D(graphicsDevice, w, h);

            Color[] colors = new Color[w * h];
            for (int y = 0; y < h; y++)
            {
                if (y < 14)
                {
                    for (int x = 0; x < w; x++)
                    {
                        int bottom = h - y - 1;
                        colors[y * w + x] = Color.White;
                        colors[bottom * w + x] = Color.White;
                    }
                }
                else
                {
                    for (int x = 0; x < 14; x++)
                    {
                        int right = w - x - 1;
                        colors[y * w + x] = Color.White;
                        colors[y * w + right] = Color.White;
                    }

                    // Draw the middle dotted line
                    if (y % 9 < 4)
                    {
                        int centre = (w / 2) - 3;
                        for (int x = 0; x < 6; x++)
                        {
                            colors[y * w + centre + x] = Color.White;
                        }
                    }
                }
            }

            texture.SetData(colors);
            return texture;
        }
    }
}
