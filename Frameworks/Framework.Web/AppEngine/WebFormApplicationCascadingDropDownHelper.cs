using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
	
namespace Framework.Web
{
    public class WebFormApplicationCascadingDropDownHelper
    {
        public static string ParseValue(string input)
        {
            return input.Substring(0, input.IndexOf(":::"));
        }
    }
}