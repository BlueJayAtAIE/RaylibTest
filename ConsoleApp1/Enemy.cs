using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace ConsoleApp1
{
    public class Enemy
    {
        public Vector2 pos = new Vector2(0, 0);
        float speed = 5f;
        public bool enabled = true;
        public Color[] coreColor = new Color[4] { Color.RED, Color.MAROON, Color.GRAY, Color.DARKGRAY };

        public void EnemyUpdate()
        {
            if (!enabled) // If the enemy is dead, disables controls
            {
                return;
            }

            //Basic Movement
            pos.x += Tools.rng.Next(6); //temp
            pos.y -= Tools.rng.Next(20);

            //Checking for screen wrap
            if (pos.x > 800)
            {
                pos.x = -30;
            }
            if (pos.x < -30)
            {
                pos.x = 800;
            }
            if (pos.y > 450)
            {
                pos.y = -30;
            }
            if (pos.y < -30)
            {
                pos.y = 450;
            }
        }

        public Color CurrentInnerColor()
        {
            if (enabled)
                return coreColor[0];
            else
                return coreColor[2];
        }
        public Color CurrentOutterColor()
        {
            if (enabled)
                return coreColor[1];
            else
                return coreColor[3];
        }

        public void EnemyDraw()
        {
            rl.DrawRectangleGradientV((int)pos.x, (int)pos.y, 30, 30, Color.VIOLET, Color.DARKPURPLE);
            rl.DrawCircleGradient((int)pos.x + 15, (int)pos.y + 15, 10f, CurrentInnerColor(), CurrentOutterColor());
        }
    }
}
