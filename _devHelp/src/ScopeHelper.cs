using _tempName;

namespace _devHelp;

public static class ScopeHelper
{
    public static LinkTo<T> DummyInvocationScope<T>(Func<T> createT) where T : struct
    {
        var scopedContext = createT();
        return LinkTo<T>.Create(in scopedContext);
    }
}