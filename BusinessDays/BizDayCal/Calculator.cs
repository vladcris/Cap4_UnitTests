using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizDayCal
{
    public class Calculator
    {
        private List<IRule> rules = new List<IRule>();
        
        public void AddRule(IRule rule)
        {
            rules.Add(rule);
        }

        public bool IsBusinessDay(DateTime date)
        {
            foreach (var rule in rules)
            {
                if(!rule.CheckIsBusinessDay(date))
                    return false;
            }
            return true;
        }
    }
}