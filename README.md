# Word Counter
Sample repository for writing a word counter 

**Notes:**
- Visual Studio 2017 solution
- .netcore 2.1 console project
- Look at ``Program -> Main`` for the code that displays top ten words
- Two implementations of a *WordCounter* have been added:
    * SimpleCounter
    * ParallelCounter
- Some basic unit tests added to ```WordCounterTests```
- Unit tests test that the results are being calculated correctly
- A unit test has also been added to ensure that the counter which uses ``ConcurrentDictionary`` & ``Parallel.ForEach`` is more efficient than the counter that doesn't utilises them. This is noticable more when loading larger files.  For my test, I copied the pasted the text from the sample file multiple times and saved it as new file.


**Assumptions:**
- Space (" ") used as a seperator for words but could be a semi-colons or commas as well
- Upper case and lower case words are being treated differently. So, "the" will be counted seperately to "The" and "THE".
- This can be overcome by using this constructor of ```Dictionary``` object instead which does a case insensitive match: [MSDN](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.-ctor?redirectedfrom=MSDN&view=netframework-4.7.2#System_Collections_Generic_Dictionary_2__ctor_System_Collections_Generic_IEqualityComparer__0__)
- When reading really large files, we should definitely be utilising something like ``Parallel.ForEach`` or `async`
- I used two small text files for the tests:
    * lotr.txt - straight from the link in the email (~1MB)
    * lotr_large.txt - larger version of the text from the link in the email (~8MB)
