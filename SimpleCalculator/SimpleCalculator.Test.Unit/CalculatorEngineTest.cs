using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SimpleCalculator.Test.Unit
{
    [TestClass]
    public class CalculatorEngineTest
    {
        private readonly CalculatorEngine _calculatorEngine = new CalculatorEngine();

        int firstNum = 5;
        int secondNum = 6;
        
        [TestMethod]
        public void AddingTwoValidInputsWithSymbolOperator()
        {
            Assert.AreEqual(11, _calculatorEngine.Calculate("+", firstNum, secondNum));
        }

        [TestMethod]
        public void MultiplyingTwoValidInputsWithWordOperator()
        {
            Assert.AreEqual(30, _calculatorEngine.Calculate("Multiply", firstNum, secondNum));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddingTwoValidInputsWithInvalidOperator()
        {
            Assert.AreEqual(11, _calculatorEngine.Calculate("plus", firstNum, secondNum));
        }
    }
}
