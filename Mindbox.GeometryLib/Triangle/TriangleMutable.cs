
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
                                          IMutable, IEquatable<TriangleMutable?>
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

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), SideA, SideB, SideC, SideA, SideB, SideC, Area);
        }

        #region CONTRACTS_IMPLEMENTATION
        public event Action? onChanges;

        public override bool Equals(object? obj)
        {
            return Equals(obj as TriangleMutable);
        }

        public bool Equals(TriangleMutable? other)
        {
            return other is not null &&
                   base.Equals(other) &&
                   SideA == other.SideA &&
                   SideB == other.SideB &&
                   SideC == other.SideC &&
                   SideA == other.SideA &&
                   SideB == other.SideB &&
                   SideC == other.SideC &&
                   Area == other.Area;
        }

        public static bool operator ==(TriangleMutable? left, TriangleMutable? right)
        {
            return EqualityComparer<TriangleMutable>.Default.Equals(left, right);
        }

        public static bool operator !=(TriangleMutable? left, TriangleMutable? right)
        {
            return !(left == right);
        }
        #endregion
    }
}
