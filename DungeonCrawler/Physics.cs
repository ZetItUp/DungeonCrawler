using System.Collections.Generic;
using AtriLib3.Utility;
using AtriLib3.Interfaces;
using AtriLib3.Graphics;
using Microsoft.Xna.Framework;

namespace DungeonCrawler
{
    public class Physics
    {
        public Physics()
        {

        }

        public static bool CollisionCheck(IWorldObject currentWorldObject, out Rectangle rect)
        {
            QuadTree qTree = Screens.GameScreen.GetQuadTree();
            List<IWorldObject> worldObjects = Screens.GameScreen.GetAllColliders();

            List<IWorldObject> retList = new List<IWorldObject>();
            for (int i = 0; i < worldObjects.Count; i++)
            {
                retList.Clear();
                qTree.Retrieve(retList, currentWorldObject.ObjectRectangle);

                for(int j = 0; j < retList.Count; j++)
                {
                    if(retList[j] == currentWorldObject)
                    {
                        continue;
                    }

                    if (retList[j].ObjectRectangle.Intersects(currentWorldObject.ObjectRectangle))
                    {
                        rect = retList[j].ObjectRectangle;
                        return true;
                    }
                }
            }

            rect = Rectangle.Empty;
            return false;
        }
    }
}
