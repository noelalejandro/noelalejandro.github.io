using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace BananaManor.Scenes
{
    class GreenhouseScene : Scene
    {
        public GreenhouseScene(Game game) : base(game)
        {

        }

        public override void Run()
        {
            string prompt = "There are so many banana trees in the greenhouse. Let's get a little closer to them.\n";
            string[] options = { "Climb", "Shake", "Water", "Hug", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Clear();
                    WriteLine("You've found the tallest banana tree in the greenhouse. Let's climb it to get a better view!");
                    ConsoleUtils.WaitForKeyPress();
                    Clear();
                    WriteLine("We can see so much from up here! It's a little shaky though. Let's go back down");
                    ConsoleUtils.WaitForKeyPress();
                    Clear();
                    NewGame.NewGreenhouseScene.Run();
                    break;
                case 1:
                    Clear();
                    WriteLine("Those bananas up there look fairly loose. Let's see if we can shake them off!");
                    ConsoleUtils.WaitForKeyPress();
                    Clear();
                    WriteLine("Shake! Shake! Shake!");
                    ConsoleUtils.WaitForKeyPress();
                    Clear();
                    WriteLine("We did it! A fresh bunch of bananas have fallen at your feet. Let's save a few for later.");
                    ConsoleUtils.WaitForKeyPress();
                    NewGame.NewGreenhouseScene.Run();
                    break;
                case 2:
                    Clear();
                    WriteLine("Some of these trees look a little thirsty. Let's give them some water.");
                    ConsoleUtils.WaitForKeyPress();
                    Clear();
                    WriteLine("Drip. Drip. Drip.");
                    ConsoleUtils.WaitForKeyPress();
                    Clear();
                    WriteLine("The trees are so much happier now that they've been watered!");
                    ConsoleUtils.WaitForKeyPress();
                    NewGame.NewGreenhouseScene.Run();
                    break;
                case 3:
                    Clear();
                    WriteLine("Aww, the trees look sad. Let's show them some love with a hug!");
                    ConsoleUtils.WaitForKeyPress();
                    Clear();
                    WriteLine("<3 <3 <3 <3");
                    ConsoleUtils.WaitForKeyPress();
                    Clear();
                    WriteLine("Much better! All of the trees are happy now.");
                    ConsoleUtils.WaitForKeyPress();
                    NewGame.NewGreenhouseScene.Run();
                    break;
                case 4:
                    NewGame.NewNavigationScene.Run();
                    break;
            }
        }
    }
}
