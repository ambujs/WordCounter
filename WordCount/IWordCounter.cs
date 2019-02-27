using System.Collections.Generic;

namespace WordCount
{
    public interface IWordCounter
    {
        IDictionary<string, int> CountWords(string path);
    }
}
