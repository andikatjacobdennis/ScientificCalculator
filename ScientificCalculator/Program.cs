using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientificCalculator
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Write("Enter a math expression: \n");
                string expression = Console.ReadLine();

                if (expression.ToLower() == "no")
                {
                    break;
                }

                try
                {
                    ShuntingYardAlgorithm shuntingYardAlgorithm = new ShuntingYardAlgorithm();
                    double result = shuntingYardAlgorithm.Evaluate(expression);
                    Console.WriteLine("Result: " + result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }
    }
}