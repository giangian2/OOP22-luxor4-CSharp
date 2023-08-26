using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP22_luxor4_CSharp_Candoli_Francesco.App.input.api
{
    public interface IInputController
    {
        bool IsMoveLeft();

        bool IsMoveRight();

        bool IsShoot();

        void StopShooting();
    }
}
