using CalculatorApp.Data;

namespace CalculatorApp.Logic
{
    public class Calculator
    {
        public CalculationResult Add(double a, double b)
        {
            return new CalculationResult(a, b, a + b, "Addition");
        }

        public CalculationResult Subtract(double a, double b)
        {
            return new CalculationResult(a, b, a - b, "Subtraction");
        }

        public CalculationResult Multiply(double a, double b)
        {
            return new CalculationResult(a, b, a * b, "Multiplication");
        }

        public CalculationResult Divide(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException("You cannot divide by zero!");
            return new CalculationResult(a, b, a / b, "Division");
        }
    }
}
