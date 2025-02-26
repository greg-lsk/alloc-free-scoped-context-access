using _devHelp;
using _tempName.Exceptions;

namespace _tempName.Tests;


public class IRemoteTests
{
    [Fact]
    public void Get_ReturnsCorrectValue_WhenActiveLink_IsProvided()
    {
        // Arrange
        IRemote<ReadonlyDummyStruct> dummyRemote = new DummyRemote();
        var linkTo = LinkTo<ReadonlyDummyStruct>.Create(new(42, "Hellow"));

        // Act
        var intValue = dummyRemote.Get<DummyGetInt, int>(linkTo);
        var stringValue = dummyRemote.Get<DummyGetString, string>(linkTo);

        // Assert
        Assert.Equal(expected: 42, actual: intValue);
        Assert.Equal(expected: "Hellow", actual: stringValue);
    }

    [Fact]
    public void Get_ThrowsInactiveLinkException_WhenInactiveLink_IsProvided()
    {
        // Arrange
        IRemote<ReadonlyDummyStruct> dummyRemote = new DummyRemote();
        LinkTo<ReadonlyDummyStruct> link = default;

        // Act
        void act() => dummyRemote.Get<DummyGetInt, int>(link);

        // Assert
        var exception = Assert.Throws<InactiveLinkException>(act);

    }
}