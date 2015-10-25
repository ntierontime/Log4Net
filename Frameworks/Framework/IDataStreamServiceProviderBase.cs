using System;
namespace Framework
{
    public interface IDataStreamServiceProviderBase<TCollection, TItem>
        where TCollection : System.Collections.Generic.List<TItem>
    {
        Framework.DataStreamServiceResult BuildResult(TCollection input, Framework.DataServiceTypes dataServiceType);
    }
}