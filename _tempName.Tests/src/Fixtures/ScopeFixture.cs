namespace _tempName.Tests.Fixtures;


public delegate void MockEscapedLinkTo<T>(out LinkTo<T> linkTo, Func<T> createTargetInScope) where T : struct;

public class ScopeFixture : IDisposable
{
    public void Dispose(){}

    public void MockEscapedLink<T>(out LinkTo<T> linkTo, Func<T> createTargetInScope) where T : struct
    {
        var scopedTarget = createTargetInScope();
        linkTo = LinkTo<T>.Create(in scopedTarget);
    }  
}