
namespace Mindbox.GeometryLib.Circle
{
    public sealed class CircleMutable : CircleAbstract,
                                        IMutable
    {
        public override double Radius {
            get { return Radius; }
            protected set
            {
                Radius = value;
                this.onChanges?.Invoke();
            }
        }
        public double Area { 
            get { return Area; }
            private set
            {
                Area = value;
                this.onChanges?.Invoke();
            }
        }

        public event Action? onChanges;

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
