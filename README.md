This code creates a 8x8 matrix and a word stream with some repeated words. 
It then creates a WordFinder instance and uses it to find the top 10 most repeated words in the matrix. Finally, it prints the result to the console.

The code uses strategies to speed up the search process:

1- Parallel processing to search for words in the matrix. Using multiple CPU cores to search for words in the matrix concurrently.
https://learn.microsoft.com/es-es/dotnet/standard/parallel-programming/how-to-write-a-simple-parallel-foreach-loop 

2- Use of ConcurrentDictionary: https://resulhsn.medium.com/understanding-of-concurrentdictionary-in-net-3434105ba371 

3- Early exits: I exit early from the iteration process if the word is not found in the matrix, instead of checking all possible positions.

Version: .NET 8.0
