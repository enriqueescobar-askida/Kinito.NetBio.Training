namespace Lab1
{
    using System;

    using StringProcessor;

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            foreach (string argument in args)
            {
                Console.WriteLine(argument);
            }

            Run();
        }

        /// <summary>
        /// The run.
        /// </summary>
        private static void Run()
        {
            IStringProcessor processor = new ReverseProcessor();
            ConsoleColor originalColor = Console.ForegroundColor;
            try
            {
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Enter Some Text: ");
                    Console.ForegroundColor = originalColor;

                    string input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                        return;

                    string result = processor.Process(input);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(result);
                }
            }
            finally
            {
                Console.ForegroundColor = originalColor;
            }
        }
    }
}
