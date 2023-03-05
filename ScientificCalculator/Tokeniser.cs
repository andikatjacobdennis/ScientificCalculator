using System;
using System.Collections.Generic;
using System.Linq;

namespace ScientificCalculator
{
    public class Tokeniser
    {
        List<string> Methods = new List<string>()
        {
            "sin", "cos", "tan", "asin", "acos", "atan", "fact"
        };
        public List<Token> GetTokensInInfixNotation(string mathExpression)
        {
            List<Token> tokensInInfixNotation = new List<Token>();
            string buffer = string.Empty;

            for (int i = 0; i < mathExpression.Length; i++)
            {
                char c = mathExpression[i];

                if (c == '(' || c == ')')
                {
                    AddBuffer(tokensInInfixNotation, buffer);
                    AddToken(tokensInInfixNotation, TokenType.Bracket, c.ToString());
                    buffer = string.Empty;
                }
                else if (c == '+' || c == '*' || c == '/' || c == '%' || c == '^')
                {
                    AddBuffer(tokensInInfixNotation, buffer);
                    AddToken(tokensInInfixNotation, TokenType.Operator, c.ToString());
                    buffer = string.Empty;
                }
                else if (c == '-')
                {
                    // Check if the minus sign is a unary operator or a binary operator
                    if (i == 0 || mathExpression[i - 1] == '(' || mathExpression[i - 1] == '+' || mathExpression[i - 1] == '-' || mathExpression[i - 1] == '*' || mathExpression[i - 1] == '/' || mathExpression[i - 1] == '^')
                    {
                        // Unary minus operator
                        AddToken(tokensInInfixNotation, TokenType.OperatorUnary, "-");
                    }
                    else
                    {
                        // Binary minus operator
                        AddBuffer(tokensInInfixNotation, buffer);
                        AddToken(tokensInInfixNotation, TokenType.Operator, c.ToString());
                        buffer = string.Empty;
                    }
                }
                else if (char.IsDigit(c) || c == '.' || char.IsUpper(c) || char.IsLower(c))
                {
                    // If the character is a digit or decimal point, add it to the buffer
                    buffer += c;
                }
            }

            AddBuffer(tokensInInfixNotation, buffer);
            return tokensInInfixNotation;
        }

        private void AddBuffer(List<Token> tokensInInfixNotation, string buffer)
        {
            if (!string.IsNullOrWhiteSpace(buffer))
            {
                if (double.TryParse(buffer, out double number))
                {
                    AddToken(tokensInInfixNotation, TokenType.Number, number.ToString());
                }
                else if (Methods.Any(x => string.Equals(x, buffer)))
                {
                    AddToken(tokensInInfixNotation, TokenType.Method, buffer);
                }
                else
                {
                    throw new ArgumentException($"Error while parsing buffer => {buffer}");
                }
            }
        }

        private void AddToken(List<Token> tokensInInfixNotation, TokenType tokenType, string value)
        {
            tokensInInfixNotation.Add(new Token
            {
                tokenType = tokenType,
                Value = value
            });
        }
    }
}