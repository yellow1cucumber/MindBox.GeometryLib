namespace Mindbox.GeometryLib.Circle
{
    public sealed class CircleMutable : CircleAbstract,
                                        IMutable
    {
        public override double Radius { get; protected set; }
        public double Area { get; private set; }

        public void SetRadius(double radius)
        {
            Radius = radius;
            Area = GetArea();
            this.onChanges?.Invoke();
        }

        public CircleMutable(double radius)
            : base(radius)
            => Area = GetArea();

        #region CONTRACTS_IMPLEMENTATION
        public event Action? onChanges;
        #endregion
    }
}
