namespace Mindbox.GeometryLib.Triangle
{
    public sealed class TriangleImmutable : TriangleAbstract
    {
        public override double SideA { get; protected set; }
        public override double SideB { get; protected set; }
        public override double SideC { get; protected set; }

        public TriangleImmutable(double sideLength) 
            : base(sideLength){}
        public TriangleImmutable(double sideA, double sideB, double sideC) 
            : base(sideA, sideB, sideC){}
    }
}
