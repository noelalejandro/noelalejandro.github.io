using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace BananaManor.Scenes
{
    class KitchenScene : Scene
    {
        public KitchenScene(Game game) : base(game)
        {

        }

        public override void Run()
        {
            string prompt = "Welcome to the kitchen. What are you in the mood for?\n";
            string[] options = { "Banana Pudding", "Banana Bread", "Chocolate Cake", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Clear();
                    WriteLine("Splendid choice! Our Banana Pudding is world renowned!");
                    ConsoleUtils.WaitForKeyPress();
                    Clear();
                    WriteLine("Nom nom nom.");
                    ConsoleUtils.WaitForKeyPress();
                    Clear();
                    WriteLine("So tasty! That was probably the best Banana Pudding I've ever had.");
                    ConsoleUtils.WaitForKeyPress();
                    NewGame.NewKitchenScene.Run();
                    break;
                case 1:
                    Clear();
                    WriteLine("My favorite! Our Banana Bread is made fresh with the bananas from the greenhouse.");
                    ConsoleUtils.WaitForKeyPress();
                    Clear();
                    WriteLine("mMmM mMmM mMmM");
                    ConsoleUtils.WaitForKeyPress();
                    Clear();
                    WriteLine("Wow! That was some out-of-this-world Banana Bread!");
                    ConsoleUtils.WaitForKeyPress();
                    NewGame.NewKitchenScene.Run();
                    break;
                case 2:
                    Clear();
                    WriteLine("The Chocolate Cake is Pepper the monkey's personal favorite.\nMake sure to save a slice!");
                    ConsoleUtils.WaitForKeyPress();
                    Clear();
                    WriteLine("Munch. Munch. Munch.");
                    ConsoleUtils.WaitForKeyPress();
                    Clear();
                    WriteLine("How rich! That was such a decadent Chocolate Cake");
                    ConsoleUtils.WaitForKeyPress();
                    NewGame.NewKitchenScene.Run();
                    break;
                case 3:
                    NewGame.NewNavigationScene.Run();
                    break;
            }
        }
    }
}
