using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace ConsoleApp1
{
    public class Tools
    {
        public Random rng = new Random();
        public bool CheckCollision(Player _pl, Pickup _pu)
        {
            bool rtn = false;
            Rectangle pickupCol = new Rectangle(_pu.pos.x + 5, _pu.pos.y + 5, 20, 20);
            Rectangle playerCol = new Rectangle(_pl.pos.x, _pl.pos.y, 30, 30);
            rtn = rl.CheckCollisionRecs(pickupCol, playerCol);
            if (rtn)
            {
                _pu.Enabled = false;
            }
            return rtn;
        }
    }
}
