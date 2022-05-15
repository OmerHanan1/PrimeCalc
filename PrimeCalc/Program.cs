using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace PrimeCalc
{
    internal class Program
    {
        /// <summary>
        /// Main function.
        /// </summary>
        /// <param name="args">
        /// (1) LowerBound
        /// (2) UpperBound
        /// (3) NumberOfThreads to use
        /// </param>
        static void Main(string[] args)
        {
            // arrange
            int lowerbound = int.Parse(args[0]);
            int upperbound = int.Parse(args[1]);
            int numOfThreads = int.Parse(args[2]);
            List<Thread> threads = new List<Thread>();

            // assert
            for (int i = 0; i < numOfThreads; i++) 
            {
                int range = (int) (upperbound-lowerbound) / numOfThreads;
                int startAt = i * range;
                int endAt = (i+1) * range;

                Thread thread = 
                    new Thread(() => DoWork(startAt, endAt));
                threads.Add(thread);

                // act
                thread.Start();
            }

            foreach (Thread thread in threads) 
            {
                thread.Join();
            }
        }

        /// <summary>
        /// Thread work. given two int's, printing all PrimeNumbers between them.
        /// </summary>
        /// <param name="lowerBound">
        /// Use in range, lowerBound
        /// </param>
        /// <param name="upperBound">
        /// Use in range, UpperBound
        /// </param>
        public static void DoWork(int lowerBound, int upperBound) 
        {
            for (int i = lowerBound; i < upperBound; i++)
                if (isPrime(i))
                    Console.WriteLine(i);
        }

        /// <summary>
        /// Check if a given number is a Prime number.
        /// Iterate from 2 to sqrt(number) checking modular arithmetic.
        /// </summary>
        /// <param name="number">
        /// Int number
        /// </param>
        /// <returns>
        /// true if Prime number, false if Composite number.
        /// </returns>
        public static Boolean isPrime(int number) 
        {
            if (number == 0 || number == 1)
                return false;
            int sqrt = (int)Math.Sqrt(number);
            for (int i = 2; i <= sqrt; i++) 
                if (number % i == 0) { return false; }
            return true;
        }
    }
}
