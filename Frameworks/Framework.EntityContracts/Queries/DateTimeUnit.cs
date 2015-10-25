using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.EntityContracts.Queries
{
    /// <summary>
    /// unit types of datetime
    /// </summary>
    public enum DateTimeUnit
    {
        Tick,
        Year,
        QuarterOfYear,// every 3 months
        Month,
        SemiMonth,
        BiWeek,
        Week,
        Day,
        Hour,
        Minute,
        Second,
        MilliSecond,
        Negate,
        None,
    }
}