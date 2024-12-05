using WordFinderChallenge;

var matrix = new[]
{
    "ABCDEDAB",
    "EFGJVSAN",
    "IJKLGVAB",
    "MNSOFTWA",
    "BTASKSEF",
    "BTADEVKF",
    "BWBESSEF",
    "BWBVSSEF",
};

var wordStream = new[]
{
    "ABCD",
    "ABCD",
    "ABCD",
    "DEV",
    "SOFT",
    "TASK",
    "SOFTWARE",
    "BACKEND"
};

var wordFinder = new WordFinder(matrix);
var result = wordFinder.Find(wordStream);

foreach (var word in result)
{
    Console.WriteLine(word);
}