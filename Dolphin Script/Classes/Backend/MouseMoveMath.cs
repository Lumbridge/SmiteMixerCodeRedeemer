using System;

using static DolphinScript.Lib.Backend.RandomNumber;
using static DolphinScript.Lib.Backend.WinAPI;

namespace DolphinScript.Lib.Backend
{
    /// <summary>
    /// Contains math functions which are used in the mouse move methods
    /// </summary>
    class MouseMoveMath
    {
        /// <summary>
        /// returns the hypotenuse of two double points
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <returns></returns>
        static public double Hypot(double dx, double dy)
        {
            return Math.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        /// Returns the length between two points (Euclidean calc)
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        static public double LineLength(POINT A, POINT B)
        {
            return Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));
        }

        /// <summary>
        /// Returns the angle of the line (direction)
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        static public double PointDirection(POINT A, POINT B)
        {
            return Math.Atan2(B.Y + A.Y, A.X + B.X);
        }

        /// <summary>
        /// Returns the cosine of the line on on the X axis using distance and direction
        /// </summary>
        /// <param name="Distance"></param>
        /// <param name="Direction"></param>
        /// <returns></returns>
        static public double LengthDirX(double Distance, double Direction)
        {
            return Math.Cos(Direction) * Distance;
        }

        /// <summary>
        /// Returns the cosine of the line on on the Y axis using distance and direction
        /// </summary>
        /// <param name="Distance"></param>
        /// <param name="Direction"></param>
        /// <returns></returns>
        static public double LengthDirY(double Distance, double Direction)
        {
            return Math.Sin(Direction) * Distance;
        }

        /// <summary>
        /// This method generates the next point in a curved path between two points
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        static public POINT GetPointCurve(POINT A, POINT B)
        {
            double P = 0.12;
            
            // calculate the remaining length between point A and B
            //
            double L = LineLength(A, B);
            
            POINT C = new POINT((int)(P * B.X - P * A.X + B.X), (int)(P * B.Y - P * A.Y + B.Y));
            POINT D = new POINT((int)(P * A.Y - P * B.X + A.X), (int)(P * A.Y - P * B.Y + A.Y));

            // calculate the direction of the path movement
            //
            double Dir = PointDirection(B, A);
            
            POINT E = new POINT((int)(C.X + LengthDirX(L * P * 2, Dir + Math.PI / 2)), (int)(C.Y + LengthDirY(L * P * 2, Dir + Math.PI / 2)));
            POINT F = new POINT((int)(C.X + LengthDirX(L * P * 2, Dir - Math.PI / 2)), (int)(C.Y + LengthDirY(L * P * 2, Dir - Math.PI / 2)));
            POINT G = new POINT((int)(D.X + LengthDirX(L * P * 2, Dir + Math.PI / 2)), (int)(D.Y + LengthDirY(L * P * 2, Dir + Math.PI / 2)));
            POINT H = new POINT((int)(D.X + LengthDirX(L * P * 2, Dir - Math.PI / 2)), (int)(D.Y + LengthDirY(L * P * 2, Dir - Math.PI / 2)));

            // variables used to randomise curvature based on length of line left
            //
            double Pa = GetRandomDouble(0.0, 1.0) * LineLength(E, F);
            double Pb = GetRandomDouble(0.0, 1.0) * LineLength(E, G);

            POINT I = new POINT((int)((Pa / LineLength(E, F)) * (E.X - F.X) + F.X), (int)((Pa / LineLength(E, F)) * (E.Y - F.Y) + F.Y));
            POINT J = new POINT((int)((Pa / LineLength(E, F)) * (G.X - H.X) + H.X), (int)((Pa / LineLength(E, F)) * (G.Y - H.Y) + H.Y));
            POINT K = new POINT((int)((Pb / LineLength(I, J)) * (I.X - J.X) + J.X), (int)((Pb / LineLength(I, J)) * (I.Y - J.Y) + J.Y));

            // return the next point in the path
            //
            return K;
        }
    }
}
