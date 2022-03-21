using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabClassLibrary
{
    public class TimeProvider : ITimeProvider
    {
        int ITimeProvider.getHour()
        {
            return DateTime.Now.Hour;
        }

        int ITimeProvider.getMinute()
        {
            return DateTime.Now.Minute;
        }

        int ITimeProvider.getSecond()
        {
            return DateTime.Now.Second;
        }
    }
}
