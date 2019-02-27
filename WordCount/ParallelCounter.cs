using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace WordCount
{
    public class ParallelCounter : IWordCounter
    {
        public IDictionary<string, int> CountWords(string path)
        {
            ParallelOptions options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 2,
            };

            var response = new ConcurrentDictionary<string, int>();
            Parallel.ForEach(File.ReadLines(path), options, line =>
            {
                var words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    response.AddOrUpdate(word, 1, (key, value) => value + 1);
                }
            });

            return response;
        }
    }
}
