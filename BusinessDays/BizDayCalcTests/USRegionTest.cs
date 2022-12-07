using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace BizDayCalcTests
{
    public class USRegionTest : IClassFixture<USRegionFixture>
    {
        private readonly USRegionFixture fixture;
        private readonly ITestOutputHelper output;

        public USRegionTest(USRegionFixture fixture, ITestOutputHelper output)
        {
            this.fixture = fixture;
            this.output = output;
        }

        [Theory]
        [InlineData("2022.12.7")]
        [InlineData("2022.12.8")]
        [Trait("Holiday", "true")] //dotnet test --filter Holiday=true
        public void TestNonUSHolidays(string date)
        {
            output.WriteLine($"Testing TestNonUsHolidays {date}");
            Assert.True(fixture.calculator.IsBusinessDay(DateTime.Parse(date)));
        }
    }
}