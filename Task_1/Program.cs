using System.Collections;
using System.Runtime.ConstrainedExecution;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "The “C# Professional” course includes the topics I discuss in my CLR via C# book and teaches how the CLR works thereby showing you how to develop applications and reusable components for the .NET Framework.";
            Console.WriteLine(input);
            Console.WriteLine();

            var inputToHashSet = new HashSet<string>();
            string[] splittedInputsForHashSet = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in splittedInputsForHashSet)
            {
                inputToHashSet.Add(item);               
            }

            var sortedHashSet = inputToHashSet.OrderBy(item => item.Length).GroupBy(item => item.Length);

            foreach (var item in sortedHashSet)
            {
                Console.WriteLine($"Words of length: {item.Key}, Count: {item.Count()}");

                foreach (string word in item)
                    Console.WriteLine(word);
            }
        }      
    }
}
