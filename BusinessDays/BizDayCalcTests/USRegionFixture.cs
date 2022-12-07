using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BizDayCal;

namespace BizDayCalcTests
{
    public class USRegionFixture
    {
        public Calculator calculator {get; private set;}

        public USRegionFixture()
        {
            calculator = new Calculator();
            calculator.AddRule(new WeekendRule());
            calculator.AddRule(new USHolidaysRule());
        }

        [CollectionDefinition("US region collection")]
        public class USRegionCollection : ICollectionFixture<USRegionFixture>
        {}

        // [Collection("US region collection")] 
        // public class USRegionTest 
        // {
        // private USRegionFixture fixture;
        // public USRegionTest(USRegionFixture fixture)
        // {
        // this.fixture = fixture;
        // }
        // ... 
        // }
    }
}