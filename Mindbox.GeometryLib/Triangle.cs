namespace Mindbox.GeometryLib
{
    public class Triangle : IShape
    {
        public double SideA { get; protected set; }
        public double SideB { get; protected set; }
        public double SideC { get; protected set; }

        public Triangle(double sideLength)
        {
            this.SideA = sideLength;
            this.SideB = sideLength;
            this.SideC = sideLength;
        }
        public Triangle(double sideA, double sideB, double sideC)
        {
            this.SideA = sideA;
            this.SideB = sideB;
            this.SideC = sideC;
        }

        public bool IsRightTriangle()
        {
            double[] sides = new[] { SideA, SideB, SideC };
            Array.Sort(sides);
            double c = Math.Pow(sides.ElementAt(2), 2);
            double a = Math.Pow(sides.ElementAt(1), 2);
            double b = Math.Pow(sides.ElementAt(0), 2);
            return Math.Abs(c - (b + a)) < 0.0001;
        }

        #region CONTRACTS_IMPLEMENTATION
        public double GetArea()
        {
            double area = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(area * (area - SideA) * (area - SideB) * (area - SideC));
        }
        #endregion
    }
}
