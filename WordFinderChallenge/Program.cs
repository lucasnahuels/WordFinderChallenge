using System;
using System.Collections.Generic;
using System.Linq;

var matrix = new[]
{
    "ABCD",
    "EFGH",
    "IJKL",
    "MNOP"
};

var wordStream = new[]
{
    "ABCD",
    "EFGH",
    "IJKL",
    "MNOP",
    "PONM",
    "MOP",
    "ABC",
    "FGH",
    "BFJN"
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
        var wordCount = new Dictionary<string, int>();
        var uniqueWords = new HashSet<string>(wordStream);

        foreach (var word in uniqueWords)
        {
            if (SearchWord(word))
            {
                wordCount[word] = 1;
            }
        }

        return wordCount.OrderByDescending(x => x.Value).Take(10).Select(x => x.Key);
    }

    private bool SearchWord(string word)
    {
        int len = word.Length;

        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j <= _cols - len; j++)
            {
                if (_matrix[i].Substring(j, len) == word)
                {
                    return true;
                }
            }
        }

        for (int i = 0; i <= _rows - len; i++)
        {
            for (int j = 0; j < _cols; j++)
            {
                bool found = true;
                for (int k = 0; k < len; k++)
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
