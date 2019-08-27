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
        public bool enabled = true;

        public static Texture2D myTexture; //placeholder

        public static void SetTexture()
        {
            //myTexture = rl.LoadTexture(file);
        }

        public void PickupDraw()
        {
            if (!enabled)
            {
                return;
            }
            rl.DrawCircleGradient((int)pos.x + 15, (int)pos.y + 15, 10f, Color.GOLD, Color.YELLOW);
            //rl.DrawTexture(myTexture, (int)pos.x + 15, (int)pos.y + 15, Color.WHITE);
        }
    }
}
