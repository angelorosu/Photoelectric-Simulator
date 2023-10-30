using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Photoelectric
{
    class Current
    {
        public static double planksConstant = 6.626e-34;
        public static double electronCharge = 1.602e-19;

        public static double GetCurrent(double power, double wavelength, double lightIntensity)
        {
            double tresholdWavelength = Maths.ThresholdWavelength();
            double currentReading = 0;
            
            if (tresholdWavelength > (wavelength/1e-9))
            {
                double photonFrequency = Maths.WavelengthConverter(wavelength);
                double noOfPhotons = power / (planksConstant * photonFrequency);
                double noOfElectronsEmmited = noOfPhotons * 1.00;
                 currentReading = electronCharge * noOfElectronsEmmited;
                return currentReading * (lightIntensity/100);
            }

            return currentReading;            

        }
       
        public static double GetCurrent2nd(double power, double wavelength)
        {
           double photonFrequency =  Maths.WavelengthConverter(wavelength);
           double noOfPhotons = power / (planksConstant * photonFrequency);
            Random probabilityGenerator = new Random();
            double probability = probabilityGenerator.NextDouble();
            while(probability > 0.8)
            {
            double noOfElectronsEmmited = probability * noOfPhotons;
            noOfElectronsEmmited = Math.Round(noOfElectronsEmmited);
            double currentReading = electronCharge * noOfElectronsEmmited;
            return currentReading;


            }


            return noOfPhotons * electronCharge;

           



        }
        

    }
}
 //https://www.askiitians.com/iit-jee-dual-nature-of-matter-and-x-rays/determine-the-photoelectric-current/
