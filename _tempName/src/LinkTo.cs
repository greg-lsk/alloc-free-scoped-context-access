namespace _tempName;


public unsafe readonly struct LinkTo<TTarget> where TTarget : struct
{
    private readonly TTarget* _target;
    private LinkTo(TTarget* target) => _target = target;

    public ref TTarget Target => ref *_target;

    public static LinkTo<TTarget> Create(in TTarget _target)
    {
        fixed (TTarget* ptr = &_target)
        {
            return new LinkTo<TTarget>(ptr);
        }
    }

    public bool TargetIsSet() => _target is not null;
}