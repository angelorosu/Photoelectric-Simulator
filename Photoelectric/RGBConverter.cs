﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoelectric
{
    //https://stackoverflow.com/questions/1472514/convert-light-frequency-to-rgb

    class RGBConverter
    {
        static private double Gamma = 0.80;
        static private double IntensityMax = 255;

        /** Taken from Earl F. Glynn's web page:
        * <a href="http://www.efg2.com/Lab/ScienceAndEngineering/Spectra.htm">Spectra Lab Report</a>
        * */
        public static byte[] waveLengthToRGB(double Wavelength)
        {
            double factor;
            double Red, Green, Blue;

            if ((Wavelength >= 380) && (Wavelength < 440))
            {
                Red = -(Wavelength - 440) / (440 - 380);
                Green = 0.0;
                Blue = 1.0;
            }
            else if ((Wavelength >= 440) && (Wavelength < 490))
            {
                Red = 0.0;
                Green = (Wavelength - 440) / (490 - 440);
                Blue = 1.0;
            }
            else if ((Wavelength >= 490) && (Wavelength < 510))
            {
                Red = 0.0;
                Green = 1.0;
                Blue = -(Wavelength - 510) / (510 - 490);
            }
            else if ((Wavelength >= 510) && (Wavelength < 580))
            {
                Red = (Wavelength - 510) / (580 - 510);
                Green = 1.0;
                Blue = 0.0;
            }
            else if ((Wavelength >= 580) && (Wavelength < 645))
            {
                Red = 1.0;
                Green = -(Wavelength - 645) / (645 - 580);
                Blue = 0.0;
            }
            else if ((Wavelength >= 645) && (Wavelength < 781))
            {
                Red = 1.0;
                Green = 0.0;
                Blue = 0.0;
            }
            else
            {
                Red = 0.0;
                Green = 0.0;
                Blue = 0.0;
            };

            // Let the intensity fall off near the vision limits

            if ((Wavelength >= 380) && (Wavelength < 420))
            {
                factor = 0.3 + 0.7 * (Wavelength - 380) / (420 - 380);
            }
            else if ((Wavelength >= 420) && (Wavelength < 701))
            {
                factor = 1.0;
            }
            else if ((Wavelength >= 701) && (Wavelength < 781))
            {
                factor = 0.3 + 0.7 * (780 - Wavelength) / (780 - 700);
            }
            else
            {
                factor = 0.0;
            };


            int[] rgb = new int[3];

            // Don't want 0^x = 1 for x <> 0
            rgb[0] = Red == 0.0 ? 0 : (int)Math.Round(IntensityMax * Math.Pow(Red * factor, Gamma));
            rgb[1] = Green == 0.0 ? 0 : (int)Math.Round(IntensityMax * Math.Pow(Green * factor, Gamma));
            rgb[2] = Blue == 0.0 ? 0 : (int)Math.Round(IntensityMax * Math.Pow(Blue * factor, Gamma));

            rgb[0] = Convert.ToByte(rgb[0]);


            byte[] byteRgb = new byte[3];
            byteRgb[0] = Convert.ToByte(rgb[0]);
            byteRgb[1] = Convert.ToByte(rgb[1]);
            byteRgb[2] = Convert.ToByte(rgb[2]);


            return byteRgb;
        }
    }
}