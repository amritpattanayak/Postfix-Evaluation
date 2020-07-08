# Postfix-Evaluation

C# program to evaluate a Postfix Expression for an input string.

Ref: https://nanopdf.com/download/postfix-expression_pdf

Stack is sused to solve the problem

This code only includes operation for +, - , *, /

Also expected space delimited expression

Example:

Expression: 2 5 * 5 4 * + 2 -

Step 1: 10 5 4 * + 2 -

Step 2: 10 20 + 2 -

Step 3: 30 2 -

Step 4: 28
