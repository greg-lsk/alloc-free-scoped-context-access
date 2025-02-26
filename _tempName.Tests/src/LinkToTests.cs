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
    public void Target_HasCorruptData_WhenLinkEscapes_ScopeOfTarget()
    {
        // Arrange

        // Act
        var linkTo = ScopeHelper.DummyEscapedLink<ReadonlyDummyStruct>(createInScope:() => new(42, "Hellow"));
        var intValue = linkTo.Target.IntValue;
        var stringValue = linkTo.Target.StringValue;

        // Assert
        Assert.False(intValue == 42 && stringValue == "Hellow");
    }

    [Fact]
    public void IsActive_ReturnsTrue_WhenLinkEscapes_ScopeOfTarget()
    {
        // Arrange

        // Act
        var linkTo = ScopeHelper.DummyEscapedLink<ReadonlyDummyStruct>(() => new(42, "Hellow"));

        // Assert
        Assert.True(linkTo.IsActive());
    }

    [Fact]
    public void IsActive_ReturnsTrue_When_UsingDefault_AsCreateArgument()
    {
        // Arrange
        var linkTo = LinkTo<int>.Create(default);

        // Act

        // Assert
        Assert.True(linkTo.IsActive());
    }
    
    [Fact]
    public void IsActive_ReturnsFalse_When_UsedUnassigned()
    {
        // Arrange
        LinkTo<int> linkTo;

        // Act

        // Assert
        Assert.False(linkTo.IsActive());
    }

    [Fact]
    public void IsActive_ReturnsFalse_When_UsingDefaultCtor()
    {
        // Arrange
        var linkTo = new LinkTo<int>();

        // Act

        // Assert
        Assert.False(linkTo.IsActive());
    }

    [Fact]
    public void IsActive_ReturnsFalse_When_Initialized_UsingDefaultKeyword()
    {
        // Arrange
        LinkTo<int> linkTo = default;

        // Act

        // Assert
        Assert.False(linkTo.IsActive());
    }
}