namespace _devHelp;


public readonly struct ReadonlyDummyStruct(int intValue, string stringValue)
{
    public int IntValue { get; } = intValue;
    public string StringValue { get; } = stringValue;
}

public struct MutableDummyStruct(int intValue, string stringValue)
{
    public int IntValue { get; set; } = intValue;
    public string StringValue { get; set; } = stringValue;
}