using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;

namespace Log4Net.WcfWebApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAtom10Feeds" in both code and config file together.
    [ServiceContract]
    public interface IAtom10Feeds
    {

        [OperationContract]
        [WebGet]
        Atom10FeedFormatter GetLog();

    }
}

