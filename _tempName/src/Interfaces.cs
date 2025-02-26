using _tempName.Exceptions;

namespace _tempName;

public interface IRemoteFunc<TTarget, TReturn> where TTarget : struct
{ 
    public TReturn Invoke(in TTarget target); 
}

public interface IRemote<TTarget> where TTarget : struct
{
    public TReturn Get<TFunc, TReturn>(LinkTo<TTarget> via) where TFunc : IRemoteFunc<TTarget, TReturn>, new()
    {
        var func = new TFunc();

        TTarget targetRef;
        if(via.IsActive()) targetRef = via.Target;
        else throw new InactiveLinkException(ExceptionMessages.InactiveLinkProvided);
        
        return func.Invoke(in targetRef);
    }
}

public interface IRemoteAccessor<TTarget> where TTarget : struct
{
    public ref LinkTo<TTarget> Link {get;}
}