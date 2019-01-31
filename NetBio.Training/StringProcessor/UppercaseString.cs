namespace StringProcessor
{
    /// <summary>
    /// The uppercase string.
    /// </summary>
    public class UppercaseString : IStringProcessor
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
        public string Process(string input)
        {
            return input.ToUpper();
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return "Uppercase the String";
        } 
    }
}