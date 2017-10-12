using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.Text;

namespace Log4Net.WcfWebApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RSSFacade" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RSSFacade.svc or RSSFacade.svc.cs at the Solution Explorer and start debugging.
    public class RssFeeds : Log4Net.WcfWebApp.IRssFeeds
    {

        public Rss20FeedFormatter GetLog()
        {
            SyndicationFeed feed = Log4Net.CommonBLL.SyndicationFeedFacade.GetLog();
            return new Rss20FeedFormatter(feed);
        }

    }
}

