using System;
using System.Collections.Generic;

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
            List<BaseTR1Control> tr1Controls = new List<BaseTR1Control>
            {
                new TR1CavesControl(),
                new TR1VilcabambaControl(),
                new TR1ValleyControl(),
                new TR1ToQControl(),
                new TR1FollyControl(),
                new TR1ColosseumControl(),
                new TR1MidasControl(),
                new TR1CisternControl(),
                new TR1ToTControl(),
                new TR1KhamoonControl(),
                new TR1ObeliskControl(),
                new TR1SanctuaryControl(),
                new TR1MinesControl(),
                new TR1AtlantisControl(),
                new TR1PyramidControl()
            };

            foreach (BaseTR1Control control in tr1Controls)
            {
                Console.WriteLine("Generating for {0}", control.Level);
                control.GenerateSecretRoomMapping();
                control.GenerateEnvironmentMapping();
            }
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
