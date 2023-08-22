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
    /*
     * Test class to verify the correct functioning of the game engine
     */
    [TestFixture]
    internal class GameEngineTest
    {
        public IGameEngine Engine;


        [SetUp]
        public void SetUp()
        {
            Engine = new GameEngineImpl(Levels.L1);
        }

        /*
         * Verify the correct functioning of the main loop,
         * initializing the game endigne and starting the main loop
         */
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

        /*
         * Verify that the game engine correctly detects 
         * the game over state and stops the main loop
         */
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

        /*
         * Verify that the game engine correctly detects 
         * the win state and stops the main loop
         */
        [Test]
        public void TestWinState()
        {
            Assert.DoesNotThrow(() =>
            {
                Task t = Task.Factory.StartNew(() =>
                {
                    Engine.InitGame();

                    Engine.MainLoop();
                    foreach (int value in Enumerable.Range(1, 30))
                    {
                        Engine.GameState.IncScore();
                    }

                    Assert.True(Engine.GameState.IsWin());
                });

                t.Wait(2000);
            });
        }


    }
}
