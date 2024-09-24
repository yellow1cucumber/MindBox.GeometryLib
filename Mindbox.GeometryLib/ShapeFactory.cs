namespace Mindbox.GeometryLib
{
    /// <summary>
    /// Universal <seealso cref="IShape"/> factory, based on reflection
    /// </summary>
    public static class ShapeFactory
    {
        /// <summary>
        /// Creates instance of shape, that implements <seealso cref="IShape"/> contract
        /// </summary>
        /// <typeparam name="T">shape type</typeparam>
        /// <param name="args">ctor arguments</param>
        /// <returns>
        /// instance of shape
        /// </returns>
        public static T CreateShape<T>(params object[] args) where T : IShape
        {
            Type shape = typeof(T);
            return (T)Activator.CreateInstance(shape, args)!;
        }

        /// <summary>
        /// Creates list of shapes, that implements <seealso cref="IShape"> contract
        /// </summary>
        /// <typeparam name="T">shape type</typeparam>
        /// <param name="shapesInfo">ctor arhuments</param>
        /// <returns>
        /// list of shapes
        /// </returns>
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
