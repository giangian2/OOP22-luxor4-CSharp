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
        public IGameEngine EngineLiv1;
        public IGameEngine EngineLiv2;
        public LevelDelegate Liv1;
        public LevelDelegate Liv2;


        [SetUp]
        public void SetUp()
        {
            this.EngineLiv1 = new GameEngineImpl(Levels.L1);
            LevelDelegate level1 = () => {
                return new WorldImpl(new RectBoundingBox(600, 800), 10, 1, "testPath1", EngineLiv1, new Cannon(470, 470));
            };

            EngineLiv1.SetGameState(new GameStateImpl(EngineLiv1, level1));
            this.EngineLiv2 = new GameEngineImpl(Levels.L2);
        }

        [Test]
        public void TestMainLoopLevel1()
        {
            Assert.DoesNotThrow(() =>
            {
                Task t = Task.Factory.StartNew(() => {
                    EngineLiv1.InitGame();
                    EngineLiv1.MainLoop();
                });

                t.Wait(2000);
            });
        }

        [Test]
        public void TestMainLoopLevel2()
        {
            Assert.DoesNotThrow(() =>
            {
                Task t = Task.Factory.StartNew(() => {
                    EngineLiv2.InitGame();
                    EngineLiv2.MainLoop();
                });

                t.Wait(2000);
            });
        }
    }
}
