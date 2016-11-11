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

        static char[] Constants = {'x','p','e' };

        private static short GetPriority(string InputStatement)//returnes priority of function
        {

            foreach(string Statement in Statements)
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
            foreach(char constant in Constants)
            {
                if (symbol == constant)
                {
                    return true;
                }
            }
            return false;
        }

        public static List<string> ConvertToPostfix(string InputExpression)
        {
            List<string> OutputExpression = new List<string>();

                if (InputExpression[0] == '-')
                {
                    InputExpression.Remove(0, 1);
                    InputExpression.Insert(0, "~");
                }
                InputExpression.Replace("(-", "(~");

                Stack<string> stack = new Stack<string>();

            string buffer = string.Empty;

            for (int j=0; j < InputExpression.Length; j++)
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
                    while (char.IsLetter(InputExpression[j]))
                    {
                      buffer += InputExpression[j];
                        j++;
                    }
                    j--;
                    stack.Push(buffer);
                    buffer = string.Empty;
                }
                else if (InputExpression[j] == ';')
                {
                    continue;

                }
                else
                {
                    if (stack.Count() == 0)
                    {
                        stack.Push(InputExpression[j].ToString());
                    }
                    else if (GetPriority(stack.Peek()) < GetPriority(InputExpression[j].ToString())) //сравнение приоритетов операций
                    {
                        stack.Push(InputExpression[j].ToString());
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
                    else
                    {
                        while ((stack.Count!=0)&&(GetPriority(stack.Peek()) >= GetPriority(InputExpression[j].ToString())))

                        {
                            OutputExpression.Add(stack.Pop());
                        }
                        stack.Push(InputExpression[j].ToString());
                    }


                }

            }

            while (stack.Count() != 0)
            {
                OutputExpression.Add(stack.Pop());
            }
            return OutputExpression;
        }
    }
}

