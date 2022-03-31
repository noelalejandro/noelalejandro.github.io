using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace BananaManor.Scenes
{
    class NavigationScene : Scene
    {
        public NavigationScene(Game game) : base(game)
        {

        }

        public override void Run()
        {
            string prompt = "Where would you like to explore?\n";
            string[] options = { "Bedroom", "Kitchen", "Greenhouse", "Garage", "Get me out of here!" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();
            ConsoleKey keyPressed;

            switch (selectedIndex)
            {
                case 0:
                    NewGame.NewBedroomScene.Run();
                    break;
                case 1:
                    NewGame.NewKitchenScene.Run();
                    break;
                case 2:
                    NewGame.NewGreenhouseScene.Run();
                    break;
                case 3:
                    NewGame.NewGarageScene.Run();
                    break;
                case 4:
                    do
                    {
                        Clear();
                        WriteLine("Are you sure you want to leave Banana Manor?");
                        WriteLine("Press < Y > to leave. Press < N > to stay");

                        ConsoleKeyInfo keyInfo = ReadKey(true);
                        keyPressed = keyInfo.Key;


                        if (keyPressed == ConsoleKey.Y)
                        {
                            Clear();
                            WriteLine("We hope you had a pleasant stay.\nPress any key to end the game.");
                            ReadKey(true);
                            Environment.Exit(0);
                        }
                        else if (keyPressed == ConsoleKey.N)
                        {
                            NewGame.NewNavigationScene.Run();
                        }
                    } while (keyPressed != ConsoleKey.Y || keyPressed != ConsoleKey.N);
                    
                    break;
            }
        }
    }
}
