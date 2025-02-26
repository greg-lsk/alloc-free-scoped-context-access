using _devHelp;

namespace _tempName.Tests.Fixtures;


public class RemoteFixture : IDisposable
{
    public IRemote<ReadonlyDummyStruct> Target;

    public RemoteFixture() => Target = new DummyRemote();

    public void Dispose() => Target = null;
}