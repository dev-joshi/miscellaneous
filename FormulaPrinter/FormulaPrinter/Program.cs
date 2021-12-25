using System;
using System.ComponentModel;

namespace FormulaPrinter
{
    class Program
    {
        private static float result(float x, float y)
        {
            // Edit this formula...
            return (y * 5f) / (x + y);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to 2 variable formula printer!");

            var f = new Formula(result);

            float startX, incX, startY, incY;
            int iX, iY;

            if (args.Length < 6)
            {
                if(!GetInput("starting point of X", out startX)
                    || !GetInput("increment in X", out incX)
                    || !GetInput("iterations of X", out iX)
                    || !GetInput("starting point of Y", out startY)
                    || !GetInput("increment in Y", out incY)
                    || !GetInput("iterations of Y", out iY))
                {
                    return;
                }
            }
            else
            {
                if(!ValidateInput(args[0], out startX)
                    || !ValidateInput(args[1], out incX)
                    || !ValidateInput(args[2], out iX)
                    || !ValidateInput(args[3], out startY)
                    || !ValidateInput(args[4], out incY)
                    || !ValidateInput(args[5], out iY))
                {
                    return;
                }
            }

            Console.WriteLine(f.Print(startX, incX, iX, startY, incY, iY));
            Console.ReadKey();
        }

        private static bool GetInput<T>(string name, out T val) where T : struct
        {
            Console.WriteLine($"Please enter the {name} :");
            var input = Console.ReadLine();
            return ValidateInput(input, out val);
        }

        private static bool ValidateInput<T>(string input, out T val) where T : struct
        {
            val = default(T);
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));

                if (converter is not null)
                {
                    val = (T)converter.ConvertFromString(input);
                    return true;
                }
            }
            catch (Exception)
            {
            }

            Console.WriteLine("Incorrect input!!!!");

            return false;
        }
    }
}
