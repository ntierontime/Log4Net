using Framework.EntityContracts;

namespace Framework.CommonBLLEntities
{
    public interface IBusinessLogicLayerResponseMessageBase
    {
        string BusinessLogicLayerRequestID { get; set; }
        string BusinessLogicLayerResponseID { get; set; }
        BusinessLogicLayerResponseStatus BusinessLogicLayerResponseStatus { get; set; }
        DataStreamServiceResult DataStreamServiceResult { get; set; }
        QueryPagingResult QueryPagingResult { get; set; }
        string ServerErrorMessage { get; set; }

        string GetStatusMessage();
    }
}

