using System;
using System.Collections.Generic;
using System.Text;

namespace BananaManor.Scenes
{
    class Scene
    {
        protected Game NewGame;
        public Scene(Game game)
        {
            NewGame = game;
        }

        virtual public void Run()
        {
            // Runs the scene logic
            // Override in child classes
        }
    }
}
