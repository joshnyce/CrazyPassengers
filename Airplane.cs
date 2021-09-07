using System;
using System.Collections.Generic;

namespace CrazyPassengerProblem
{
    class Airplane
    {
        SortedSet<int> AvailableSeats;
        int[] Seats;

        public Airplane(int seats)
        {
            Seats = new int[seats];
        }

        public bool seatLastPassengerSuccessfully()
        {
            // prepopulate the seat array w/empty seat value
            // populate available seats
            for (int x = 0; x < Seats.Length; x++)
            {
                Seats[x] = -1;
                AvailableSeats.Add(x);
            }

            // put the first passenger in a random seat
            var r = new Random();
            var firstRandomSeat = r.Next(0, 99); //for ints
            Seats[firstRandomSeat] = 0;
            AvailableSeats.Remove(firstRandomSeat);

            bool seatedCorrectly = true;

            for (int x = 1; x < Seats.Length - 1; x++)
                if (Seats[x] == -1)
                {
                    // seat is empty, passenger x takes assigned seat
                    Seats[x] = x;

                    // remove the value from available seats, not the index
                    AvailableSeats.Remove(x);
                    seatedCorrectly = true;
                }
                else
                {
                    // put passenger x in Random available seat
                    var rand = r.Next(0, AvailableSeats.Count - 1); //for ints

                    AvailableSeats.TryGetValue(rand, out var randomSeatNumber);
                    AvailableSeats.Remove(randomSeatNumber);

                    Seats[randomSeatNumber] = x;
                    seatedCorrectly = false;
                }

            return seatedCorrectly;
        }
    }
}