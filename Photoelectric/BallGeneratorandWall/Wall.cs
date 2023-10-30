using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoelectric
{
    class Wall
    {
        internal readonly double Dampening;
        private double xPos, yPos, length;
        private bool isHorizontal;

        public double XPos { get => xPos; set => xPos = value; }
        public double YPos { get => yPos; set => yPos = value; }
        public double Length { get => length; set => length = value; }
        public bool IsHorizontal { get => isHorizontal; set => isHorizontal = value; }
    }
}
