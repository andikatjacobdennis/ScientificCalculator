using System;

namespace ScientificCalculator
{
    class Program
    {
        /// <summary>
        /// This is a C# program for a scientific calculator. 
        /// It starts by displaying a welcome message and some information about the program. 
        /// It then enters a loop where it prompts the user to enter a math expression to evaluate. 
        /// The program uses a MathExpressionEvaluator class to evaluate the expression and prints the result to the console. 
        /// If an error occurs during the evaluation, it catches the exception and prints an error message to the console. 
        /// The program continues to prompt the user for expressions until the user types "no". 
        /// Finally, it displays a closing message and waits for the user to press any key before exiting.
        /// </summary>
        static void Main()
        {
            // Update title
            Console.Title = "Scientific Calculator";

            // Display welcome message
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==============================================================");
            Console.WriteLine("||            Welcome to the Scientific Calculator          ||");
            Console.WriteLine("==============================================================\n");
            Console.WriteLine("1. This program can evaluate arithmetic, trigonometric, constants and bracketed expressions.\r\n");
            Console.WriteLine("2. Sample usage: sin(2*(3+4))-1+pi");

            Console.WriteLine("\n******** FOR EDUCATIONAL PURPOSE ONLY. USE AT YOUR OWN RISK ********");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                // Get the math expression from the user
                Console.Write("\nPlease enter the math expression (or type \"no\" to exit): ");
                Console.ForegroundColor = ConsoleColor.White;
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
                    MathExpressionEvaluator mathEvaluator = new MathExpressionEvaluator();
                    double result = mathEvaluator.Evaluate(mathExpression);
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