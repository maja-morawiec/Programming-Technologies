// See https://aka.ms/new-console-template for more information

using CalculatorApp.Data;
using CalculatorApp.Logic;
using System;

class Program
{
    static void Main()
    {
        var calculator = new Calculator();

        Console.WriteLine("Enter the first number: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter the second number: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Choose an operation: +, -, *, /");
        string operation = Console.ReadLine();

        try
        {
            CalculationResult result = operation switch
            {
                "+" => calculator.Add(num1, num2),
                "-" => calculator.Subtract(num1, num2),
                "*" => calculator.Multiply(num1, num2),
                "/" => calculator.Divide(num1, num2),
                _ => throw new InvalidOperationException("That's forbidden!")
            };

            Console.WriteLine($"Wynik: {result.Result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
