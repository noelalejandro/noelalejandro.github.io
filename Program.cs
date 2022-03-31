/*
 * [Banana Manor]
 * by Noel Gutierrez, March 2022
 *  
 * This work is a derivative of 
 * "C# Adventure Game" by http://programmingisfun.com, used under CC BY.
 * https://creativecommons.org/licenses/by/4.0/
 */

using System;
using static System.Console;

namespace BananaManor
{
    class Program
    {
        static void Main()
        {
            Title = "Banana Manor";
            CursorVisible = false;

            try
            {
                WindowWidth = 130;
                WindowHeight = 35;
            }
            catch
            {
                WriteLine("Cannot create a big enough console window.");
                WriteLine("Try adjusting your font/console settings and restarting.");
                WriteLine("You can continue playing, just be aware that some art might not render properly!");
                ConsoleUtils.WaitForKeyPress();
            }

            Game NewGame = new Game();
            NewGame.Start();
        }
    }
}
