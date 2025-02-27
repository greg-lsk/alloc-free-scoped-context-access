using _devHelp;
using _tempName.Tests.Fixtures;

namespace _tempName.Tests;

public class LinkToTests(ScopeFixture scopeFixture) : IClassFixture<ScopeFixture>
{
    private readonly MockEscapedLinkTo<DummyStruct> _mockEscape = scopeFixture.MockEscapedLink;


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
        _mockEscape(out LinkTo<DummyStruct> link,
                    createTargetInScope: () => new(42, "Hellow"));
        var intValue = link.Target.IntValue;
        var stringValue = link.Target.StringValue;

        // Assert
        Assert.NotEqual(42, intValue);
        Assert.False("Hellow" == stringValue);
    }

    [Fact]
    public void IsActive_ReturnsTrue_WhenLinkEscapes_ScopeOfTarget()
    {
        // Arrange

        // Act
        _mockEscape(out LinkTo<DummyStruct> link,
                    createTargetInScope: () => new(42, "Hellow"));

        // Assert
        Assert.True(link.IsActive());
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