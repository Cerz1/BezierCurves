using System;
using Aiv.Fast2D;
using OpenTK;

namespace _80_Lezione_10_06_BezierCurves
{
    class Program
    {
        static void Main(string[] args)
        {
            Window window = new Window(800, 600, "Bezier");

            // Movement Speed for each Control Point
            float speed = 100;

            // Control Points
            Vector2 point0 = new Vector2(10, 250);
            Vector2 point1 = new Vector2(200, 250);
            Vector2 point2 = new Vector2(300, 250);
            Vector2 point3 = new Vector2(400, 250);

            // Sprites used for Rendering Points and Curve (made of lots of tiny points)
            Sprite ctrlPoint = new Sprite(10, 10);
            Sprite curvePoint = new Sprite(2, 2);

            // Main Loop
            while (window.IsOpened)
            {
                if (window.GetKey(KeyCode.Left)) point1 += new Vector2(-1f, 0) * speed * window.DeltaTime;
                if (window.GetKey(KeyCode.Right)) point1 += new Vector2(1f, 0) * speed * window.DeltaTime;
                if (window.GetKey(KeyCode.Up)) point1 += new Vector2(0f, -1) * speed * window.DeltaTime;
                if (window.GetKey(KeyCode.Down)) point1 += new Vector2(0f, 1) * speed * window.DeltaTime;

                if (window.GetKey(KeyCode.A)) point2 += new Vector2(-1f, 0) * speed * window.DeltaTime;
                if (window.GetKey(KeyCode.D)) point2 += new Vector2(1f, 0) * speed * window.DeltaTime;
                if (window.GetKey(KeyCode.W)) point2 += new Vector2(0f, -1) * speed * window.DeltaTime;
                if (window.GetKey(KeyCode.S)) point2 += new Vector2(0f, 1) * speed * window.DeltaTime;

                if (window.GetKey(KeyCode.F)) point3 += new Vector2(-1f, 0) * speed * window.DeltaTime;
                if (window.GetKey(KeyCode.H)) point3 += new Vector2(1f, 0) * speed * window.DeltaTime;
                if (window.GetKey(KeyCode.T)) point3 += new Vector2(0f, -1) * speed * window.DeltaTime;
                if (window.GetKey(KeyCode.G)) point3 += new Vector2(0f, 1) * speed * window.DeltaTime;

                for (float t = 0; t <= 1f; t += 0.001f)
                {
                    // DRAW BEZIER CURVES

                    // Get each point interpolated position from Bezier formulas
                    //Vector2 pointI = Bezier.Linear(point0, point1, t);
                    //Vector2 pointI = Bezier.Quadratic(point0, point1, point2, t);
                    Vector2 pointI = Bezier.Cubic(point0, point1, point2, point3, t);
                    
                    // Set and Draw each Curve Point
                    curvePoint.position = pointI;
                    curvePoint.DrawColor(0, 1f, 0);
                }

                // Set the Sprite for each Control Point and Draw it (same sprite used 4 times)
                ctrlPoint.position = point0;
                ctrlPoint.DrawColor(1f, 0, 0);

                ctrlPoint.position = point1;
                ctrlPoint.DrawColor(0, 0, 1f);

                ctrlPoint.position = point2;
                ctrlPoint.DrawColor(0, 1f, 1f);

                ctrlPoint.position = point3;
                ctrlPoint.DrawColor(1f, 1f, 0f);


                window.Update();
            }
        }
    }
}
