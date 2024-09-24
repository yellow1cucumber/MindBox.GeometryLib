namespace Mindbox.GeometryLib.Circle
{
    public sealed class CircleImmutable : CircleAbstract
    {
        public override double Radius { get; protected set; }

        public CircleImmutable(double radius)
            : base(radius) { }
    }
}
