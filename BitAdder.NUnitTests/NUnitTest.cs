using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using NUnit.Framework;
using BitAdder;

namespace BitAdder.NUnitTests
{
    [TestFixture]
    public class NUnitTest
    {
        [Test, TestCaseSource(typeof(MyDataClass), "TestCases")]
        public void SummTwoNumbersParts_Summ255And853_Int863(int number1, int number2, int startPosition, int endPosition, int result)
        {
            Assert.That(Adder.insertIntoPosition(number1, number2, startPosition, endPosition), Is.EqualTo(result));
        }

        [Test]
        public void SummTwoNumbersParts_Summ106And106_Int106()
        {
            Assert.That(Adder.insertIntoPosition(106, 106, 2, 5), Is.EqualTo(106));
        }
       
        [Test, TestCaseSource(typeof(MyDataClass), "ExceptionTestCases")]
        public void SummTwoNumbersParts_WrongPositionValues_ArgumentException(int number1, int number2, int startPosition, int endPosition)
        {
            Assert.That(() => { Adder.insertIntoPosition( number1, number2, startPosition, endPosition); } , Throws.TypeOf<ArgumentException>());
        }
           
    }
    public class MyDataClass
    {
        public static IEnumerable ExceptionTestCases
        {
            get
            {
                yield return new TestCaseData(255, 523, 1, 0);
                yield return new TestCaseData(213, 453, -4, -2);
                yield return new TestCaseData(25, 52, 1, 35);
                yield return new TestCaseData(255, 523, 37, 65);
                yield return new TestCaseData(255, 523, -1, 3);

            }
        }

        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(255, 853, 5, 9, 863);
                yield return new TestCaseData(106, 106, 2, 5, 106);
                yield return new TestCaseData(0, 7, 2, 2, 4);
                yield return new TestCaseData(-7, 2, 1, 1, -5);

            }
        }
    }
}
