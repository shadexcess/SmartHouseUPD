using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    internal class LivingRoom : Room
    {
        private TV tv;
        public LivingRoom()
        {
            tv = new TV();
        }
        public void OnTv()
        {
            tv.OnTV();
        }
        public void OffTV()
        {
            tv.OffTV();
        }
        public void IsOnTV(Service service)
        {
            tv.IsOnTV(service);
        }

    }
}