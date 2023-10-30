using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoelectric
{
    class VoltageMeasurement
    {
        private double voltageValue;
        public double VoltageValue
        {
            get { return voltageValue; }
            set { voltageValue = value; }
        }


        Maths mathEquations = new Maths();
        Quanta quantaVals = new Quanta();


      /*  public double StoppingPotential(double maxKineticEnergy)
        {
            Metal metalSelected = new Metal();
            

            double kineticEnergy = mathEquations.KineticEnergy(quantaVals.LightIntensity,   );

        }
        */

    }
}
