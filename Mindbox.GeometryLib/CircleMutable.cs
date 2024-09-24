namespace Mindbox.GeometryLib
{
    public class CircleMutable : CircleAbstract
    {
        public override double Radius { get; protected set; }
        public double Area { get; private set; }

        public void SetRadius(double radius)
        {
            this.Radius = radius;
            this.Area = base.GetArea();
        }


        public CircleMutable(double radius) 
            : base(radius)
            => this.Area = base.GetArea();
    }
}
