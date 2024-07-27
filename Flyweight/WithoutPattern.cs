using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    internal class WithoutPattern
    {
        public void Test()
        {
            GraphicEditor editor = new GraphicEditor();

            for (int i = 0; i < 1000; i++)
            {
                Circle circle = new Circle { X = i, Y = i, Radius = 10, Color = "Red", Fill = "Solid" };
                editor.AddCircle(circle);
            }

            editor.DrawCircles();
        }

        
        public class Circle
        {
            public string Color { get; set; }
            public string Fill { get; set; }
            public int Radius { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

            public void Draw()
            {
                Console.WriteLine($"Drawing Circle at ({X}, {Y}) with radius {Radius}, color {Color}, fill {Fill}");
            }
        }

        public class GraphicEditor
        {
            private List<Circle> circles = new List<Circle>();

            public void AddCircle(Circle circle)
            {
                circles.Add(circle);
            }

            public void DrawCircles()
            {
                foreach (var circle in circles)
                {
                    circle.Draw();
                }
            }
        }

    }
}
