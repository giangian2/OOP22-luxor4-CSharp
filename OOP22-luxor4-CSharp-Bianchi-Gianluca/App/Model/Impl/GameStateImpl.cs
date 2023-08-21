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
    internal class GameStateImpl : IGameState
    {
        public bool status=false;
     
        public GameStateImpl(IWorldEventListener eventListener, GameEngineImpl.LevelDelegate level) { 
        }
        public void ChangePauseState()
        {
            throw new NotImplementedException();
        }

        public void DecScore()
        {
            throw new NotImplementedException();
        }

        public int GetScore()
        {
            throw new NotImplementedException();
        }

        public IWorld GetWorld()
        {
            throw new NotImplementedException();
        }

        public void IncScore()
        {
            throw new NotImplementedException();
        }

        public bool IsGameOver()
        {
            return status;
        }

        public bool IsWin()
        {
            return false;
        }

        public void Update(long dt)
        {
           
        }
    }
}
