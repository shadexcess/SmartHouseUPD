using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    internal class Bedroom : Room
    {
        private Computer computer;
        public Bedroom()
        {
            computer = new Computer();
        }
        public void OnPC()
        {
            computer.OnPC();
        }
        public void OffPC()
        {
            computer.OffPC();
        }
        public void IsOnPC(Service service)
        {
            computer.IsOnPC(service);
        }
    }
}