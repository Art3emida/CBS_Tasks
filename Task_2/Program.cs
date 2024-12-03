using System.Collections.Generic;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 1, 2, 3, 4, 4, 56 };

            var result = MakeOutput(input);

            foreach (int i in result) 
            { 
                Console.Write(i + " ");
            }
        }

        static int[] MakeOutput(int[] input)
        {
            if (input.Length == 0)
            {
                return new int[0];
            }

            var hashSet = new HashSet<int>();

            foreach (int item in input)
            {
                hashSet.Add(item);
            }

            int[] result = new int[hashSet.Count];
            int i = 0;

            foreach (int num in hashSet)
            {
                result[i] = num;
                i++;
            }

            return result;
        }

        static int[] MakeOutputAlt(int[] input)
        {
            int? previous = null;
            var list = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                int num = input[i];

                if (num == previous)
                {
                    continue;
                }
                else
                {
                    previous = num;
                    list.Add(num);
                }
            }

            int[] result = new int[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                result[i] = list[i];
            }

            return result;
        }
    }
}
