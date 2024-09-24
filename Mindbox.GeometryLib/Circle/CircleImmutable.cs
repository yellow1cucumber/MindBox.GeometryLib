namespace Mindbox.GeometryLib.Circle
{
    /// <summary>
    /// Common circle. Cant be modified.
    /// <para>See also:</para>
    /// <para><seealso cref="CircleAbstract"/> - base class</para>
    /// <para><seealso cref="CircleMutable"/> - for modifieable circles</para>
    /// </summary>
    public sealed class CircleImmutable : CircleAbstract
    {
        public override double Radius { get; protected set; }

        public CircleImmutable(double radius)
            : base(radius) { }
    }
}
