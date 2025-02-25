namespace src;

public interface IRemoteFunc<TTarget, TReturn> where TTarget : struct
{ 
    public TReturn Invoke(in TTarget target); 
}

public interface IRemote<TTarget> where TTarget : struct
{
    public TReturn Get<TFunc, TReturn>(LinkTo<TTarget> via) where TFunc : IRemoteFunc<TTarget, TReturn>, new()
    {
        var func = new TFunc();
        var targetRef = via.Target;

        return func.Invoke(in targetRef);
    }
}

public interface IRemoteAccessor<TTarget> where TTarget : struct
{
    public ref LinkTo<TTarget> Link {get;}
}