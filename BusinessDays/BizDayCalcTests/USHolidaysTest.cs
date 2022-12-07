using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BizDayCal;

namespace BizDayCalcTests
{
    public class USHolidaysTest
    {
        public static IEnumerable<object[]> USHolidays 
        { 
            get
            {
                yield return new object[] { new DateTime(2022, 1, 1)};
                yield return new object[] { new DateTime(2022, 7, 4)};
                yield return new object[] { new DateTime(2022, 12, 24)};
                yield return new object[] { new DateTime(2022, 12, 25)};
            }
        }

        private Calculator calculator;

        public USHolidaysTest()
        {
            this.calculator = new Calculator();
            calculator.AddRule(new USHolidaysRule());
            System.Console.WriteLine("ctor initialized");
        }

        [Theory]
        [MemberData(nameof(USHolidays))]
        public void TestUSHolidays(DateTime date)
        {
            Assert.False(calculator.IsBusinessDay(date));
        }

        [Theory]
        [InlineData("2022.12.7")]
        [InlineData("2022.12.8")]
        public void TestNonUSHolidays(string date)
        {
            Assert.True(calculator.IsBusinessDay(DateTime.Parse(date)));
        }
    }
}