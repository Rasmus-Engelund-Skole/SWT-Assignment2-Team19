using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabClassLibrary
{

    public interface ILogfile
    {
        public void DoorUnlockedLog(int id);

        public void DoorLockedLog(int id);
    }
}
