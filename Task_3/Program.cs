namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your number:");
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine($"The Iterative approach result: {FibonacciIterative(num)}");
            Console.WriteLine($"The Recursive approach result: {FibonacciRecursive(num)}");
        }

        // Time = O(n) Space = O(1)
        public static int FibonacciIterative(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }

            int previous1 = 0;
            int previous2 = 1;
            int current = 0;

            for (int i = 2; i <= n; i++)
            {
                current = previous1 + previous2;
                previous1 = previous2;
                previous2 = current;
            }

            return current;

            //int[] lastTwo = [0, 1];
            //int counter = 2;

            //while (counter <= n) 
            //{
            //    int next = lastTwo[0] + lastTwo[1];
            //    lastTwo[0] = lastTwo[1];
            //    lastTwo[1] = next;
            //    counter++;
            //}

            //return lastTwo[1];
        }

        // Time = O(n^2) Space = O(n)
        public static int FibonacciRecursive(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }

            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }
    }
}
