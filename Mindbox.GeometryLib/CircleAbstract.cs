namespace Mindbox.GeometryLib
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
            this.Radius = radius;
        }

        private bool isRadiusValid(double radius)
            => radius > 0;


        #region CONTRACT_IMPLEMENTATION
        public double GetArea()
        {
            return Math.PI * Math.Pow(this.Radius, 2);
        }
        #endregion
    }
}
