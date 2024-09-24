namespace Mindbox.GeometryLib.Triangle
{
    /// <summary>
    /// Common triangle. Cant be modified
    /// <para>See also:</para>
    /// <para><seealso cref="TriangleAbstract"/> - base class</para>
    /// <para><seealso cref="TriangleMutable"/> - for modifiable triangles</para>
    /// </summary>
    public sealed class TriangleImmutable : TriangleAbstract
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
    }
}
