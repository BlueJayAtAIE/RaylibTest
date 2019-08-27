using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace ConsoleApp1
{
    public class Pickup
    {
        public Vector2 pos = new Vector2(0, 0);
        public bool Enabled = true;

        public void PickupDraw()
        {
            if (!Enabled)
            {
                return;
            }
            rl.DrawCircleGradient((int)pos.x + 15, (int)pos.y + 15, 10f, Color.GOLD, Color.YELLOW);          
        }
    }
}
