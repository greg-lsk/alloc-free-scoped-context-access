using _tempName;

namespace _devHelp;


public struct DummyIntValue : IRemoteFunc<DummyStruct, int>
{
    public readonly int Invoke(in DummyStruct target) => target.IntValue;
}

public struct DummyStringValue : IRemoteFunc<DummyStruct, string>
{
    public readonly string Invoke(in DummyStruct target) => target.StringValue;
}