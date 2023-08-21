using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Core.Impl;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP22_luxor4_CSharp_Bianchi_Gianluca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var engine = new GameEngineImpl(Levels.L1);
            engine.InitGame();
            engine.MainLoop();  

        }
    }
}
