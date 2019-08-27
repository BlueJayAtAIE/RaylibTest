using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace ConsoleApp1
{
    public class Player
    {
        public Vector2 pos = new Vector2(0, 0);
        float speed;
        public bool enabled = true;
        public bool hasWon = false;
        public Color[] coreColor = new Color[6] { Color.SKYBLUE, Color.BLUE, Color.RED, Color.DARKPURPLE, Color.GREEN, Color.LIME };

        public void PlayerUpdate()
        {
            if (rl.IsKeyDown(KeyboardKey.KEY_P)) //For Testing Only
                enabled = false;

            if (!enabled) // If the player is dead, disables controls
            {
                return;
            }

            //Running
            if (rl.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT) || rl.IsKeyDown(KeyboardKey.KEY_RIGHT_SHIFT))
            {
                speed = 3f;
            }
            else
            {
                speed = 1f;
            }

            //Normal Movement
            if (rl.IsKeyDown(KeyboardKey.KEY_W) || rl.IsKeyDown(KeyboardKey.KEY_UP))
            {
                pos.y -= speed;
            }
            if (rl.IsKeyDown(KeyboardKey.KEY_S) || rl.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                pos.y += speed;
            }
            if (rl.IsKeyDown(KeyboardKey.KEY_A) || rl.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                pos.x -= speed;
            }
            if (rl.IsKeyDown(KeyboardKey.KEY_D) || rl.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                pos.x += speed;
            }

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
            if (hasWon)
            {
                return coreColor[4];
            }
            if (enabled)
            {
                return coreColor[0];
            }
            else
            {
                return coreColor[2];
            }
        }
        public Color CurrentOutterColor()
        {
            if (hasWon)
            {
                return coreColor[5];
            }
            if (enabled)
            {
                return coreColor[1];
            }
            else
            {
                return coreColor[3];
            }
        }

        public void PlayerDraw()
        {
            rl.DrawRectangleGradientV((int)pos.x, (int)pos.y, 30, 30, Color.RAYWHITE, Color.GRAY);
            rl.DrawCircleGradient((int)pos.x + 15, (int)pos.y + 15, 10f, CurrentInnerColor(), CurrentOutterColor());
        }
    }
}
