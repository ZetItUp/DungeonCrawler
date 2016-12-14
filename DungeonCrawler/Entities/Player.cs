using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using AtriLib3.Utility;
using AtriLib3.Screens;
using AtriLib3.Entities;
using AtriLib3.GameData;
using AtriLib3.Interfaces;
using DungeonCrawler.Interfaces;
using DungeonCrawler.World;
using DungeonCrawler.Screens;
using AtriLib3.Graphics;

namespace DungeonCrawler.Entities
{
    /*
     * I will run with this solution for now because i don't want to
     * implement the Speed stuff into the base Entity class since it is
     * incomplete.
     */
    public class Player : Entity, IBaseSpeed
    {
        public Vector2 StartPosition { get; set; }
        public float MaxSpeed { get; set; } = 2f;
        public float Friction { get; set; } = 0.9f;
        private Vector2 targetPosition = Vector2.Zero;
        private Vector2 pDir = Vector2.Zero;
        private Vector2 targetOffset = Vector2.Zero;
        private float safeSpeed = 2f;

        private AnimationComponent _ac;
        private float deltaTime;
        private List<Vector2> tarPositions;

        public Color DrawColor
        {
            get
            {
                return _ac.DrawColor;
            }
            set
            {
                _ac.DrawColor = value;
            }
        }

        public override Rectangle ObjectRectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
            }
        }

        public Player()
            : base()
        {
            StartPosition = new Vector2(64, 64);
            BaseSpeed = 0.15f;
            HasCollision = true;
        }

        public override void LoadContent()
        {
            Texture2D txt = GraphicsManager.GetEntity(GameConstants.ENTITY_PLAYER_SPRITE);

            _ac = new AnimationComponent(txt,
                StartPosition, 32, 32, 0, 150f);
            _ac.Depth = GameConstants.DEPTH_ENTITY;
            targetPosition = StartPosition;
            tarPositions = new List<Vector2>();

            Components.Add(_ac);

            base.LoadContent();
        }

        public override Vector2 Position
        {
            get
            {
                return _ac.Position;
            }
            protected set
            {
                _ac.Position = value;
            }
        }

        private float _baseSpeed;
        private Vector2 _appliedSpeed;

        public float BaseSpeed
        {
            get { return _baseSpeed; }
            set { _baseSpeed = value; }
        }

        public Vector2 AppliedSpeed
        {
            get { return _appliedSpeed; }
            set { _appliedSpeed = value; }
        }

        public override void Unload()
        {
            base.Unload();
        }

        private int previousRealXOffset;
        private int previousRealYOffset;

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            deltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            /*
             * So im figuring out a way to get the offset from the selected tile and save it...
             */

            int mx = 0;
            int my = 0;
            int playerOffsetX = 0;
            int playerOffsetY = 0;

            if (Input.KeyDown(Keys.W) || AMouse.MouseDown(AMouse.MouseButton.Right))
            {
                //currTargetPosition = Position;
                targetPosition = GameScreen.Camera.GetMousePosition(AMouse.MousePosition);

                // Make sure we don't go out of bounds!
                if(targetPosition.X < 0 || targetPosition.X > Game1.Monitor.Width ||
                    targetPosition.Y < 0 || targetPosition.Y > Game1.Monitor.Height)
                {
                    return;
                }
                int squaresPerTile = GameScreen.TileSizeMultiplier;

                int tileOffsetX = (int)(targetPosition.X / GameScreen.TileWidth);
                int mouseX = tileOffsetX * GameScreen.TileWidth;
                int mouseTileOffsetX = ((int)targetPosition.X - ((int)(targetPosition.X / GameScreen.TileWidth) * GameScreen.TileWidth));
                int mouseOffsetX = mouseTileOffsetX / (GameScreen.TileWidth / squaresPerTile);

                int tileOffsetY = (int)(targetPosition.Y / GameScreen.TileHeight);
                int mouseY = tileOffsetY * GameScreen.TileHeight;
                int mouseTileOffsetY = ((int)targetPosition.Y - ((int)(targetPosition.Y / GameScreen.TileHeight) * GameScreen.TileHeight));
                int mouseOffsetY = mouseTileOffsetY / (GameScreen.TileHeight / squaresPerTile);
                
                int mouseGridX = (mouseOffsetX * (GameScreen.TileWidth / squaresPerTile)) + mouseX;
                int mouseGridY = (mouseOffsetY * (GameScreen.TileHeight / squaresPerTile)) + mouseY;

                mx = mouseGridX / (GameScreen.TileWidth / squaresPerTile);
                my = mouseGridY / (GameScreen.TileHeight / squaresPerTile);

                playerOffsetX = (int)(Position.X / (GameScreen.TileWidth / squaresPerTile));
                playerOffsetY = (int)((Position.Y) / (GameScreen.TileHeight / squaresPerTile));

                // Make sure we don't update the pathing or move unless we need to!
                if (tarPositions.Count > 0)
                {
                    var currGoal = new Vector2(tarPositions[tarPositions.Count - 1].X / (GameScreen.TileWidth / GameScreen.TileSizeMultiplier), 
                        tarPositions[tarPositions.Count - 1].Y / (GameScreen.TileWidth / GameScreen.TileSizeMultiplier));

                    Vector2 mp = new Vector2(mx, my);
                    Game1.WindowMessage = currGoal.ToString() + "   " + mp.ToString();

                    if (currGoal.X != mp.X && currGoal.Y != mp.Y)
                    {
                        tarPositions.Clear();

                        Point playerPoint = new Point(playerOffsetX, playerOffsetY);
                        Point tarPoint = new Point(mx, my);
                        var paths = GameScreen.aStar.FindPath(playerPoint, tarPoint);

                        for (int i = 0; i < paths.Count; i++)
                        {
                            tarPositions.Add(paths[i]);
                        }
                    }
                }
                // Set the pathing if there is none set
                else
                {
                    Point playerPoint = new Point(playerOffsetX, playerOffsetX);
                    Point tarPoint = new Point(mx, my);

                    if (playerPoint.X != tarPoint.X && playerPoint.Y != tarPoint.Y)
                    {
                        Game1.WindowMessage = playerPoint.ToString() + "   " + tarPoint.ToString();

                        var paths = GameScreen.aStar.FindPath(playerPoint, tarPoint);

                        for (int i = 0; i < paths.Count; i++)
                        {
                            tarPositions.Add(paths[i]);
                        }
                    }
                }
            }

            Move(tarPositions, gameTime);

            //Game1.WindowMessage = "PlayerTile: (" + playerOffsetX + ", " + playerOffsetY + ")  MouseTile: (" + mx + ", " + my + ")";
        }

        //private int safeMoveOffset = 2;
        private void Move(List<Vector2> possiblePath, GameTime gameTime)
        {
            if (possiblePath.Count > 0)
            {
                int posX = (int)Position.X;
                int posY = (int)Position.Y;
                int tarX = (int)possiblePath[0].X - GameScreen.TileWidth / 2 - ObjectRectangle.Width / 2;
                int tarY = (int)possiblePath[0].Y;

                if (posX != tarX || posY != tarY)
                {
                    pDir.X = tarX - posX;
                    pDir.Y = tarY - posY;
                    pDir.Normalize();

                    Vector2 velocity;

                    pDir.X *= MaxSpeed;
                    velocity.X = (int)pDir.X;

                    pDir.Y *= MaxSpeed;
                    velocity.Y = (int)pDir.Y;

                    Position += velocity;
                }
                else
                {
                    possiblePath.RemoveAt(0);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            DrawColor = WorldTimer.GetWorldColorTint();


            if (tarPositions.Count > 0)
            {
                for (int i = 0; i < tarPositions.Count; i++)
                {
                    Drawing.DrawRectangle(spriteBatch, new Rectangle((int)tarPositions.ElementAt(i).X, (int)tarPositions.ElementAt(i).Y, GameScreen.TileWidth / GameScreen.TileSizeMultiplier, GameScreen.TileHeight / GameScreen.TileSizeMultiplier), Color.Red);
                }
            }

        }

        public void SetSpeed(float speed)
        {
            AppliedSpeed = new Vector2(speed, speed);
        }

        public void SetSpeed(float speedX, float speedY)
        {
            AppliedSpeed = new Vector2(speedX, speedY);
        }

        public void ApplySpeed(Vector2 velocity)
        {
            AppliedSpeed += velocity * deltaTime;

            if(AppliedSpeed.X > MaxSpeed)
            {
                AppliedSpeed = new Vector2(MaxSpeed, AppliedSpeed.Y);
            }
            else if(AppliedSpeed.X < -MaxSpeed)
            {
                AppliedSpeed = new Vector2(-MaxSpeed, AppliedSpeed.Y);
            }

            if(AppliedSpeed.Y > MaxSpeed)
            {
                AppliedSpeed = new Vector2(AppliedSpeed.X, MaxSpeed);
            }
            else if(AppliedSpeed.Y < -MaxSpeed)
            {
                AppliedSpeed = new Vector2(AppliedSpeed.X, -MaxSpeed);
            }
        }

        public float GetVelocity()
        {
            // TODO: Add other elements, friciton etc later, for now
            // we just add the flat numbers together for functionality.

            return BaseSpeed;
        }
    }
}
