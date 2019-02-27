using System;
using System.Collections.Generic;
using System.IO;

namespace WordCount
{
    public class SimpleCounter : IWordCounter
    {
        private static readonly char[] separators = { ' ' };

        public IDictionary<string, int> CountWords(string path)
        {
            var response = new Dictionary<string, int>();

            using (var fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
            using (var streamReader = new StreamReader(fileStream))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in words)
                    {
                        if (response.ContainsKey(word))
                        {
                            response[word] = response[word] + 1;
                        }
                        else
                        {
                            response.Add(word, 1);
                        }
                    }
                }
            }

            return response;
        }
    }
}
