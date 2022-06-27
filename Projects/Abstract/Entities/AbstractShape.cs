using Abstract.Entities.Enums;

namespace Abstract.Entities
{
    abstract class AbstractShape : IShape
    {
        public Color Color { get; set; }
        
        public AbstractShape(Color color)
        {
            Color = color;
        }

        public abstract double Area();
    }
}