namespace Mindbox.GeometryLib.Circle
{
    /// <summary>
    /// Abstract circle.
    /// Insted use <seealso cref="CircleImmutable"/> or <seealso cref="CircleMutable"/>
    /// </summary>
    public abstract class CircleAbstract : IShape, IEquatable<CircleAbstract?>
    {
        public abstract double Radius { get; protected set; }

        protected CircleAbstract(double radius)
        {
            if (!isRadiusValid(radius))
            {
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius has to be > 0");
            }
            Radius = radius;
        }

        private bool isRadiusValid(double radius)
            => radius > 0;


        #region CONTRACTS_IMPLEMENTATION
        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as CircleAbstract);
        }

        public bool Equals(CircleAbstract? other)
        {
            return other is not null &&
                   Radius == other.Radius;
        }

        public static bool operator ==(CircleAbstract? left, CircleAbstract? right)
        {
            return EqualityComparer<CircleAbstract>.Default.Equals(left, right);
        }

        public static bool operator !=(CircleAbstract? left, CircleAbstract? right)
        {
            return !(left == right);
        }
        #endregion

        public override int GetHashCode()
        {
            return HashCode.Combine(Radius);
        }
    }
}
