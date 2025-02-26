using _devHelp;
using _tempName.Exceptions;
using _tempName.Tests.Fixtures;

namespace _tempName.Tests;


public class IRemoteTests(LinkToFixture linkToFixture, RemoteFixture remoteFixture) : 
    IClassFixture<LinkToFixture>,
    IClassFixture<RemoteFixture>
{
    private readonly ArrangeLinkTo<ReadonlyDummyStruct> _arrangeLink = linkToFixture.ArrangeLinkTo;
    private readonly ArrangeRemote<DummyRemote, ReadonlyDummyStruct> _arrangeRemote =
    remoteFixture.ArrangeRemote<DummyRemote, ReadonlyDummyStruct>; 

    [Fact]
    public void Get_ReturnsCorrectValue_WhenActiveLink_IsProvided()
    {
        // Arrange
        var dummy = new ReadonlyDummyStruct(1, "test");
        var remote = _arrangeRemote(); 
        var linkTo = _arrangeLink(LinkState.Active, in dummy);

        // Act
        var intActual = remote.Get<DummyGetInt, int>(linkTo);
        var stringActual = remote.Get<DummyGetString, string>(linkTo);

        // Assert
        Assert.Equal(expected: 1, actual: intActual);
        Assert.Equal(expected: "test", actual: stringActual);
    }

    [Fact]
    public void Get_ThrowsInactiveLinkException_WhenInactiveLink_IsProvided()
    {
        // Arrange
        var remote = _arrangeRemote();
        var linkTo = _arrangeLink(LinkState.Inactive);

        // Act
        void act() => remote.Get<DummyGetInt, int>(linkTo);

        // Assert
        var exception = Assert.Throws<InactiveLinkException>(act);

    }
}