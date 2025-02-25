namespace _tempName.Tests;

public class LinkToTests
{
    [Fact]
    public void Test1()
    {
        // Arrange
        var linkTo = LinkTo<int>.Create(42);

        // Act
        var resultRef = linkTo.Target;

        // Assert
        Assert.True(resultRef == 42); 
    }
}