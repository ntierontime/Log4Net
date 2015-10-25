using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.UI.WebControls;
using System.Web.UI;


namespace Framework.Web
{
    public static class ListViewHelper
    {
		/// <summary>
        /// Zwraca formant stronicujący
        /// </summary>
        public static DataPager GetActivePager( this ListView ListView )
        {
            DataPager Pager =
                    ControlHelper.Find( ListView,
                       control => control is DataPager &&
                       ( (DataPager)control ).PagedControlID == ListView.ID ) as DataPager;

            if ( Pager != null )
                return Pager;
            else
                return new DataPager();
        }
    }
}