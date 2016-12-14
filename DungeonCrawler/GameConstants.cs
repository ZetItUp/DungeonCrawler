using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonCrawler
{
    public static class GameConstants
    {
        #region ENTITIES

        public const int ENTITY_PLAYER_SPRITE = 10000;

        #endregion

        #region PHYSICS

        public const int BASE_WIDTH = 32;
        public const int BASE_HEIGHT = 32;

        public const float UnitToPixel = 100.0f;
        public const float PixelToUnit = 1 / UnitToPixel;

        #endregion

        #region DEPTHS

        public const float DEPTH_ENTITY = 0.9f;
        public const float DEPTH_JUST_ABOVE_ENTITY = 0.91f; // I Love my var naming..

        #endregion

        #region LAYERS

        public const int BOTTOM_LAYER = 0;
        public const int SHADOW_LAYER = 1;
        public const int FLOOR_LAYER = 2;

        #endregion

        public const int TILESHEET_DUNGEON_01 = 0x0001;
        public const int TILESHEET_GAMEOBJECTS = 0x0010;

        public const string TILE_EMPTY = "-1";

        #region SHADOWS

        public const int ENVIRONMENT_SHADOW_SQUARE = 2000;
        public const int ENVIRONMENT_SHADOW_POINT_DOWN_RIGHT = 2001;
        public const int ENVIRONMENT_SHADOW_POINT_DOWN_RIGHT_BOTTOM = 2002;
        public const int ENVIRONMENT_SHADOW_POINT_UP_LEFT = 2003;
        public const int ENVIRONMENT_SHADOW_POINT_UP_RIGHT = 2004;

        #endregion

        #region ROOMW

        public const string ROOM_ROOM_01 = "Room01";
        public const string ROOM_ROOM_02 = "Room02";
        public const string ROOM_ROOM_03 = "Room03";

        #endregion

        #region ROOFS

        public const int TILE_ROOF = 1000;
        public const int TILE_ROOF_SMALL_TOP_LEFT_CORNER = 1001;
        public const int TILE_ROOF_EDGE_BOTTOM = 1002;
        public const int TILE_ROOF_EDGE_RIGHT = 1003;
        public const int TILE_ROOF_SMALL_TOP_RIGHT_CORNER = 1004;
        public const int TILE_ROOF_EDGE_LEFT = 1005;
        public const int TILE_ROOF_RIGHT_BOTTOM_CORNER = 1006;
        public const int TILE_ROOF_SMALL_BOTTOM_LEFT_CORNER = 1007;
        public const int TILE_ROOF_LEFT_TOP_CORNER = 1008;
        public const int TILE_ROOF_EDGE_TOP = 1009;
        public const int TILE_ROOF_RIGHT_TOP_CORNER = 1010;
        public const int TILE_ROOF_LEFT_BOTTOM_CORNER = 1011;
        public const int TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER = 1012;

        #endregion

        #region FLOORS

        public const int TILE_FLOOR_BRICK = 1200;
        public const int TILE_FLOOR_BRICK_DARK = 1201;
        public const int TILE_FLOOR_WOOD = 1202;

        #endregion

        #region WALLS

        public const int TILE_WALL_TOP = 1300;
        public const int TILE_WALL_TOP_DARK = 1301;
        public const int TILE_WALL_BOTTOM = 1302;
        public const int TILE_WALL_BOTTOM_DARK = 1303;
        public const int TILE_WALL_PILLAR_LEFT_TOP = 1304;
        public const int TILE_WALL_PILLAR_LEFT_MIDDLE = 1305;
        public const int TILE_WALL_PILLAR_LEFT_BOTTOM = 1306;
        public const int TILE_WALL_PILLAR_RIGHT_TOP = 1307;
        public const int TILE_WALL_PILLAR_RIGHT_MIDDLE = 1308;
        public const int TILE_WALL_PILLAR_RIGHT_BOTTOM = 1309;
        public const int TILE_WALL_DOOR = 1310;
        public const int TILE_WALL_DOOR_LARGE = 1311;

        #endregion

        #region ENTITIES

        public const int ENTITY_PLAYER = 0;

        #endregion
    }
}
