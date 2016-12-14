using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AtriLib3.Screens;
using AtriLib3.Utility;
using AtriLib3.World2D;
using DungeonCrawler.World;

namespace DungeonCrawler.Screens
{
    public partial class GameScreen : Screen
    {
        public enum TileDirection
        {
            UP = 0,
            RIGHT = 1,
            DOWN = 2,
            LEFT = 3
        };

        private void SetupTileEngine()
        {
            TileEngine.AddTileSheet(GameConstants.TILESHEET_DUNGEON_01, GraphicsManager.GetTexture(GameConstants.TILESHEET_DUNGEON_01));

            TileData tileRoof = new TileData()
            {
                TextureID = GameConstants.TILE_ROOF.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(0, 0, 32, 32)
            };

            TileData tileRoofSmallTopLeftCorner = new TileData()
            {
                TextureID = GameConstants.TILE_ROOF_SMALL_TOP_LEFT_CORNER.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(32, 0, 32, 32)
            };

            TileData tileRoofEdgeBottom = new TileData()
            {
                TextureID = GameConstants.TILE_ROOF_EDGE_BOTTOM.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(64, 0, 32, 32)
            };

            TileData tileRoofEdgeRight = new TileData()
            {
                TextureID = GameConstants.TILE_ROOF_EDGE_RIGHT.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(96, 0, 32, 32)
            };

            TileData tileRoofSmallTopRightCorner = new TileData()
            {
                TextureID = GameConstants.TILE_ROOF_SMALL_TOP_RIGHT_CORNER.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(128, 0, 32, 32)
            };

            TileData tileRoofEdgeLeft = new TileData()
            {
                TextureID = GameConstants.TILE_ROOF_EDGE_LEFT.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(160, 0, 32, 32)
            };

            TileData tileRoofRightBottomCorner = new TileData()
            {
                TextureID = GameConstants.TILE_ROOF_RIGHT_BOTTOM_CORNER.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(192, 0, 32, 32)
            };

            TileData tileRoofSmallBottomLeftCorner = new TileData()
            {
                TextureID = GameConstants.TILE_ROOF_SMALL_BOTTOM_LEFT_CORNER.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(224, 0, 32, 32)
            };

            TileData tileRoofLeftTopCorner = new TileData()
            {
                TextureID = GameConstants.TILE_ROOF_LEFT_TOP_CORNER.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(256, 0, 32, 32)
            };

            TileData tileRoofEdgeTop = new TileData()
            {
                TextureID = GameConstants.TILE_ROOF_EDGE_TOP.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(288, 0, 32, 32)
            };

            TileData tileRoofRightTopCorner = new TileData()
            {
                TextureID = GameConstants.TILE_ROOF_RIGHT_TOP_CORNER.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(320, 0, 32, 32)
            };

            TileData tileRoofLeftBottomCorner = new TileData()
            {
                TextureID = GameConstants.TILE_ROOF_LEFT_BOTTOM_CORNER.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(352, 0, 32, 32)
            };

            TileData tileRoofSmallBottomRightCorner = new TileData()
            {
                TextureID = GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(384, 0, 32, 32)
            };

            TileData tileFloorBrick = new TileData()
            {
                TextureID = GameConstants.TILE_FLOOR_BRICK.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(0, 64, 32, 32)
            };

            TileData tileFloorBrickDark = new TileData()
            {
                TextureID = GameConstants.TILE_FLOOR_BRICK_DARK.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(32, 64, 32, 32)
            };

            TileData tileFloorWood = new TileData()
            {
                TextureID = GameConstants.TILE_FLOOR_WOOD.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(0, 96, 32, 32)
            };

            TileData tileWallTop = new TileData()
            {
                TextureID = GameConstants.TILE_WALL_TOP.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(0, 96, 32, 32)
            };

            TileData tileWallDoor = new TileData()
            {
                TextureID = GameConstants.TILE_WALL_DOOR.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(32, 32, 32, 32)
            };

            TileData tileWallLarge = new TileData()
            {
                TextureID = GameConstants.TILE_WALL_DOOR_LARGE.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(64, 32, 32, 64)
            };

            TileData tileShadow = new TileData()
            {
                TextureID = GameConstants.ENVIRONMENT_SHADOW_SQUARE.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(96, 64, 32, 32)
            };

            TileData tileShadowPointDownRight = new TileData()
            {
                TextureID = GameConstants.ENVIRONMENT_SHADOW_POINT_DOWN_RIGHT.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(128, 32, 32, 32)
            };

            TileData tileShadowPointDownRightBottom = new TileData()
            {
                TextureID = GameConstants.ENVIRONMENT_SHADOW_POINT_DOWN_RIGHT_BOTTOM.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(128, 64, 32, 32)
            };

            TileData tileShadowPointUpRight = new TileData()
            {
                TextureID = GameConstants.ENVIRONMENT_SHADOW_POINT_UP_RIGHT.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(160, 32, 32, 64)
            };

            TileData tileShadowPointUpLeft = new TileData()
            {
                TextureID = GameConstants.ENVIRONMENT_SHADOW_POINT_UP_LEFT.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(192, 32, 32, 64)
            };

            TileData tileWallDark = new TileData()
            {
                TextureID = GameConstants.TILE_WALL_TOP_DARK.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(32, 96, 32, 32)
            };

            TileData tileWallTopDark = new TileData()
            {
                TextureID = GameConstants.TILE_WALL_TOP_DARK.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(32, 96, 32, 32)
            };

            TileData tileWallBottom = new TileData()
            {
                TextureID = GameConstants.TILE_WALL_BOTTOM.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(64, 96, 32, 32)
            };

            TileData tileWallBottomDark = new TileData()
            {
                TextureID = GameConstants.TILE_WALL_BOTTOM_DARK.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(96, 96, 32, 32)
            };

            TileData tileWallPillarLeftTop = new TileData()
            {
                TextureID = GameConstants.TILE_WALL_PILLAR_LEFT_TOP.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(128, 96, 32, 32)
            };

            TileData tileWallPillarLeftMiddle = new TileData()
            {
                TextureID = GameConstants.TILE_WALL_PILLAR_LEFT_MIDDLE.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(160, 96, 32, 32)
            };

            TileData tileWallPillarLeftBottom = new TileData()
            {
                TextureID = GameConstants.TILE_WALL_PILLAR_LEFT_BOTTOM.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(192, 96, 32, 32)
            };
            
            TileData tileWallPillarRightTop = new TileData()
            {
                TextureID = GameConstants.TILE_WALL_PILLAR_RIGHT_TOP.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(224, 96, 32, 32)
            };

            TileData tileWallPillarRightMiddle = new TileData()
            {
                TextureID = GameConstants.TILE_WALL_PILLAR_RIGHT_MIDDLE.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(256, 96, 32, 32)
            };

            TileData tileWallPillarRightBottom = new TileData()
            {
                TextureID = GameConstants.TILE_WALL_PILLAR_RIGHT_BOTTOM.ToString(),
                TextureSheetNum = GameConstants.TILESHEET_DUNGEON_01,
                TileSheetRectangle = new Rectangle(288, 96, 32, 32)
            };

            TileEngine.AddTileData(tileWallPillarRightBottom);
            TileEngine.AddTileData(tileWallPillarRightMiddle);
            TileEngine.AddTileData(tileWallPillarRightTop);
            TileEngine.AddTileData(tileWallPillarLeftBottom);
            TileEngine.AddTileData(tileWallPillarLeftMiddle);
            TileEngine.AddTileData(tileWallPillarLeftTop);
            TileEngine.AddTileData(tileWallBottomDark);
            TileEngine.AddTileData(tileWallBottom);
            TileEngine.AddTileData(tileWallTopDark);
            TileEngine.AddTileData(tileWallDark);
            TileEngine.AddTileData(tileShadowPointUpLeft);
            TileEngine.AddTileData(tileShadowPointUpRight);
            TileEngine.AddTileData(tileShadowPointDownRight);
            TileEngine.AddTileData(tileShadowPointDownRightBottom);
            TileEngine.AddTileData(tileShadow);
            TileEngine.AddTileData(tileWallLarge);
            TileEngine.AddTileData(tileWallDoor);
            TileEngine.AddTileData(tileWallTop);
            TileEngine.AddTileData(tileFloorWood);
            TileEngine.AddTileData(tileFloorBrickDark);
            TileEngine.AddTileData(tileFloorBrick);
            TileEngine.AddTileData(tileRoofSmallBottomRightCorner);
            TileEngine.AddTileData(tileRoofSmallBottomLeftCorner);
            TileEngine.AddTileData(tileRoofLeftBottomCorner);
            TileEngine.AddTileData(tileRoofRightTopCorner);
            TileEngine.AddTileData(tileRoofEdgeTop);
            TileEngine.AddTileData(tileRoofLeftTopCorner);
            TileEngine.AddTileData(tileRoofSmallTopLeftCorner);
            TileEngine.AddTileData(tileRoofRightBottomCorner);
            TileEngine.AddTileData(tileRoofEdgeLeft);
            TileEngine.AddTileData(tileRoofSmallTopRightCorner);
            TileEngine.AddTileData(tileRoofEdgeRight);
            TileEngine.AddTileData(tileRoof);
            TileEngine.AddTileData(tileRoofSmallTopLeftCorner);
            TileEngine.AddTileData(tileRoofEdgeBottom);
        }

        /// <summary>
        /// Get a random tile style depending on the current style of the current tile.
        /// For example, if it is a FLOOR_BRICK, return a light or dark version.
        /// </summary>
        /// <param name="originalID">Current Tile ID</param>
        /// <returns>Random Generated Tile ID</returns>
        private int GetRandomGroundTileStyle(int originalID)
        {
            if(originalID == GameConstants.TILE_FLOOR_BRICK)
            {
                return Game1.rand.Next(GameConstants.TILE_FLOOR_BRICK, GameConstants.TILE_FLOOR_BRICK_DARK);
            }

            return 0;
        }

        private void DoLayerCalculations(Layer layer)
        {
            /*
             *   # = Occupied Tile
             *   . = Free Tile
             */
            var floorLayer = worldMap.GetLayer(GameConstants.FLOOR_LAYER);

            for (int x = 0; x < layer.Width; x++)
            {
                for (int y = 0; y < layer.Height; y++)
                {
                    Tile t = layer.GetTile(x, y);

                    if (t.IDInt >= GameConstants.TILE_ROOF && t.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER)
                    {
                        #region TOP LEFT CORNER
                        if (x == 0 && y == 0)
                        {
                            /*
                             *  Get tiles around tile at 0, 0
                             */
                            Tile tRight = layer.GetTile(x + 1, y);
                            Tile tDown = layer.GetTile(x, y + 1);
                            Tile tDiagRightDown = layer.GetTile(x + 1, y + 1);

                            /*
                             *    t#
                             *    ##
                             */
                            if ((tRight.IDInt >= GameConstants.TILE_ROOF && tRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDown.IDInt >= GameConstants.TILE_ROOF && tDown.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDiagRightDown.IDInt >= GameConstants.TILE_ROOF && tDiagRightDown.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                continue;
                            }
                            /*
                             *    t#
                             *    #.
                             */
                            else if ((tRight.IDInt >= GameConstants.TILE_ROOF && tRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDown.IDInt >= GameConstants.TILE_ROOF && tDown.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDiagRightDown.IDInt < GameConstants.TILE_ROOF || tDiagRightDown.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_SMALL_TOP_LEFT_CORNER.ToString();
                                t.HasCollision = true;
                            }
                            /*
                             *    t.
                             *    #
                             */
                            else if ((tRight.IDInt >= GameConstants.TILE_ROOF && tRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDown.IDInt >= GameConstants.TILE_ROOF && tDown.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_LEFT.ToString();
                            }
                            /*
                             *    t#
                             *    .
                             */
                            else if ((tRight.IDInt >= GameConstants.TILE_ROOF && tRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDown.IDInt < GameConstants.TILE_ROOF || tDown.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_BOTTOM.ToString();
                            }
                        }
                        #endregion
                        #region BOTTOM LEFT CORNER
                        else if (x == 0 && y == layer.Height - 1)
                        {
                            /*
                             *  Get tiles around tile at 0, 0
                             */
                            Tile tRight = layer.GetTile(x + 1, y);
                            Tile tUp = layer.GetTile(x, y - 1);
                            Tile tDiagUpRight = layer.GetTile(x + 1, y - 1);

                            /*
                             *    ##
                             *    t#
                             */
                            if ((tRight.IDInt >= GameConstants.TILE_ROOF && tRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tUp.IDInt >= GameConstants.TILE_ROOF && tUp.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDiagUpRight.IDInt >= GameConstants.TILE_ROOF && tDiagUpRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                continue;
                            }
                            /*
                             *    #.
                             *    t#
                             */
                            else if ((tRight.IDInt >= GameConstants.TILE_ROOF && tRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tUp.IDInt >= GameConstants.TILE_ROOF && tUp.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDiagUpRight.IDInt < GameConstants.TILE_ROOF || tDiagUpRight.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_SMALL_BOTTOM_LEFT_CORNER.ToString();
                                t.HasCollision = true;
                            }
                            /*
                             *    #.
                             *    t.
                             */
                            else if ((tRight.IDInt >= GameConstants.TILE_ROOF && tRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tUp.IDInt >= GameConstants.TILE_ROOF && tUp.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_LEFT.ToString();
                            }
                            /*
                             *    ..
                             *    t#
                             */
                            else if ((tRight.IDInt >= GameConstants.TILE_ROOF && tRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tUp.IDInt < GameConstants.TILE_ROOF || tUp.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_BOTTOM.ToString();
                            }
                        }
                        #endregion
                        #region TOP RIGHT CORNER
                        else if (x == layer.Width - 1 && y == 0)
                        {
                            /*
                             *  Get tiles around tile at 0, 0
                             */
                            Tile tLeft = layer.GetTile(x - 1, y);
                            Tile tDown = layer.GetTile(x, y + 1);
                            Tile tDiagLeftDown = layer.GetTile(x - 1, y + 1);

                            /*
                             *    #t
                             *    ##
                             */
                            if ((tLeft.IDInt >= GameConstants.TILE_ROOF && tLeft.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDown.IDInt >= GameConstants.TILE_ROOF && tDown.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDiagLeftDown.IDInt >= GameConstants.TILE_ROOF && tDiagLeftDown.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                continue;
                            }
                            /*
                             *    #t
                             *    .#
                             */
                            else if ((tLeft.IDInt >= GameConstants.TILE_ROOF || tLeft.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDown.IDInt >= GameConstants.TILE_ROOF || tDown.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDiagLeftDown.IDInt < GameConstants.TILE_ROOF || tDiagLeftDown.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_SMALL_TOP_RIGHT_CORNER.ToString();
                                t.HasCollision = true;
                            }
                            /*
                             *    .t
                             *     #
                             */
                            else if ((tLeft.IDInt < GameConstants.TILE_ROOF || tLeft.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDown.IDInt >= GameConstants.TILE_ROOF || tDown.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_RIGHT.ToString();
                            }
                            /*
                             *    #t
                             *     .
                             */
                            else if ((tLeft.IDInt >= GameConstants.TILE_ROOF || tLeft.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDown.IDInt < GameConstants.TILE_ROOF || tDown.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_BOTTOM.ToString();
                            }
                        }
                        #endregion
                        #region BOTTOM RIGHT CORNER
                        else if (x == layer.Width - 1 && y == layer.Height - 1)
                        {
                            /*
                             *  Get tiles around tile at 0, 0
                             */
                            Tile tLeft = layer.GetTile(x - 1, y);
                            Tile tUp = layer.GetTile(x, y - 1);
                            Tile tDiagUpLeft = layer.GetTile(x - 1, y - 1);

                            /*
                             *    ##
                             *    #t
                             */
                            if ((tLeft.IDInt >= GameConstants.TILE_ROOF && tLeft.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tUp.IDInt >= GameConstants.TILE_ROOF && tUp.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDiagUpLeft.IDInt >= GameConstants.TILE_ROOF && tDiagUpLeft.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                continue;
                            }
                            /*
                             *    .#
                             *    #t
                             */
                            else if ((tLeft.IDInt >= GameConstants.TILE_ROOF && tLeft.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tUp.IDInt >= GameConstants.TILE_ROOF && tUp.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDiagUpLeft.IDInt < GameConstants.TILE_ROOF || tDiagUpLeft.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER.ToString();
                                t.HasCollision = true;
                            }
                            /*
                             *    .#
                             *    .t
                             */
                            else if ((tLeft.IDInt < GameConstants.TILE_ROOF || tLeft.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tUp.IDInt >= GameConstants.TILE_ROOF || tUp.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_RIGHT.ToString();
                            }
                            /*
                             *    ..
                             *    #t
                             */
                            else if ((tLeft.IDInt >= GameConstants.TILE_ROOF || tLeft.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tUp.IDInt < GameConstants.TILE_ROOF || tUp.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_BOTTOM.ToString();
                            }
                        }
                        #endregion  
                        #region TOP ROW X > 0 && X < Layer Width - 1
                        else if (x > 0 && x < layer.Width - 1 && y == 0)
                        {
                            /*
                             *  Get tiles around tile at X when y == 0
                             */
                            Tile tRight = layer.GetTile(x + 1, y);
                            Tile tDown = layer.GetTile(x, y + 1);
                            Tile tLeft = layer.GetTile(x - 1, y);
                            Tile tDiagLeftDown = layer.GetTile(x - 1, y + 1);
                            Tile tDiagRightDown = layer.GetTile(x + 1, y + 1);

                            /*
                             *   #t#
                             *   ###
                             */
                            if ((tRight.IDInt >= GameConstants.TILE_ROOF && tRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tLeft.IDInt >= GameConstants.TILE_ROOF && tLeft.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDown.IDInt >= GameConstants.TILE_ROOF && tDown.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDiagLeftDown.IDInt >= GameConstants.TILE_ROOF && tDiagLeftDown.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDiagRightDown.IDInt >= GameConstants.TILE_ROOF && tDiagRightDown.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.HasCollision = true;
                                continue;
                            }
                            /*
                             *   #t#
                             *   ...   
                             */
                            else if ((tRight.IDInt >= GameConstants.TILE_ROOF || tRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tLeft.IDInt >= GameConstants.TILE_ROOF || tLeft.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDown.IDInt < GameConstants.TILE_ROOF || tDown.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_BOTTOM.ToString();
                                t.HasCollision = true;
                            }
                            /*
                             *   #t#
                             *   .##
                             */
                            else if ((tRight.IDInt >= GameConstants.TILE_ROOF || tRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tLeft.IDInt >= GameConstants.TILE_ROOF || tLeft.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDown.IDInt >= GameConstants.TILE_ROOF || tDown.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDiagLeftDown.IDInt < GameConstants.TILE_ROOF || tDiagLeftDown.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDiagRightDown.IDInt >= GameConstants.TILE_ROOF || tDiagRightDown.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_SMALL_TOP_RIGHT_CORNER.ToString();
                                t.HasCollision = true;
                            }
                            /*
                             *   #t#
                             *   ##.
                             */
                            else if ((tRight.IDInt >= GameConstants.TILE_ROOF || tRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tLeft.IDInt >= GameConstants.TILE_ROOF || tLeft.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDown.IDInt >= GameConstants.TILE_ROOF || tDown.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDiagLeftDown.IDInt >= GameConstants.TILE_ROOF || tDiagLeftDown.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDiagRightDown.IDInt < GameConstants.TILE_ROOF || tDiagRightDown.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_SMALL_TOP_LEFT_CORNER.ToString();
                                t.HasCollision = true;
                            }
                        }
                        #endregion
                        #region BOTTOM ROW X > 0 && X < Layer Width - 1
                        else if (x > 0 && x < layer.Width - 1 && y == layer.Height - 1)
                        {
                            /*
                             *  Get tiles around tile at X when y == 0
                             */
                            Tile tRight = layer.GetTile(x + 1, y);
                            Tile tUp = layer.GetTile(x, y - 1);
                            Tile tLeft = layer.GetTile(x - 1, y);
                            Tile tDiagUpLeft = layer.GetTile(x - 1, y - 1);
                            Tile tDiagUpRight = layer.GetTile(x + 1, y - 1);

                            /*
                             *   ###
                             *   #t#
                             */
                            if ((tRight.IDInt >= GameConstants.TILE_ROOF && tRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tLeft.IDInt >= GameConstants.TILE_ROOF && tLeft.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tUp.IDInt >= GameConstants.TILE_ROOF && tUp.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDiagUpLeft.IDInt >= GameConstants.TILE_ROOF && tDiagUpLeft.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDiagUpRight.IDInt >= GameConstants.TILE_ROOF && tDiagUpRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.HasCollision = true;
                                continue;
                            }
                            /*
                             *   ...
                             *   #t#   
                             */
                            else if ((tRight.IDInt >= GameConstants.TILE_ROOF || tRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tLeft.IDInt >= GameConstants.TILE_ROOF || tLeft.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tUp.IDInt < GameConstants.TILE_ROOF || tUp.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_TOP.ToString();
                                t.Depth = GameConstants.DEPTH_JUST_ABOVE_ENTITY;
                                t.HasCollision = true;
                            }
                            /*
                             *   .##
                             *   #t#
                             */
                            else if ((tRight.IDInt >= GameConstants.TILE_ROOF || tRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tLeft.IDInt >= GameConstants.TILE_ROOF || tLeft.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tUp.IDInt >= GameConstants.TILE_ROOF || tUp.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDiagUpLeft.IDInt < GameConstants.TILE_ROOF || tDiagUpLeft.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDiagUpRight.IDInt >= GameConstants.TILE_ROOF || tDiagUpRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER.ToString();
                                t.HasCollision = true;
                            }
                            /*
                             *   ##.
                             *   #t#
                             */
                            else if ((tRight.IDInt >= GameConstants.TILE_ROOF || tRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tLeft.IDInt >= GameConstants.TILE_ROOF || tLeft.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tUp.IDInt >= GameConstants.TILE_ROOF || tUp.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDiagUpLeft.IDInt >= GameConstants.TILE_ROOF || tDiagUpLeft.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                (tDiagUpRight.IDInt < GameConstants.TILE_ROOF || tDiagUpRight.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_SMALL_BOTTOM_LEFT_CORNER.ToString();
                                t.HasCollision = true;
                            }
                        }
                        #endregion
                        #region LEFT COLUMN Y > 0 Y < Layer.Height - 1
                        else if (x == 0 && y > 0 && y < layer.Height - 1)
                        {
                            /*
                             *  Get tiles around tile
                             */
                            Tile tDown = layer.GetTile(x, y + 1);
                            Tile tUp = layer.GetTile(x, y - 1);
                            Tile tRight = layer.GetTile(x + 1, y);
                            Tile tDiagDownRight = layer.GetTile(x + 1, y + 1);
                            Tile tDiagUpRight = layer.GetTile(x + 1, y - 1);

                            /*
                             *   ##
                             *   t#
                             *   ##
                             */
                            if ((tRight.IDInt >= GameConstants.TILE_ROOF && tRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                               (tUp.IDInt >= GameConstants.TILE_ROOF && tUp.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                               (tDown.IDInt >= GameConstants.TILE_ROOF && tDown.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                               (tDiagDownRight.IDInt >= GameConstants.TILE_ROOF && tDiagDownRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                               (tDiagUpRight.IDInt >= GameConstants.TILE_ROOF && tDiagUpRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.HasCollision = true;
                                continue;
                            }
                            /*
                             *  #.
                             *  t.
                             *  #.
                             */
                            else if ((tUp.IDInt >= GameConstants.TILE_ROOF && tUp.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              (tDown.IDInt >= GameConstants.TILE_ROOF && tDown.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              (tRight.IDInt < GameConstants.TILE_ROOF || tRight.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              (tDiagDownRight.IDInt < GameConstants.TILE_ROOF || tDiagDownRight.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              (tDiagUpRight.IDInt < GameConstants.TILE_ROOF || tDiagUpRight.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_RIGHT.ToString();
                                t.HasCollision = true;
                            }
                            /*
                             *  #.
                             *  t.
                             *  ##
                             */
                            else if ((tUp.IDInt >= GameConstants.TILE_ROOF && tUp.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              (tDown.IDInt >= GameConstants.TILE_ROOF && tDown.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              (tRight.IDInt < GameConstants.TILE_ROOF || tRight.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              (tDiagDownRight.IDInt >= GameConstants.TILE_ROOF && tDiagDownRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              (tDiagUpRight.IDInt < GameConstants.TILE_ROOF || tDiagUpRight.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_RIGHT.ToString();
                                t.HasCollision = true;
                            }
                            /*
                             *  ##
                             *  t.
                             *  #.
                             */
                            else if ((tUp.IDInt >= GameConstants.TILE_ROOF && tUp.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              (tDown.IDInt >= GameConstants.TILE_ROOF && tDown.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              (tRight.IDInt < GameConstants.TILE_ROOF || tRight.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              (tDiagDownRight.IDInt < GameConstants.TILE_ROOF || tDiagDownRight.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              (tDiagUpRight.IDInt >= GameConstants.TILE_ROOF && tDiagUpRight.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_RIGHT.ToString();
                                t.HasCollision = true;
                            }
                            /*
                             *  #.
                             *  t#
                             *  ##
                             */
                            else if (IsWithin(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagUpRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_SMALL_BOTTOM_LEFT_CORNER.ToString();
                                t.HasCollision = true;
                            }
                            /*
                             *  ##
                             *  t#
                             *  #.
                             */
                            else if (IsWithin(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagDownRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_SMALL_TOP_LEFT_CORNER.ToString();
                                t.HasCollision = true;
                            }
                        }
                        #endregion
                        #region RIGHT COLUMN Y > 0 Y < Layer.Height - 1
                        else if (x == layer.Width - 1 && y > 0 && y < layer.Height - 1)
                        {
                            /*
                             *  Get tiles around tile
                             */
                            Tile tDown = layer.GetTile(x, y + 1);
                            Tile tUp = layer.GetTile(x, y - 1);
                            Tile tLeft = layer.GetTile(x - 1, y);
                            Tile tDiagDownLeft = layer.GetTile(x - 1, y + 1);
                            Tile tDiagUpLeft = layer.GetTile(x - 1, y - 1);

                            /*
                             *   ##
                             *   #t
                             *   ##
                             */
                            if ((tLeft.IDInt >= GameConstants.TILE_ROOF && tLeft.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                               (tUp.IDInt >= GameConstants.TILE_ROOF && tUp.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                               (tDown.IDInt >= GameConstants.TILE_ROOF && tDown.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                               (tDiagDownLeft.IDInt >= GameConstants.TILE_ROOF && tDiagDownLeft.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                               (tDiagUpLeft.IDInt >= GameConstants.TILE_ROOF && tDiagUpLeft.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.HasCollision = true;
                                t.Depth = GameConstants.DEPTH_JUST_ABOVE_ENTITY;
                                continue;
                            }
                            /*
                             *  .#
                             *  .t
                             *  .#
                             */
                            else if ((tUp.IDInt >= GameConstants.TILE_ROOF && tUp.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              (tDown.IDInt >= GameConstants.TILE_ROOF && tDown.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              (tLeft.IDInt < GameConstants.TILE_ROOF || tLeft.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              (tDiagDownLeft.IDInt < GameConstants.TILE_ROOF || tDiagDownLeft.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              (tDiagUpLeft.IDInt < GameConstants.TILE_ROOF || tDiagUpLeft.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_LEFT.ToString();
                                t.HasCollision = true;
                            }
                            /*
                             *  .#
                             *  .t
                             *  ##
                             */
                            else if ((tUp.IDInt >= GameConstants.TILE_ROOF && tUp.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              (tDown.IDInt >= GameConstants.TILE_ROOF && tDown.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              (tLeft.IDInt < GameConstants.TILE_ROOF || tLeft.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              (tDiagDownLeft.IDInt >= GameConstants.TILE_ROOF && tDiagDownLeft.IDInt <= GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              (tDiagUpLeft.IDInt < GameConstants.TILE_ROOF || tDiagUpLeft.IDInt > GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_LEFT.ToString();
                                t.HasCollision = true;
                            }
                            /*
                             *  ##
                             *  .t
                             *  .#
                             */
                            else if (IsWithin(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagDownLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_LEFT.ToString();
                                t.HasCollision = true;
                            }
                            /*
                             *  ##
                             *  #t
                             *  .#
                             */
                            else if (IsWithin(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagDownLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_SMALL_TOP_RIGHT_CORNER.ToString();
                                t.HasCollision = true;
                            }
                            /*
                             *  .#
                             *  #t
                             *  ##
                             */
                            else if (IsWithin(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER.ToString();
                                t.HasCollision = true;
                            }
                        }
                        #endregion
                        #region EVERY OTHER VARIATION
                        if (x > 0 && x < layer.Width - 1 && y > 0 && y < layer.Height - 1)
                        {
                            /*
                             *  Get tiles around tile
                             */
                            Tile tDown = layer.GetTile(x, y + 1);
                            Tile tUp = layer.GetTile(x, y - 1);
                            Tile tLeft = layer.GetTile(x - 1, y);
                            Tile tRight = layer.GetTile(x + 1, y);

                            Tile tDiagDownLeft = layer.GetTile(x - 1, y + 1);
                            Tile tDiagUpLeft = layer.GetTile(x - 1, y - 1);
                            Tile tDiagUpRight = layer.GetTile(x + 1, y - 1);
                            Tile tDiagDownRight = layer.GetTile(x + 1, y + 1);

                            /*
                             *   ###
                             *   #t#
                             *   ###
                             */
                            if (IsWithin(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                               IsWithin(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                               IsWithin(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                               IsWithin(tRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                               IsWithin(tDiagDownLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                               IsWithin(tDiagUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                               IsWithin(tDiagUpRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                               IsWithin(tDiagDownRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.HasCollision = true;
                                t.Depth = GameConstants.DEPTH_JUST_ABOVE_ENTITY;
                                continue;
                            }
                            /*
                             *   ...
                             *   #t.    Transparent Tile Family
                             *   ##.
                             */
                            else if (IsWithin(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagUpRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagDownRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_RIGHT_TOP_CORNER.ToString();

                                AddTileCopyFromLayer(t, floorLayer);
                                t.Depth = GameConstants.DEPTH_JUST_ABOVE_ENTITY;
                                tDown.HasCollision = true;
                            }
                            /*
                             *   ##.
                             *   #t.
                             *   ...
                             */
                            else if (IsWithin(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagDownLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagUpRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagDownRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_RIGHT_BOTTOM_CORNER.ToString();
                                t.Depth = GameConstants.DEPTH_JUST_ABOVE_ENTITY;
                                t.HasCollision = true;
                            }
                            /*
                             *   ##.
                             *   #t.
                             *   ##.
                             */
                            else if (IsWithin(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagUpRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagDownRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_RIGHT.ToString();
                                t.Depth = GameConstants.DEPTH_JUST_ABOVE_ENTITY;
                                t.HasCollision = true;
                            }
                            /*
                             *   .##
                             *   .t#
                             *   .##
                             */
                            else if (IsOutside(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagDownLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_LEFT.ToString();
                                t.Depth = GameConstants.DEPTH_JUST_ABOVE_ENTITY;
                                t.HasCollision = true;
                            }
                            /*
                             *   ...
                             *   .t#    Transparent Tile Family
                             *   .##
                             */
                            else if (IsOutside(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagDownLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagUpRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_LEFT_TOP_CORNER.ToString();

                                AddTileCopyFromLayer(t, floorLayer);
                                t.Depth = GameConstants.DEPTH_JUST_ABOVE_ENTITY;
                            }
                            /*
                             *   .##
                             *   .t#
                             *   ...
                             */
                            else if (IsOutside(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagDownLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagDownRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_LEFT_BOTTOM_CORNER.ToString();
                                t.HasCollision = true;
                                t.Depth = GameConstants.DEPTH_JUST_ABOVE_ENTITY;
                            }
                            /*
                             *   ###
                             *   #t#
                             *   ...
                             */
                            else if (IsWithin(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagDownLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagDownRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_BOTTOM.ToString();
                                t.HasCollision = true;
                                t.Depth = GameConstants.DEPTH_JUST_ABOVE_ENTITY;
                            }
                            /*
                             *   ###
                             *   #t#
                             *   #..
                             */
                            else if (IsWithin(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagDownRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_BOTTOM.ToString();
                                t.HasCollision = true;
                                t.Depth = GameConstants.DEPTH_JUST_ABOVE_ENTITY;
                            }
                            /*
                             *   ###
                             *   #t#
                             *   #.#
                             */
                            else if (IsWithin(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_BOTTOM.ToString();
                                t.HasCollision = true;
                                t.Depth = GameConstants.DEPTH_JUST_ABOVE_ENTITY;
                            }
                            /*
                             *   ###
                             *   #t#
                             *   ..#
                             */
                            else if (IsWithin(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagDownLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_BOTTOM.ToString();
                                t.HasCollision = true;
                                t.Depth = GameConstants.DEPTH_JUST_ABOVE_ENTITY;
                            }
                            /*
                             *   ...
                             *   #t#    Transparent Tile Family
                             *   ###
                             */
                            else if (IsWithin(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagUpRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_TOP.ToString();

                                AddTileCopyFromLayer(t, floorLayer);
                                t.Depth = GameConstants.DEPTH_JUST_ABOVE_ENTITY;
                                tDown.HasCollision = true;
                            }
                            /*
                             *   #..
                             *   #t#    Transparent Tile Family
                             *   ###
                             */
                            else if (IsWithin(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagUpRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_TOP.ToString();

                                AddTileCopyFromLayer(t, floorLayer);
                                t.Depth = GameConstants.DEPTH_JUST_ABOVE_ENTITY;
                                tDown.HasCollision = true;
                            }
                            /*
                             *   #.#
                             *   #t#    Transparent Tile Family
                             *   ###
                             */
                            else if (IsWithin(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_TOP.ToString();

                                AddTileCopyFromLayer(t, floorLayer);
                                t.Depth = GameConstants.DEPTH_JUST_ABOVE_ENTITY;
                            }
                            /*
                             *   ..#
                             *   #t#    Transparent Tile Family
                             *   ###
                             */
                            else if (IsWithin(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_TOP.ToString();

                                AddTileCopyFromLayer(t, floorLayer);
                                t.Depth = GameConstants.DEPTH_JUST_ABOVE_ENTITY;
                                tDown.HasCollision = true;
                            }
                            /*
                             *   ###
                             *   .t#
                             *   .##
                             */
                            else if (IsOutside(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagDownLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_LEFT.ToString();
                                t.HasCollision = true;
                                t.Depth = GameConstants.DEPTH_JUST_ABOVE_ENTITY;
                            }
                            /*
                             *   ###
                             *   #t.
                             *   ##.
                             */
                            else if (IsWithin(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagDownRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_RIGHT.ToString();
                                t.HasCollision = true;
                                t.Depth = GameConstants.DEPTH_JUST_ABOVE_ENTITY;
                            }
                            /*
                             *   ##.
                             *   #t.
                             *   ###
                             */
                            else if (IsWithin(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagUpRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_RIGHT.ToString();
                                t.HasCollision = true;
                                t.Depth = GameConstants.DEPTH_JUST_ABOVE_ENTITY;
                            }
                            /*
                             *   .##
                             *   .t#
                             *   ###
                             */
                            else if (IsOutside(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsOutside(tDiagUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagUpRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                              IsWithin(tDiagDownRight.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                            {
                                t.ID = GameConstants.TILE_ROOF_EDGE_LEFT.ToString();
                                t.HasCollision = true;
                                t.Depth = GameConstants.DEPTH_JUST_ABOVE_ENTITY;
                            }
                        }
                        #endregion
                    }
                }
            }

            GenerateWalls(layer);
            GenerateShadows();
        }

        private void GenerateShadows()
        {
            Layer layer = worldMap.GetLayer(GameConstants.BOTTOM_LAYER);
            Layer shadowLayer = worldMap.GetLayer(GameConstants.SHADOW_LAYER);

            for (int x = 0; x < layer.Width - 1; x++)
            {
                for (int y = 0; y < layer.Height - 1; y++)
                {
                    Tile t = layer.GetTile(x, y);
                    Tile shadowTile = shadowLayer.GetTile(x, y);
                    shadowTile.Depth = 0.95f;

                    if (IsWithin(t.IDInt, GameConstants.TILE_WALL_TOP, GameConstants.TILE_WALL_BOTTOM_DARK))
                    {
                        // TODO: Make checks for different room types
                        Tile tLeft = layer.GetTile(x - 1, y);
                        Tile tUp = layer.GetTile(x, y - 1);
                        Tile tDown = layer.GetTile(x, y + 1);
                        Tile tDownLeft = layer.GetTile(x - 1, y + 1);
                        /*
                         *  #
                         * #t
                         *  ?
                         */
                        if (IsWithin(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                            IsWithin(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                            IsWithin(tDown.IDInt, GameConstants.TILE_WALL_TOP, GameConstants.TILE_WALL_BOTTOM_DARK))
                        {
                            shadowTile.ID = GameConstants.ENVIRONMENT_SHADOW_POINT_UP_RIGHT.ToString();
                        }

                        if (IsWithin(tUp.IDInt, GameConstants.TILE_WALL_TOP, GameConstants.TILE_WALL_TOP_DARK) &&
                            IsWithin(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                        {
                            shadowTile.ID = GameConstants.ENVIRONMENT_SHADOW_SQUARE.ToString();
                        }
                    }
                    else if (IsWithin(t.IDInt, GameConstants.TILE_FLOOR_BRICK, GameConstants.TILE_FLOOR_BRICK_DARK))
                    {
                        Tile tLeft = layer.GetTile(x - 1, y);
                        Tile tRight = layer.GetTile(x + 1, y);
                        Tile tUp = layer.GetTile(x, y - 1);
                        Tile tDown = layer.GetTile(x, y + 1);
                        Tile tDownLeft = layer.GetTile(x - 1, y + 1);
                        Tile tUpLeft = layer.GetTile(x - 1, y - 1);
                        Tile tDownRight = layer.GetTile(x + 1, y + 1);

                        /*  
                         *  ?
                         * #t
                         *  #
                         */
                        if (IsWithin(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                            IsWithin(tDown.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                            IsOutside(tUp.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                        {
                            shadowTile.ID = GameConstants.ENVIRONMENT_SHADOW_SQUARE.ToString();
                        }
                        /*  
                         *  ?
                         * #t
                         *  ?
                         */
                        else if (IsWithin(tLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                                ((IsWithin(tDown.IDInt, GameConstants.TILE_FLOOR_BRICK, GameConstants.TILE_FLOOR_BRICK_DARK) ||
                                (IsWithin(tDown.IDInt, GameConstants.TILE_WALL_TOP, GameConstants.TILE_WALL_BOTTOM_DARK) &&
                                    IsWithin(tUp.IDInt, GameConstants.TILE_FLOOR_BRICK, GameConstants.TILE_FLOOR_BRICK_DARK)) ||
                                    (IsWithin(tUp.IDInt, GameConstants.TILE_WALL_TOP, GameConstants.TILE_WALL_BOTTOM_DARK)))))
                        {
                            shadowTile.ID = GameConstants.ENVIRONMENT_SHADOW_SQUARE.ToString();
                        }
                        /*  
                         * #B
                         * Wt
                         * WB
                         */
                        //else if (IsWithin(tLeft.IDInt, GameConstants.TILE_WALL_TOP, GameConstants.TILE_WALL_BOTTOM_DARK) &&
                        //        IsWithin(tUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                        //        IsWithin(tUp.IDInt, GameConstants.TILE_FLOOR_BRICK, GameConstants.TILE_FLOOR_BRICK_DARK) &&
                        //        IsWithin(tDown.IDInt, GameConstants.TILE_FLOOR_BRICK, GameConstants.TILE_FLOOR_BRICK_DARK) &&
                        //        IsWithin(tDownLeft.IDInt, GameConstants.TILE_WALL_TOP, GameConstants.TILE_WALL_BOTTOM_DARK))
                        //{
                        //    //shadowTile.ID = GameConstants.ENVIRONMENT_SHADOW_POINT_DOWN_RIGHT.ToString();
                        //}
                        /*  
                         * #
                         * Pt   P = Pillar.
                         * PB
                         */
                        else if (IsWithin(tDownLeft.IDInt, GameConstants.TILE_WALL_PILLAR_RIGHT_TOP, GameConstants.TILE_WALL_PILLAR_RIGHT_BOTTOM) &&
                            IsWithin(tLeft.IDInt, GameConstants.TILE_WALL_PILLAR_RIGHT_TOP, GameConstants.TILE_WALL_PILLAR_RIGHT_BOTTOM) &&
                            IsWithin(tDown.IDInt, GameConstants.TILE_FLOOR_BRICK, GameConstants.TILE_FLOOR_BRICK_DARK) &&
                            IsWithin(tUpLeft.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER))
                        {
                            shadowTile.ID = GameConstants.ENVIRONMENT_SHADOW_POINT_DOWN_RIGHT.ToString();
                        }
                        /*  
                         * P
                         * Pt
                         * P 
                         */
                        else if (IsWithin(tDownLeft.IDInt, GameConstants.TILE_WALL_PILLAR_RIGHT_TOP, GameConstants.TILE_WALL_PILLAR_RIGHT_BOTTOM) &&
                            IsWithin(tLeft.IDInt, GameConstants.TILE_WALL_PILLAR_RIGHT_TOP, GameConstants.TILE_WALL_PILLAR_RIGHT_BOTTOM) &&
                            IsWithin(tUpLeft.IDInt, GameConstants.TILE_WALL_PILLAR_RIGHT_TOP, GameConstants.TILE_WALL_PILLAR_RIGHT_BOTTOM))
                        {
                            shadowTile.ID = GameConstants.ENVIRONMENT_SHADOW_POINT_DOWN_RIGHT_BOTTOM.ToString();
                        }
                    }
                }
            }
        }

        private string GetWallType(bool top = true)
        {
            var r = Game1.rand.Next(0, 200 + 1);

            if (top)
            {
                if (r >= 40 && r <= 60)
                {
                    return GameConstants.TILE_WALL_TOP_DARK.ToString();
                }
                else
                {
                    return GameConstants.TILE_WALL_TOP.ToString();
                }
            }
            else
            {
                if (r >= 40 && r <= 60)
                {
                    return GameConstants.TILE_WALL_BOTTOM_DARK.ToString();
                }
                else
                {
                    return GameConstants.TILE_WALL_BOTTOM.ToString();
                }
            }
        }

        private void GenerateWalls(Layer layer)
        {
            for (int x = 0; x < layer.Width; x++)
            {
                for (int y = 0; y < layer.Height; y++)
                {
                    Tile t = layer.GetTile(x, y);

                    if (y == layer.Height - 2)
                    {
                        Tile tDown1 = layer.GetTile(x, y + 1);
                        Tile tLeft = layer.GetTile(x - 1, y);
                        Tile tRight = layer.GetTile(x + 1, y);

                        /*
                         *    t
                         *    #
                         */
                        if (IsWithin(t.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                            IsWithin(tDown1.IDInt, GameConstants.TILE_FLOOR_BRICK, GameConstants.TILE_FLOOR_BRICK_DARK))
                        {
                            if (IsWithin(tLeft.IDInt, GameConstants.TILE_FLOOR_BRICK, GameConstants.TILE_FLOOR_BRICK_DARK))
                            {
                                tDown1.ID = GameConstants.TILE_WALL_PILLAR_LEFT_TOP.ToString();
                                tDown1.HasCollision = true;
                            }
                            else if(IsWithin(tLeft.IDInt, GameConstants.TILE_FLOOR_BRICK, GameConstants.TILE_FLOOR_BRICK_DARK))
                            {
                                tDown1.ID = GameConstants.TILE_WALL_PILLAR_RIGHT_TOP.ToString();
                                tDown1.HasCollision = true;
                            }
                            else
                            {
                                tDown1.ID = GetWallType();
                                tDown1.HasCollision = true;
                            }
                        }
                    }
                    else if (y < layer.Height - 2)
                    {
                        Tile tDown1 = layer.GetTile(x, y + 1);
                        Tile tDown2 = layer.GetTile(x, y + 2);
                        Tile tLeft = layer.GetTile(x - 1, y);
                        Tile tRight = layer.GetTile(x + 1, y);

                        /*
                         *    t
                         *    #
                         *    #
                         */
                        if (IsWithin(t.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                            IsWithin(tDown1.IDInt, GameConstants.TILE_FLOOR_BRICK, GameConstants.TILE_FLOOR_BRICK_DARK) &&
                            IsWithin(tDown2.IDInt, GameConstants.TILE_FLOOR_BRICK, GameConstants.TILE_FLOOR_BRICK_DARK))
                        {
                            if (IsWithin(tRight.IDInt, GameConstants.TILE_FLOOR_BRICK, GameConstants.TILE_FLOOR_BRICK_DARK))
                            {
                                Tile tDown3 = layer.GetTile(x, y + 3);

                                tDown1.ID = GameConstants.TILE_WALL_PILLAR_RIGHT_TOP.ToString();
                                tDown1.HasCollision = true;
                                tDown2.ID = GameConstants.TILE_WALL_PILLAR_RIGHT_MIDDLE.ToString();
                                tDown2.HasCollision = true;
                                tDown3.ID = GameConstants.TILE_WALL_PILLAR_RIGHT_BOTTOM.ToString();
                            }
                            else if (IsWithin(tLeft.IDInt, GameConstants.TILE_FLOOR_BRICK, GameConstants.TILE_FLOOR_BRICK_DARK))
                            {
                                Tile tDown3 = layer.GetTile(x, y + 3);

                                tDown1.ID = GameConstants.TILE_WALL_PILLAR_LEFT_TOP.ToString();
                                tDown1.HasCollision = true;
                                tDown2.ID = GameConstants.TILE_WALL_PILLAR_LEFT_MIDDLE.ToString();
                                tDown2.HasCollision = true;
                                tDown3.ID = GameConstants.TILE_WALL_PILLAR_LEFT_BOTTOM.ToString();
                            }
                            else
                            {
                                tDown1.ID = GetWallType();
                                tDown1.HasCollision = true;
                                tDown2.ID = GetWallType(false);
                            }
                        }
                        /*
                         *    t
                         *    #
                         *    ?
                         */
                        else if (IsWithin(t.IDInt, GameConstants.TILE_ROOF, GameConstants.TILE_ROOF_SMALL_BOTTOM_RIGHT_CORNER) &&
                            IsWithin(tDown1.IDInt, GameConstants.TILE_FLOOR_BRICK, GameConstants.TILE_FLOOR_BRICK_DARK) &&
                            IsOutside(tDown2.IDInt, GameConstants.TILE_FLOOR_BRICK, GameConstants.TILE_FLOOR_BRICK_DARK))
                        {
                            tDown1.ID = GetWallType();
                        }
                    }
                }
            }
        }

        private bool IsWithin(int id, int rangeMin, int rangeMax)
        {
            if (id >= rangeMin && id <= rangeMax)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool IsOutside(int id, int rangeMin, int rangeMax)
        {
            if (id < rangeMin || id > rangeMax)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetupWorld()
        {
            RoomBuilder rb = new RoomBuilder();
            rb.LoadRooms();

            //var roomNum = Game1.rand.Next(0, 2);
            var roomNum = 0;

            if (roomNum == 0)
            {
                DungeonLayer layer = new DungeonLayer();
                DungeonLayer topLayer = new DungeonLayer();
                DungeonLayer floorLayer = new DungeonLayer();
                layer.ZOrder = 0.001f;
                topLayer.ZOrder = 0.9f;
                Room room = rb.GetRoom(GameConstants.ROOM_ROOM_02);

                WorldWidth = room.Width;
                WorldHeight = room.Height;

                layer.Width = room.Width;
                layer.Height = room.Height;
                topLayer.Width = layer.Width;
                topLayer.Height = layer.Height;
                floorLayer.Width = room.Width;
                floorLayer.Height = room.Height;

                for (int y = 0; y < room.Height; y++)
                {
                    for (int x = 0; x < room.Width; x++)
                    {
                        if (room.Tiles[x + y * room.Width] == '#')
                        {
                            Tile t = new Tile(GameConstants.TILE_ROOF.ToString(), new Vector2(x, y));
                            layer.AddTile(t);
                        }
                        else
                        {
                            var dark = Game1.rand.Next(0, 200 + 1);

                            if (dark >= 40 && dark <= 60)
                            {
                                Tile t = new Tile(GameConstants.TILE_FLOOR_BRICK_DARK.ToString(), new Vector2(x, y));
                                layer.AddTile(t);
                            }
                            else
                            {
                                Tile t = new Tile(GameConstants.TILE_FLOOR_BRICK.ToString(), new Vector2(x, y));
                                layer.AddTile(t);
                            }
                        }

                        Tile tEmpty = new Tile(GameConstants.TILE_EMPTY.ToString(), new Vector2(x, y));
                        topLayer.AddTile(tEmpty);
                        floorLayer.AddTile(tEmpty.DeepCopy());
                    }
                }

                // Make sure we add the layers in the order we want them...
                worldMap.AddLayer(GameConstants.BOTTOM_LAYER, layer);
                worldMap.AddLayer(GameConstants.SHADOW_LAYER, topLayer);
                worldMap.AddLayer(GameConstants.FLOOR_LAYER, floorLayer);

                DoLayerCalculations(layer);
            }
        }

        private void AddTileCopyFromLayer(Tile t, Layer newLayer)
        {
            var newTile = t.DeepCopy();
            newTile.ID = GetRandomGroundTileStyle(GameConstants.TILE_FLOOR_BRICK).ToString();
            newLayer.AddTile(newTile);
        }
    }
}
