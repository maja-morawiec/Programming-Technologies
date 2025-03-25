namespace CalculatorApp.Data
{
    public class CalculationResult
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public double Result {  get; set; }
        public string Operation {  get; set; }

        public CalculationResult (double firstNumber, double secondNumber, double result, string operation)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            Result = result;
            Operation = operation;
        }
    }
}
