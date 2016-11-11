using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BL.Tests
{
    [TestFixture]
    public class MAtest
    {
        [Test]
        public void ConvertToPostfix_Test()
        {
            const string InputExpression = "2*sin(x)/3+5*x-1";
            //const string InputExpression = "2-1";

            string EXPECTED_RESULT = "2xsin*3/5x*+1-";
           // string EXPECTED_RESULT = "21-";

            Assert.That(string.Concat<string>(Converter.ConvertToPostfix(InputExpression)), Is.EqualTo(EXPECTED_RESULT));
        }
        [Test]
        public void GetValue_Test()
        {
            List<string> InputExpression = new List<string> {"4","p","sin","*","2","/","3","-"};
            const double point = 0;

            double EXPECTED_RESULT = 4*Math.Sin(Math.PI)/2-3;
            Assert.That(Converter.GetValue(InputExpression, point), Is.EqualTo(EXPECTED_RESULT));

        }

    }
}
