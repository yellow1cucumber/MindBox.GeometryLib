namespace Mindbox.GeometryLib.Triangle
{
    /// <summary>
    /// Abstract triangle.
    /// <para>See also:</para>
    /// <para><seealso cref="TriangleImmutable"/></para>
    /// <para><seealso cref="TriangleMutable"/></para>
    /// </summary>
    public abstract class TriangleAbstract : IShape, IEquatable<TriangleAbstract?>
    {
        public abstract double SideA { get; protected set; }
        public abstract double SideB { get; protected set; }
        public abstract double SideC { get; protected set; }

        /// <summary>
        /// Sets all triangle sides as sideLength
        /// </summary>
        /// <param name="sideLength"> - length of triangle side</param>
        /// <exception cref="ArgumentOutOfRangeException"> - throws, if sideLength arg 0 </exception>
        protected TriangleAbstract(double sideLength)
        {
            if (!isSidesValid(sideLength))
            {
                throw new ArgumentOutOfRangeException(nameof(sideLength), "Side has to be > 0");
            }
            SideA = sideLength;
            SideB = sideLength;
            SideC = sideLength;
        }
        /// <summary>
        /// Sets triangle sides manualy
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        /// <param name="sideC"></param>
        /// <exception cref="ArgumentOutOfRangeException"> - throws, if sideLength arg 0 </exception>
        protected TriangleAbstract(double sideA, double sideB, double sideC)
        {
            if (!isSidesValid(sideA, sideB, sideC))
            {
                throw new ArgumentOutOfRangeException("Side has to be > 0");
            }
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        /// <summary>
        /// Checks if triangle is rigth
        /// </summary>
        /// <returns>
        /// <para>true - if triangle is right</para>
        /// <para>false - if triangle is not right</para>
        /// </returns>
        public bool IsRightTriangle()
        {
            double[] sides = new[] { SideA, SideB, SideC };
            Array.Sort(sides);
            double c = Math.Pow(sides.ElementAt(2), 2);
            double a = Math.Pow(sides.ElementAt(1), 2);
            double b = Math.Pow(sides.ElementAt(0), 2);
            return Math.Abs(c - (b + a)) < 0.0001;
        }

        protected bool isSidesValid(params double[] sides)
        {
            foreach (var side in sides)
            {
                if (side < 0) return false;
            }
            return true;
        }

        #region CONTRACTS_IMPLEMENTATION
        public double GetArea()
        {
            double area = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(area * (area - SideA) * (area - SideB) * (area - SideC));
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as TriangleAbstract);
        }

        public bool Equals(TriangleAbstract? other)
        {
            return other is not null &&
                   SideA == other.SideA &&
                   SideB == other.SideB &&
                   SideC == other.SideC;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SideA, SideB, SideC);
        }
        #endregion
    }
}
