using Mindbox.GeometryLib;
using Mindbox.GeometryLib.Circle;
using Mindbox.GeometryLib.Triangle;

namespace Mindbox.Tests
{
    public class ShapeTests
    {
        #region IMMUTABLE
        [Fact]
        public void CircleAreaTest()
        {
            var circle = new CircleImmutable(10);
            double area = circle.GetArea();

            Assert.Equal(Math.PI * 100, area, 3);
        }

        [Fact]
        public void TriangleAreaTest()
        {
            var triangle = new TriangleImmutable(3, 4, 5);
            double area = triangle.GetArea();

            Assert.Equal(6, area, 3);
        }

        [Fact]
        public void IsRightTriangleTest()
        {
            var triangle = new TriangleImmutable(3, 4, 5);
            Assert.True(triangle.IsRightTriangle());
        }

        [Fact]
        public void CalculateAreaTest()
        {
            IShape shape = new CircleImmutable(10);
            double area = shape.GetArea();

            Assert.Equal(Math.PI * 100, area, 3);
        }
        #endregion


        #region MUTABLE
        [Fact]
        public void MutableCircleAreaTest()
        {
            var circle = new CircleMutable(5);
            double areaOld = circle.GetArea();
            circle.SetRadius(10);
            double areaNew = circle.GetArea();

            Assert.Equal(Math.PI * 25, areaOld, 3);
            Assert.Equal(Math.PI * 100, areaNew, 3);
        }

        [Fact]
        public void MutableTriangleAreaTest()
        {
            var triangle = new TriangleMutable(3, 4, 5);
            var areaOld = triangle.GetArea();
            triangle.SetSides(7, 24, 25);
            var areaNew = triangle.GetArea();

            Assert.Equal(6, areaOld, 3);
            Assert.Equal(84, areaNew, 3);
        }

        [Fact]
        public void MutableCircleCallBackTest()
        {
            var circle = new CircleMutable(5);
            bool callbackTriggered = false;

            circle.onChanges += () => callbackTriggered = true;

            circle.SetRadius(10);
            Assert.True(callbackTriggered, "Callback should be triggered when radius is changed");
        }

        [Fact]
        public void MutableTriangleCallBackTest()
        {
            var circle = new TriangleMutable(5);
            bool callbackTriggered = false;

            circle.onChanges += () => callbackTriggered = true;

            circle.SetSides(6, 6, 6);
            Assert.True(callbackTriggered, "Callback should be triggered when radius is changed");
        }
        #endregion
    }
}