using Abstract.Entities;
using Abstract.Entities.Enums;

namespace Course
{
    class AbstractMain
    {
        public AbstractMain()
        {
            Run();
        }
        public void Run()
        {
            List<IShape> list = new List<IShape>();

            Console.Write("Enter the number of shapes: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Shape #{i} data:");
                Console.Write("Rectangle or Circle (r/c)? ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Color (Black/Blue/Red)");
                Color color = Enum.Parse<Color>(Console.ReadLine());
                if (char.ToUpper(ch) == 'R')
                {
                    Console.Write("Width: ");
                    double width = double.Parse(Console.ReadLine());
                    Console.Write("Height: ");
                    double height = double.Parse(Console.ReadLine());
                    list.Add(new Rectangle(width, height, color));
                } else {
                    Console.Write("Radius: ");
                    double radius = double.Parse(Console.ReadLine());
                    list.Add(new Circle(radius, color));
                }
            }

            Console.WriteLine();
            Console.WriteLine("SHAPE AREAS:");
            foreach (IShape shape in list)
            {
                Console.WriteLine(shape);
            }
        }
    }
}