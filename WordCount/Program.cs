using System;
using System.Linq;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            const string sampleFilePath = @"D:\Projects\WordCount\lotr.txt";

            IWordCounter simpleWordCounter = new SimpleCounter();
            var wordCountResult = simpleWordCounter.CountWords(sampleFilePath);

            var ordered = wordCountResult.OrderByDescending(x => x.Value).Take(10);
            foreach (var keyValuePair in ordered)
            {
                Console.WriteLine($"Word: {keyValuePair.Key} | Count: {keyValuePair.Value}");
            }

            Console.ReadKey();
        }
    }
}
