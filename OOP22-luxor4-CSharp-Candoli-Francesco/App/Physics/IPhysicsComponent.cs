using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using OOP22_luxor4_CSharp_Candoli_Francesco.App.Model.Api;
using OOP22_luxor4_CSharp_Candoli_Francesco.App.Utils;

namespace OOP22_luxor4_CSharp_Candoli_Francesco.Physics.Api
{
    public interface IPhysicsComponent
    {        
        void Update(long dt, GameObject obj, IWorld w);
    }
}
