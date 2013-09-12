﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterBlaster.GameScreens
{
    public class GameScreenManager
    {
        private Stack<IGameScreen> _gameScreens;

        public GameScreenManager()
        {
            _gameScreens = new Stack<IGameScreen>();
        }

        public IGameScreen ActiveGameScreen
        {
            get
            {
                return _gameScreens.Peek();
            }
        }

        public void Push(IGameScreen gameScreen)
        {
            if (_gameScreens.Count > 0)
            {
                ActiveGameScreen.Deactivate();
            }
            _gameScreens.Push(gameScreen);

            gameScreen.Activate();

        }

        public IGameScreen Pop()
        {
            IGameScreen poppedGameScreen = _gameScreens.Pop();

            poppedGameScreen.Deactivate();

            if (_gameScreens.Count > 0)
            {
                ActiveGameScreen.Activate();
            }

            return poppedGameScreen;
        }
    }
}