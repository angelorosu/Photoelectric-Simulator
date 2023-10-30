using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoelectric
{
   public class BallGenerator
    {
        private int diameter;
        private double xPos, yPos, xVel, yVel;
        private byte r, g, b;
        private static double gravity;
        private static Random myRnd = new Random();

        
        public int Diameter { get => diameter; set => diameter = value; }
        public double XPos { get => xPos; set => xPos = value; }
        public double YPos { get => yPos; set => yPos = value; }
        public double XVel { get => xVel; set => xVel = value; }
        public double YVel { get => yVel; set => yVel = value; }
        public byte R { get => r; set => r = value; }
        public byte G { get => g; set => g = value; }
        public byte B { get => b; set => b = value; }
        public static double Gravity { get => gravity; set => gravity = value; }



        public BallGenerator(double startXPos, double startYPos, double startXVel, double startYVel)

        {

            XVel = startXVel;
            YVel = startYVel;
            YPos = startXPos;
            XPos = startXPos;

        }
        public BallGenerator(double height, double width, double Diameter)
        {


            Diameter = myRnd.Next(5, 50);
            XPos = myRnd.NextDouble() * (width - Diameter);
            YPos = myRnd.NextDouble() * (height - Diameter);

            R = (Byte)myRnd.Next(255);
            G = (Byte)myRnd.Next(255);
            B = (Byte)myRnd.Next(255);

            XVel = (myRnd.NextDouble() * 10) - 5;
            YVel = (myRnd.NextDouble() * 10) - 5;
        }
    }
}
