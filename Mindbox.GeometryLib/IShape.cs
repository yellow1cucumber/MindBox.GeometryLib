namespace Mindbox.GeometryLib
{
    /// <summary>
    /// Contract, that defines common behavior of shapes
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Method, that returns area of geometry shape
        /// </summary>
        /// <returns>
        /// area of shape
        /// </returns>
        public double GetArea();
    }
}
