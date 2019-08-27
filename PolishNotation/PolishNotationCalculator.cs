using System;
using System.Collections.Generic;

namespace PolishNotation
{
    public class PolishNotationCalculator
    {
        public string CalculateExpression(string expression)
        {
            Queue<string> store = new Queue<string>();

            // Process the expression - run for all tokens
            string[] tokens = expression.Split(" ");
            for (int i = 0; i < tokens.Length; i++)
            {
                string token = tokens[i];

                if (IsOperator(token))
                {
                    // If token is a calc operator, get the next 2 tokens to calculate
                    string firstToken = tokens[i + 1];
                    string secondToken = tokens[i + 2];

                    int firstOperand;
                    int secondOperand;

                    // If the next 2 tokens are numbers then they can be calculated
                    if (int.TryParse(firstToken, out firstOperand) && int.TryParse(secondToken, out secondOperand))
                    {
                        // Store the calculated result
                        int result = Calculate(token, firstOperand, secondOperand);
                        store.Enqueue(result.ToString());

                        // Jump to the next token after the 2 operands
                        i += 2;
                    }
                    else
                    {
                        store.Enqueue(token);
                    }
                }
                else
                {
                    store.Enqueue(token);
                }
            }

            string processedExpression = string.Join(" ", store);

            // Return the processedExpression, if there is only one element (the expression was fully calculated) or the expression kept the same (no further simplifications are possible)
            if (store.Count == 1 || processedExpression == expression)
            {
                return processedExpression;
            }
            // Try to process the expression again (recursively)
            else
            {
                return CalculateExpression(processedExpression);
            }
        }

        private bool IsOperator(string digit)
        {
            return (digit == "+" || digit == "-" || digit == "*");
        }

        private int Calculate(string calcOperator, int firstOperand, int secondOperand)
        {
            switch (calcOperator)
            {
                case "+":
                    return firstOperand + secondOperand;
                case "-":
                    return firstOperand - secondOperand;
                case "*":
                    return firstOperand * secondOperand;
            }

            return 0;
        }

    }
}
