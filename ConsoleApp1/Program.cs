using Raylib;
using rl = Raylib.Raylib;


namespace ConsoleApp1
{
    static class Program
    {     
       public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            int screenWidth = 800;
            int screenHeight = 450;

            Tools tl = new Tools();
            Player player = new Player();
            Pickup[] pickup = new Pickup[10];
            Enemy[] enemy = new Enemy[3];

            int timer = 1800;
            int scoreToWin = 10;
            int score = 0;

            float i = 10f;
            bool condense = false;

            player.enabled = true;

            System.Array.Clear(pickup, 0, 9);
            int idx = 0;
            for (int j = 0; j < 10 && idx < 10; j++)
            {
                pickup[idx] = new Pickup();
                pickup[idx].pos.x = tl.rng.Next(100, 700);
                pickup[idx].pos.y = tl.rng.Next(50, 400);
                idx++;
            }

            System.Array.Clear(enemy, 0, 2);
            idx = 0;
            for (int j = 0; j < 3 && idx < 3; j++)
            {
                enemy[idx] = new Enemy();
                enemy[idx].pos.x = tl.rng.Next(100, 700);
                enemy[idx].pos.y = tl.rng.Next(50, 400);
                idx++;
            }

            rl.InitWindow(screenWidth, screenHeight, "Raylib Playground");
            rl.SetTargetFPS(60);
            //--------------------------------------------------------------------------------------

            // Main game loop
            while (!rl.WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update - Where you update variables, run update functions, etc.
                //----------------------------------------------------------------------------------
                player.PlayerUpdate();
                if (timer > 0 && player.enabled && score < scoreToWin)
                {
                    timer--;
                }

                if (condense == true)
                {
                    i--;
                    if (i == 10)
                        condense = false;
                }
                else
                {
                    i++;
                    if (i > 250)
                        condense = true;
                }

                //End Update -----------------------------------------------------------------------

                // Draw - The top is drawn first, and is thusly on the bottom.
                //----------------------------------------------------------------------------------
                rl.BeginDrawing();

                rl.ClearBackground(Color.BLACK);
                rl.DrawCircleGradient(400, 225, i, Color.DARKBLUE, Color.BLUE);

                player.PlayerDraw();

                foreach (Pickup p in pickup)
                {
                    if (p.enabled)
                    {
                        p.PickupDraw();
                        score += tl.CheckCollisionPickup(player, p) ? 1 : 0;
                    }
                }

                foreach (Enemy e in enemy)
                {
                    e.EnemyDraw();
                    if (e.enabled)
                    {
                        tl.CheckCollisionEnemy(player, e);
                    }
                    if (score >= scoreToWin)
                    {
                        e.enabled = false;
                    }
                }

                rl.DrawText($"Your score is {score}", 275, 50, 30, Color.WHITE);
                rl.DrawText($"{timer / 60}", 350, 100, 30, Color.WHITE);

                if (score >= scoreToWin)
                {
                    rl.DrawText($"You Win!", 325, 400, 30, Color.WHITE);
                    player.hasWon = true;
                    player.enabled = false;
                }

                if (!player.enabled && timer > 0 && score < scoreToWin)
                {
                    rl.DrawText($"You Died.", 325, 400, 30, Color.WHITE);
                }

                if (timer == 0)
                {
                    rl.DrawText($"Times up!", 325, 400, 30, Color.WHITE);
                    player.enabled = false;
                }

                

                rl.EndDrawing();
                //End Drawing ----------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            rl.CloseWindow();        // Close window and OpenGL context
            //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}