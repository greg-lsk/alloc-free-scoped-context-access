using _tempName;

namespace _devHelp;


public struct DummyGetInt : IRemoteFunc<ReadonlyDummyStruct, int>
{
    public readonly int Invoke(in ReadonlyDummyStruct target) => target.IntValue;
}

public struct DummyGetString : IRemoteFunc<ReadonlyDummyStruct, string>
{
    public readonly string Invoke(in ReadonlyDummyStruct target) => target.StringValue;
}