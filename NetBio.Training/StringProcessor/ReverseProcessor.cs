namespace StringProcessor
{
    using System;

    /// <summary>
    /// The reverse processor.
    /// </summary>
    public class ReverseProcessor : IStringProcessor
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
            char[] charInput = input.ToCharArray();
            Array.Reverse(charInput);
            return new string(charInput);
        } 
    }
}