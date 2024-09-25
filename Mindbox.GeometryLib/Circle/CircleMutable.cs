
namespace Mindbox.GeometryLib.Circle
{
    /// <summary>
    /// Modifiable version of Circle.
    /// <para>See also:</para>
    /// <para><seealso cref="CircleAbstract"/> - base class</para>
    /// <para><seealso cref="CircleImmutable"/> - immutable version</para>
    /// <para><seealso cref="IMutable"/> - implementing contract</para>
    /// </summary>
    public sealed class CircleMutable : CircleAbstract,
                                        IMutable, IEquatable<CircleMutable?>
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

        public override bool Equals(object? obj)
        {
            return Equals(obj as CircleMutable);
        }

        public bool Equals(CircleMutable? other)
        {
            return other is not null &&
                   Radius == other.Radius &&
                   Radius == other.Radius &&
                   Area == other.Area;
        }

        public static bool operator ==(CircleMutable? left, CircleMutable? right)
        {
            return EqualityComparer<CircleMutable>.Default.Equals(left, right);
        }

        public static bool operator !=(CircleMutable? left, CircleMutable? right)
        {
            return !(left == right);
        }
        #endregion

        public override int GetHashCode()
        {
            return HashCode.Combine(Radius, Radius, Area);
        }
    }
}
