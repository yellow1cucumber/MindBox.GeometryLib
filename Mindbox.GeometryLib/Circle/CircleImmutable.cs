
namespace Mindbox.GeometryLib.Circle
{
    /// <summary>
    /// Common circle. Cant be modified.
    /// <para>See also:</para>
    /// <para><seealso cref="CircleAbstract"/> - base class</para>
    /// <para><seealso cref="CircleMutable"/> - for modifieable circles</para>
    /// </summary>
    public sealed class CircleImmutable : CircleAbstract, IEquatable<CircleImmutable?>
    {
        public override double Radius { get; protected set; }

        public CircleImmutable(double radius)
            : base(radius) { }

        #region CONTRACTS_IMPLEMENTATION
        public override bool Equals(object? obj)
        {
            return Equals(obj as CircleImmutable);
        }

        public bool Equals(CircleImmutable? other)
        {
            return other is not null &&
                   Radius == other.Radius &&
                   Radius == other.Radius;
        }

        public static bool operator ==(CircleImmutable? left, CircleImmutable? right)
        {
            return EqualityComparer<CircleImmutable>.Default.Equals(left, right);
        }

        public static bool operator !=(CircleImmutable? left, CircleImmutable? right)
        {
            return !(left == right);
        }
        #endregion

        public override int GetHashCode()
        {
            return HashCode.Combine(Radius, Radius);
        }
    }
}
