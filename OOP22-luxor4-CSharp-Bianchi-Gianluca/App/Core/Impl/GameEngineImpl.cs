using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Core.Api;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Enums;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Events.Api;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Events.Impl;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Graphics.Api;
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
    /*
     * The GameEngineImpl class will implement the IGameEngine and IWorldEventListener
     * interface in such a way as to be able to directly manage the events related
     * to the World that are triggered during the mainLoop.
     */
    public class GameEngineImpl : IGameEngine
    {
        private static int _period = 30; // Period of rendering
        private IGameState _gameState;
        private List<IWorldEvent> _eventQueue; // Event queue used to process any event
        private IScene _view; // View
        private KeyboardInputController _controller; // Controller
        private Levels _currentLevel; // Selected Level


        public delegate IWorld LevelDelegate(); // Delegate for represent the world initialization based on a specific level
        public IScene View { get => _view; set => _view = value; }
        public IGameState GameState { get => _gameState; set => _gameState = value; }

        /*
         * Initialize the GameEngineImpl with the given level in order to instatiate the
         * World properly and render the correct view.
         */
        public GameEngineImpl(Levels currentLevel)
        {
            this._currentLevel = currentLevel;
        }

        /*
         * Initialize the View and the World based on the selected level throught the
         * delegate LevelDelegate.
         */
        public void InitGame()
        {
            this._eventQueue = new List<IWorldEvent>();
            this._controller = new KeyboardInputController();

            switch (this._currentLevel)
            {
                case Levels.L1:
                    /*
                     * In case the selected level is l1,
                     * the game state is instantiated having the GameEngine itself as an event
                     * listener and a method is passed that implements the LevelDelegate method,
                     * in this way there will be a fluid and scalable
                     * development process for the creation of new levels.
                     */
                    LevelDelegate level1 = () => {
                        return new WorldImpl(new RectBoundingBox(new P2d(0,0), new P2d(0,0)), 10, 1, "testPath1",  this, new WorldImpl.Cannon());
                    };
                    var gamestate1= new GameStateImpl(this, level1);
                    this.GameState= gamestate1;
                    this.View=(this._view);
                    break;

                case Levels.L2:

                    LevelDelegate level2 = () => {
                        return new WorldImpl(new RectBoundingBox(new P2d(0, 0), new P2d(0, 0)), 20, 2, "testPath2", this, new WorldImpl.Cannon());
                    };

                    var gamestate2 = new GameStateImpl(this, level2);
                    this.GameState = gamestate2;
                    this.View=(this._view);

                    break;
            }
        }

        /*
         * Method used to start the game loop.
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
                UpdateGame(elapsed);
                Render();
                WaitForNextFrame(currentCycleStartTime);
                previousCycleStartTime = currentCycleStartTime;
            }

            // If win state is reached, render the respective view

            // If game over state is reached, render the respective view
            if (this._gameState.IsWin())
            {
                RenderWin();
            }
            else if (this._gameState.IsGameOver())
            {
                RenderGameOver();
            }
        }


        /*
         * Implementing the worldEventListener, this method will add the notified event
         * to the event queue in orther to be processed in the further step.
         */
        public void NotifyEvent(IWorldEvent e)
        {
            this._eventQueue.Add(e);
        }

        /*
         */
        private void RenderGameOver()
        {
            this._view.RenderGameOver();
        }

        /* 
         */
        private void RenderWin()
        {
            this._view.RenderWin();
        }

        /*
         * Update the game state at each frame of the game loop.
         */
        public void UpdateGame(long elapsed)
        {
            this._gameState.Update(elapsed); // update game state
            CheckEvents(); // check events generated from input and world
        }

        /*
         * Renders the view at each frame of game loop.
         */
        protected void Render()
        {
            //this._view.Render();
        }

        /*
         * Waith for the next frame if the game loop cycle has taken less time than the
         * PERIOD.
         */
        protected void WaitForNextFrame(long cycleStartTime)
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
                    Console.WriteLine(e.ToString());   
                }
            }

        }
        
        /*
         */
        protected void ProcessInput(){}

        /*
         * Check the events present in the respective queue and manage them one by one.
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

        /*
         * Nested class to define the KeyboardInputController class that is used only by the GameEngineImpl class 
         */
        private class KeyboardInputController
        {
            public KeyboardInputController(){}
        }
    }
}
