using _devHelp;

namespace _tempName.Tests;

public class LinkToTests
{
    [Fact]
    public void Create_ReturnsCorrectLink()
    {
        // Arrange
        var linkTo = LinkTo<int>.Create(42);

        // Act

        // Assert
        Assert.Equal(expected: 42, actual: linkTo.Target); 
    }

    [Fact]
    public void Target_ReturnsRef()
    {
        // Arrange
        var linkTo = LinkTo<int>.Create(42);

        // Act
        linkTo.Target++;

        // Assert
        Assert.Equal(expected: 43, actual: linkTo.Target); 
    }

    [Fact]
    public void TargetIsSet_ReturnsFalse_When_UsedUnassigned()
    {
        // Arrange
        LinkTo<int> linkTo;

        // Act

        // Assert
        Assert.False(linkTo.IsActive()); 
    }  
    
    [Fact]
    public void TargetIsSet_ReturnsFalse_When_UsingDefaultCtor()
    {
        // Arrange
        var linkTo = new LinkTo<int>();

        // Act

        // Assert
        Assert.False(linkTo.IsActive()); 
    }

    [Fact]
    public void TargetIsSet_ReturnsFalse_When_Initialized_UsingDefaultKeyword()
    {
        // Arrange
        LinkTo<int> linkTo = default;

        // Act

        // Assert
        Assert.False(linkTo.IsActive()); 
    }

    [Fact]
    public void TargetIsSet_ReturnsTrue_When_UsingDefault_AsCreateArgument()
    {
        // Arrange
        var linkTo = LinkTo<int>.Create(default); ;

        // Act

        // Assert
        Assert.True(linkTo.IsActive()); 
    }

    [Fact]
    public void TargetIsSet_ReturnsTrue_WhenEscaping_ScopeOfTarget()
    {
        //Arrange

        //Act
        var linkTo = ScopeHelper.DummyEscapedLink<ReadonlyDummyStruct>( () => new(42, "Hellow") );

        //Assert
        Assert.True(linkTo.IsActive());
    }             
}