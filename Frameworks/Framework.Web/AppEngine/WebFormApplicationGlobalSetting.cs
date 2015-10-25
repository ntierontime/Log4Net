using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
	
namespace Framework.Web
{
    public class WebFormApplicationGlobalSetting
    {
        string m_PageContentAlign = "center";

        public string PageContentAlign
        {
            get { return m_PageContentAlign; }
            set { m_PageContentAlign = value; }
        }

        string m_PageContentStyle = "width:80%";

        public string PageContentStyle
        {
            get { return m_PageContentStyle; }
            set { m_PageContentStyle = value; }
        }
    }
}