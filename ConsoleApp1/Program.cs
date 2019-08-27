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

            Player pl = new Player();

            Pickup[] pickup = new Pickup[10];
            int idx = 0;
            for (int j = 0; j < 10 && idx < 10; j++)
            {
                pickup[idx] = new Pickup();
                pickup[idx].pos.x = tl.rng.Next(100, 700);
                pickup[idx].pos.y = tl.rng.Next(50, 400);
                idx++;
            }

            rl.InitWindow(screenWidth, screenHeight, "Raylib Playground");

            float i = 10f;
            bool condense = false;

            int score = 0;

            rl.SetTargetFPS(60);
            //--------------------------------------------------------------------------------------

            // Main game loop
            while (!rl.WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update - Where you update variables, run update functions, etc.
                //----------------------------------------------------------------------------------
                pl.PlayerUpdate();

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
                //Color test = rl.ColorFromHSV(new Vector3(i, 255, 200)); // N O

                //End Update -----------------------------------------------------------------------

                // Draw - The top is drawn first, and is thusly on the bottom.
                //----------------------------------------------------------------------------------
                rl.BeginDrawing();

                rl.ClearBackground(Color.BLACK);
                rl.DrawCircleGradient(400, 225, i, Color.DARKBLUE, Color.BLUE);
                foreach (Pickup p in pickup)
                {
                    if (p.Enabled)
                    {
                        p.PickupDraw();
                        score += tl.CheckCollision(pl, p) ? 1 : 0;
                    }
                }
                pl.PlayerDraw();
                rl.DrawText($"Your score is {score}", 275, 50, 30, Color.WHITE);
                if (score >= 10)
                {
                    rl.DrawText($"You Win!", 325, 400, 30, Color.WHITE);
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