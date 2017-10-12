using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using Microsoft.Practices.Unity;

namespace Log4Net.WcfContracts
{
    public static partial class WcfServiceResolver
    {

        public static Log4Net.WcfContracts.ILogService ResolveWcfServiceLog()
        {
            Framework.CommonBLLEntities.IBusinessLogicLayerContextContainer _IBusinessLogicLayerContextContainer = Framework.IoCContainerWrapperSingleton.Instance.IoCContainer.Resolve<Framework.CommonBLLEntities.IBusinessLogicLayerContextContainer>();
            Framework.CommonBLLEntities.BusinessLogicLayerContext _BusinessLogicLayerContext = _IBusinessLogicLayerContextContainer.BusinessLogicLayerContext;
            Log4Net.WcfContracts.IBusinessLogicLayerFactory _IBusinessLogicLayerFactory = Framework.IoCContainerWrapperSingleton.Instance.IoCContainer.Resolve<Log4Net.WcfContracts.IBusinessLogicLayerFactory>();
            Log4Net.WcfContracts.ILogService _BusinessLogicLayerInstance = _IBusinessLogicLayerFactory.CreateBLLInstanceOfEntityLog(_BusinessLogicLayerContext);
            return _BusinessLogicLayerInstance;
        }

    }

    public static partial class WcfServiceResolverAsyn
    {

        public static Log4Net.WcfContracts.ILogServiceAsyn ResolveWcfServiceLog()
        {
            Framework.CommonBLLEntities.IBusinessLogicLayerContextContainer _IBusinessLogicLayerContextContainer = Framework.IoCContainerWrapperSingleton.Instance.IoCContainer.Resolve<Framework.CommonBLLEntities.IBusinessLogicLayerContextContainer>();
            Framework.CommonBLLEntities.BusinessLogicLayerContext _BusinessLogicLayerContext = _IBusinessLogicLayerContextContainer.BusinessLogicLayerContext;
            Log4Net.WcfContracts.IBusinessLogicLayerFactoryAsyn _IBusinessLogicLayerFactory = Framework.IoCContainerWrapperSingleton.Instance.IoCContainer.Resolve<Log4Net.WcfContracts.IBusinessLogicLayerFactoryAsyn>();
            Log4Net.WcfContracts.ILogServiceAsyn _BusinessLogicLayerInstance = _IBusinessLogicLayerFactory.CreateBLLInstanceOfEntityLog(_BusinessLogicLayerContext);
            return _BusinessLogicLayerInstance;
        }

    }
}