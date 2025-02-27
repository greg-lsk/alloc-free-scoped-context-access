namespace _tempName.Tests.Fixtures;


public enum LinkState
{
    Active,
    Inactive
}

public delegate LinkTo<T> ArrangeLinkTo<T>(LinkState link, in T dummy = default) where T : struct;

public class LinkToFixture : IDisposable
{
    public void Dispose(){}

    public LinkTo<T> ArrangeLinkTo<T>(LinkState link, in T dummy = default) where T : struct => link switch
    {
        LinkState.Active => LinkTo<T>.Create(in dummy),
        LinkState.Inactive => default,
    };  
}