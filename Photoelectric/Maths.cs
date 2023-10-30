using Photoelectric.DatabaseTestingç;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoelectric
{
    public class Maths
    {
        public static double lightSpeed = 3e8;
        public static double planksConstant = 6.626e-34;
        public static double electronMass = 9.11e-31;

        public static double FrequencyConverter(double photonFrequency)
        {

            double wavelength;

            wavelength = lightSpeed / (photonFrequency);

            return wavelength;
        }

        public static double WavelengthConverter(double wavelength)
        {

            double photonFrequency;

            photonFrequency = lightSpeed / (wavelength / 1e9);

            return photonFrequency;
        }

        public static double JouletoElectroVoltConverter(double jouleValue)
        {
            double ElectronVoltConverted = jouleValue * (6.242e+18);
            return ElectronVoltConverted;
        }

        public static double ElectroVolttoJouleConverter(double EvValue)
        {
            double JouleConverted = EvValue / (6.242e+18);
            return JouleConverted;

        }

        public static double KineticEnergy(double photonFrequency, double workFunction)
        {
            double kineticEnergy = (6.626e-34 * photonFrequency) - ElectroVolttoJouleConverter(workFunction);
            return kineticEnergy;
        }

        public static string ScientificNotation(double largeNumber)
        {
            string scientificNumber = largeNumber.ToString("E2");

            return scientificNumber;
        }

        public static double GetMaxElectonSpeed(double frequency, double workFunction)
        {
            double hfminusThetha = (planksConstant * frequency) - ElectroVolttoJouleConverter(workFunction);
            double velocitySquared = (hfminusThetha * 2) / electronMass;
            double velocity = Math.Sqrt(velocitySquared);
            return velocity;


        }

        public static double XvelocityofElectron(double wavelength)
        {
            double vmax = 0;

            double convertedWavelength = wavelength * (1e-9);
            double frequency = WavelengthConverter(convertedWavelength);
            double tresholdWavelength = ThresholdWavelength();


            if (MetalWorkFunction.currentMetal == conductiveMetal.aluminium)
            {
                if (tresholdWavelength > wavelength)
                {
                    double range = tresholdWavelength - 1;
                    double maxVelocityAllowed = 30;
                    double step = range / maxVelocityAllowed;
                    return maxVelocityAllowed - (wavelength / step);
                }
            }
            else if (MetalWorkFunction.currentMetal == conductiveMetal.iron)
            {
                if (tresholdWavelength > wavelength)
                {

                    double range = tresholdWavelength - 1;
                    double maxVelocityAllowed = 30;
                    double step = range / maxVelocityAllowed;
                    return maxVelocityAllowed - (wavelength / step);
                }

            }
            else if (MetalWorkFunction.currentMetal == conductiveMetal.sodium)
            {
                if (tresholdWavelength > wavelength)
                {

                    double range = tresholdWavelength - 1;
                    double maxVelocityAllowed = 30;
                    double step = range / maxVelocityAllowed;
                    return maxVelocityAllowed - (wavelength / step);
                }
            }
            else if (MetalWorkFunction.currentMetal == conductiveMetal.zinc)
            {
                if (tresholdWavelength > wavelength)
                {

                    double range = tresholdWavelength - 1;
                    double maxVelocityAllowed = 30;
                    double step = range / maxVelocityAllowed;
                    return maxVelocityAllowed - (wavelength / step);
                }
            }

            return vmax;
        }

        public static double ThresholdWavelength()
        {
            double tresholdWavelength = 0;
            if (MetalWorkFunction.currentMetal == conductiveMetal.iron)
            {
                tresholdWavelength = (((lightSpeed * planksConstant) / ElectroVolttoJouleConverter(MetalWorkFunction.ironWorkfunction))) / 1e-9;
            }
            else if (MetalWorkFunction.currentMetal == conductiveMetal.aluminium)
            {
                tresholdWavelength = (((lightSpeed * planksConstant) / ElectroVolttoJouleConverter(MetalWorkFunction.aluminiumWorkFunction))) / 1e-9;
            }
            else if (MetalWorkFunction.currentMetal == conductiveMetal.sodium)
            {
                tresholdWavelength = (((lightSpeed * planksConstant) / ElectroVolttoJouleConverter(MetalWorkFunction.sodiumWorkFunction))) / 1e-9;
            }
            else if (MetalWorkFunction.currentMetal == conductiveMetal.zinc)
            {
                tresholdWavelength = (((lightSpeed * planksConstant) / ElectroVolttoJouleConverter(MetalWorkFunction.zincWorkFunction) / 1e-9));
            }

            return tresholdWavelength;
        }

        public static double DisplayKineticEnergy(double frequency)
        {

            if (MetalWorkFunction.currentMetal == conductiveMetal.iron)
            {
                return KineticEnergy(frequency, MetalWorkFunction.ironWorkfunction);

            }
            else if (MetalWorkFunction.currentMetal == conductiveMetal.aluminium)
            {
                return KineticEnergy(frequency, MetalWorkFunction.aluminiumWorkFunction);

            }
            else if (MetalWorkFunction.currentMetal == conductiveMetal.sodium)
            {
                return KineticEnergy(frequency, MetalWorkFunction.sodiumWorkFunction);

            }
            else if (MetalWorkFunction.currentMetal == conductiveMetal.zinc)
            {
                return KineticEnergy(frequency, MetalWorkFunction.zincWorkFunction);

            }
            return 0;
        }

        public static double DisplayElectronSpeed(double frequency)
        {
            double frequencyF = WavelengthConverter(frequency);
            double tresholdWavelength = ThresholdWavelength();

         

                if (MetalWorkFunction.currentMetal == conductiveMetal.iron)
                {
                    return GetMaxElectonSpeed(frequency, MetalWorkFunction.ironWorkfunction);

                }
                else if (MetalWorkFunction.currentMetal == conductiveMetal.aluminium)
                {
                    return GetMaxElectonSpeed(frequency, MetalWorkFunction.aluminiumWorkFunction);

                }
                else if (MetalWorkFunction.currentMetal == conductiveMetal.sodium)
                {
                    return GetMaxElectonSpeed(frequency, MetalWorkFunction.sodiumWorkFunction);

                }
                else if (MetalWorkFunction.currentMetal == conductiveMetal.zinc)
                {
                    return GetMaxElectonSpeed(frequency, MetalWorkFunction.zincWorkFunction);
                
                }
            return 0;

        
        }



    }
}
