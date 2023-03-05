using System;
using System.Collections.Generic;
using System.Linq;

namespace ScientificCalculator
{
    public class MathExpressionEvaluator
    {
        public double Evaluate(string mathExpression)
        {
            double result = 0;

            // Get tokens in Infix notation
            Tokeniser tokeniser = new Tokeniser();
            List<Token> infixTokens = tokeniser.GetTokensInInfixNotation(mathExpression);
            Console.WriteLine("Infix => " + infixTokens.Aggregate((i, j) => new Token { Value = i.Value + ", " + j.Value }).Value);

            // Convert Infix to Postfix notation
            ShuntingYardAlgorithm shuntingYardAlgorithm = new ShuntingYardAlgorithm();
            List<Token> postfixTokens = shuntingYardAlgorithm.ConvertToPostfix(infixTokens);
            Console.WriteLine("Postfix => " + postfixTokens.Aggregate((i, j) => new Token { Value = i.Value + ", " + j.Value }).Value);

            // Do the evaluation here
            result = PostfixEvaluator.Evaluate(postfixTokens);

            return result;
        }
    }
}