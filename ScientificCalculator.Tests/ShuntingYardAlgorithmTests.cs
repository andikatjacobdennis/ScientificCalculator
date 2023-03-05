using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ScientificCalculator.Tests
{
    [TestClass]
    public class ShuntingYardAlgorithmTests
    {
        [TestMethod]
        public void TestEvaluate()
        {
            ShuntingYardAlgorithm shuntingYardAlgorithm = new ShuntingYardAlgorithm();

            // Test addition
            Assert.AreEqual(5, shuntingYardAlgorithm.Evaluate("2 + 3"));

            // Test subtraction
            Assert.AreEqual(-1, shuntingYardAlgorithm.Evaluate("2 - 3"));

            // Test multiplication
            Assert.AreEqual(6, shuntingYardAlgorithm.Evaluate("2 * 3"));

            // Test division
            Assert.AreEqual(2, shuntingYardAlgorithm.Evaluate("6 / 3"));

            // Test exponentiation
            Assert.AreEqual(8, shuntingYardAlgorithm.Evaluate("2 ^ 3"));

            // Test sin function
            Assert.AreEqual(Math.Sin(Math.PI / 2), shuntingYardAlgorithm.Evaluate("sin(pi / 2)"));

            // Test cos function
            Assert.AreEqual(Math.Cos(Math.PI / 2), shuntingYardAlgorithm.Evaluate("cos(pi / 2)"));

            // Test tan function
            Assert.AreEqual(Math.Tan(Math.PI / 4), shuntingYardAlgorithm.Evaluate("tan(pi / 4)"));

            // Test signed sin function
            Assert.AreEqual(-Math.Sin(Math.PI / 2), shuntingYardAlgorithm.Evaluate("-sin(pi / 2)"));

            // Test signed cos function
            Assert.AreEqual(-Math.Cos(Math.PI / 2), shuntingYardAlgorithm.Evaluate("-cos(pi / 2)"));

            // Test signed tan function
            Assert.AreEqual(-Math.Tan(Math.PI / 4), shuntingYardAlgorithm.Evaluate("-tan(pi / 4)"));

            // Test negative number
            Assert.AreEqual(-5, shuntingYardAlgorithm.Evaluate("-5"));

            // Test parentheses
            Assert.AreEqual(14, shuntingYardAlgorithm.Evaluate("(2 + 3) * 4"));

            // Test pi constant
            Assert.AreEqual(Math.PI * 2, shuntingYardAlgorithm.Evaluate("pi * 2"));

            // Test division by zero
            Assert.ThrowsException<DivideByZeroException>(() => shuntingYardAlgorithm.Evaluate("1 / 0"));

            // Test invalid token
            Assert.ThrowsException<ArgumentException>(() => shuntingYardAlgorithm.Evaluate("sqrt(2)"));

            // Test invalid expression
            Assert.ThrowsException<ArgumentException>(() => shuntingYardAlgorithm.Evaluate("2 + * 3"));
        }
    }
}
