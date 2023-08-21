using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Core.Api;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Enums;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Events.Api;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Events.Impl;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Graphics.Api;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Input.Api;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Model.Api;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Model.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Core.Impl
{
    public class GameEngineImpl : IGameEngine
    {
        private static int _period = 30;
        private IGameState _gameState { get; set; }
        private List<IWorldEvent> _eventQueue;
        private IScene _view { get;  set; }
        private KeyboardInputController _controller;
        private Levels _currentLevel; // Selected Level
        public delegate IWorld LevelDelegate();
        

        /*
         */
        public GameEngineImpl(Levels currentLevel)
        {
            this._currentLevel = currentLevel;
        }

        /*
         */
        public void InitGame()
        {
            this._eventQueue = new List<IWorldEvent>();
            this._controller = new KeyboardInputController();

            switch (this._currentLevel)
            {
                case Levels.L1:

                    LevelDelegate level1 = () => {
                        return new WorldImpl(new RectBoundingBox(600,800), 10, 1, "testPath1",  this, new Cannon(470, 470));
                    };

                    this.SetGameState(new GameStateImpl(this, level1));
                    this.SetView(this._view);
                    break;

                case Levels.L2:

                    LevelDelegate level2 = () => {
                        return new WorldImpl(new RectBoundingBox(600, 800), 20, 2, "testPath2", this, new Cannon(470, 470));
                    };

                    this.SetGameState(new GameStateImpl(this, level2));
                    this.SetView(this._view);

                    break;
            }
        }

        /*
         */
        public void MainLoop()
        {
            long previousCycleStartTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            // Main loop, process input -> updateGame -> render utile game over or win state
            // is reached
            while (!this._gameState.IsWin() && !this._gameState.IsGameOver())
            {
                long currentCycleStartTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                long elapsed = currentCycleStartTime - previousCycleStartTime;
                ProcessInput();
                updateGame(elapsed);
                render();
                waitForNextFrame(currentCycleStartTime);
                previousCycleStartTime = currentCycleStartTime;
            }

            // If win state is reached, render the respective view

            // If game over state is reached, render the respective view
            if (this._gameState.IsWin())
            {
                renderWin();
            }
            else if (this._gameState.IsGameOver())
            {
                renderGameOver();
            }
        }

        /*
         */
        public void SetGameState(IGameState gameState)
        {
            this._gameState=gameState;
        }


        public void SetView(IScene view)
        {
            this._view = view;
        }

        /*
         */
        public void notifyEvent(IWorldEvent e)
        {
            this._eventQueue.Add(e);
        }

        /*
         */
        private void renderGameOver()
        {
            this._view.RenderGameOver();
        }

        /**
         * 
         */
        private void renderWin()
        {
            this._view.RenderWin();
        }

        /*
         */
        public void updateGame(long elapsed)
        {
            this._gameState.Update(elapsed); // update game state
            CheckEvents(); // check events generated from input and world
        }

        /*
         */
        protected void render()
        {
            //this._view.Render();
        }

        /*
         */
        protected void waitForNextFrame(long cycleStartTime)
        {
            long dt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - cycleStartTime;
            if (dt < GameEngineImpl._period)
            {
                try
                {
                    Thread.Sleep(Convert.ToInt32(GameEngineImpl._period - dt));
                }
                catch (Exception e)
                {
                    
                }
            }

        }
        
        /*
         */
        protected void ProcessInput(){}

        /*
         */
        private void CheckEvents()
        {
            this._eventQueue.ForEach(ev =>
            {
                if (ev.GetType() == typeof(PauseGameEvent))
                {
                    Console.WriteLine("Pause game event detected!");
                }
                else if(ev.GetType() == typeof(HitBallEvent))
                {
                    Console.WriteLine("Hit ball event detected!");
                }
                else if(ev.GetType() == typeof(HitBorderEvent))
                {
                    Console.WriteLine("Hit border event detected!");
                }
            });
        }
       

    }
}
