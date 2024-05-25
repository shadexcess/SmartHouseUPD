using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    internal class BathRoom : Room
    {
        private bool isWaterOn;
        public void WaterOn()
        {
            isWaterOn = true;
        }
        public void WaterOff()
        {
            isWaterOn = false;
        }
        public void UseService(Service service)
        {
            isWaterOn = service.IsOnWater;
        }
        public void IsOnWater(Service service)
        {
            service.IsWaterOn();
        }
    }
}