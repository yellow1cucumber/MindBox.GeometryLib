namespace Mindbox.GeometryLib.Circle
{
    public abstract class CircleAbstract : IShape
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
        #endregion
    }
}
