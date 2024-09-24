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
                                        IMutable
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
        #endregion
    }
}
