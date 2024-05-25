using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    internal class Computer
    {
        private bool isOn;
        public void OnPC()
        {
            isOn = true;
        }
        public void OffPC()
        {
            isOn = false;
        }
        public void UseService(Service service)
        {
            isOn = service.IsOnPC;
        }
        public void IsOnPC(Service service)
        {
            service.IsOnComputer();
        }
    }
}