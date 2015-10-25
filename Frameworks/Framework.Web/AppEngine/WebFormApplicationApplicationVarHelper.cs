using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Framework.Web
{
    public static class WebFormApplicationApplicationVarHelper
    {
        public const string VarName_WorkflowRuntime = "VarName_WorkflowRuntime";
        public const string m_NameOfApplicationVarOfGlobalSetting = "m_NameOfApplicationVarOfGlobalSetting";

        public static Framework.Web.WebFormApplicationGlobalSetting GlobalSetting
        {
            get 
            {
                if (System.Web.HttpContext.Current.Application[m_NameOfApplicationVarOfGlobalSetting] == null)
                {
                    System.Web.HttpContext.Current.Application[m_NameOfApplicationVarOfGlobalSetting] = new Framework.Web.WebFormApplicationGlobalSetting();
                }
                return (Framework.Web.WebFormApplicationGlobalSetting)System.Web.HttpContext.Current.Application[m_NameOfApplicationVarOfGlobalSetting]; 
            }
            //set { m_GlobalSetting = value; }
        }

        public static string PageContentAlign
        {
            get { return GlobalSetting.PageContentAlign; }
        }

        public static string PageContentStyle
        {
            get { return GlobalSetting.PageContentStyle; }
        }

        public const string Name_RssWebHandlerRootPath = "RssWebHandlerRootPath";
        public static string RssWebHandlerRootPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings[Name_RssWebHandlerRootPath];
            }
        }
    }
}