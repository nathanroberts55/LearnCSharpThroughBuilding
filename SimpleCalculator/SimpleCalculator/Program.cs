using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create InputCoverter and CalculatorEnginer objects
                InputConverter inputConverter = new InputConverter();
                CalculatorEngine calculatorEngine = new CalculatorEngine();

                // Take in the two numbers and the operation to be performed
                Console.Write("Please Enter the First Number: ");
                double firstNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());
                Console.Write("Please Enter the Second Number: ");
                double secondNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());
                Console.Write("Please Enter the Operation: ");
                string operation = Console.ReadLine();

                // Perform the calculation and print the result
                double result = calculatorEngine.Calculate(operation, firstNumber, secondNumber);
                Console.WriteLine(String.Format("The Result is : {0}", result));
            }
            catch (Exception ex)
            {
                // Catch any exception and print it to the console before ending execution
                // In real word we would want to log this message
                Console.WriteLine(ex.Message);
            }


        }
    }
}
