using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabClassLibrary
{
    public interface IChargeControl
    {
        bool Connected { get; set; }

        public void StartCharge();

        public void StopCharge();

        public bool IsConnected();


    }
}
