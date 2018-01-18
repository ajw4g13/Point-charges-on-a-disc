using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Content
{
    class Disc
    {
        public List<Charge> allCharges;
        public double electrostaticPotentialEnergy;
        Random random = new Random();

        /// <summary>
        /// Creates a disc containing N charges, with an associated electrostatic energy.
        /// </summary>
        /// <param name="numberOfPointCharges"></param>
        /// <param name="discRadius"></param>
        public Disc(int numberOfPointCharges)
        {
            allCharges = new List<Charge>();

            for (int i = 0; i < numberOfPointCharges; i++)
            {
                Charge charge = new Charge();
                allCharges.Add(charge);
            }

            electrostaticPotentialEnergy = GetEnergy();
        }

        /// <summary>
        /// Updates the position of a charge on the disc, and the disc's energy.
        /// </summary>
        /// <param name="delta"></param>
        /// <param name="phi"></param>
        /// <param name="chargeKey"></param>
        public void UpdateDisc(double[] newCoords, int chargeKey)
        {
            // Updates the selected charge's coordinates in the selected direction.
            allCharges[chargeKey].coordinates = newCoords;

            // Updates the disc's energy.
            electrostaticPotentialEnergy = GetEnergy();
        }
        

        /// <summary>
        /// Returns the electrostatic energy of a system.
        /// </summary>
        /// <returns></returns>
        double GetEnergy()
        {
            double totalEnergy = 0;

            // For each pair of charges...
            for (int i = 0; i < allCharges.Count; i++)
            {
                for (int j = i + 1; j < allCharges.Count; i++)
                {
                    // ... calculate energy (0.5 * q_i * q_2 / r_ij), and add to the running total of energy.
                    totalEnergy += allCharges[i].charge * allCharges[j].charge / GetRadiusBetweenTwoPositions(allCharges[i].coordinates, allCharges[j].coordinates);
                }
            }

            // The multiplication of 0.5 is outside the loop for efficiency.
            return 0.5 * totalEnergy;
        }

        public double CalculateEnergyChange(double[] newCoords, int chargeKey)
        {
            double energyChange = 0;
            
            for (int i = 0; i < allCharges.Count; i++)
            {
                if (i != chargeKey)
                {
                    energyChange += (allCharges[i].charge * allCharges[chargeKey].charge) * ((1/ GetRadiusBetweenTwoPositions(allCharges[i].coordinates, newCoords)) - (1 / GetRadiusBetweenTwoPositions(allCharges[i].coordinates, allCharges[chargeKey].coordinates)));
                }
            }
            return 0.5 * energyChange;
        }

        /// <summary>
        /// Returns the distance between the two inputted charges.
        /// </summary>
        /// <param name="chargeA"></param>
        /// <param name="chargeB"></param>
        /// <returns></returns>
        public double GetRadiusBetweenTwoPositions(double[] positionA, double[] positionB)
        {
            return Math.Sqrt((positionA[0] - positionB[0]) * (positionA[0] - positionB[0]) + (positionA[1] - positionB[1]) * (positionA[1] - positionB[1]));
        }

        /// <summary>
        /// For a particular charge on the disk, generate an angle in which it is possible for the charge to move by given distance delta.
        /// </summary>
        /// <param name="delta"></param>
        /// <param name="chargeKey"></param>
        /// <returns></returns>
        public double GenerateValidAngle(double delta, int chargeKey)
        {
            bool invalidMovement = true;
            double phi = 0;

            while (invalidMovement)
            {
                // Generates a random angle, phi, between 0 and 2pi. This is the direction in which the charge will move. The angle is created on axes perpendicular to the origonal radial coordinate, i.e. phi = pi/2 correponds to the direction parallel to the current radial coordinate.
                phi = random.NextDouble() * 2 * Math.PI;           

                // Before continuing, checks that the new coordinates lie inside the disc. If the charge's new radial coordinate is less than or equal to 1, the new coordinates are valid.
                if (allCharges[chargeKey].coordinates[0] + (delta * Math.Sin(phi)) <= 1.0)
                {
                    invalidMovement = false;
                }
            }
            return phi;
        }
    }
}
