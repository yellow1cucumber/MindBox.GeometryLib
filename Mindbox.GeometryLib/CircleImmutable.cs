namespace Mindbox.GeometryLib
{
    public class CircleImmutable : CircleAbstract
    {
        public override double Radius { get; protected set; }

        public CircleImmutable(double radius)
            : base(radius) { }
    }
}
