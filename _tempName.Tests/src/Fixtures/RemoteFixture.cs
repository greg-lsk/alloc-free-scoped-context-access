namespace _tempName.Tests.Fixtures;


public delegate IRemote<T> ArrangeRemote<R, T>() where T: struct 
                                                 where R: IRemote<T>, new(); 

public class RemoteFixture : IDisposable
{
    public void Dispose(){}

    public IRemote<T> ArrangeRemote<R, T>() where T: struct 
                                            where R: IRemote<T>, new()
    {
        return new R();
    } 
}
