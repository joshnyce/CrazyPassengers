using System;

namespace CrazyPassengerProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var iterations = Convert.ToInt32(args[0]);
            var seatsOnThePlane = Convert.ToInt32(args[1]);

            int successCounter = 0;
            for (int i = 0; i < iterations; i++)
            {
                var p = new Airplane(seatsOnThePlane);
                if (p.seatLastPassengerSuccessfully())
                    successCounter++;
            }

            // probability of last passenger successfully seated
            double probability = successCounter / (iterations * 1.0);
        }
    }
}