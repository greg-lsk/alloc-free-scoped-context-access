namespace _tempName.Tests.Fixtures;


public enum LinkState
{
    Active,
    Inactive
}

public delegate LinkTo<T> ArrangeLinkTo<T>(LinkState link, in T target = default) where T : struct;

public class LinkToFixture : IDisposable
{
    public void Dispose(){}

    public LinkTo<T> ArrangeLinkTo<T>(LinkState link, in T target = default) where T : struct => link switch
    {
        LinkState.Active => LinkTo<T>.Create(in target),
        LinkState.Inactive => default,
        _ => throw new InvalidDataException("Invalid LinkState")
    };  
}