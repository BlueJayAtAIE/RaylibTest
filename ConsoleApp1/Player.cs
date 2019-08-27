using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace ConsoleApp1
{
    public class Player
    {
        public Vector2 pos = new Vector2(20, 20);
        public float speed;
        //public Color myColor = Color.SKYBLUE;

        public void PlayerUpdate()
        {
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
        }

        public void PlayerDraw()
        {
            rl.DrawRectangleGradientV((int)pos.x, (int)pos.y, 30, 30, Color.RAYWHITE, Color.GRAY);
            rl.DrawCircleGradient((int)pos.x + 15, (int)pos.y + 15, 10f, Color.SKYBLUE, Color.BLUE);
        }
    }
}
