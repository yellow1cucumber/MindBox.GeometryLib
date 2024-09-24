namespace Mindbox.GeometryLib.Triangle
{
    /// <summary>
    /// Modifiable version of circle.
    /// <para>See also:</para>
    /// <para><seealso cref="TriangleAbstract"> - base class</para>
    /// <para><seealso cref="TriangleImmutable" - immutable triangle/></para>
    /// <para><seealso cref="IMutable"/> - implementing contract</para>
    /// </summary>
    public sealed class TriangleMutable : TriangleAbstract, 
                                          IMutable
    {
        public override double SideA { get; protected set; }
        public override double SideB { get; protected set; }
        public override double SideC { get; protected set; }

        public double Area { get; private set; }

        /// <summary>
        /// <inheritdoc cref="TriangleAbstract.TriangleAbstract(double)"/>
        /// </summary>
        public TriangleMutable(double sideLength) 
            : base(sideLength){}
        /// <summary>
        /// <inheritdoc cref="TriangleAbstract.TriangleAbstract(double, double, double)"/>
        /// </summary>
        public TriangleMutable(double sideA, double sideB, double sideC) 
            : base(sideA, sideB, sideC) {}

        /// <summary>
        /// Set sides of triangle manualy. Invokes event <see cref="IMutable.onChanges"/> when completes
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        /// <param name="sideC"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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
