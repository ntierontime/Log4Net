using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;

namespace Log4Net.CommonBLL
{
    public static class SyndicationFeedFacade
    {

        public static SyndicationFeed GetLog()
        {
            string urlOfList = string.Format("{0}{1}/{2}", Framework.Web.WebFormApplicationApplicationVariables.WebAppRootUrl, "Log", "WPCommonOfLog");

            SyndicationFeed feed = new SyndicationFeed(Log4Net.Resx.UIStringResourcePerEntityLog.Rss_Title_of_Log, Log4Net.Resx.UIStringResourcePerEntityLog.Rss_Description_of_Log, new Uri(urlOfList));
            //feed.Authors.Add(new SyndicationPerson(Log4Net.Resx.UIStringResourcePerEntityLog.));
            //feed.Categories.Add(new SyndicationCategory(Log4Net.Resx.UIStringResourcePerEntityLog.));

            Log4Net.CommonBLL.LogService instance = new Log4Net.CommonBLL.LogService();

            var request = new Log4Net.CommonBLLEntities.LogRequestMessageUserDefinedOfAll();
            request.QueryPagingSetting = new Framework.EntityContracts.QueryPagingSetting(1, 10);
            request.QueryOrderBySettingCollection = new Framework.EntityContracts.QueryOrderBySettingCollection("LastModifiedDateTime:DESC");
            var fromDataSource = instance.GetCollectionOfRssItemOfAll(request);

            List<SyndicationItem> items = new List<SyndicationItem>();
            if (fromDataSource.BusinessLogicLayerResponseStatus == Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageOK)
            {
                foreach (var datasourceItem in fromDataSource.Message)
                {
                    //string urlOfEntityRelated = string.Format("{0}{1}/{2}?{3}", Log4Net.Resx.UIStringResourcePerEntityLog.HomeOwner, "Log", "WPEntityRelatedOfLog", "{Query String Parameters}");
                    SyndicationItem item1 = new SyndicationItem(
                        datasourceItem.Title,
                        datasourceItem.Description,
                        new Uri(urlOfList), // should be urlOfEntityRelated, should enter query string parameters
                        datasourceItem.IdentifierInString,
                        datasourceItem.PubDate);

                    items.Add(item1);
                }
            }

            feed.Items = items;
            return feed;
        }

    }
}

