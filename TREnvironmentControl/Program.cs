using System;

namespace TREnvironmentControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1 || args[0].Contains("?"))
            {
                Usage();
                return;
            }

            switch (args[0].ToLower())
            {
                case "tr1":
                    GenerateTR1Environment();
                    break;
                case "tr2":
                    GenerateTR2Environment();
                    break;
                case "tr3":
                    GenerateTR3Environment();
                    break;
            }
        }

        private static void GenerateTR1Environment()
        {
            throw new NotImplementedException();
        }

        private static void GenerateTR2Environment()
        {
            throw new NotImplementedException();
        }

        private static void GenerateTR3Environment()
        {
            throw new NotImplementedException();
        }

        private static void Usage()
        {
            Console.WriteLine();
            Console.WriteLine("Usage: TREnvironmentControl [TR1 | TR2 | TR3]");
            Console.WriteLine();

            Console.WriteLine("Example");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\tTREnvironmentControl TR1");
            Console.ResetColor();
            Console.WriteLine("\t\tGenerate environment and secret room JSON for TR1.");
            Console.WriteLine();
        }
    }
}
