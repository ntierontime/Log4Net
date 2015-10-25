using System;
using System.Collections.Generic;
using System.Text;
using System.Web.SessionState;
	
namespace Framework.Web
{
    public static class WebFormApplicationSessionHelper
    {
        //public const string SessionName_ = "SessionName_";

        public const string SessionName_RootSiteMapID = "SessionName_RootSiteMapID";
        public static long RootSiteMapID
        {
            get
            {
                if (null != System.Web.HttpContext.Current && null != System.Web.HttpContext.Current.Session[SessionName_RootSiteMapID])
                {
                    return (long)System.Web.HttpContext.Current.Session[SessionName_RootSiteMapID];
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                System.Web.HttpContext.Current.Session[SessionName_RootSiteMapID] = value;
            }
        }

        public const string SessionName_GenericActionDonePage_GoBackUrl = "SessionName_GenericActionDonePage_GoBackUrl";
        public static string GenericActionDonePage_GoBackUrl
        {
            get
            {
                if (null != System.Web.HttpContext.Current && null != System.Web.HttpContext.Current.Session[SessionName_GenericActionDonePage_GoBackUrl])
                {
                    return (string)System.Web.HttpContext.Current.Session[SessionName_GenericActionDonePage_GoBackUrl];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                System.Web.HttpContext.Current.Session[SessionName_GenericActionDonePage_GoBackUrl] = value;
            }
        }


        public const string SessionName_LanguageDropDownListUniqueID = "SessionName_LanguageDropDownListUniqueID";
        
        public static string LanguageDropDownListUniqueID
        {
            get
            {
                if (null != System.Web.HttpContext.Current && null != System.Web.HttpContext.Current.Session[SessionName_LanguageDropDownListUniqueID])
                {
                    return (string)System.Web.HttpContext.Current.Session[SessionName_LanguageDropDownListUniqueID];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                System.Web.HttpContext.Current.Session[SessionName_LanguageDropDownListUniqueID] = value;
            }
        }

        public static string RootUrl
        {
            get
            {
                string _OriginalString;
                _OriginalString = System.Web.HttpContext.Current.Request.Url.OriginalString;

                string _RootUrl;
                _RootUrl = _OriginalString.Substring(0, _OriginalString.IndexOf("/") + 1);
                return _RootUrl;
            }
        }

        public const string SessionName_PersonTypeID = "SessionName_PersonTypeID";

        public static long PersonTypeID
        {
            get
            {
                if (null != System.Web.HttpContext.Current && null != System.Web.HttpContext.Current.Session[SessionName_PersonTypeID])
                {
                    return (long)System.Web.HttpContext.Current.Session[SessionName_PersonTypeID];
                }
                else
                {
                    return 1;
                }
            }
            set
            {
                System.Web.HttpContext.Current.Session[SessionName_PersonTypeID] = value;
            }
        }

        public const string SessionName_PersonTypeGuid = "SessionName_PersonTypeGuid";

        public static Guid PersonTypeGuid
        {
            get
            {
                if (null != System.Web.HttpContext.Current && null != System.Web.HttpContext.Current.Session[SessionName_PersonTypeGuid])
                {
                    return (Guid)System.Web.HttpContext.Current.Session[SessionName_PersonTypeGuid];
                }
                else
                {
                    return Guid.NewGuid();
                }
            }
            set
            {
                System.Web.HttpContext.Current.Session[SessionName_PersonTypeGuid] = value;
            }
        }

        public const string SessionName_PersonTypeGuidInString = "SessionName_PersonTypeGuidInString";

        public static string PersonTypeGuidInString
        {
            get
            {
                if (null != System.Web.HttpContext.Current && null != System.Web.HttpContext.Current.Session[SessionName_PersonTypeGuidInString])
                {
                    return (string)System.Web.HttpContext.Current.Session[SessionName_PersonTypeGuidInString];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != null)
                {
                    System.Web.HttpContext.Current.Session[SessionName_PersonTypeGuidInString] = value.ToString();
                }
            }
        }

    }
}