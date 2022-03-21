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
            throw new NotImplementedException();
        }

        int ITimeProvider.getMinute()
        {
            throw new NotImplementedException();
        }

        int ITimeProvider.getSecond()
        {
            throw new NotImplementedException();
        }
    }
}
