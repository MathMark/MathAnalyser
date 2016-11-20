using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    /*This class is in charge of converting a function written in Infix notation (It is characterized 
     * by the placement of operators between operands, e.g. "2+2") to function written in Postfix notation 
     * (Reverse Polish Notation). It is needed to easily read the function and calculate
     values in a particular point.*/

    public class Converter 
    {
        static string[] Statements = {"sqrt","abs","sin","cos","tan","cot","arcsin","arccos","arctan","arccot","sinh","cosh",
            "tanh","cth","arsinh","arcosh","artanh","arcth","ln","log","sign","rem",
            "sec","csc","arcsec","arcsc","sech","csch","arsech","arcsch"};

        static char[] Constants = { 'x', 'p', 'e' };
        static char[] Operators = { '~','+', '-', '/', '*', '^' };


        private static short GetPriority(string InputStatement)//returnes priority of function
        {

            foreach (string Statement in Statements)
            {
                if (InputStatement == Statement) return 5;
            }

            switch(InputStatement)
            {
                case "~":
                    return 5;
                case "^":
                    return 4;
                case "/":
                    goto case "*";
                case "*":
                    return 3;
                case "-":
                    goto case "+";
                case "+":
                    return 2;
                case "(":
                    return 1;
                default:
                    return 0;//e.g. '\0' -> 0
            }

        }
        private static bool EqualsToConstant(char symbol)
        {
            foreach (char constant in Constants)
            {
                if (symbol == constant)
                {
                    return true;
                }
            }
            return false;
        }
        private static bool EqualsToOperator(char symbol)
        {
            foreach (char Operator in Operators)
            {
                if (symbol == Operator)
                {
                    return true;
                }
            }
            return false;
        }

        public static List<string> ConvertToPostfix(string InputExpression)
        {
            if(InputExpression==string.Empty)
            {
                throw new Exception("Input line is empty");
            }
            List<string> OutputExpression = new List<string>();

            if (InputExpression[0] == '-')
            {
                InputExpression=InputExpression.Remove(0, 1);
                InputExpression=InputExpression.Insert(0, "~");
            }
            InputExpression=InputExpression.Replace("(-", "(~");
            

            Stack<string> stack = new Stack<string>();

            string buffer = string.Empty;

            for (int j = 0; j < InputExpression.Length; j++)
            {
                if ((char.IsDigit(InputExpression[j])) || (EqualsToConstant(InputExpression[j])))
                {
                    buffer += InputExpression[j];
                    if ((j == InputExpression.Length - 1) || (!char.IsDigit(InputExpression[j + 1])))
                    {
                        OutputExpression.Add(buffer);
                        buffer = string.Empty;
                    }
                }
                else if ((char.IsLetter(InputExpression[j])) && (!EqualsToConstant(InputExpression[j])))
                {
                    for(;j<InputExpression.Length;j++)
                    {
                        if(char.IsLetter(InputExpression[j]))
                        {
                            buffer += InputExpression[j];
                        }
                        else
                        {
                            j--;
                            break;
                        }
                    }

                    stack.Push(buffer);
                    buffer = string.Empty;
                }
                else if (InputExpression[j] == ';')
                {
                    continue;

                }
                else if (InputExpression[j] == '(')
                {
                    stack.Push(InputExpression[j].ToString());
                }
                else if (InputExpression[j] == ')')
                {
                    while (GetPriority(stack.Peek()) != 1)
                    {
                        OutputExpression.Add(stack.Pop());
                    }
                    stack.Pop();
                }
                else if (EqualsToOperator(InputExpression[j]))
                {
                    if (stack.Count() == 0)
                    {
                        stack.Push(InputExpression[j].ToString());
                    }
                    else if (GetPriority(stack.Peek()) < GetPriority(InputExpression[j].ToString())) 
                    {
                        stack.Push(InputExpression[j].ToString());
                    }
                    else
                    {
                        while ((stack.Count != 0) && (GetPriority(stack.Peek()) >= GetPriority(InputExpression[j].ToString())))

                        {
                            OutputExpression.Add(stack.Pop());
                        }
                        stack.Push(InputExpression[j].ToString());
                    }

                }
                else
                {
                    throw new Exception(String.Format("There is unkown symbol in line: {0}",InputExpression[j]));
                }

            }

            while (stack.Count() != 0)
            {
                OutputExpression.Add(stack.Pop());
            }
            return OutputExpression;
        }

        public static double GetValue(List<string> PostfixLine, double point)
        {
            Stack<double> stack = new Stack<double>();

            double number1, number2;
 

            foreach (string piece in PostfixLine)
            {
                if (char.IsDigit(piece[0]))
                    {
                        stack.Push(Convert.ToDouble(piece));
                    }
                else if ((char.IsLetter(piece[0])) && (!EqualsToConstant(piece[0])))
                    {
                        double variable = Convert.ToDouble(stack.Pop());
                        switch (piece)
                        {
                            case "sqrt":
                                stack.Push(Math.Sqrt(variable));
                                break;
                            case "abs":
                                stack.Push(Math.Abs(variable));
                                break;
                            case "sin":
                                stack.Push(Math.Sin(variable));
                                break;
                            case "sinh":
                                stack.Push(Math.Sinh(variable));
                                break;
                            case "cosh":
                                stack.Push(Math.Cosh(variable));
                                break;
                            case "cos":
                                stack.Push(Math.Cos(variable));
                                break;
                            case "cth":
                                stack.Push(1 / Math.Tanh(variable));
                                break;
                            case "tanh":
                                stack.Push(Math.Tanh(variable));
                                break;
                            case "tan":
                                stack.Push(Math.Tan(variable));
                                break;
                            case "cot":
                                stack.Push(1 / Math.Tan(variable));
                                break;
                            case "аbs":
                                stack.Push(Math.Abs(variable));
                                break;
                            case "ln":
                                stack.Push(Math.Log(variable));
                                break;
                            case "arsinh":
                                stack.Push(Math.Log(variable + Math.Sqrt(variable * variable + 1)));
                                break;
                            case "arcsin":
                                stack.Push(Math.Asin(variable));
                                break;
                            case "arcosh":
                                stack.Push(Math.Log(variable + Math.Sqrt(variable + 1) * Math.Sqrt(variable - 1)));
                                break;
                            case "arccos":
                                stack.Push(Math.Acos(variable));
                                break;
                            case "artanh":
                                stack.Push(Math.Log((variable + 1) / (variable - 1)) / 2);
                                break;
                            case "arccot":
                                stack.Push(Math.Atan(-1 * variable) + Math.PI / 2);
                                break;
                            case "arcth":
                                stack.Push(Math.Log((variable + 1) / (1 - variable)) / 2);
                                break;
                            case "arctan":
                                stack.Push(Math.Atan(variable));
                                break;
                            case "log":
                                stack.Push(Math.Log(Convert.ToDouble(stack.Pop()), variable));
                                break;
                            case "sign":
                                stack.Push(Math.Sign(variable));
                                break;
                            case "rem":
                                stack.Push(Convert.ToDouble(stack.Pop()) % variable);
                                break;
                            case "sec":
                                stack.Push(1 / Math.Cos(variable));
                                break;
                            case "csc":
                                stack.Push(1 / Math.Sin(variable));
                                break;
                            case "arcsec":
                                stack.Push(Math.Acos(1 / variable));
                                break;
                            case "arccsc":
                                stack.Push(Math.Asin(1 / variable));
                                break;
                            case "sech":
                                stack.Push(1 / Math.Cosh(variable));
                                break;
                            case "csch":
                                stack.Push(1 / Math.Sinh(variable));
                                break;
                            case "arsech":
                                stack.Push(Math.Log(1 / variable + Math.Sqrt(1 / variable + 1) * Math.Sqrt(1 / variable - 1)));
                                break;
                            case "arcsch":
                                stack.Push(Math.Log(1 / variable + Math.Sqrt(1 / variable * variable + 1)));
                                break;
                            default:
                                throw new Exception(String.Format("The line contains unknown operator: {0}",piece));

                        }
                    }
                else
                {
                    switch (piece[0])
                        {

                            case 'e':
                                stack.Push(Math.E);
                                break;
                            case 'p':
                                stack.Push(Math.PI);
                                break;
                            case 'x':
                                stack.Push(point);
                                break;
                            case '~':
                                stack.Push(-1 * stack.Pop());
                                break;

                            ///binary operations
                            case '+':
                                number2 = Convert.ToDouble(stack.Pop());
                                number1 = Convert.ToDouble(stack.Pop());
                                stack.Push(number1 + number2);
                                    break;
                                case '-':
                                number2 = Convert.ToDouble(stack.Pop());
                                number1 = Convert.ToDouble(stack.Pop());
                                stack.Push(number1 - number2);
                                    break;
                                case '*':
                                number2 = Convert.ToDouble(stack.Pop());
                                number1 = Convert.ToDouble(stack.Pop());
                                stack.Push(number1 * number2);
                                    break;
                                case '/':
                                number2 = Convert.ToDouble(stack.Pop());
                                number1 = Convert.ToDouble(stack.Pop());
                                stack.Push(number1 / number2);
 
                                    break;
                                case '^':
                                number2 = Convert.ToDouble(stack.Pop());
                                number1 = Convert.ToDouble(stack.Pop());
                                stack.Push(Math.Pow(number1,number2));
                                    break;
                                case ';':
                                    break;
                            }
                        }
                    }

            return stack.Pop();
        }

    }
}


