using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.EntityContracts
{
    /// <summary>
    /// PreDefine dDateTime Ranges
    /// </summary>
    public enum PreDefinedDateTimeRanges
    {
        Unknown,
        Custom,
        LastTenYears,
        LastFiveYears,
        LastYear,
        LastSixMonths,
        LastThreeMonths,
        LastMonth,
        LastWeek,
        Yesterday,
        //LastHour,
        ThisYear,
        ThisMonth,
        ThisWeek,
        Today,
        //ThisHour,
        //NextHour,
        Tomorrow,
        NextWeek,
        NextMonth,
        NextThreeMonths,
        NextSixMonths,
        NextYear,
        NextFiveYears,
        NextTenYears,
    }
}

