using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using AtriLib3.World2D;

namespace DungeonCrawler.World
{
    public class DungeonLayer : Layer
    {
        public int BaseTileOffsetX { get; set; } = 32;
        public int BaseTileOffsetY { get; set; } = 32;

        public DungeonLayer()
            : base()
        {

        }

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach(var t in Tiles)
            {
                var texture = TileEngine.GetTexture(t.ID);

                if(t.ID == GameConstants.TILE_EMPTY)
                {
                    continue;
                }

                spriteBatch.Draw(texture.Texture, new Rectangle((int)(t.Position.X * BaseTileOffsetX), (int)(t.Position.Y * BaseTileOffsetY), Tile.DEFAULT_WIDTH, Tile.DEFAULT_HEIGHT),
                    texture.SourceRectangle, 
                    Color.White, 0f, Vector2.Zero, SpriteEffects.None, ZOrder);
            }
        }
    }
}
