using System;

namespace TestProject.Design_Patterns
{
    public class Factory
    {
        public Shape CreateShape(string shape)
        {
            Shape obj = null;

            if (shape.Equals("Circle"))
            {
                obj = new Circle();
            }
            else if (shape.Equals("Rectangle"))
            {
                obj = new Rectangle();
            }

            return obj;
        }
    }

    public interface Shape
    {
        void DrawShape();
    }

    public class Circle : Shape
    {
        public void DrawShape()
        {
            Console.WriteLine("Circle is being drawn");
        }
    }

    public class Rectangle : Shape
    {
        public void DrawShape()
        {
            Console.WriteLine("Rectangle is being drawn");
        }
    }
}
