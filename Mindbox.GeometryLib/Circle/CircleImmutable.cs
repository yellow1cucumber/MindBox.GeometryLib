namespace Mindbox.GeometryLib.Circle
{
    public class CircleImmutable : CircleAbstract
    {
        public override double Radius { get; protected set; }

        public CircleImmutable(double radius)
            : base(radius) { }
    }
}
