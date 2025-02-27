using _devHelp;

namespace _tempName.Tests.Fixtures.Tests;


public class ScopeFixtureTest(ScopeFixture scopeFixture) : IClassFixture<ScopeFixture>
{
    private readonly MockEscapedLinkTo<DummyStruct> _mockEscape = scopeFixture.MockEscapedLink;


    [Fact]
    public void MockEscapedLink_IsCorrupted()
    {
        // Arrange

        // Act
        _mockEscape(out LinkTo<DummyStruct> linkTo, 
                    createTargetInScope: () => new DummyStruct(1, "test"));

        // Assert
        Assert.NotEqual(1, linkTo.Target.IntValue);
        Assert.False(linkTo.Target.StringValue == "test");
    }

    [Fact]
    public void MockEscapedLink_IsActive()
    {
        // Arrange

        // Act
        _mockEscape(out LinkTo<DummyStruct> linkTo, 
                                      createTargetInScope: () => new DummyStruct(1, "test"));

        // Assert
        Assert.True(linkTo.IsActive());
    }        
}