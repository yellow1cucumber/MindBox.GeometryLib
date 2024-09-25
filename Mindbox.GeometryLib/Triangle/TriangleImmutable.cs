
namespace Mindbox.GeometryLib.Triangle
{
    /// <summary>
    /// Common triangle. Cant be modified
    /// <para>See also:</para>
    /// <para><seealso cref="TriangleAbstract"/> - base class</para>
    /// <para><seealso cref="TriangleMutable"/> - for modifiable triangles</para>
    /// </summary>
    public sealed class TriangleImmutable : TriangleAbstract, IEquatable<TriangleImmutable?>
    {
        public override double SideA { get; protected set; }
        public override double SideB { get; protected set; }
        public override double SideC { get; protected set; }

        /// <summary>
        /// <inheritdoc cref="TriangleAbstract.TriangleAbstract(double)"/>
        /// </summary>
        public TriangleImmutable(double sideLength) 
            : base(sideLength){}
        /// <summary>
        /// <inheritdoc cref="TriangleAbstract.TriangleAbstract(double, double, double)"/>
        /// </summary>
        public TriangleImmutable(double sideA, double sideB, double sideC) 
            : base(sideA, sideB, sideC){}


        #region CONTRACTS_IMPLEMENTATION
        public override bool Equals(object? obj)
        {
            return Equals(obj as TriangleImmutable);
        }

        public bool Equals(TriangleImmutable? other)
        {
            return other is not null &&
                   base.Equals(other) &&
                   SideA == other.SideA &&
                   SideB == other.SideB &&
                   SideC == other.SideC &&
                   SideA == other.SideA &&
                   SideB == other.SideB &&
                   SideC == other.SideC;
        }
        #endregion

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), SideA, SideB, SideC, SideA, SideB, SideC);
        }

        public static bool operator ==(TriangleImmutable? left, TriangleImmutable? right)
        {
            return EqualityComparer<TriangleImmutable>.Default.Equals(left, right);
        }

        public static bool operator !=(TriangleImmutable? left, TriangleImmutable? right)
        {
            return !(left == right);
        }
    }
}
