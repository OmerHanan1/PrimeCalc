using System;

namespace PrimeCalc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static Boolean isPrime(int number) 
        {
            if (number == 0 || number == 1)
                return false;
            int sqrt = (int)Math.Sqrt(number);
            for (int i = 2; i <= sqrt; i++) 
            {
                if (number % i == 0) { return false; }
            }
            return true;
        }
    }
}
