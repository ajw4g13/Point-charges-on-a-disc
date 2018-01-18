using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Content
{
    class Charge
    {
        // Coordinates are polar.
        public double[] coordinates = new double[2];
        public int charge = 1;
        Random random = new Random();


        /// <summary>
        /// Returns a charge with random coordinates.
        /// </summary>
        /// <param name="N"></param>
        /// <param name="radiusOfDisc"></param>
        public Charge()
        {
            coordinates = CreateRandomCoordinates();
        }

        /// <summary>
        /// Creates random polar coordinates for a point on the disc.
        /// </summary>
        /// <param name="radiusOfDisc"></param>
        double[] CreateRandomCoordinates()
        {
            double[] newCoordinates = new double[2];

            newCoordinates[0] = (random.NextDouble());
            newCoordinates[1] = (random.NextDouble() * 2 * Math.PI);

            return newCoordinates;
        }

        /// <summary>
        /// Takes in a charge's coordinates, outputs new coordinates which have been shifted by delta in some angle phi.
        /// </summary>
        /// <param name="inputCoordinates"></param>
        /// <parreturnsam name="allCharges"></param>
        /// <></returns>
        public double[] GetUpdatedCoordinates(double delta, double phi)
        {
            // Updates the radial coordinate by delta * sin(phi), and updates anglular coordinate by (delta/r)/cos(phi), where r is the original radial coordinate.
            return new double[2] { coordinates[0] + (delta * Math.Sin(phi)), coordinates[1] + ((delta / coordinates[0]) * Math.Cos(phi)) };
        }
    }
}
