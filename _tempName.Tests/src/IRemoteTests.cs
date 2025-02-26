using _devHelp;
using _tempName.Exceptions;
using _tempName.Tests.Fixtures;

namespace _tempName.Tests;


public class IRemoteTests(RemoteFixture remoteFixture) : IClassFixture<RemoteFixture>
{
    private readonly IRemote<ReadonlyDummyStruct> _remote = remoteFixture.Target;
    private readonly ArrangeLinkTo<ReadonlyDummyStruct> _arrangeLink = RemoteFixture.ArrangeLink;

    [Fact]
    public void Get_ReturnsCorrectValue_WhenActiveLink_IsProvided()
    {
        // Arrange
        var dummy = new ReadonlyDummyStruct(1, "test");
        var linkTo = _arrangeLink(LinkState.Active, in dummy);

        // Act
        var intActual = _remote.Get<DummyGetInt, int>(linkTo);
        var stringActual = _remote.Get<DummyGetString, string>(linkTo);
        
        // Assert
        Assert.Equal(expected: 1, actual: intActual);
        Assert.Equal(expected: "test", actual: stringActual);
    }

    [Fact]
    public void Get_ThrowsInactiveLinkException_WhenInactiveLink_IsProvided()
    {
        // Arrange
        var linkTo = _arrangeLink(LinkState.Inactive);

        // Act
        void act() => _remote.Get<DummyGetInt, int>(linkTo);

        // Assert
        var exception = Assert.Throws<InactiveLinkException>(act);

    }
}