using System;
using System.Collections.Generic;

namespace ScientificCalculator
{
    public class ShuntingYardAlgorithm
    {
        public double Evaluate(string expression)
        {
            // Tokenize the expression
            List<string> tokens = Tokenize(expression);

            // Convert infix to postfix notation using the Shunting Yard Algorithm
            List<string> postfix = ShuntingYard(tokens);

            // Evaluate the postfix expression
            Stack<double> stack = new Stack<double>();
            foreach (string token in postfix)
            {
                if (IsNumber(token))
                {
                    stack.Push(double.Parse(token));
                }
                else if (IsUnaryOperator(token))
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid expression: " + string.Join(" ", postfix));
                    }
                    double operand = stack.Pop();
                    stack.Push(ApplyUnaryOperator(token, operand));
                }
                else if (IsBinaryOperator(token))
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression: " + string.Join(" ", postfix));
                    }
                    double rightOperand = stack.Pop();
                    double leftOperand = stack.Pop();
                    stack.Push(ApplyBinaryOperator(token, leftOperand, rightOperand));
                }
                else if (IsFunction(token))
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid expression: " + string.Join(" ", postfix));
                    }
                    double operand = stack.Pop();
                    stack.Push(ApplyFunction(token, operand));
                }
                else
                {
                    throw new ArgumentException("Invalid token: " + token);
                }
            }

            if (stack.Count != 1)
            {
                throw new ArgumentException("Invalid expression: " + string.Join(" ", postfix));
            }

            return stack.Pop();
        }

        static List<string> Tokenize(string expression)
        {
            List<string> tokens = new List<string>();
            string buffer = "";

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];

                if (char.IsDigit(c) || c == '.')
                {
                    // If the character is a digit or decimal point, add it to the buffer
                    buffer += c;
                }
                else if (IsOperator(c.ToString()) || IsParenthesis(c.ToString()))
                {
                    // If the character is an operator or parenthesis, add the buffer to the list
                    // of tokens and add the operator or parenthesis as a separate token
                    if (buffer != "")
                    {
                        tokens.Add(buffer);
                        buffer = "";
                    }
                    tokens.Add(c.ToString());
                }
                else if (char.IsLetter(c))
                {
                    // If the character is a letter, it may be the start of a function name
                    buffer += c;

                    // Check if the buffer matches any of the known functions
                    foreach (string function in functions)
                    {
                        if (function.StartsWith(buffer))
                        {
                            // If there is a match, continue building the buffer
                            break;
                        }
                        else if (function == buffer)
                        {
                            // If the buffer matches a function name exactly, add it to the tokens
                            tokens.Add(buffer);
                            buffer = "";
                            break;
                        }
                    }
                }
                else if (char.IsWhiteSpace(c))
                {
                    // Ignore whitespace
                }
                else
                {
                    // If the character is anything else, it's a syntax error
                    throw new ArgumentException("Invalid expression");
                }
            }

            // Add the final buffer to the list of tokens
            if (buffer != "")
            {
                tokens.Add(buffer);
            }

            return tokens;
        }

        static List<string> ShuntingYard(List<string> infix)
        {
            List<string> postfix = new List<string>();
            Stack<string> operators = new Stack<string>();

            foreach (string token in infix)
            {
                if (IsNumber(token))
                {
                    postfix.Add(token);
                }
                else if (IsFunction(token))
                {
                    operators.Push(token);
                }
                else if (IsOperator(token))
                {
                    while (operators.Count > 0 && IsOperator(operators.Peek())
                        && ((IsLeftAssociative(token) && Precedence(token) <= Precedence(operators.Peek()))
                        || (IsRightAssociative(token) && Precedence(token) < Precedence(operators.Peek()))))
                    {
                        postfix.Add(operators.Pop());
                    }
                    operators.Push(token);
                }
                else if (IsLeftParenthesis(token))
                {
                    operators.Push(token);
                }
                else if (IsRightParenthesis(token))
                {
                    while (operators.Count > 0 && !IsLeftParenthesis(operators.Peek()))
                    {
                        postfix.Add(operators.Pop());
                    }
                    if (operators.Count == 0)
                    {
                        throw new ArgumentException("Mismatched parentheses");
                    }
                    operators.Pop();
                    if (operators.Count > 0 && IsFunction(operators.Peek()))
                    {
                        postfix.Add(operators.Pop());
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid token: " + token);
                }
            }

            while (operators.Count > 0)
            {
                if (IsParenthesis(operators.Peek()))
                {
                    throw new ArgumentException("Mismatched parentheses");
                }
                postfix.Add(operators.Pop());
            }

            return postfix;
        }

        static bool IsNumber(string token)
        {
            double result;
            return double.TryParse(token, out result);
        }

        static bool IsOperator(string token)
        {
            return operators.ContainsKey(token);
        }

        static bool IsUnaryOperator(string token)
        {
            return unaryOperators.ContainsKey(token);
        }

        static bool IsBinaryOperator(string token)
        {
            return binaryOperators.ContainsKey(token);
        }

        static bool IsFunction(string token)
        {
            return functions.Contains(token);
        }

        static bool IsParenthesis(string token)
        {
            return IsLeftParenthesis(token) || IsRightParenthesis(token);
        }

        static bool IsLeftParenthesis(string token)
        {
            return token == "(";
        }

        static bool IsRightParenthesis(string token)
        {
            return token == ")";
        }

        static bool IsLeftAssociative(string token)
        {
            return operators[token].Associativity == Associativity.Left;
        }

        static bool IsRightAssociative(string token)
        {
            return operators[token].Associativity == Associativity.Right;
        }

        static int Precedence(string token)
        {
            return operators[token].Precedence;
        }

        static double ApplyUnaryOperator(string op, double operand)
        {
            return unaryOperators[op](operand);
        }

        static double ApplyBinaryOperator(string op, double leftOperand, double rightOperand)
        {
            return binaryOperators[op](leftOperand, rightOperand);
        }

        static double ApplyFunction(string name, double operand)
        {
            return functionMap[name](operand);
        }

        static Dictionary<string, OperatorInfo> operators = new Dictionary<string, OperatorInfo>()
        {
            { "^", new OperatorInfo(4, Associativity.Right) },
            { "*", new OperatorInfo(3, Associativity.Left) },
            { "/", new OperatorInfo(3, Associativity.Left) },
            { "+", new OperatorInfo(2, Associativity.Left) },
            { "-", new OperatorInfo(2, Associativity.Left) }
        };

        static Dictionary<string, Func<double, double>> unaryOperators = new Dictionary<string, Func<double, double>>()
        {
            { "-", x => -x }
        };

        static Dictionary<string, Func<double, double, double>> binaryOperators = new Dictionary<string, Func<double, double, double>>()
        {
            { "^", (x, y) => Math.Pow(x, y) },
            { "*", (x, y) => x * y },
            { "/", (x, y) => x / y },
            { "+", (x, y) => x + y },
            { "-", (x, y) => x - y }
        };

        static HashSet<string> functions = new HashSet<string>()
        {
            "sin", "cos", "tan", "sqrt"
        };

        static Dictionary<string, Func<double, double>> functionMap = new Dictionary<string, Func<double, double>>()
        {
            { "sin", x => Math.Sin(x) },
            { "cos", x => Math.Cos(x) },
            { "tan", x => Math.Tan(x) },
            { "sqrt", x => Math.Sqrt(x) }
        };

        class OperatorInfo
        {
            public int Precedence { get; private set; }
            public Associativity Associativity { get; private set; }

            public OperatorInfo(int precedence, Associativity associativity)
            {
                Precedence = precedence;
                Associativity = associativity;
            }
        }

        enum Associativity
        {
            Left,
            Right
        }
    }
}