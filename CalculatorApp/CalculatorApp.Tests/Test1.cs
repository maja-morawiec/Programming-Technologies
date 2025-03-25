using CalculatorApp.Logic;
using CalculatorApp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorApp.Tests
{
    [TestClass]
    public sealed class Test1
    {
        private Calculator calculator;

        [TestInitialize]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TestMethod]
        public void Add_ShouldReturnCorrectResult()
        {
            var result = calculator.Add(3, 5);
            Assert.AreEqual(8, result.Result);
            Assert.AreEqual("Addition", result.Operation);
        }

        [TestMethod]
        public void Subtract_ShouldReturnCorrectResult()
        {
            var result = calculator.Subtract(10, 4);
            Assert.AreEqual(6, result.Result);
            Assert.AreEqual("Subtraction", result.Operation);
        }

        [TestMethod]
        public void Multiply_ShouldReturnCorrectResult()
        {
            var result = calculator.Multiply(2, 3);
            Assert.AreEqual(6, result.Result);
            Assert.AreEqual("Multiplication", result.Operation);
        }

        [TestMethod]
        public void Divide_ShouldReturnCorrectResult()
        {
            var result = calculator.Divide(10, 2);
            Assert.AreEqual(5, result.Result);
            Assert.AreEqual("Division", result.Operation);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_ByZero_ShouldThrow()
        {
            calculator.Divide(5, 0);
        }

        [TestMethod]
        public void Add_NegativeNumbers_ShouldWork()
        {
            var result = calculator.Add(-3, -4);
            Assert.AreEqual(-7, result.Result);
            Assert.AreEqual("Addition", result.Operation);
        }

        [TestMethod]
        public void Multiply_WithZero_ShouldReturnZero()
        {
            var result = calculator.Multiply(100, 0);
            Assert.AreEqual(0, result.Result);
            Assert.AreEqual("Multiplication", result.Operation);
        }
    }
}