using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoelectric.Electrons
{
    public class Wall
    {
        private int xPos, yPos, length;

        public int XPos
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
        public int YPos
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
        public int Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
            }
        }

        public Wall(int newXPos, int newYPos, int newLength)
        {
            XPos = newXPos;
            YPos = newYPos;
            Length = newLength;

        }
    }
}
