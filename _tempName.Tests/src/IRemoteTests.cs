using _devHelp;

namespace _tempName.Tests;


public class IRemoteTests
{
    [Fact]
    public void Get_ReturnsCorrectValue()
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
}