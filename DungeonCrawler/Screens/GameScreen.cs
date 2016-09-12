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
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;

namespace DungeonCrawler.Screens
{
    public partial class GameScreen : Screen
    {
        private Map worldMap;
        private Camera2D camera;
        private int WorldWidth { get; set; }
        private int WorldHeight { get; set; }
        public EntityManager EntityMgr { get; set; }
        private FarseerPhysics.Dynamics.World world;

        public GameScreen()
            : base()
        {
            EntityMgr = new EntityManager();

            // Might need to be changed due to no gravity...
            world = new FarseerPhysics.Dynamics.World(Vector2.Zero);
        }

        float scrollSpeed = 1f;

        public FarseerPhysics.Dynamics.World GetWorld()
        {
            return world;
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

            camera = new Camera2D(Game1.Monitor, WorldWidth * 32, WorldHeight * 32);
            camera.Zoom = 2f;
        }

        public override bool Update(GameTime gameTime)
        {
            if (base.Update(gameTime))
            {
                world.Step((float)gameTime.ElapsedGameTime.TotalMilliseconds);
                camera.CenterToPosition(EntityMgr.GetEntity(0).Position);

                // Update the world @ 30 FPS... or not... good that they know what they are doing with
                // their own documentation...
                //world.Step(0.03333f);

                EntityMgr.Update(gameTime);

                if(Input.KeyDown(Keys.Up))
                {
                    camera.Position += new Vector2(0, -scrollSpeed) * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                }
                else if (Input.KeyDown(Keys.Down))
                {
                    camera.Position += new Vector2(0, scrollSpeed) * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                }

                if (Input.KeyDown(Keys.Left))
                {
                    camera.Position += new Vector2(-scrollSpeed, 0) * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                }
                else if (Input.KeyDown(Keys.Right))
                {
                    camera.Position += new Vector2(scrollSpeed, 0) * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
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

        public override bool Draw(SpriteBatch spriteBatch)
        {
            if (base.Draw(spriteBatch))
            {
                spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, camera.Transform);

                worldMap.Draw(spriteBatch);
                EntityMgr.Draw(spriteBatch);

                spriteBatch.End();

                return true;
            }

            return false;
        }
    }
}
