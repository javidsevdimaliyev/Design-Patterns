using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    internal class WithPattern
    {
        public void Test()
        {
            CircleFactory factory = new CircleFactory();
            GraphicEditor editor = new GraphicEditor();
            
            for (int i = 0; i < 1000; i++)
            {
                Circle circle = factory.GetCircle("Red", "Solid", 10);
                editor.AddCircle(circle, i, i);
            }

            editor.DrawCircles();
        }

        // Flyweight class
        public class Circle
        {
            public string Color { get; private set; }
            public string Fill { get; private set; }
            public int Radius { get; private set; }

            public Circle(string color, string fill, int radius)
            {
                Color = color;
                Fill = fill;
                Radius = radius;
            }

            public void Draw(int x, int y)
            {
                Console.WriteLine($"Drawing Circle at ({x}, {y}) with radius {Radius}, color {Color}, fill {Fill}");
            }
        }

        // FlyweightFactory class
        public class CircleFactory
        {
            private Dictionary<string, Circle> circles = new Dictionary<string, Circle>();

            public Circle GetCircle(string color, string fill, int radius)
            {
                string key = $"{color}_{fill}_{radius}";
                if (!circles.ContainsKey(key))
                {
                    circles[key] = new Circle(color, fill, radius);
                }
                return circles[key];
            }
        }

        public class GraphicEditor
        {
            private List<(Circle circle, int x, int y)> circles = new List<(Circle, int, int)>();

            public void AddCircle(Circle circle, int x, int y)
            {
                circles.Add((circle, x, y));
            }

            public void DrawCircles()
            {
                foreach (var (circle, x, y) in circles)
                {
                    circle.Draw(x, y);
                }
            }
        }

    }
}
