using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.Text;

namespace Log4Net.WcfWebApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Atom10Feeds" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Atom10Feeds.svc or Atom10Feeds.svc.cs at the Solution Explorer and start debugging.
    public class Atom10Feeds : Log4Net.WcfWebApp.IAtom10Feeds
    {

        public Atom10FeedFormatter GetLog()
        {
            SyndicationFeed feed = Log4Net.CommonBLL.SyndicationFeedFacade.GetLog();
            return new Atom10FeedFormatter(feed);
        }

    }
}

