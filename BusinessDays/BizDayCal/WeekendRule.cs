using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizDayCal
{
    public class WeekendRule : IRule
    {
        public bool CheckIsBusinessDay(DateTime date)
        {
            return 
                date.DayOfWeek != DayOfWeek.Saturday &&
                date.DayOfWeek != DayOfWeek.Sunday;
        }
    }
}