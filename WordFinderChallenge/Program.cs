using WordFinderChallenge;

var wordFinder = new WordFinder(MockData.Matrix);
var result = wordFinder.Find(MockData.WordStream);

foreach (var word in result)
{
    Console.WriteLine(word);
}