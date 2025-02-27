using _devHelp;

namespace _tempName.Tests.Fixtures.Tests;

public class RemoteFixtureTest
{
    [Fact]
    public void ArrangRemote_ReturnsTheCorrectType()
    {
        // Arrange
        var fixture = new RemoteFixture();

        // Act
        var result = fixture.ArrangeRemote<DummyRemote, DummyStruct>();

        // Assert
        Assert.IsType<DummyRemote>(result);
        Assert.IsAssignableFrom<IRemote<DummyStruct>>(result);
    }    
}