/******************************************************************/
// C# program to evaluate a Postfix Expression for an input string./ 
// Ref: https://nanopdf.com/download/postfix-expression_pdf        /
// Stack is sused to solve the problem.                            /
// This code only includes operation for +, - , *, /               /
// Also expected space delimited expression                        /
/******************************************************************/
using System;
using System.Collections;

namespace Postfix_Evaluation
{
    class Program
    {
        static void Main(string[] args)
        {
            Start:
            Console.WriteLine("Enter the Postfix expression (Space (' ') delemeted) to be evaluated:");
            string expression = Console.ReadLine(); //User input
            EvaluatePostfixExpression(expression);

            //User input for next operation
            Console.WriteLine("Do you want to evaluate new expression? (y/n)");
            string moreEvalaution = Console.ReadLine();
            if (moreEvalaution == "y") {
                goto Start; 
            }
        }

        /// <summary>
        /// Evaluate Postfix Expression
        /// </summary>
        /// <param name="expression"></param>
        static void EvaluatePostfixExpression(string expression) {
            Stack operandStack = new Stack();
            string[] expressionArray = expression.Split(" "); //Splitting the expression with space to an atring array

            //Minimum 2 operands and 1 operator is required to evaluate the expresion
            if (expressionArray.Length < 3) {
                Console.WriteLine("Invalid Expression");
                return;
            }

            for (int i = 0; i < expressionArray.Length; i++) {
                // Check if the currnt value in array is a Operator
                if (expressionArray[i] == "*" || expressionArray[i] == "/" || expressionArray[i] == "+" || expressionArray[i] == "-")
                {
                    //Get the top two values of the Stack and remove them
                    int operand1 = (int)operandStack.Peek(); 
                    operandStack.Pop();

                    int operand2 = (int)operandStack.Peek();
                    operandStack.Pop();

                    int result = 0;

                    switch (expressionArray[i])
                    {
                        case "*":
                            result = operand2 * operand1;
                            break;
                        case "/":
                            result = operand2 / operand1;
                            break;
                        case "+":
                            result = operand2 + operand1;
                            break;
                        case "-":
                            result = operand2 - operand1;
                            break;
                    }
                    operandStack.Push(result); //Push the result in to the Stack
                }
                else
                {
                    int value = 0;
                    if (int.TryParse(expressionArray[i], out value))
                    {
                        // If the current array value is an integer, push it on the to of the Stack
                        operandStack.Push(value); 
                    }
                    else
                    {
                        //If the current array value is not integer, Invalid expression
                        Console.WriteLine("Invalid expression. Integer operands expected."); return;
                    }
                }
            }

            //Print the result
            Console.WriteLine("Result = {0}", operandStack.Peek());
        }
    }
}
