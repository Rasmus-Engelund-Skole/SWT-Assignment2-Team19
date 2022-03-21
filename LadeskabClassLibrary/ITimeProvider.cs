using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabClassLibrary
{
    public interface ITimeProvider
    {
        public int getHour();

        public int getMinute();

        public int getSecond();



    }
}
