using Mindbox.GeometryLib;
using Mindbox.GeometryLib.Circle;

namespace Mindbox.Tests
{
    public class ShapeFactoryTests
    {
        [Fact]
        public void ShapeFactoryCreateCircle()
        {
            IShape? shape = ShapeFactory.CreateShape<CircleImmutable>(10);
            Assert.NotNull(shape);
            Assert.Equal(Math.PI * 100, shape.GetArea(), 3);
        }

        [Fact]
        public void ShapeFactoryCreateCircles()
        {
            var shapeInfo = new object[][]
            {
                [1],
                [2],
                [3],
                [4],
                [5],
            };
            IEnumerable<IShape?> shapes = ShapeFactory.CreateShapes<CircleImmutable>(shapeInfo);

            foreach (var shape in shapes)
            {
                Assert.NotNull(shape);
            };
            Assert.Equal(Math.PI * 1, shapes.ElementAt(0)!.GetArea(), 3);
            Assert.Equal(Math.PI * 4, shapes.ElementAt(1)!.GetArea(), 3);
            Assert.Equal(Math.PI * 9, shapes.ElementAt(2)!.GetArea(), 3);
            Assert.Equal(Math.PI * 16, shapes.ElementAt(3)!.GetArea(), 3);
            Assert.Equal(Math.PI * 25, shapes.ElementAt(4)!.GetArea(), 3);
        }
    }
}
