using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Model.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Model.Impl
{
    /*
     * Class that models a rectangular bounding box, therefore identified by the 2
     * vertices of the rectangle p0 and p1.
     */
    public class RectBoundingBox : IBoundingBox
    {
        private P2d p0, p1;

        public P2d ULCorner { get { return p0; } }
        public P2d ULCorner2 { get { return p1; } }

        public RectBoundingBox(P2d p0, P2d p1)
        {
            this.p0 = p0;
            this.p1 = p1;
        }

        /*
         * In this case the method exposed by the BoundingBox interface has not been
         * implemented as in the game it is not necessary to detect collisions between
         * rectangular bounding boxes and circular bounding boxes.
         * 
         */

        public bool isCollidingWith(P2d p, double radius)
        {
            return false;
        }
    }
}
