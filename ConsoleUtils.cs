using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace BananaManor
{
    static class ConsoleUtils
    {
        public static void ItemColor()
        {
            ForegroundColor = ConsoleColor.Green;
        }
        public static void TextColor()
        {
            ForegroundColor = ConsoleColor.Yellow;
        }

        public static void CharacterColor()
        {
            ForegroundColor = ConsoleColor.Cyan;
        }
        public static void WaitForKeyPress()
        {
            WriteLine("(Press any key to continue.)");
            ReadKey(true);
        }

        public static void QuitConsole()
        {
            WriteLine("(Press any key to exit.)");
            ReadKey(true);
            Environment.Exit(0);
        }

        public static void QuitGame()
        {
            Environment.Exit(0);
        }
    }
}
