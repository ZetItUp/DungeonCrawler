using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DungeonCrawler.Interfaces
{
    public interface IBaseSpeed
    {
        float BaseSpeed { get; set; }
        Vector2 AppliedSpeed { get; set; }

        void SetSpeed(float speed);
        void SetSpeed(float speedX, float speedY);
        void ApplySpeed(Vector2 velocity);
        float GetVelocity();
    }
}
