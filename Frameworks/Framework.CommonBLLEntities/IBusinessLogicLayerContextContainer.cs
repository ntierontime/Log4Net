using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.CommonBLLEntities
{
    public interface IBusinessLogicLayerContextContainer
    {
        Framework.CommonBLLEntities.BusinessLogicLayerContext BusinessLogicLayerContext { get; set; }
    }
}