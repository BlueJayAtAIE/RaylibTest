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
        public bool CheckCollisionPickup(Player _pl, Pickup _pu)
        {
            bool rtn = false;
            Rectangle pickupCol = new Rectangle(_pu.pos.x + 5, _pu.pos.y + 5, 20, 20);
            Rectangle playerCol = new Rectangle(_pl.pos.x, _pl.pos.y, 30, 30);
            //Debug Stuff Below
            rl.DrawRectangleLines((int)_pu.pos.x + 5, (int)_pu.pos.y + 5, 20, 20, Color.RED); //Hitbox for pickups
            rl.DrawRectangleLines((int)_pl.pos.x, (int)_pl.pos.y, 30, 30, Color.GREEN); //Hitbox for Player
            rtn = rl.CheckCollisionRecs(pickupCol, playerCol);
            if (rtn)
            {
                _pu.pos.x = rng.Next(100, 700);
                _pu.pos.y = rng.Next(50, 400);
            }
            return rtn;
        }

        public bool CheckCollisionEnemy(Player _pl, Enemy _em)
        {
            bool rtn = false;
            Rectangle enemyCol = new Rectangle(_em.pos.x, _em.pos.y, 30, 30);
            Rectangle playerCol = new Rectangle(_pl.pos.x, _pl.pos.y, 30, 30);
            //Debug Stuff Below
            rl.DrawRectangleLines((int)_em.pos.x, (int)_em.pos.y, 30, 30, Color.ORANGE); //Hitbox for enemies
            rl.DrawRectangleLines((int)_pl.pos.x, (int)_pl.pos.y, 30, 30, Color.GREEN); //Hitbox for Player
            rtn = rl.CheckCollisionRecs(enemyCol, playerCol);
            if (rtn)
            {
                _pl.enabled = false;
            }
            return rtn;
        }
    }
}
