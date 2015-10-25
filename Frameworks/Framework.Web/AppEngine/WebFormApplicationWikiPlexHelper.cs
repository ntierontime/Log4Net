using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
	
namespace Framework.Web
{
    public static class WebFormApplicationWikiPlexHelper
    {
        public static WikiPlex.WikiEngine m_WikiEngine = new WikiPlex.WikiEngine();
        public static string Parse(string input)
        {
            return m_WikiEngine.Render(input);
        }
    }
}