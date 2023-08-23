using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Model.Api
{
    /*
    * Interface that models the 2D physical space occupied by a game object.
    */
    public interface IBoundingBox
    {
        /*
         * Allows you to check at a specific instant whether the current bounding box
         * instance collides with an object having the point "p" as its center and
         * "radius" as its radius.
         */
        bool isCollidingWith(P2d p, double radius);
    }
}
