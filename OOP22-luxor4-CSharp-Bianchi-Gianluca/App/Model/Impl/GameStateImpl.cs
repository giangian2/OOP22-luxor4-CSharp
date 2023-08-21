using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Core.Impl;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Events.Api;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Model.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Model.Impl
{
    public class GameStateImpl : IGameState
    {
        private int _score;
        private IWorld _world;
        private bool _pause;
        private GameEngineImpl.LevelDelegate _levelDelegate;

        public int Score { get { return _score; } }
        public IWorld World { get { return _world; } }

        public GameStateImpl(IWorldEventListener eventListener, GameEngineImpl.LevelDelegate level) {
            this._score = 0;
            this._pause = false;
            this._levelDelegate = level;
            this.LoadLevel();
            this._world.SetEventListener(eventListener);
        }

        public void ChangePauseState() => this._pause = !this._pause;

        public void DecScore() => this._score--;

        public void IncScore() => this._score++;

        public bool IsGameOver() => this._score >= 20; //Implementazione utile per il testing

        public bool IsWin() => this._score < 20 && this._score >= 10; //Implementazione utile per il testing

        public void Update(long dt) { }

        private void LoadLevel() => this._world = this._levelDelegate.Invoke();
    }
}
