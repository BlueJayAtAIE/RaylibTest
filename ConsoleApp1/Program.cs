using System.IO;
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

            void Restart()
            {
                if (rl.IsKeyDown(KeyboardKey.KEY_R))
                {
                    Init();
                }
            }

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

            void Init()
            {
                timer = 1800;
                score = 0;

                player.pos.x = 20;
                player.pos.y = 20;
                player.enabled = true;
                player.hasWon = false;

                System.Array.Clear(pickup, 0, 9);
                int idx = 0;
                for (int j = 0; j < 10 && idx < 10; j++)
                {
                    pickup[idx] = new Pickup();
                    pickup[idx].pos.x = Tools.rng.Next(100, 700);
                    pickup[idx].pos.y = Tools.rng.Next(50, 400);
                    idx++;
                }

                System.Array.Clear(enemy, 0, 2);
                idx = 0;
                for (int j = 0; j < 3 && idx < 3; j++)
                {
                    enemy[idx] = new Enemy();
                    enemy[idx].pos.x = Tools.rng.Next(100, 700);
                    enemy[idx].pos.y = Tools.rng.Next(50, 400);
                    idx++;
                }
            }

            Init();

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
                rl.DrawCircleGradient(400, 225, i, Color.DARKBLUE, Color.BLACK);

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
                    e.EnemyUpdate();
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

                rl.DrawRectangleGradientV(320, -5, 155, 80, Color.DARKBLUE, Color.SKYBLUE);
                rl.DrawText($"Score: {score}", 335, 10, 30, Color.WHITE);
                rl.DrawText($"Timer: {timer / 60}", 330, 40, 30, Color.WHITE);


                if (score >= scoreToWin)
                {
                    rl.DrawRectangleGradientV(280, 395, 250, 55, Color.SKYBLUE, Color.BLUE);
                    rl.DrawText($"You Win!", 300, 400, 50, Color.WHITE);
                    rl.DrawText("Press \"r\" to restart.", 195, 180, 40, Color.WHITE);
                    player.hasWon = true;
                    player.enabled = false;
                    Restart();
                }

                if (!player.enabled && timer > 0 && !player.hasWon)
                {
                    rl.DrawRectangleGradientV(280, 395, 265, 55, Color.RED, Color.MAROON);
                    rl.DrawText($"You Died.", 300, 400, 50, Color.WHITE);
                    rl.DrawText("Press \"r\" to restart.", 195, 180, 40, Color.WHITE);
                    Restart();
                }

                if (timer == 0)
                {
                    rl.DrawRectangleGradientV(280, 395, 250, 55, Color.RED, Color.MAROON);
                    rl.DrawText($"Times up!", 300, 400, 50, Color.WHITE);
                    rl.DrawText("Press \"r\" to restart.", 195, 180, 40, Color.WHITE);
                    player.enabled = false;
                    Restart();
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