using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{

    class Level
    {
        private Player[] players;
        private List<Texture2D> layers;
        private List<Vector2> map;
        private SpriteFont font;

        // Level content.
        public ContentManager Content { get => content; }
        private ContentManager content;

        public Level(IServiceProvider serviceProvider)
        {
            // Create a new content manager to load content used just by this level.
            content = new ContentManager(serviceProvider, "Content");

            this.LoadTiles();
            this.LoadContent();
        }

        public void LoadContent()
        {
            this.layers = new List<Texture2D>();
            this.layers.Add(Content.Load<Texture2D>("Levels/1"));

            font = Content.Load<SpriteFont>("Levels/font"); // Use the name of your sprite font file here instead of 'Score'.

        }

        public void LoadTiles()
        {

            this.map = new List<Vector2>(9);
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    this.map.Add(new Vector2(22 + (183 + 6) * x, 22 + (183 + 6) * y));
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            this.layers.ForEach(delegate (Texture2D layer)
            {
                spriteBatch.Draw(layer, Vector2.Zero, Color.White);
            });
            this.map.ForEach(delegate (Vector2 position)
            {
                spriteBatch.DrawString(font, "X", position, Color.Black);
                //spriteBatch.Draw(layer, position, Color.White);
            });
        }
    }
}
