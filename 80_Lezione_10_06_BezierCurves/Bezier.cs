using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace _80_Lezione_10_06_BezierCurves
{
    static class Bezier
    {
        //(1 – t)P0 + tP1
        public static Vector2 Linear(Vector2 point0, Vector2 point1, float t)
        {
            return (1f - t) * point0 + t * point1;
        }

        //(1 - t)^2*P0 + 2*t(1 - t)*P1 + t^2*P2
        public static Vector2 Quadratic(Vector2 point0, Vector2 point1, Vector2 point2, float t)
        {
            return (float)Math.Pow(1f - t, 2) * point0 +
                   2 * t * (1f - t) * point1 +
                   (float)Math.Pow(t, 2) * point2;
        }

        //(1 – t)^3*P0 + 3*t*(1 - t)^2*P1 + 3*t^2*(1 - t)*P2 + t^3*P3
        public static Vector2 Cubic(Vector2 point0, Vector2 point1, Vector2 point2, Vector2 point3, float t)
        {
            return (float)Math.Pow(1f - t, 3) * point0 +
                   3 * t * (float)Math.Pow(1f - t, 2) * point1 +
                   3 * (float)Math.Pow(t, 2) * (1 - t) * point2 +
                   (float)Math.Pow(t, 3) * point3;
        }
    }
}
