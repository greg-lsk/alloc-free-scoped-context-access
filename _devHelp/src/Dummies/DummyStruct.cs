namespace _devHelp;


public readonly struct DummyStruct(int intValue, string stringValue)
{
    public int IntValue { get; } = intValue;
    public string StringValue { get; } = stringValue;
}