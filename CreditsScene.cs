using System;
using System.Collections.Generic;
using System.Text;

namespace BananaManor.Scenes
{
    class CreditsScene : Scene
    {
        public CreditsScene(Game game) : base(game)
        {

        }

        public override void Run()
        {
            string prompt = @"Thanks for playing Banana Manor. I hope you enjoyed your stay!

=== Credits ===
> ASCIIFlow, http://asciiflow.com/
> TAAG, http://patorjk.com/software/taag/

Would you like to play again?";
            string[] options = { "Yes", "No" };
            Menu menu = new Menu(prompt, options);
            int selectedIndex = menu.Run();
            switch (selectedIndex)
            {
                case 0:
                    NewGame.Start();
                    break;
                case 1:
                    ConsoleUtils.QuitConsole();
                    break;
            }
        }
    }
}
