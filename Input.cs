using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Content
{
    class Input
    {
        bool invalidInput = true;
        string input;

        public Input()
        {

        }

        public int InputNumberOfPointCharges()
        {
            int numberOfPointCharges = 0;

            while (invalidInput)
            {
                Console.WriteLine("Type number of charges, N.");
                input = Console.ReadLine();
                invalidInput = Int32.TryParse(input, out numberOfPointCharges);
            }

            return numberOfPointCharges;
        }

        public double InputDelta()
        {
            double delta = 0;

            while (invalidInput)
            {
                Console.WriteLine("Type number of charges, N.");
                input = Console.ReadLine();
                invalidInput = Double.TryParse(input, out delta);
            }

            return delta;
        }
    }
}
