using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoelectric.Electrons
{
    class Ball
    {
        private static double charge;
        private double diameter;
        private double xPos, yPos, xVel;
        private static Random myRand = new Random();
   
        public static double Charge
        {
            get
            {
                return charge;
            }
            set
            {
                charge = value;
            }
        }
    
        public double Diameter
        {
            get
            {
                return diameter;
            }
            set
            {
                diameter = value;
            }
        }

        public double XPos
        {
            get
            {
                return xPos;
            }

            set
            {
                xPos = value;
            }
        }

        public double YPos
        {
            get
            {
                return yPos;
            }

            set
            {
                yPos = value;
            }
        }
     
        public double XVel
        {
            get
            {
                return xVel;
            }

            set
            {
                xVel = value;
            }
        }

        public Ball(double diameter, double startXPos, double startYPos, double startXVel, double startYVel)
        {
            Diameter = diameter;
            XPos = startXPos;
            YPos = startYPos;
            XVel = startXVel;

        }

        public void Move()
        {
            double newXPos;
            newXPos = XPos + XVel;
            XVel += charge;
            XPos = newXPos;
        }
    }
}

