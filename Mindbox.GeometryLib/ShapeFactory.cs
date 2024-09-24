namespace Mindbox.GeometryLib
{
    public static class ShapeFactory
    {
        public static T CreateShape<T>(params object[] args) where T : IShape
        {
            Type shape = typeof(T);
            return (T)Activator.CreateInstance(shape, args)!;
        }

        public static IEnumerable<T> CreateShapes<T>(IEnumerable<(T, object[] args)> shapesInfo) where T : IShape
        {
            var shapes = new List<T>();
            foreach (var (type, args) in shapesInfo)
            {
                Type shapeType = typeof(T);
                var shape = (T)Activator.CreateInstance(shapeType, args)!;
                shapes.Add(shape);
            }
            return shapes;
        }
    }
}
