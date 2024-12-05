using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

var matrix = new[]
{
    "ABCDE",
    "EFGHF",
    "IJKLG",
    "MNOPH",
    "BWBCS"
};

var wordStream = new[]
{
    "ABCD",
    "ABCD",
    "ABCD",
    "EFGH",
    "IJKL",
    "MNOP",
    "PONM",
    //"MOP",
    //"ABC",
    //"FGH",
    //"BFJN",
    //"BFJN",
    //"GKO",
    //"WBC",
    //"HLP"
};

var wordFinder = new WordFinder(matrix);
var result = wordFinder.Find(wordStream);

foreach (var word in result)
{
    Console.WriteLine(word);
}


public class WordFinder
{
    private readonly string[] _matrix;
    private readonly int _rows;
    private readonly int _cols;

    public WordFinder(IEnumerable<string> matrix)
    {
        _matrix = matrix.ToArray();
        _rows = _matrix.Length;
        _cols = _matrix[0].Length;
    }

    public IEnumerable<string> Find(IEnumerable<string> wordStream)
    {
        var wordCount = new ConcurrentDictionary<string, int>();

        Parallel.ForEach(wordStream, word =>
        {
            if (SearchWord(word))
            {
                wordCount.AddOrUpdate(word, 1, (word, count) => count + 1);
            }
        });

        return wordCount
            .OrderByDescending(x => x.Value)
                .Take(10).Select(x => x.Key);
    }


    private bool SearchWord(string word)
    {
        int len = word.Length;

        // Search horizontally
        for (int i = 0; i < _rows; i++) //i iterates downwards
        {
            for (int j = 0; j <= _cols - len; j++) //j iterates to the right 
            {
                if (_matrix[i].Substring(j, len) == word)
                {
                    return true;
                }
            }
        }

        // Search vertically. Need to do an extra iteration because .Substring cannot be used
        for (int i = 0; i <= _rows - len; i++) //i sets the initial position
        {
            for (int j = 0; j < _cols; j++) //j iterates to the right
            {
                bool found = true;
                for (int k = 0; k < len; k++) //k iterates from i(initial position) downwards
                {
                    if (_matrix[i + k][j] != word[k])
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
