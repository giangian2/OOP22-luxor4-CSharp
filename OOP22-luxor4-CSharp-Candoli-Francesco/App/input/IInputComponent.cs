using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OOP22_luxor4_CSharp_Candoli_Francesco.App.Utils;

namespace OOP22_luxor4_CSharp_Candoli_Francesco.App.input.api
{
    public interface IInputComponent
    {
        void Update(GameObject gameObject, IInputController c);
    }
}
