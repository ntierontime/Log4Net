using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Framework.Web
{
    public static class WebFormApplicationPageHelper
    {
        public static void BuildCurrentLanguageOfMultiLanguage(System.Web.HttpRequest request)
        {
            if (false == string.IsNullOrEmpty(Framework.Web.WebFormApplicationSessionHelper.LanguageDropDownListUniqueID))
            {
                string _langDropDownListUniqueID = Framework.Web.WebFormApplicationSessionHelper.LanguageDropDownListUniqueID;
                string lang = request[_langDropDownListUniqueID];
                if (string.IsNullOrEmpty(lang) == false)
                {
                    System.Globalization.CultureInfo _CultureInfo = new System.Globalization.CultureInfo(lang);
                    System.Threading.Thread.CurrentThread.CurrentCulture = _CultureInfo;
                    System.Threading.Thread.CurrentThread.CurrentUICulture = _CultureInfo;
                }
            }
        }

        //This is how to invoke Page_PreInit.
        //protected void Page_PreInit(object sender, EventArgs e)
        //{
        //    UStandard.AppEngine.WebFormApp.PageHelper.Page_PreInit((Page)sender, e);
        //}
        public static void Page_PreInit(
            System.Web.UI.Page sender
            , EventArgs e)
        {
            //string _Url_AbsolutePath = sender.Request.Url.AbsolutePath;

            //BLL_ZOne.ZWebSite.SiteMapNode_Basic _BLLSiteMapNode_Basic = new BLL_ZOne.ZWebSite.SiteMapNode_Basic();
            //DBBO_ZOne.ZWebSite.SiteMapNode_Basic _DBBOSiteMapNode_Basic = _BLLSiteMapNode_Basic.GetByString_source("~" + _Url_AbsolutePath);

            //if (_DBBOSiteMapNode_Basic != null)
            //{
            //    DBBO_ZOne.ZWebSite.SiteMapNode_Composite _Result =
            //        SWAToLoadComposite_ZOne.ZWebSite.Load_ZWebSite_SiteMapNode.Facade(
            //        _DBBOSiteMapNode_Basic.SiteMapNodeID
            //        , true
            //        , true
            //        , true
            //        , true
            //        , true
            //        );
            //    sender.MasterPageFile = _Result.FK_From_ZWebSite_MasterDef_To_ZWebSite_SiteMapNode_ZWebSite_MasterDef_MasterDefID_MasterPage.source;
            //    sender.Theme = _Result.FK_From_ZWebSite_ThemeDef_To_ZWebSite_SiteMapNode_ZWebSite_ThemeDef_ThemeDefID_ThemeDef.source;

            //    BLL_ZOne.ZWebSite.LayoutSetting_Basic _BLLOfLayoutSetting_Basic = new BLL_ZOne.ZWebSite.LayoutSetting_Basic();
            //    DBBO_ZOne.ZWebSite.LayoutSetting_Basic _DBBOOfLayoutSetting_Basic = _BLLOfLayoutSetting_Basic.GetByID(_Result.FK_From_ZWebSite_MasterDef_To_ZWebSite_SiteMapNode_ZWebSite_MasterDef_MasterDefID_MasterPage.ZWebSite_LayoutSetting_LayoutSettingID_LayoutSetting);
            //    if (_DBBOOfLayoutSetting_Basic != null)
            //    {
            //        ApplicationVar_LayoutSettingHelper.DirectionOfAdditionalMainZone = (System.Web.UI.WebControls.Orientation)Enum.Parse(typeof(System.Web.UI.WebControls.Orientation), _DBBOOfLayoutSetting_Basic.DirectionOfAdditionalMainZone);
            //        ApplicationVar_LayoutSettingHelper.DirectionOfMainBottomZone = (System.Web.UI.WebControls.Orientation)Enum.Parse(typeof(System.Web.UI.WebControls.Orientation), _DBBOOfLayoutSetting_Basic.DirectionOfMainBottomZone);
            //        ApplicationVar_LayoutSettingHelper.DirectionOfMainTopZone = (System.Web.UI.WebControls.Orientation)Enum.Parse(typeof(System.Web.UI.WebControls.Orientation), _DBBOOfLayoutSetting_Basic.DirectionOfMainTopZone);
            //        ApplicationVar_LayoutSettingHelper.DirectionOfMainZone = (System.Web.UI.WebControls.Orientation)Enum.Parse(typeof(System.Web.UI.WebControls.Orientation), _DBBOOfLayoutSetting_Basic.DirectionOfMainZone);

            //        ApplicationVar_LayoutSettingHelper.WidthOfLeftZone = _DBBOOfLayoutSetting_Basic.WidthOfLeftZone;
            //        ApplicationVar_LayoutSettingHelper.WidthOfMainZone = _DBBOOfLayoutSetting_Basic.WidthOfMainZone;
            //        ApplicationVar_LayoutSettingHelper.WidthOfRightZone = _DBBOOfLayoutSetting_Basic.WidthOfRightZone;
            //    }
            //}
        }
    }
}