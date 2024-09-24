namespace Mindbox.GeometryLib.Triangle
{
    public sealed class TriangleMutable : TriangleAbstract, 
                                          IMutable
    {
        public override double SideA { get; protected set; }
        public override double SideB { get; protected set; }
        public override double SideC { get; protected set; }

        public double Area { get; private set; }

        public TriangleMutable(double sideLength) 
            : base(sideLength){}

        public TriangleMutable(double sideA, double sideB, double sideC) 
            : base(sideA, sideB, sideC) {}


        public void SetSides(double sideA, double sideB, double sideC)
        {
            if (!isSidesValid(sideA, sideB, sideC))
            {
                throw new ArgumentOutOfRangeException("Side has to be > 0");
            }
            this.SideA = sideA;
            this.SideB = sideB;
            this.SideC = sideC;
            this.Area = base.GetArea();
            this.onChanges?.Invoke();
        }

        #region CONTRACTS_IMPLEMENTATION
        public event Action? onChanges;
        #endregion
    }
}
