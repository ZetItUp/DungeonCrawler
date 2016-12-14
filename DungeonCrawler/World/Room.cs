using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtriLib3.World2D;

namespace DungeonCrawler.World
{
    public class Room
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public char[] Tiles { get; set; }

        public Room()
        {
            
        }

        public void InitRoom(int width, int height)
        {
            Width = width;
            Height = height;
            Tiles = new char[width * height];
        }
    }
}
