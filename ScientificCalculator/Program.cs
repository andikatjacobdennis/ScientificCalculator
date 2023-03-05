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
            // Display welcome message
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===========================================================");
            Console.WriteLine("||            Welcome to the Scientific Calculator       ||");
            Console.WriteLine("===========================================================\n");
            Console.WriteLine("This program can evaluate arithmetic, trigonometric, and bracketed expressions.\n");
            Console.WriteLine("Sample usage: sin(2*(3+4))-1");
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                // Get the math expression from the user
                Console.Write("\nPlease enter the math expression (or type \"no\" to exit): ");
                string mathExpression = Console.ReadLine();

                // Exit the loop if the user types "no"
                if (mathExpression == "no")
                {
                    break;
                }

                // Evaluate the math expression
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    ShuntingYardAlgorithm shuntingYardAlgorithm = new ShuntingYardAlgorithm();
                    double result = shuntingYardAlgorithm.Evaluate(mathExpression);
                    Console.WriteLine($"Result: {result}\n");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}\n");
                }
            }

            Console.ResetColor();
            Console.WriteLine("Thank you for using the Scientific Calculator! Press any key to exit...");
            Console.ReadKey();
        }
    }
}