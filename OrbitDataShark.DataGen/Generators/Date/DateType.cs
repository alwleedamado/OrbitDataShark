using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitDataShark.DataGen.Generators.Date
{
    public enum DateType
    {
        Between,
        BetweenDateOnly,
        BetweenOffset,
        BetweenTimeOnly,
        Future,
        FutureDateOnly,
        FutureOffset,
        Month,
        Past,
        PastDateOnly,
        PastOffset,
        Recent,
        RecentDateOnly,
        RecentOffset,
        RecentTimeOnly,
        Soon,
        SoonDateOnly,
        SoonOffset,
        SoonTimeOnly,
        TimeSpan,
        TimeZoneString,
        WeekDay
    }
}
