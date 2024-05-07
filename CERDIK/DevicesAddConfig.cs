//Class Device

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CERDIK
{
    public class DevicesAddConfig
    {

        public string namaDevice { get; set; }
        public string Os { get; set; }
        public string merekDevice { get; set; }

        public DevicesAddConfig() { }
        public DevicesAddConfig(string nama, string jenis, string merekdevice)
        {
            this.namaDevice = nama;
            this.Os = jenis;
            this.merekDevice = merekdevice;
        }
    }

}

