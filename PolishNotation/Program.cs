using System;

namespace PolishNotation
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Polish Notation Interpreter
            var polishNotationCalculator = new PolishNotationCalculator();

            // Read the expressions (Console)
            Console.WriteLine("Input expression: ");
            string line;
            while ((line = Console.ReadLine()) != string.Empty)
            {
                var processedExpression = polishNotationCalculator.CalculateExpression(line);
                Console.WriteLine(processedExpression);
            }
        }
    }
}