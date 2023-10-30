using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoelectric
{
    class Quanta
    {
        private double wavelength;
        public double Wavelength
        {
            get { return wavelength; }
            set { wavelength = value; }
        }


        private double lightIntensity;
        public double LightIntensity
        {
            get { return lightIntensity; }
            set { lightIntensity = value; }
        }
    }
}
