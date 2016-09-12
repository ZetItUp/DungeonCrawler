using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AtriLib3;

namespace DungeonCrawler
{
    public static class GraphicsManager
    {
        private static Texture2D _tileSheet1;
        private static Texture2D _gameObjects;

        private static Texture2D _playerTexture;

        public static void InitGraphics()
        {
            _tileSheet1 = Constants.ContentMgr.Load<Texture2D>("Data\\GFX\\Tileset1");
            _gameObjects = Constants.ContentMgr.Load<Texture2D>("Data\\GFX\\GameObjects");

            _playerTexture = Constants.ContentMgr.Load<Texture2D>("Data\\GFX\\Entities\\HeroKnight");
        }

        public static Texture2D GetTexture(int ID)
        {
            switch(ID)
            {
                case GameConstants.TILESHEET_DUNGEON_01:
                    return _tileSheet1;
                case GameConstants.TILESHEET_GAMEOBJECTS:
                    return _gameObjects;
                default:
                    return null;
            }
        }

        public static Texture2D GetEntity(int entityID)
        {
            switch(entityID)
            {
                case GameConstants.ENTITY_PLAYER_SPRITE:
                    return _playerTexture;
                default:
                    return null;
            }
        }
    }
}
