using _tempName;

namespace _devHelp;

public static class ScopeHelper
{
    public static void DummyInvocationScope(ref LinkTo<ReadonlyDummyStruct> linkTo)
    {
        var scopedContext = new ReadonlyDummyStruct(42, "Hello");
        linkTo = LinkTo<ReadonlyDummyStruct>.Create(in scopedContext);
    }
}