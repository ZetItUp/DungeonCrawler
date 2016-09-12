using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtriLib3.Utility;
using System.IO;

namespace DungeonCrawler.World
{
    public class RoomBuilder
    {
        private Dictionary<string, Room> rooms;

        public Room GetRoom(string key)
        {
            Room room;
            rooms.TryGetValue(key, out room);

            return room;
        }

        public RoomBuilder()
        {
            rooms = new Dictionary<string, Room>();
        }

        public void LoadRooms()
        {
            string _path = Path.Combine(Utils.AssemblyDirectory, "Content", "Data", "Rooms");

            foreach (var file in Directory.EnumerateFiles(_path, "*.txt"))
            {
                bool firstLine = true;
                Room room = new Room();

                int x = 0;
                int y = 0;

                using (StreamReader sr = new StreamReader(file))
                {
                    while(sr.Peek() > 0)
                    {
                        string currLine = sr.ReadLine();

                        if(firstLine)
                        {
                            string[] sizes = currLine.Split(' ');

                            if(sizes.Length != 2)
                            {
                                // TODO: Evil Error Message later!
                            }
                            else
                            {
                                int width = int.Parse(sizes[0]);
                                int height = int.Parse(sizes[1]);

                                room.InitRoom(width, height);
                            }

                            firstLine = false;

                            continue;
                        }

                        for(int i = 0; i < currLine.Length; i++)
                        {
                            room.Tiles[x, y] = currLine[i];
                            x++;
                        }

                        y++;
                        x = 0;
                    }

                    if (room.Width != 0 && room.Height != 0 && room.Tiles.Length > 0)
                    {
                        string key = string.Empty;

                        // TODO: Make this suitable for more rooms...

                        if (file.Contains("Room1"))
                        {
                            key = GameConstants.ROOM_ROOM_01;
                        }
                        else if (file.Contains("Room2"))
                        {
                            key = GameConstants.ROOM_ROOM_02;
                        }
                        else if(file.Contains("Room3"))
                        {
                            key = GameConstants.ROOM_ROOM_03;
                        }
                        else
                        {
                            // TODO: Evil error message! File error stuff.
                            continue;
                        }

                        rooms.Add(key, room);
                    }
                }
            }
        }
    }
}
