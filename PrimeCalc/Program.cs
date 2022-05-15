using System;
using System.Threading;

namespace PrimeCalc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lowerbound = int.Parse(args[0]);
            int upperbound = int.Parse(args[1]);
            int numOfThreads = int.Parse(args[2]);
            Thread[] threads = new Thread[numOfThreads];
            for (int i = 0; i < numOfThreads; i++) 
            {
                int range = (int) (upperbound-lowerbound) / numOfThreads;
                int startAt = i * range;
                int endAt = (i+1) * range;

                Thread thread = new Thread(() => 
                    DoWork(startAt, endAt)); // callBack
                thread.Start();
                thread.Join();
            }
        }

        public static void DoWork(int lowerBound, int upperBound) 
        {
            for (int i = lowerBound; i < upperBound; i++)
                if (isPrime(i)) 
                    Console.WriteLine(i);
        }

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
