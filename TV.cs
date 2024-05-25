using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    internal class TV
    {
        private bool isOn;
        private int channels;
        public void OnTV()
        {
            isOn = true;
        }
        public void OffTV()
        {
            isOn = false;
        }
        public void IsOnTV(Service service)
        {
            service.IsOnTV();
        }
    }
}