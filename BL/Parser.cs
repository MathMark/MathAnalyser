using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;


namespace BL
{
    /*This class is in charge of converting a function written in Infix notation (It is characterized 
     * by the placement of operators between operands, e.g. "2+2") to function written in Postfix notation 
     * (Reverse Polish Notation). It is needed to easily read the function and calculate
     values in a particular point.*/

    public class Parser 
    {
        static string[] Statements = {"sqrt","abs","sin","cos","tan","cot","asin","acos","atan","acot","sinh","cosh",
            "tanh","cth","arsinh","arcosh","artanh","arcth","ln","log","sign","rem",
            "sec","csc","asec","acsc","sech","csch","arsech","arcsch","lg","trun"};

        static char[] Constants = { 'x', 'p', 'e', '\u03c0' };
        static char[] Operators = { '~','+', '-', '/', '*', '^' , '\u00d7' };


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

        public static string ConvertToPostfix(string InputExpression)
        {
            if(InputExpression==string.Empty)
            {
                throw new Exception("Input line is empty");
            }

            if (InputExpression[0] == '-')
            {
                InputExpression=InputExpression.Remove(0, 1);
                InputExpression=InputExpression.Insert(0, "~");
            }
            InputExpression=InputExpression.Replace("(-", "(~");

            string OutputExpression = string.Empty;

            Stack<string> stack = new Stack<string>();

            string buffer = string.Empty;

            for (int j = 0; j < InputExpression.Length; j++)
            {
                if ((char.IsDigit(InputExpression[j])) || (EqualsToConstant(InputExpression[j])))
                {
                    buffer += InputExpression[j];
                    if ((j == InputExpression.Length - 1) || (!char.IsDigit(InputExpression[j + 1])))
                    {
                        OutputExpression += buffer+" ";
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
                        OutputExpression += stack.Pop() + " ";
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
                            OutputExpression += stack.Pop() + " ";
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
                OutputExpression += stack.Pop() + " ";
            }
            return OutputExpression;
        }

        public static double GetValue(string PostfixExpression, double point)
        {
            //Prepare the stack by creating a variable of Stack type
            Stack<double> stack = new Stack<double>();
            //Prepare two operands
            double number1, number2;
            //Remove spaces from the input string
            string[] Statements = PostfixExpression.Split(new char[] {}, StringSplitOptions.RemoveEmptyEntries);
            //scaning the input line by each separate token
            foreach (string token in Statements)
            {
                //if current token is digit
                if (char.IsDigit(token[0]))
                {
                    //push the digit onto the stack
                    stack.Push(Convert.ToDouble(token));
                }
                //if current token is letter or equals to x, e or pi
                else if ((char.IsLetter(token[0])) && (!EqualsToConstant(token[0])))
                {
                    //take one number from the stack
                        double variable = Convert.ToDouble(stack.Pop());
                        switch (token)
                        {
                            case "trun":
                                stack.Push(MathFunctions.Trun(variable));
                                break;
                            case "sqrt":
                                stack.Push(Math.Sqrt(variable));
                                break;
                            case "abs":
                                stack.Push(Math.Abs(variable));
                                break;
                            case "sin":
                                stack.Push(MathFunctions.Sin(variable));
                                break;
                            case "sinh":
                                stack.Push(MathFunctions.Sinh(variable));
                                break;
                            case "cosh":
                                stack.Push(Math.Cosh(variable));
                                break;
                            case "cos":
                                stack.Push(MathFunctions.Cos(variable));
                                break;
                            case "cth":
                                stack.Push(MathFunctions.Cth(variable));
                                break;
                            case "tanh":
                                stack.Push(Math.Tanh(variable));
                                break;
                            case "tan":
                                stack.Push(MathFunctions.Tan(variable));
                                break;
                            case "cot":
                            stack.Push(MathFunctions.Cotan(variable));
                            break;
                        case "lg":
                            stack.Push(Math.Log10(variable));
                            break;
                            case "аbs"://if current operator equals to "abs"
                            //calculate absolute value from prepared number
                            stack.Push(Math.Abs(variable));
                                break;
                            case "ln":
                                stack.Push(Math.Log(variable));
                                break;
                            case "arsinh":
                                stack.Push(MathFunctions.Arsinh(variable));
                                break;
                            case "asin":
                                stack.Push(Math.Asin(variable));
                                break;
                            case "arcosh":
                                stack.Push(MathFunctions.Arcosh(variable));
                                break;
                            case "acos":
                                stack.Push(Math.Acos(variable));
                                break;
                            case "artanh":
                                stack.Push(MathFunctions.Artanh(variable));
                                break;
                            case "acot":
                                stack.Push(MathFunctions.Acot(variable));
                                break;
                            case "arcth":
                                stack.Push(MathFunctions.Arcth(variable));
                                break;
                            case "atan":
                                stack.Push(Math.Atan(variable));
                                break;
                            case "log":
                                stack.Push(Math.Log(Convert.ToDouble(stack.Pop()), variable));
                                break;
                            case "sign":
                                stack.Push(MathFunctions.Sign(variable));
                                break;
                            case "rem":
                            stack.Push(MathFunctions.Rem(stack.Pop(),variable));
                            break;
                            case "sec":
                                stack.Push(MathFunctions.Sec(variable));
                                break;
                            case "csc":
                                stack.Push(MathFunctions.Csc(variable));
                                break;
                            case "asec":
                                stack.Push(MathFunctions.Arcsec(variable));
                                break;
                            case "acsc":
                                stack.Push(MathFunctions.Acsc(variable));
                                break;
                            case "sech":
                                stack.Push(MathFunctions.Sech(variable));
                                break;
                            case "csch":
                                stack.Push(MathFunctions.Csch(variable));
                                break;
                            case "arsech":
                                stack.Push(MathFunctions.Arsech(variable));
                                break;
                            case "arcsch":
                                stack.Push(MathFunctions.Arcsch(variable));
                                break;
                            //if current operator doesn't equal to any of reserved operators
                            default:
                                throw new Exception(String.Format("The line contains unknown operator: {0}",token));

                        }
                    }
                else
                {
                    switch (token[0])
                        {

                            case 'e':
                                stack.Push(Math.E);
                                break;
                        case '\u03c0':
                            goto case 'p';
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
                        case '\u00d7':
                            goto case '*';
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
            if (stack.Count != 1)
            {
                throw new Exception("Wrong line");
            }
            return Math.Round(stack.Pop(),2);
        }
        public static PointF[] GetValues(string PostfixExpression,int scale,int from,int to)
        {
            List<PointF> coordinates = new List<PointF>();
            double argument;
            double value;
            int MinValue = -10000000;
            int MaxValue = 10000000;
            StreamWriter w = new StreamWriter("D:\\o.txt");
            for (float x = from; x < to; x += 0.1f)
            {
                argument = Math.Round(x, 1) / scale;
                value=(-scale * GetValue(PostfixExpression, argument));
                value = (float)Math.Round(value, 6);
               // w.WriteLine($"{argument} - {value}");
                if (Double.IsInfinity(value))
                {
                    coordinates.Add(new PointF(x, (float)value));
                }
                else
                {
                    if (value.ToString()=="NaN"||(value < MaxValue && value > MinValue))
                    {
                        w.WriteLine($"{argument} - {value}");
                        coordinates.Add(new PointF(x, (float)value));
                    }
                }
                
            }
            w.Close();
            return coordinates.ToArray();
        }
        //public static float[,] GetDataSet(string RPNfunction,int from,int to,float increment)
        //{
        //    int dimention_0 = (int)((to - from) / increment);
        //    const int dimention_1 = 2;

        //    float[,] DataSet = new float[dimention_0, dimention_1];

        //    int counter = 0;
        //    for(float i=from;i<to;i+=increment,counter++)
        //    {
        //        DataSet[counter, 0] = i;
        //        DataSet[counter, 1] = GetValue(RPNfunction, i);
        //    }
        //    return DataSet;
        //}
        public static float GetDerivativeInPoint(string RPNfunction, float point)
        {
            float dx = 0.001f;

            float result=(float)((GetValue(RPNfunction,point+dx)- GetValue(RPNfunction, point))/dx);
            return result;
           // return (float)Math.Round(result + 0.001, 3);
        }
       public static PointF[] FindDerivativeValues(string RPNfunction,int scale,int from,int to)
        {
            List<PointF> coordinates = new List<PointF>();
            float value;
            int MinValue = -10000000;
            int MaxValue = 10000000;
            float argument;
            StreamWriter w = new StreamWriter("D:\\derivatives.txt");
            for (float x = from; x <to; x += 0.1f)
            {
                //calculate values
                argument = (float)Math.Round(x, 1) / scale;
                value = (-scale * GetDerivativeInPoint(RPNfunction, argument));
                value = (float)Math.Round(value, 2);
                //filer the NaN values
                
                if (Single.IsInfinity(value))
                {
                    coordinates.Add(new PointF((float)x, value));
                }
                if (value.ToString()=="NaN"|| (value < MaxValue && value > MinValue))
                {
                    coordinates.Add(new PointF((float)(x),value));
                }
                w.WriteLine($"{argument} - {value}");
                
            }
            w.Close();
            PointF[] result=coordinates.ToArray();
            return result;
        }
        public static PointF[]FindExtrermums(string RPNfunction,int scale,PointF[]derivativeValues)
        {
            List<PointF> extremumPointsList = new List<PointF>();
            float EPS = 0.1f;
            foreach(PointF point in derivativeValues)
            {
                if(Math.Abs(point.Y)<EPS)
                {
                    extremumPointsList.Add(new PointF(point.X, (float)(-scale*GetValue(RPNfunction, point.X/scale))));
                }
            }
            PointF[] result = extremumPointsList.ToArray();
            return result;
        }
    }
}


