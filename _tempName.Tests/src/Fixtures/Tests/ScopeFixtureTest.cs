using _devHelp;

namespace _tempName.Tests.Fixtures.Tests;


public class ScopeFixtureTest(ScopeFixture scopeFixture) : IClassFixture<ScopeFixture>
{
    private readonly ScopeFixture _scopeFixture = scopeFixture;


    [Fact]
    public void MockEscapedLink_IsCorrupted()
    {
        // Arrange

        // Act
        _scopeFixture.MockEscapedLink(out LinkTo<DummyStruct> linkTo, 
                                      createTargetInScope: () => new DummyStruct(1, "test"));

        // Assert
        Assert.NotEqual(1, linkTo.Target.IntValue);
        Assert.NotEqual("test", linkTo.Target.StringValue);
    }

    [Fact]
    public void MockEscapedLink_IsActive()
    {
        // Arrange

        // Act
        _scopeFixture.MockEscapedLink(out LinkTo<DummyStruct> linkTo, 
                                      createTargetInScope: () => new DummyStruct(1, "test"));

        // Assert
        Assert.True(linkTo.IsActive());
    }        
}