using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SimpleCalculator.Test.Unit
{
    [TestClass]
    public class InputConverterTest
    {
        private readonly InputConverter _inputCoverter = new InputConverter();
        string validInput = "5";
        string invalidInput = "invalid";

        [TestMethod]
        public void ConvertToNumericWithValidInputString()
        {
            Assert.AreEqual(5, _inputCoverter.ConvertInputToNumeric(validInput));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConvertToNumericWithInvalidInputString()
        {
            Assert.AreEqual(5, _inputCoverter.ConvertInputToNumeric(invalidInput));
        }
    }
}
