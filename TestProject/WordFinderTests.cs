using WordFinderChallenge;

public class WordFinderTests
{
    [Fact]
    public void FindWords_WordStreamContainsMatrixWords_ReturnsTop10MostRepeatedWords()
    {
        // Arrange
        var matrix = MockData.Matrix;
        var wordStream = MockData.WordStream;

        var wordFinder = new WordFinder(matrix);

        // Act
        var result = wordFinder.Find(wordStream);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(4, result.Count());
        Assert.Contains("ABCD", result);
        Assert.DoesNotContain("SOFTWARE", result);
        Assert.Equal("ABCD", result.First());
    }
}