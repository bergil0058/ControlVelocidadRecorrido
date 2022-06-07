using Abstractions;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementations.Solvers
{
    public class GenericSolver : ISolver
    {


        /// <summary>
        /// Obtiene el caballo que más tarde llegará a la meta.
        /// Calcula la velocidad máxima que debe llevar Ana para no alcanzar a ese caballo.
        /// </summary>
        /// <param name="aTest"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<double> GetMaximumConstantSpeedAsync(Test aTest)
        {
            double iRetVal = await Task.Run(() => GetMaximumConstantSpeed(aTest));

            return iRetVal;
        }




        #region Private


        /// <summary>
        /// Algoritmo para calcular la máxima velocidad constante a la que puede salir un caballo desde el origen
        /// para llegar a destino en el mínimo tiempo posible sin adelantar a ningún otro caballo
        /// </summary>
        /// <param name="aTest"></param>
        /// <returns></returns>
        private double GetMaximumConstantSpeed(Test aTest)
        {
            double iTimeToCompleteJourney = GetMaximumTimeToCompleteJourney(aTest.LenghtKms, aTest.Horses);

            double iRetVal = Calculator.CalculateSpeed(aTest.LenghtKms, iTimeToCompleteJourney);
            return iRetVal;
        }



        /// <summary>
        /// Devuelve el caballo que más tarde llegará a la meta
        /// </summary>
        /// <param name="aLenght"></param>
        /// <param name="aHorses"></param>
        /// <returns></returns>
        private double GetMaximumTimeToCompleteJourney(double aLenght, IEnumerable<Horse> aHorses)
        {
            double iRetVal = aHorses
                .Max(x => Calculator.CalculateTime(aLenght - x.Position, x.Speed));
            return iRetVal;
        }

        #endregion Private
    }
}
