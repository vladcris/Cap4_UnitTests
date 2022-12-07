using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizDayCal
{
    public class USHolidaysRule : IRule
    {   
        public static readonly int[,] USHolidays = 
        {
            { 1, 1 },
            { 7, 4 },
            { 12, 24 },
            { 12, 25 }
        };
        public bool CheckIsBusinessDay(DateTime date)
        {
            for (int i = 0; i <= USHolidays.GetUpperBound(0); i++)
            {
                if( date.Month == USHolidays[i , 0] &&
                    date.Day == USHolidays[i, 1])
                {
                    return false;   
                }
            }

            return true;
        }
    }
}