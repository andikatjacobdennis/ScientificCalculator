using System;
using System.Collections.Generic;
using System.Linq;

namespace ScientificCalculator
{
    public class ShuntingYardAlgorithm
    {
        private readonly Dictionary<string, int> _precedence = new Dictionary<string, int>()
        {
            { "(", 0 },
            { "+", 1 },
            { "-", 1 },
            { "*", 2 },
            { "/", 2 },
            { "%", 2 },
            { "^", 3 },
            { "sin", 4 },
            { "cos", 4 },
            { "tan", 4 },
            { "asin", 4 },
            { "acos", 4 },
            { "atan", 4 },
            { "fact", 4 },
        };

        public List<Token> ConvertToPostfix(List<Token> infixTokens)
        {
            List<Token> postfixTokens = new List<Token>();
            Stack<Token> operatorStack = new Stack<Token>();

            foreach (Token token in infixTokens)
            {
                switch (token.tokenType)
                {
                    case TokenType.Number:
                        postfixTokens.Add(token);
                        break;

                    case TokenType.Constant:
                        postfixTokens.Add(token);
                        break;

                    case TokenType.Method:
                        operatorStack.Push(token);
                        break;

                    case TokenType.Operator:
                        while (operatorStack.Count > 0 &&
                               _precedence[operatorStack.Peek().Value] >= _precedence[token.Value])
                        {
                            postfixTokens.Add(operatorStack.Pop());
                        }
                        operatorStack.Push(token);
                        break;

                    case TokenType.OperatorUnary:
                        operatorStack.Push(token);
                        break;

                    case TokenType.Bracket:
                        if (token.Value == "(")
                        {
                            operatorStack.Push(token);
                        }
                        else if (token.Value == ")")
                        {
                            while (operatorStack.Peek().Value != "(")
                            {
                                postfixTokens.Add(operatorStack.Pop());
                            }
                            operatorStack.Pop();

                            if (operatorStack.Count > 0 && operatorStack.Peek().tokenType == TokenType.Method)
                            {
                                postfixTokens.Add(operatorStack.Pop());
                            }
                        }
                        break;
                }
            }

            while (operatorStack.Count > 0)
            {
                postfixTokens.Add(operatorStack.Pop());
            }

            return postfixTokens;
        }
    }
}