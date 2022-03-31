using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using static BananaManor.ConsoleUtils;

namespace BananaManor.Scenes
{
    class BedroomScene : Scene
    {
        public BedroomScene(Game game) : base(game)
        {

        }

        public override void Run()
        {
            string prompt = "This is the bedroom. What would you like to do?\n";
            string[] options = { "Organize", "Read", "Journal", "Sleep", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Clear();
                    CharacterColor();
                    WriteLine("This room is a mess! Let's tidy up a little bit.");
                    TextColor();
                    WaitForKeyPress();
                    Clear();
                    WriteLine("...");
                    WaitForKeyPress();
                    Clear();
                    ItemColor();
                    WriteLine("You found a CD! It's Sheryl Crow's greatest hits.");
                    TextColor();
                    WaitForKeyPress();
                    Clear();
                    CharacterColor();
                    WriteLine("I wonder if this is Pepper's favorite CD...");
                    TextColor();
                    WaitForKeyPress();
                    NewGame.NewBedroomScene.Run();
                    break;
                case 1:
                    Clear();
                    CharacterColor();
                    WriteLine("What a cozy reading nook! How about we read for a little while.");
                    WaitForKeyPress();
                    Clear();
                    TextColor();
                    WriteLine("...Time flies when you're reading a great book...");
                    WaitForKeyPress();
                    Clear();
                    CharacterColor();
                    WriteLine("Wow! Very interesting!");
                    WaitForKeyPress();
                    NewGame.NewBedroomScene.Run();
                    break;
                case 2:
                    Clear();
                    WriteLine("It's been a while since we've written down all of our secrets. Let's put that pen to paper!");
                    WaitForKeyPress();
                    Clear();
                    WriteLine("What would you like to write?");
                    WaitForKeyPress();
                    Clear();
                    NewGame.NewBedroomScene.Run();
                    break;
                case 3:
                    Clear();
                    CharacterColor();
                    WriteLine("So sleepy! Time to rest my head.");
                    WaitForKeyPress();
                    Clear();
                    TextColor();
                    WriteLine("zZzZ");
                    WaitForKeyPress();
                    Clear();
                    CharacterColor();
                    WriteLine("I didn't realize how tired I was!");
                    WaitForKeyPress();
                    NewGame.NewBedroomScene.Run();
                    break;
                case 4:
                    NewGame.NewNavigationScene.Run();
                    break;
            }
        }
    }
}
