using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementations
{
    internal class Calculator
    {

        /// <summary>
        /// Devuelve la velocidad para cubrir la distancia en el tiempo especificado
        /// </summary>
        /// <param name="aLenght"></param>
        /// <param name="aTime"></param>
        /// <returns></returns>
        internal static double CalculateSpeed(double aLenght, double aTime)
        {
            double iRetVal = aLenght / aTime;
            return iRetVal;
        }


        /// <summary>
        /// Devuelve el tiempo que se necesita para recorrer la distancia con la velocidad especificada
        /// </summary>
        /// <param name="aLenght"></param>
        /// <param name="aSpeed"></param>
        /// <returns></returns>
        internal static double CalculateTime(double aLenght, double aSpeed)
        {
            double iRetVal = aLenght / aSpeed;
            return iRetVal;
        }

    }
}
