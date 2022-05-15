using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace PrimeCalc
{
    internal class Program
    {
        //public static ConcurrentStack<int> thStack = new ConcurrentStack<int>();

        static void Main(string[] args)
        {
            int lowerbound = int.Parse(args[0]);
            int upperbound = int.Parse(args[1]);
            int numOfThreads = int.Parse(args[2]);
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < numOfThreads; i++) 
            {
                int range = (int) (upperbound-lowerbound) / numOfThreads;
                int startAt = i * range;
                int endAt = (i+1) * range;

                Thread thread = new Thread(() => 
                    DoWork(startAt, endAt)); // callBack
                threads.Add(thread);
                thread.Start();
            }

            foreach (Thread thread in threads) 
            {
                thread.Join();
            }

            //Console.WriteLine(thStack.Count);
        }

        public static void DoWork(int lowerBound, int upperBound) 
        {
            for (int i = lowerBound; i < upperBound; i++)
                if (isPrime(i))
                {
                    Console.WriteLine(i);
                    //thStack.Push(i);
                }
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
