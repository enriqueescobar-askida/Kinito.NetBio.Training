namespace StringProcessor
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The randomize string.
    /// </summary>
    public class RandomizeString : IStringProcessor
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
            Random rng = new Random();
            List<char> charInput = new List<char>(input.ToCharArray()); // input.ToList();
            List<char> charOutput = new List<char>();

            // Go through character input, remove a random
            // character and add it to the output.
            while (charInput.Count > 0)
            {
                int pos = rng.Next(charInput.Count - 1);
                charOutput.Add(charInput[pos]);
                charInput.RemoveAt(pos);
            }

            // Generate a string from the character collection.
            return new string(charOutput.ToArray());
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return "Scramble the String";
        }
    }
}