using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace BananaManor.Scenes
{
    class GarageScene : Scene
    {
        string GarageArt = @" ";
        string TruckArt = @" ";
        string SportsCarArt = @" ";
        string MinivanArt = @" ";
        public GarageScene(Game game) : base(game)
        {
            
        }

        public override void Run()
        {
            if (!NewGame.NewPlayer.HasCarKeys)
            {
                Clear();
                WriteLine("This is the garage where there are a number of fancy cars available.");
                WriteLine("It looks like you don't have any car keys. Come back when you find them.");
                ConsoleUtils.WaitForKeyPress();
                NewGame.NewNavigationScene.Run();
            }
            else
            {
                Clear();
                string prompt = $@" {GarageArt} < Art will go here showing the fancy cars >
Which vehicle would you like to take for a ride?";
                string[] options = { "Truck", "Sports Car", "Minivan", "Motorcycle" };
                Menu menu = new Menu(prompt, options);
                int selectedIndex = menu.Run();
                switch (selectedIndex)
                {
                    case 0:
                        WriteLine("You picked the Truck. Enjoy your ride!");
                        break;
                    case 1:
                        WriteLine("You picked the Sports Car. Enjoy your ride!");
                        break;
                    case 2:
                        WriteLine("You picked the Minivan. Enjoy your ride!");
                        break;
                }
            }
        }
    }
}
