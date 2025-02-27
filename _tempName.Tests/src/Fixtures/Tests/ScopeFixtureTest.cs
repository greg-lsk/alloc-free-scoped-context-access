using _devHelp;

namespace _tempName.Tests.Fixtures.Tests;


public class ScopeFixtureTest(ScopeFixture scopeFixture) : IClassFixture<ScopeFixture>
{
    private readonly ScopeFixture _scopeFixture = scopeFixture;


    [Fact]
    public void LinkEscapesTargetsScope_IsCorrupted()
    {
        // Arrange

        // Act
        _scopeFixture.LinkEscapesTargetsScope
        (
            out var linkTo, 
            createTargetInScope: () => new DummyStruct(1, "test")
        );

        // Assert
        Assert.NotEqual(1, linkTo.Target.IntValue);
        Assert.False(linkTo.Target.StringValue == "test");
    }

    [Fact]
    public void LinkEscapesTargetsScope_IsActive()
    {
        // Arrange

        // Act
        _scopeFixture.LinkEscapesTargetsScope
        (
            out var linkTo, 
            createTargetInScope: () => new DummyStruct(1, "test")
        );

        // Assert
        Assert.True(linkTo.IsActive());
    }        
}