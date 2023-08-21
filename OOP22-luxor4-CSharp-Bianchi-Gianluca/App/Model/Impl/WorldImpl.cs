using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Events.Api;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Model.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Model.Impl
{
    internal class WorldImpl : IWorld
    {
        public WorldImpl(RectBoundingBox bbox, int nBalls,int steps, string xmlSrc,
             IWorldEventListener eventListener, Cannon cannon)
        {

        }
    }
}
