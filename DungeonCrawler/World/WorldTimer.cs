using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DungeonCrawler.World
{
    public enum TimeOfDay
    {
        Morning = 0,
        Day = 1,
        Afternoon = 2,
        Night = 3
    };

    public static class WorldTimer
    {
        private static Color colorMorning = new Color(190, 80, 50);
        private static Color colorDay = Color.White;
        private static Color colorAfternoon = new Color(235, 135, 75);
        private static Color colorNight = new Color(28, 37, 53);

        public static TimeOfDay CurrentTimeOfDay { get; set; }

        static WorldTimer()
        {
            CurrentTimeOfDay = TimeOfDay.Day;
        }

        public static Color GetWorldColorTint()
        {
            if (CurrentTimeOfDay == TimeOfDay.Morning)
                return colorMorning;
            else if (CurrentTimeOfDay == TimeOfDay.Day)
                return colorDay;
            else if (CurrentTimeOfDay == TimeOfDay.Afternoon)
                return colorAfternoon;
            else
                return colorNight;
        }
    }
}
