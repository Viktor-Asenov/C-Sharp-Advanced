using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            HashSet<string> vipReservations = new HashSet<string>();
            HashSet<string> regularReservations = new HashSet<string>();

            while (true)
            {
                if (input == "PARTY")
                {
                    while (input != "END")
                    {
                        string actualReservationNumber = input;
                        char firstCharOfActual = actualReservationNumber[0];

                        if (char.IsDigit(firstCharOfActual))
                        {
                            if (vipReservations.Contains(actualReservationNumber))
                            {
                                vipReservations.Remove(actualReservationNumber);
                            }
                        }
                        else
                        {
                            if (regularReservations.Contains(actualReservationNumber))
                            {
                                regularReservations.Remove(actualReservationNumber);
                            }
                        }

                        input = Console.ReadLine();
                    }                    
                }
                else
                {
                    string reservationNumber = input;
                    char firstChar = reservationNumber[0];

                    if (char.IsDigit(firstChar))
                    {
                        vipReservations.Add(reservationNumber);
                    }
                    else
                    {
                        regularReservations.Add(reservationNumber);
                    }
                }                

                if (input == "END")
                {
                    break;
                }

                input = Console.ReadLine();
            }

            int wholeNotComming = vipReservations.Count + regularReservations.Count;
            Console.WriteLine(wholeNotComming);

            if (vipReservations.Count > 0 && regularReservations.Count > 0)
            {
                foreach (var reservation in vipReservations)
                {
                    Console.WriteLine(reservation);
                }

                foreach (var reservation in regularReservations)
                {
                    Console.WriteLine(reservation);
                }
            }
            else if (vipReservations.Count == 0 && regularReservations.Count > 0)
            {
                foreach (var reservation in regularReservations)
                {
                    Console.WriteLine(reservation);
                }
            }
            else if (vipReservations.Count > 0 && regularReservations.Count == 0)
            {
                foreach (var reservation in vipReservations)
                {
                    Console.WriteLine(reservation);
                }
            }
        }
    }
}
