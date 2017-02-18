using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Postfix
    {
        string postfixExpression;
        char argument;
        public char Argument
        {
            get
            {
                return argument;
            }
            set
            {
                argument = value;
            }
        }
        public Postfix(string postfixExpression,char argument)
        {
            this.postfixExpression = postfixExpression;
            this.argument = argument;
        }
        public override string ToString()
        {
            return postfixExpression.ToString();
        }
    }
}
