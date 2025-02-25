namespace _tempName;


public unsafe readonly struct LinkTo<TTarget> where TTarget : struct
{
    private readonly TTarget* _target;
    private LinkTo(TTarget* target) => _target = target;

    public ref TTarget Target => ref *_target;

    internal static LinkTo<TTarget> Create(in TTarget _target)
    {
        fixed (TTarget* ptr = &_target)
        {
            return new LinkTo<TTarget>(ptr);
        }
    }

    public bool IsVoid() => _target is null;
}