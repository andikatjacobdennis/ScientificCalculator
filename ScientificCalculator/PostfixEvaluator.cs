using System;
using System.Collections.Generic;

namespace ScientificCalculator
{
    public class PostfixEvaluator
    {
        public double Evaluate(List<Token> tokensInPostfixNotation)
        {
            Stack<double> operands = new Stack<double>();

            foreach (Token token in tokensInPostfixNotation)
            {
                switch (token.tokenType)
                {
                    case TokenType.Constant:
                        operands.Push(GetConstant(token.Value));
                        break;
                    case TokenType.Number:
                        operands.Push(Convert.ToDouble(token.Value));
                        break;
                    case TokenType.OperatorUnary:
                        double operand = operands.Pop();
                        operands.Push(-operand);
                        break;
                    case TokenType.Operator:
                        double operand2 = operands.Pop();
                        double operand1 = operands.Pop();
                        double result = PerformOperation(token.Value, operand1, operand2);
                        operands.Push(result);
                        break;
                    case TokenType.Method:
                        double argument = operands.Pop();
                        double methodResult = PerformMethod(token.Value, argument);
                        operands.Push(methodResult);
                        break;
                }
            }

            return operands.Pop();
        }

        private double GetConstant(dynamic value)
        {
            double result;

            if (string.Equals("pi", value))
            {
                result = Math.PI;
            }
            else
            {
                throw new ArgumentException($"Invalid constant: {value}");
            }

            return result;
        }

        private double PerformOperation(string operatorSymbol, double operand1, double operand2)
        {
            switch (operatorSymbol)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "*":
                    return operand1 * operand2;
                case "/":
                    if (operand2 == 0)
                    {
                        throw new DivideByZeroException("Division by zero");
                    }
                    return operand1 / operand2;
                case "%":
                    return operand1 % operand2;
                case "^":
                    return Math.Pow(operand1, operand2);
                default:
                    throw new ArgumentException($"Invalid operator: {operatorSymbol}");
            }
        }

        private double PerformMethod(string methodName, double argument)
        {
            switch (methodName)
            {
                case "sin":
                    return Math.Sin(argument);
                case "cos":
                    return Math.Cos(argument);
                case "tan":
                    return Math.Tan(argument);
                case "asin":
                    return Math.Asin(argument);
                case "acos":
                    return Math.Acos(argument);
                case "atan":
                    return Math.Atan(argument);
                case "fact":
                    if (argument < 0)
                    {
                        throw new ArgumentException("Factorial of a negative number is undefined");
                    }
                    if (argument == 0)
                    {
                        return 1;
                    }
                    double result = 1;
                    for (int i = 1; i <= argument; i++)
                    {
                        result *= i;
                    }
                    return result;
                default:
                    throw new ArgumentException($"Invalid method name: {methodName}");
            }
        }
    }
}