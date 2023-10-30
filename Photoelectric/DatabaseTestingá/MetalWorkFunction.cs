using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoelectric.DatabaseTestingç
{
    public enum conductiveMetal
    {
        sodium = 1,
        zinc = 2,
        aluminium = 3,
        iron = 4

    }
    public class MetalWorkFunction
    {
        public static conductiveMetal currentMetal;
        public static double sodiumWorkFunction = 2.28;
        public static double zincWorkFunction = 4.43;
        public static double aluminiumWorkFunction = 4.08;
        public static double ironWorkfunction = 4.5;

    }



}
