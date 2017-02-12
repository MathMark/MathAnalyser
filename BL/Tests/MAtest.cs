using System.Collections.Generic;
using NUnit.Framework;
using System;

namespace BL.Tests
{
    [TestFixture]
    public class MAtest
    {
        [Test]
        public void ConvertToPostfix_Test()
        {
            //arrange
            const string InputExpression = "2*sin(x)/3+5*x-1";
            string EXPECTED_RESULT = "2 x sin * 3 / 5 x * + 1 - ";
            //act
            string obtaintedResult = Parser.ConvertToPostfix(InputExpression);
            //assert
            Assert.That(obtaintedResult, Is.EqualTo(EXPECTED_RESULT));
        }
        [Test]
        public void ConvertToPostfix_IsEmptyLineTest()
        {
            try
            {
                var result = Parser.ConvertToPostfix(string.Empty);
                Assert.Fail();
            }
            catch(Exception exception)
            {
                Assert.That(exception.Message, Is.EqualTo("Input line is empty"));
            }
            
        }
        [Test]
        public void ConvertToPostfix_UnknownSymbolInLine()
        {
            string unknownSymbol = "$"; 
            var value = "sin(x)"+unknownSymbol;
            try
            {
                var result = Parser.ConvertToPostfix(value);
            }
            catch (Exception exception)
            {
                Assert.That(exception.Message, 
                    Is.EqualTo($"There is unkown symbol in line: {unknownSymbol}"));
            }
        }
        [Test]
        public void GetValue_Test()
        {
            string InputExpression = "4 p sin * 2 / 3 - ";
            const double point = 3;

            float EXPECTED_RESULT = (float)(4*Math.Sin(Math.PI)/2-3);
            Assert.That(Parser.GetValue(InputExpression, point), Is.EqualTo(EXPECTED_RESULT));

        }
        [Test]
        public void GetValue_UnknownOperatorInLineTest()
        {
            string unknownOperator = "C#";
            string value = "x "+unknownOperator;
            try
            {
                var result = Parser.GetValue(value,1);
                Assert.Fail();
            }
            catch (Exception exception)
            {
                Assert.That(exception.Message, 
                    Is.EqualTo($"The line contains unknown operator: {unknownOperator}"));
            }
        }
        [Test]
        public void GetValue_WrongLineTest()
        {
            string value =  "x x sin";
            try
            {
                var result = Parser.GetValue(value,1);
                Assert.Fail();
            }
            catch (Exception exception)
            {
                Assert.That(exception.Message, Is.EqualTo("Wrong line"));
            }
        }

    }
}
