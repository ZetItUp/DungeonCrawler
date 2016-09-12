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
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics;

namespace DungeonCrawler.Entities
{
    public class Player : Entity
    {
        private const float _speed = 7.0f;
        private const float MAX_VELOCITY = 50.0f;

        public Body Body { get; private set; }
        public Vector2 StartPosition { get; set; }

        private AnimationComponent _ac;

        public Player()
            : base()
        {
            StartPosition = new Vector2(150, 150);
        }

        public override void LoadContent()
        {
            Texture2D txt = GraphicsManager.GetEntity(GameConstants.ENTITY_PLAYER_SPRITE);

            _ac = new AnimationComponent(txt,
                StartPosition, 32, 32, 0, 150f);

            Components.Add(_ac);

            Vector2 size = new Vector2(GameConstants.BASE_WIDTH, GameConstants.BASE_HEIGHT);

            Body = BodyFactory.CreateRectangle(ScreenManager.GetScreen<Screens.GameScreen>().GetWorld(),
                size.X, size.Y, 0.001f, StartPosition);
            Body.BodyType = BodyType.Dynamic;
            Body.Restitution = 0.3f;
            Body.Friction = 0.5f;

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

        public override void Unload()
        {
            base.Unload();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Vector2 movement = Vector2.Zero;
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if(Input.KeyPressed(Keys.Q))
            {
                Body.ApplyTorque(100f);
            }

            if (Input.KeyPressed(Keys.W))
            {
                movement -= Vector2.UnitY;
            }
            if(Input.KeyPressed(Keys.S))
            {
                movement += Vector2.UnitY;
            }

            if (Input.KeyPressed(Keys.A))
            {
                movement -= Vector2.UnitX;
            }
            if (Input.KeyPressed(Keys.D))
            {
                movement += Vector2.UnitX;
            }

            if (movement != Vector2.Zero)
            {
                movement.Normalize();
            }

            movement *= MAX_VELOCITY;

            Body.ApplyLinearImpulse(movement * deltaTime);

            Position = Body.Position;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
