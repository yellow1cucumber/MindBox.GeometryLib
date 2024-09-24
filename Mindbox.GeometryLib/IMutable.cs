namespace Mindbox.GeometryLib
{
    /// <summary>
    /// Contract, that defines every mutable shape behavior
    /// </summary>
    public interface IMutable
    {
        /// <summary>
        /// Event that occurs, when shape properties changes
        /// </summary>
        public event Action? onChanges;
    }
}
