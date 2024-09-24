namespace Mindbox.GeometryLib.Circle
{
    public class CircleMutable : CircleAbstract
    {
        public override double Radius { get; protected set; }
        public double Area { get; private set; }

        public void SetRadius(double radius)
        {
            Radius = radius;
            Area = GetArea();
        }


        public CircleMutable(double radius)
            : base(radius)
            => Area = GetArea();
    }
}
