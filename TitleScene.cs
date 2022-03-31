using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace BananaManor.Scenes
{
    class TitleScene : Scene
    {

        string TitleArt = @" 
██████╗  █████╗ ███╗   ██╗ █████╗ ███╗   ██╗ █████╗     ███╗   ███╗ █████╗ ███╗   ██╗ ██████╗ ██████╗ 
██╔══██╗██╔══██╗████╗  ██║██╔══██╗████╗  ██║██╔══██╗    ████╗ ████║██╔══██╗████╗  ██║██╔═══██╗██╔══██╗
██████╔╝███████║██╔██╗ ██║███████║██╔██╗ ██║███████║    ██╔████╔██║███████║██╔██╗ ██║██║   ██║██████╔╝
██╔══██╗██╔══██║██║╚██╗██║██╔══██║██║╚██╗██║██╔══██║    ██║╚██╔╝██║██╔══██║██║╚██╗██║██║   ██║██╔══██╗
██████╔╝██║  ██║██║ ╚████║██║  ██║██║ ╚████║██║  ██║    ██║ ╚═╝ ██║██║  ██║██║ ╚████║╚██████╔╝██║  ██║
╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝    ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚═╝  ╚═╝

";
        public TitleScene(Game game) : base(game)
        {

        }

        public override void Run()
        {
            string prompt = $@"{TitleArt}
Welcome to Banana Manor! 

(Use the arrow keys to cycle through options and press enter to select an option.)
";

            string[] options = { "Play", "About", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    NewGame.NewIntroScene.Run();
                    ConsoleUtils.WaitForKeyPress();
                    break;
                case 1:
                    DisplayAboutInfo();
                    break;
                case 2:
                    ConsoleUtils.QuitConsole();
                    break;
            }

        }


        private void DisplayAboutInfo()
        {
            Clear();
            WriteLine(@"This game was created by Noel Gutierrez.

It uses assets from http://patorjk.com/software/taag and https://textart.sh.

This work is a derivative of code by Michael Hadley and 'C# Adventure Game'
by http://programmingisfun.com, used under CC BY. https://creativecommons.org/licenses/by/4.0/");
            ConsoleUtils.WaitForKeyPress();
            Run();
        }
    }
}
