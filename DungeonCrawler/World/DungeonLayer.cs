using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using AtriLib3.World2D;
using DungeonCrawler.Screens;

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
            if (!DrawMe)
            {
                return;
            }

            foreach(var t in Tiles)
            {
                var texture = TileEngine.GetTexture(t.ID);

                if(t.ID == GameConstants.TILE_EMPTY)
                {
                    continue;
                }

                Color dColor = WorldTimer.GetWorldColorTint();
                if (t.HasCollision)
                {
                    dColor = Color.Red;
                }

                var player = GameScreen.GetPlayer();
                if (player != null)
                {
                    if(t.IDInt >= GameConstants.TILE_ROOF_LEFT_TOP_CORNER && t.IDInt <= GameConstants.TILE_ROOF_RIGHT_TOP_CORNER)
                    {
                        if (player.ObjectRectangle.Intersects(t.ObjectRectangle))
                        {
                            dColor.A = 1;
                        }
                    }
                }

                spriteBatch.Draw(texture.Texture, new Rectangle((int)(t.Position.X * BaseTileOffsetX), (int)(t.Position.Y * BaseTileOffsetY), Tile.DEFAULT_WIDTH, Tile.DEFAULT_HEIGHT),
                    texture.SourceRectangle,
                    dColor, 0f, Vector2.Zero, SpriteEffects.None, t.Depth);
            }
        }
    }
}
