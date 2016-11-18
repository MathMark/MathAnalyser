using System.Collections.Generic;
using NUnit.Framework;

namespace BL.Tests
{
    [TestFixture]
    public class MAtest
    {
        [Test]
        public void ConvertToPostfix_Test()
        {
            //const string InputExpression = "2*sin(x)/3+5*x-1";
           const string InputExpression = "-sin(-x)";

            //string EXPECTED_RESULT = "2xsin*3/5x*+1-";
           string EXPECTED_RESULT = "x~sin~";

            Assert.That(string.Concat<string>(Converter.ConvertToPostfix(InputExpression)), Is.EqualTo(EXPECTED_RESULT));
        }
        [Test]
        public void GetValue_Test()
        {
            //List<string> InputExpression = new List<string> {"4","p","sin","*","2","/","3","-"};
            List<string> InputExpression = new List<string> { "2", "x", "^"};
            const double point = 3;

            //double EXPECTED_RESULT = 4*Math.Sin(Math.PI)/2-3;
            double EXPECTED_RESULT = 8;
            Assert.That(Converter.GetValue(InputExpression, point), Is.EqualTo(EXPECTED_RESULT));

        }
        //[Test]
        //public void ConvertToPostfix_CheckTheLineIsEmptyException()
        //{
        //    string InputExpression = string.Empty;
        //    string EXPECTED_MESSAGE = "Input line is empty";
        //    try
        //    {
        //        Converter.ConvertToPostfix(InputExpression);
        //        Assert.Fail("The exception must have been thrown");
        //    }
        //    catch(Exception exception)
        //    {
        //        Assert.AreEqual(EXPECTED_MESSAGE, exception.Message);
        //    }
        //}
        

    }
}
