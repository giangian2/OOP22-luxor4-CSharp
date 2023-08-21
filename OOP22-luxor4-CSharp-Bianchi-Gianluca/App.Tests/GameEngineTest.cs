using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Core.Api;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Core.Impl;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Enums;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Events.Api;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Model.Api;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Model.Impl;
using static OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Core.Impl.GameEngineImpl;


namespace OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Tests
{
    [TestFixture]
    internal class GameEngineTest
    {
        public IGameEngine Engine;


        [SetUp]
        public void SetUp()
        {
            Engine = new GameEngineImpl(Levels.L1);
        }

        [Test]
        public void TestMainLoopLevel1()
        {

            Assert.DoesNotThrow(() =>
            {
                Task t = Task.Factory.StartNew(() => {
                    Engine.InitGame();
                    Engine.MainLoop();
                });

                t.Wait(2000);
            });
        }

        [Test]
        public void TestGameOver()
        {
            Assert.DoesNotThrow(() =>
            {
                Task t = Task.Factory.StartNew(() =>
                {
                    Engine.InitGame();
                    Engine.MainLoop();
                    foreach (int value in Enumerable.Range(1, 15))
                    {
                        Engine.GameState.IncScore();
                    }

                    Assert.True(Engine.GameState.IsGameOver());
                });

                t.Wait(2000);
            });
        }


    }
}
