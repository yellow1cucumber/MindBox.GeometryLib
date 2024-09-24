﻿namespace Mindbox.GeometryLib.Triangle
{
    public abstract class TriangleAbstract : IShape
    {
        public abstract double SideA { get; protected set; }
        public abstract double SideB { get; protected set; }
        public abstract double SideC { get; protected set; }

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
        #endregion
    }
}
