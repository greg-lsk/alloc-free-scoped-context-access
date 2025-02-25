using _tempName;

namespace _devHelp;

public static class ScopeHelper
{
    public static LinkTo<T> DummyEscapedLink<T>(Func<T> createInScope) where T : struct
    {
        var scopedContext = createInScope();
        return LinkTo<T>.Create(in scopedContext);
    }
}