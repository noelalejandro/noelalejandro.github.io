using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using static BananaManor.ConsoleUtils; 

namespace BananaManor.Scenes
{
    class IntroScene : Scene
    {
        string CharacterName = "John Doe";
        string IntroArt = @"
              ██████████████████████████            
            ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██          
            ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██        
          ██▒▒▒▒░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░██        
      ██████▒▒░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░██      
    ██░░░░░░▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██████  
    ██░░░░░░▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██░░░░██
    ██░░░░░░▒▒░░░░░░░░░░██░░░░░░░░██░░░░░░░░██░░░░██
      ████░░▒▒░░░░░░░░░░██░░░░░░░░██░░░░░░░░██████  
          ██▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██      
  ████      ██▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░██        
██    ██      ██▒▒░░░░░░░░░░░░░░░░░░░░░░██          
██  ██      ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██        
██          ██▒▒▒▒▒▒▒▒░░░░░░░░░░░░▒▒▒▒▒▒▒▒██        
  ████    ██▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒██      
      ██████▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒██      
          ██▒▒▒▒██▒▒░░░░░░░░░░░░░░░░▒▒██▒▒▒▒██      
            ██████▒▒▒▒░░░░░░░░░░░░▒▒▒▒██████        
                ██▒▒▒▒▒▒████████▒▒▒▒▒▒██            
                ██░░░░██        ██░░░░██            
                ██████            ██████

";
        public IntroScene(Game game) : base(game)
        {

        }

        public override void Run()
        {
            Clear();
            TextColor();
            WriteLine($@"{IntroArt}
Hi, I'm Pepper the monkey! I'm the groundskeeper of Banana Manor.
Thank you so much for choosing to stay with us! What is your name?");
            WaitForKeyPress();
            Clear();
            WriteLine("Please enter your name:\n");
            CharacterColor();
            CharacterName = ReadLine();
            Clear();
            TextColor();
            WriteLine($"It's a pleasure to meet you {CharacterName}!");
            WaitForKeyPress();
            Clear();
            WriteLine(@"Nanner Manor, I mean.. Banana Manor has been in my family for 22 generations.
It's been a lot of work to maintain but it's a labor of love. There are many
rooms to explore and lots of fun things to do.");
            WaitForKeyPress();
            Clear();

            string prompt = "While I have you here, could I ask for your assistance?";
            string[] options = { "Yes", "No"};
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Clear();
                    CharacterColor();
                    WriteLine("'Of course! How can I help?'");
                    TextColor();
                    WaitForKeyPress();
                    Clear();
                    WriteLine(@"Great! Well as it turns out, your room isn't quite ready yet.
I've misplaced a few items and have been searching for them in a
frenzy. I haven't had much time to clean up after the last guest.");
                    WaitForKeyPress();
                    Clear();
                    CharacterColor();
                    WriteLine("'What items are you looking for?'");
                    TextColor();
                    WaitForKeyPress();
                    Clear();
                    WriteLine(@"I can't find the keys to the garage and I need to run an errand
in town but it's too far to walk. On top of that, I've misplaced
my favorite CD! I always listen to my favorite CD on my drives
into town.");
                    WaitForKeyPress();
                    Clear();
                    CharacterColor();
                    WriteLine("'I'll keep my eyes peeled.'");
                    TextColor();
                    WaitForKeyPress();
                    Clear();
                    WriteLine(@"... And since I've been looking around all day in a panic, I 
haven't had any time to eat. Do you think you could help me out 
in that regard as well?");
                    WaitForKeyPress();
                    Clear();
                    CharacterColor();
                    WriteLine("'Don't worry, Pepper! We'll get this all sorted.'");
                    TextColor();
                    WaitForKeyPress();
                    Clear();
                    WriteLine("Thank you so so so so much! You're the best!");
                    WaitForKeyPress();
                    NewGame.NewNavigationScene.Run();
                    break;
                case 1:
                    Clear();
                    CharacterColor();
                    WriteLine(@"'I'm sorry, Pepper, but I've had such a long day
and I'd like to get to my room, if you don't mind.'");
                    TextColor();
                    WaitForKeyPress();
                    Clear();
                    WriteLine(@"That's okay, I understand... I should warn you that your room
is still a little messy from the last guest. That's totally my
fault. I misplaced a few items and have been looking all over 
the property for them. I simply have not had the time to clean!");
                    WaitForKeyPress();
                    Clear();
                    WriteLine(@"You'll have to organize your room a bit before you can really
settle in. Maybe as compensation, I could show you around town
in one of the fancy cars we have in the garage.");
                    WaitForKeyPress();
                    Clear();
                    CharacterColor();
                    WriteLine("'What items are you looking for?'");
                    TextColor();
                    WaitForKeyPress();
                    Clear();
                    WriteLine(@"I can't find the keys to the garage and I need to run an errand
in town but it's too far to walk. On top of that, I've misplaced
my favorite CD! I always listen to my favorite CD on my drives
into town.");
                    WaitForKeyPress();
                    Clear();
                    CharacterColor();
                    WriteLine("'Okay Pepper, I'll help you.'");
                    TextColor();
                    WaitForKeyPress();
                    Clear();
                    WriteLine(@"You will?! Thank you so much! Since I've been looking around all
day in a panic, I haven't had any time to eat. Do you think you 
could help me out there also?");
                    WaitForKeyPress();
                    Clear();
                    CharacterColor();
                    WriteLine("'Sure Pepper, don't worry! We'll get this all sorted.'");
                    TextColor();
                    WaitForKeyPress();
                    Clear();
                    WriteLine("Thank you, thank you, thank you!!! I really appreciate it!");
                    WaitForKeyPress();
                    NewGame.NewNavigationScene.Run();
                    break;
            }
        }
    }
}
