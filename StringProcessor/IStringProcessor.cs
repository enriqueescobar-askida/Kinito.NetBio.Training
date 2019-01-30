namespace StringProcessor
{
    /// <summary>
    /// The i string processor.
    /// </summary>
    public interface IStringProcessor
    {
        /// <summary>
        /// The process.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string Process(string input);
    }
}