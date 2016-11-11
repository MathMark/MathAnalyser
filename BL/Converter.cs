using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    /*This class is in charge of converting a function written in Infix notation (It is characterized 
     * by the placement of operators between operands, e.g. "2+2") to function written in Postfix notation 
     * (Reverse Polish Notation). It is needed to easily read the function and calculate
     values in a particular point.*/
    public interface IConverter
    {
        //static string[] ConvertToPostfix(string function);
    }
    public class Converter : IConverter
    {
        static string[] Statements = {"~","sqrt","abs","sin","cos","tan","cot","arcsin","arccos","arctan","arccot","sinh","cosh",
            "tanh","cth","arsinh","arcosh","artanh","arcth","ln","log","sign","rem",
            "sec","csc","arcsec","arcsc","sech","csch","arsech","arcsch"};

        static char[] Constants = { 'x', 'p', 'e' };
        static char[] Operators = { '+', '-', '/', '*', '^' };

        public static Exception UnknownSymbolException = new Exception("There is unkown symbol in line.");
        public static Exception LineIsEmptyException = new Exception("Input line is empty");
        public static Exception UnknownOperatorException = new Exception("The line contains unknown operator");
        private static short GetPriority(string InputStatement)//returnes priority of function
        {

            foreach (string Statement in Statements)
            {
                if (InputStatement == Statement) return 5;
            }
            if (InputStatement == "^") return 4;
            else if ((InputStatement == "*") || (InputStatement == "/")) return 3;
            else if ((InputStatement == "+") || (InputStatement == "-")) return 2;
            else if (InputStatement == "(") return 1;
            else
            {
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
                throw LineIsEmptyException;
            }
            List<string> OutputExpression = new List<string>();

            if (InputExpression[0] == '-')
            {
                InputExpression.Remove(0, 1);
                InputExpression.Insert(0, "~");
            }
            InputExpression.Replace("(-", "(~");

            Stack<string> stack = new Stack<string>();

            string buffer = string.Empty;

            for (int j = 0; j < InputExpression.Length; j++)
            {
                if ((char.IsDigit(InputExpression[j])) || (EqualsToConstant(InputExpression[j])))//в буфере число?
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
                    else if (GetPriority(stack.Peek()) < GetPriority(InputExpression[j].ToString())) //сравнение приоритетов операций
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
                    throw UnknownSymbolException;
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
            double s = 0;
            double a, b;
            foreach (string piece in PostfixLine)
            {
                if (string.IsNullOrEmpty(piece)) continue;

                else
                {
                    if (char.IsDigit(piece[0]))
                    {
                        stack.Push(Convert.ToDouble(piece));
                    }
                    else if ((char.IsLetter(piece[0])) && (!EqualsToConstant(piece[0])))
                    {
                        double X = Convert.ToDouble(stack.Pop());
                        switch (piece)
                        {
                            case "sqrt":
                                stack.Push(Math.Sqrt(X));
                                break;
                            case "abs":
                                stack.Push(Math.Abs(X));
                                break;
                            case "sin":
                                stack.Push(Math.Sin(X));
                                break;
                            case "sinh":
                                stack.Push(Math.Sinh(X));
                                break;
                            case "cosh":
                                stack.Push(Math.Cosh(X));
                                break;
                            case "cos":
                                stack.Push(Math.Cos(X));
                                break;
                            case "cth":
                                stack.Push(1 / Math.Tanh(X));
                                break;
                            case "tanh":
                                stack.Push(Math.Tanh(X));
                                break;
                            case "tan":
                                stack.Push(Math.Tan(X));
                                break;
                            case "cot":
                                stack.Push(1 / Math.Tan(X));
                                break;
                            case "аbs":
                                stack.Push(Math.Abs(X));
                                break;
                            case "ln":
                                stack.Push(Math.Log(X));
                                break;
                            case "arsinh":
                                stack.Push(Math.Log(X + Math.Sqrt(X * X + 1)));
                                break;
                            case "arcsin":
                                stack.Push(Math.Asin(X));
                                break;
                            case "arcosh":
                                stack.Push(Math.Log(X + Math.Sqrt(X + 1) * Math.Sqrt(X - 1)));
                                break;
                            case "arccos":
                                stack.Push(Math.Acos(X));
                                break;
                            case "artanh":
                                stack.Push(Math.Log((X + 1) / (X - 1)) / 2);
                                break;
                            case "arccot":
                                stack.Push(Math.Atan(-1 * X) + Math.PI / 2);
                                break;
                            case "arcth":
                                stack.Push(Math.Log((X + 1) / (1 - X)) / 2);
                                break;
                            case "arctan":
                                stack.Push(Math.Atan(X));
                                break;
                            case "log":
                                stack.Push(Math.Log(Convert.ToDouble(stack.Pop()), X));
                                break;
                            case "sign":
                                stack.Push(Math.Sign(X));
                                break;
                            case "rem":
                                stack.Push(Convert.ToDouble(stack.Pop()) % X);
                                break;
                            case "sec":
                                stack.Push(1 / Math.Cos(X));
                                break;
                            case "csc":
                                stack.Push(1 / Math.Sin(X));
                                break;
                            case "arcsec":
                                stack.Push(Math.Acos(1 / X));
                                break;
                            case "arccsc":
                                stack.Push(Math.Asin(1 / X));
                                break;
                            case "sech":
                                stack.Push(1 / Math.Cosh(X));
                                break;
                            case "csch":
                                stack.Push(1 / Math.Sinh(X));
                                break;
                            case "arsech":
                                stack.Push(Math.Log(1 / X + Math.Sqrt(1 / X + 1) * Math.Sqrt(1 / X - 1)));
                                break;
                            case "arcsch":
                                stack.Push(Math.Log(1 / X + Math.Sqrt(1 / X * X + 1)));
                                break;
                            default:
                                throw UnknownOperatorException;

                        }
                    }
                    else
                    {
                        if (piece[0] == 'e') stack.Push(Math.E);
                        else if (piece[0] == 'p') stack.Push(Math.PI);
                        else if (piece[0] == 'x') stack.Push(point);
                        else
                        {
                            b = Convert.ToDouble(stack.Pop());
                            a = Convert.ToDouble(stack.Pop());
                            switch (piece[0])
                            {
                                ///binary operations
                                case '+':
                                    stack.Push(a + b);
                                    break;
                                case '-':
                                    stack.Push(a - b);
                                    break;
                                case '*':
                                    stack.Push(a * b);
                                    break;
                                case '/':
                                    stack.Push(a / b);
                                    s = b;
                                    break;
                                case '^':
                                    if (b > 1)
                                    {
                                        if ((a < 0) || (a > 0))
                                        {
                                            stack.Push(Math.Pow(a, b));
                                        }
                                        else
                                        {
                                            stack.Push(0);
                                        }
                                    }
                                    else if ((b < 1) && (b > 0))
                                    {
                                        if (a > 0)
                                        {
                                            stack.Push(Math.Pow(a, b));
                                        }
                                        else if (a < 0)
                                        {
                                            if (s % 2 == 1)
                                            {
                                                stack.Push(-Math.Pow(Math.Abs(a), b));
                                            }
                                            else stack.Push(Math.Pow(a, b));
                                        }
                                        else
                                        {
                                            stack.Push(0);
                                        }
                                    }
                                    else if (b == 1)
                                    {
                                        stack.Push(a);
                                    }
                                    else if (b == 0)
                                    {
                                        if (a == 0)
                                        {
                                            stack.Push(0);
                                        }
                                        else stack.Push(1);
                                    }
                                    break;
                                case ';':
                                    stack.Push(b);
                                    stack.Push(a);
                                    break;
                                ///unary operations
                                case '~':
                                    stack.Push(a);
                                    stack.Push(-1 * Convert.ToDouble(b));
                                    break;
                            }
                        }
                    }
                }
            }
            return stack.Pop();
        }
    }
}

