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
        public void ConvertToPostfixTest()
        {
            const string InputExpression = "2*sin(x)/3+5*x-1";
            //const string InputExpression = "2-1";

            string EXPECTED_RESULT = "2xsin*3/5x*+1-";
           // string EXPECTED_RESULT = "21-";

            Assert.That(string.Concat<string>(Converter.ConvertToPostfix(InputExpression)), Is.EqualTo(EXPECTED_RESULT));
        }

    }
}
