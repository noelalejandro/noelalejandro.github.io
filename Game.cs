using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using BananaManor.Scenes;

namespace BananaManor
{
    class Game
    {
        public Player NewPlayer;
        public TitleScene NewTitleScene;
        public CreditsScene NewCreditsScene;
        public NavigationScene NewNavigationScene;
        public KitchenScene NewKitchenScene;
        public BedroomScene NewBedroomScene;
        public GreenhouseScene NewGreenhouseScene;
        public GarageScene NewGarageScene;
        public IntroScene NewIntroScene;

        public Game()
        {
            NewNavigationScene = new NavigationScene(this);
            NewPlayer = new Player();
            NewTitleScene = new TitleScene(this);
            NewCreditsScene = new CreditsScene(this);
            NewKitchenScene = new KitchenScene(this);
            NewBedroomScene = new BedroomScene(this);
            NewGreenhouseScene = new GreenhouseScene(this);
            NewGarageScene = new GarageScene(this);
            NewIntroScene = new IntroScene(this);
        }

        public void Start()
        {
            NewTitleScene.Run();
        }
    }
}
