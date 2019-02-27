using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace WordCount.Tests
{
    public class WordCounterTests
    {
        private const string SampleFilePath = @"D:\Projects\WordCount\lotr.txt";
        private const string SampleLargeFilePath = @"D:\Projects\WordCount\lotr_large.txt";

        [Fact]
        public void ExpectSimpleCounterToCountCorrectly()
        {
            IWordCounter simpleWordCounter = new SimpleCounter();
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var wordCountResult = simpleWordCounter.CountWords(SampleFilePath);
            stopwatch.Stop();
            Debug.WriteLine($"SimpleCounter took {stopwatch.ElapsedMilliseconds} milliseconds to finish");

            var ordered = wordCountResult.OrderByDescending(x => x.Value);

            ordered.First().Key.Should().Be("the");
            ordered.First().Value.Should().Be(10695);
        }

        [Fact]
        public void ExpectParallelCounterToCountCorrectly()
        {
            IWordCounter parallelWordCounter = new ParallelCounter();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var wordCountResult = parallelWordCounter.CountWords(SampleFilePath);
            stopwatch.Stop();

            Debug.WriteLine($"ParallelCounter took {stopwatch.ElapsedMilliseconds} milliseconds to finish");
            var ordered = wordCountResult.OrderByDescending(x => x.Value);

            ordered.First().Key.Should().Be("the");
            ordered.First().Value.Should().Be(10695);
        }

        [Fact]
        public void ExpectSimpleToTakeLongerThanParallelCounterForLargeDataFile()
        {
            IWordCounter parallelWordCounter = new ParallelCounter();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            parallelWordCounter.CountWords(SampleLargeFilePath);
            stopwatch.Stop();

            var parallelElapsedSeconds = stopwatch.ElapsedMilliseconds;
            Debug.WriteLine($"ParallelCounter took {parallelElapsedSeconds} milliseconds to finish");

            IWordCounter simpleWordCounter = new SimpleCounter();
            
            stopwatch = new Stopwatch();
            stopwatch.Start();
            simpleWordCounter.CountWords(SampleLargeFilePath);
            stopwatch.Stop();
            var simpleElapsedSeconds = stopwatch.ElapsedMilliseconds;
            Debug.WriteLine($"SimpleCounter took {simpleElapsedSeconds} milliseconds to finish");

            simpleElapsedSeconds.Should().BeGreaterThan(parallelElapsedSeconds);
        }
    }
}
