using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AtriLib3.Screens;
using AtriLib3.Utility;
using AtriLib3.World2D;
using AtriLib3.Entities;
using AtriLib3.Graphics;
using DungeonCrawler.World;
using AtriLib3.Interfaces;

namespace DungeonCrawler.Screens
{
    public partial class GameScreen : Screen
    {
        private static Map worldMap;
        private static Camera2D camera;
        public static int TileWidth { get; set; }
        public static int TileHeight { get; set; }
        public static int TileSizeMultiplier { get; set; } = 8;
        public int WorldWidth { get; private set; }
        public int WorldHeight { get; private set; }
        public static EntityManager EntityMgr { get; set; }
        public static AStar aStar { get; private set; }

        public static Camera2D Camera
        {
            get { return camera; }
        }

        public GameScreen()
            : base()
        {
            EntityMgr = new EntityManager();
        }

        private static QuadTree qTree;

        static GameScreen()
        {
            qTree = new QuadTree(0, new Rectangle(0, 0, Game1.Monitor.VirtualWidth, Game1.Monitor.VirtualHeight));
        }

        public static QuadTree GetQuadTree()
        {
            return qTree;
        }

        public override void LoadContent()
        {
            base.LoadContent();

            GraphicsManager.InitGraphics();

            Entities.Player player = new Entities.Player();
            EntityMgr.Add(player);

            // Code in GameScreenSetup.cs
            SetupTileEngine();

            worldMap = new Map();
            SetupWorld();

            TileWidth = worldMap.GetLayer(GameConstants.BOTTOM_LAYER).Tiles[0].Width;
            TileHeight = worldMap.GetLayer(GameConstants.BOTTOM_LAYER).Tiles[0].Height;
            int width = worldMap.GetLayer(GameConstants.BOTTOM_LAYER).Width * TileSizeMultiplier;
            int height = worldMap.GetLayer(GameConstants.BOTTOM_LAYER).Height * TileSizeMultiplier;
            aStar = new AStar(GetMapData(), width, height, TileWidth / TileSizeMultiplier, TileHeight / TileSizeMultiplier);

            camera = new Camera2D(Game1.Monitor, WorldWidth * 32, WorldHeight * 32);
            camera.Zoom = 2f;
        }

        public static Entities.Player GetPlayer()
        {
            var player = EntityMgr?.GetEntity(GameConstants.ENTITY_PLAYER) as Entities.Player;

            return player;
        }

        private MapData[,] GetMapData()
        {
            var layer = worldMap.GetLayer(GameConstants.BOTTOM_LAYER);
            int mapWidth = layer.Width * TileSizeMultiplier;
            int mapHeight = layer.Height * TileSizeMultiplier;

            MapData[,] mData = new MapData[mapWidth, mapHeight];

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    int currX = x / TileSizeMultiplier;
                    int currY = y / TileSizeMultiplier;
                    var tile = layer.Tiles[currX + currY * layer.Width];

                    MapData tmpData = new MapData();
                    tmpData.Position = new Vector2(x, y);

                    if (tile == null)
                    {
                        tmpData.Walkable = true;
                    }
                    else
                    {
                        tmpData.Walkable = !tile.HasCollision;
                    }

                    mData[x, y] = tmpData;
                }
            }

            return mData;
        }

        public static List<IWorldObject> GetAllColliders()
        {
            List<IWorldObject> retList = new List<IWorldObject>();

            // Add all tiles
            for (int i = 0; i < worldMap.GetLayer(GameConstants.BOTTOM_LAYER).Tiles.Count; i++)
            {
                var tile = worldMap.GetLayer(GameConstants.BOTTOM_LAYER).Tiles[i];
                if (tile.HasCollision)
                {
                    retList.Add(tile);
                }
            }

            for (int i = 0; i < EntityMgr.GetEntities().Count; i++)
            {
                var ent = EntityMgr.GetEntity(i);

                if (ent.HasCollision)
                {
                    retList.Add(ent);
                }
            }

            return retList;
        }

        public override bool Update(GameTime gameTime)
        {
            if (base.Update(gameTime))
            {
                // Update the QuadTree
                qTree.Clear();
                var colliders = GetAllColliders();

                foreach (var wo in colliders)
                {
                    qTree.Insert(wo);
                }

                EntityMgr.Update(gameTime);
                camera.CenterToPosition(EntityMgr.GetEntity(0).Position);

                //if (Input.KeyDown(Keys.Up))
                //{
                //    camera.Position += new Vector2(0, -scrollSpeed) * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                //}
                //else if (Input.KeyDown(Keys.Down))
                //{
                //    camera.Position += new Vector2(0, scrollSpeed) * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                //}

                //if (Input.KeyDown(Keys.Left))
                //{
                //    camera.Position += new Vector2(-scrollSpeed, 0) * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                //}
                //else if (Input.KeyDown(Keys.Right))
                //{
                //    camera.Position += new Vector2(scrollSpeed, 0) * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                //}

                if (Input.KeyDown(Keys.D1))
                {
                    WorldTimer.CurrentTimeOfDay = TimeOfDay.Morning;
                }
                else if (Input.KeyDown(Keys.D2))
                {
                    WorldTimer.CurrentTimeOfDay = TimeOfDay.Day;
                }
                else if (Input.KeyDown(Keys.D3))
                {
                    WorldTimer.CurrentTimeOfDay = TimeOfDay.Afternoon;
                }
                else if (Input.KeyDown(Keys.D4))
                {
                    WorldTimer.CurrentTimeOfDay = TimeOfDay.Night;
                }

                worldMap.Update(gameTime);
                camera.SetCustomMatrix(Game1.Monitor.GetTransformationMatrix());
                camera.Update(gameTime);

                return true;
            }

            return false;
        }

        public override void Unload()
        {
            base.Unload();
        }

        private void DrawQuadTree(SpriteBatch spriteBatch)
        {
            List<IWorldObject> objs = GetAllColliders();

            List<IWorldObject> retList = new List<IWorldObject>();
            for (int i = 0; i < objs.Count; i++)
            {
                retList.Clear();
                qTree.Retrieve(retList, EntityMgr.GetEntity(0).ObjectRectangle);

                for (int j = 0; j < retList.Count; j++)
                {
                    //Pixels.ApplySpriteBatch(spriteBatch);
                    Drawing.DrawRectangle(spriteBatch, retList[j].ObjectRectangle, Color.Red);
                }
            }
        }

        public override bool Draw(SpriteBatch spriteBatch)
        {
            if (base.Draw(spriteBatch))
            {
                spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, camera.Transform);

                worldMap.Draw(spriteBatch);
                EntityMgr.Draw(spriteBatch);
                //DrawQuadTree(spriteBatch);

                spriteBatch.End();

                return true;
            }

            return false;
        }
    }
}
