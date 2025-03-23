namespace CalculatorApp.Data
{
    public class CalculationResult
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public int Result {  get; set; }
        public string Operation {  get; set; }

        public CalculationResult (int firstNumber, int secondNumber, int result, string operation)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            Result = result;
            Operation = operation;
        }
    }
}
