using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizDayCal
{
    public interface IRule
    {
        bool CheckIsBusinessDay(DateTime date);
    }
}