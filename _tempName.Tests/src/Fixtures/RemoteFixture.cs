using _devHelp;

namespace _tempName.Tests.Fixtures;

public enum LinkState
{
    Active,
    Inactive
}

public delegate LinkTo<T> ArrangeLinkTo<T>(LinkState link, in T dummy = default) where T : struct;

public class RemoteFixture : IDisposable
{
    public IRemote<ReadonlyDummyStruct> Target;
    public static  ArrangeLinkTo<ReadonlyDummyStruct> ArrangeLink => ArrangeLinkTo;

    public RemoteFixture() => Target = new DummyRemote();

    public void Dispose() => Target = null;

    private static LinkTo<T> ArrangeLinkTo<T>(LinkState link, in T dummy) where T : struct => link switch
    {
        LinkState.Active => LinkTo<T>.Create(in dummy),
        LinkState.Inactive => default,
    };
}