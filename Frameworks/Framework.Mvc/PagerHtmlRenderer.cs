using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace Framework.Mvc
{
    /// <summary>
    /// Helper class used for rendering the pager for a list in HTML.
    /// </summary>
    public class PagerHtmlRenderer
    {
        #region Properties

        /// <summary>
        /// The name of the action method.
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// The name of the controller.
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// An object that contains the parameters for a route.
        /// </summary>
        public RouteValueDictionary RouteValues { get; set; }

        /// <summary>
        /// The key in the RouteValues dictionary where to put the page number.
        /// </summary>
        public string PageRouteValueName { get; set; }

        /// <summary>
        /// The current page number. By default it is 1 (the first page).
        /// </summary>
        public int CurrentPageNumber { get; set; }

        /// <summary>
        /// The maximum number of elements in a page. If less then 1 we will consider 10 by default.
        /// </summary>
        public int PageSize
        {
            get { return _pageSize < 1 ? 10 : _pageSize; }
            set { _pageSize = value; }
        }
        private int _pageSize;

        /// <summary>
        /// The total number of elements in the list. 
        /// </summary>
        public int TotalNumberOfItems { get; set; }

        /// <summary>
        /// This will create a google-like pager that will display a limited number of page links. Deafult it is 10.
        /// </summary>
        public int MaximumNumberOfPageLinksToRender
        {
            get { return _maximumNumberOfPageLinksToRender < 1 ? 10 : _maximumNumberOfPageLinksToRender; }
            set { _maximumNumberOfPageLinksToRender = value; }
        }
        private int _maximumNumberOfPageLinksToRender;

        /// <summary>
        /// The HTML string to use as a container for all the pages. Example: <ul>{0}</ul> where {0} will be replaced with the page elements. Default is "{0}".
        /// </summary>
        public string ContainerHtmlFormatString
        {
            get { return string.IsNullOrEmpty(_containerHtmlFormatString) ? "{0}" : _containerHtmlFormatString; }
            set { _containerHtmlFormatString = value; }
        }
        private string _containerHtmlFormatString;

        /// <summary>
        /// The HTML string to use as a container for a page link. Example: <li>{0}</li> where {0} will be replaced with the page link. Default is "{0}".
        /// </summary>
        public string PageNumberHtmlFormatString
        {
            get { return string.IsNullOrEmpty(_pageNumberHtmlFormatString) ? "{0}" : _pageNumberHtmlFormatString; }
            set { _pageNumberHtmlFormatString = value; }
        }
        private string _pageNumberHtmlFormatString;

        /// <summary>
        /// The HTML string to use as a container for the current page number. Example: <strong><li>{0}</li></strong> where {0} will be replaced with the current page number. Default is <strong>{0}</strong>.
        /// </summary>
        public string CurrentPageNumberHtmlFormatString
        {
            get { return string.IsNullOrEmpty(_currentPageNumberHtmlFormatString) ? "<strong>{0}</strong>" : _currentPageNumberHtmlFormatString; }
            set { _currentPageNumberHtmlFormatString = value; }
        }
        private string _currentPageNumberHtmlFormatString;

        /// <summary>
        /// The HTML string used for separating two page numbers. For example you can use , as a separator. Default is ' '.
        /// </summary>
        public string SeparatorHtmlString { get; set; }

        /// <summary>
        /// True to show a go to previous page link. Default is true.
        /// </summary>
        public bool ShowPreviousLink { get; set; }

        /// <summary>
        /// The HTML/text to show inside the previous link element. Default is '&lt;'.
        /// </summary>
        public string PreviousLinkInnerHtml { get; set; }

        /// <summary>
        /// True to show a go to next page link. Default is true.
        /// </summary>
        public bool ShowNextLink { get; set; }

        /// <summary>
        /// The HTML/text to show inside the next link element. Default is '&gt;'.
        /// </summary>
        public string NextLinkInnerHtml { get; set; }

        /// <summary>
        /// True to show a go to first page link. Default is true.
        /// </summary>
        public bool ShowFirstLink { get; set; }

        /// <summary>
        /// The HTML/text to show inside the first link element. Default is '&lt;&lt;'. 
        /// </summary>
        public string FirstLinkInnerHtml { get; set; }

        /// <summary>
        /// True to show a go to last page link. Default is true.
        /// </summary>
        public bool ShowLastLink { get; set; }

        /// <summary>
        /// The HTML/text to show inside the last link element. Default is '&gt;&gt;'. 
        /// </summary>
        public string LastLinkInnerHtml { get; set; }

        /// <summary>
        /// True to hide the pager when there is only one page. Default is false.
        /// </summary>
        public bool AutoHide { get; set; }

        /// <summary>
        /// A custom JavaScript function for the page click that has as an input parameter the page number.
        /// </summary>
        public string PageLinkCustomAction { get; set; }

        #endregion

        /// <summary>
        /// Helper class used for rendering the pager for a list in HTML.
        /// </summary>
        /// <param name="currentPageNumber">The current page number. By default it is 1 (the first page).</param>
        /// <param name="pageSize">The maximum number of elements in a page. If less then 1 we will consider 10 by default.</param>
        /// <param name="totalNumberOfItems">The total number of elements in the list.</param>
        /// <param name="actionName">The name of the action method.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="pageRouteValueName">The key in the RouteValues dictionary where to put the page number.</param>
        public PagerHtmlRenderer(int currentPageNumber, int pageSize, int totalNumberOfItems, string actionName, string controllerName, RouteValueDictionary routeValues, string pageRouteValueName)
        {
            CurrentPageNumber = currentPageNumber;
            PageSize = pageSize;
            TotalNumberOfItems = totalNumberOfItems;
            ActionName = actionName;
            ControllerName = controllerName;
            RouteValues = routeValues;
            PageRouteValueName = pageRouteValueName;

            //Defaults
            MaximumNumberOfPageLinksToRender = 10;
            CurrentPageNumberHtmlFormatString = "<strong>{0}</strong>";
            SeparatorHtmlString = " ";
            ShowPreviousLink = true;
            PreviousLinkInnerHtml = "&lt;";
            ShowNextLink = true;
            NextLinkInnerHtml = "&gt";
            ShowFirstLink = true;
            FirstLinkInnerHtml = "&lt;&lt;";
            ShowLastLink = true;
            LastLinkInnerHtml = "&gt;&gt;";
            AutoHide = false;
        }

        /// <summary>
        /// Generate the HTML for the pager based on the current object properties.
        /// </summary>
        /// <param name="urlHelper">The current Url helper associated to the View. Used for generating the URLs in the page links.</param>
        /// <returns></returns>
        public string GeneratePagerHtml(UrlHelper urlHelper)
        {
            var totalNumberOfPages = TotalNumberOfItems == 0
                                         ? 1
                                         : (TotalNumberOfItems / PageSize + (TotalNumberOfItems % PageSize > 0 ? 1 : 0));
            var currentPageNumber = CurrentPageNumber < 1
                                        ? 1
                                        : (CurrentPageNumber > totalNumberOfPages
                                               ? totalNumberOfPages
                                               : CurrentPageNumber);

            if (AutoHide && totalNumberOfPages == 1)
                return string.Empty;

            var sb = new StringBuilder();

            //First, Previous
            if (ShowFirstLink && currentPageNumber > 1)
                AddToStringBuilder(sb, GetLinkHtml(1, FirstLinkInnerHtml, urlHelper));

            if (ShowPreviousLink && currentPageNumber > 1)
                AddToStringBuilder(sb, GetLinkHtml(currentPageNumber - 1, PreviousLinkInnerHtml, urlHelper));

            //Pages
            var centerPosition = MaximumNumberOfPageLinksToRender / 2;
            var startPageNumber = currentPageNumber <= centerPosition ? 1 : currentPageNumber - centerPosition;
            for (var pageNumber = startPageNumber; pageNumber <= totalNumberOfPages && pageNumber < startPageNumber + MaximumNumberOfPageLinksToRender; pageNumber++)
            {
                AddToStringBuilder(sb,
                                   pageNumber == currentPageNumber
                                       ? string.Format(CurrentPageNumberHtmlFormatString, pageNumber)
                                       : string.Format(PageNumberHtmlFormatString, GetLinkHtml(pageNumber, pageNumber.ToString(CultureInfo.InvariantCulture), urlHelper)));
            }

            //Next, Last
            if (ShowNextLink && currentPageNumber < totalNumberOfPages)
                AddToStringBuilder(sb, GetLinkHtml(currentPageNumber + 1, NextLinkInnerHtml, urlHelper));
            if (ShowLastLink && currentPageNumber < totalNumberOfPages)
                AddToStringBuilder(sb, GetLinkHtml(totalNumberOfPages, LastLinkInnerHtml, urlHelper));

            return string.Format(ContainerHtmlFormatString, sb);
        }

        protected string GetLinkHtml(int pageNumber, string innerHtml, UrlHelper urlHelper)
        {
            return string.Format("<a href=\"{0}\">{1}</a>", string.IsNullOrEmpty(PageLinkCustomAction) ? GetPageLink(pageNumber, urlHelper) : GetCustomAction(pageNumber), innerHtml);
        }

        protected string GetCustomAction(int pageNumber)
        {
            return string.Format("javascript:{0}(1);", PageLinkCustomAction);
        }

        protected string GetPageLink(int pageNumber, UrlHelper urlHelper)
        {
            if (RouteValues != null && !string.IsNullOrEmpty(PageRouteValueName) && RouteValues.ContainsKey(PageRouteValueName))
                RouteValues[PageRouteValueName] = pageNumber;

            return string.IsNullOrEmpty(ActionName) || string.IsNullOrEmpty(ControllerName) ? "#" : urlHelper.Action(ActionName, ControllerName, RouteValues);
        }

        /// <summary>
        /// Add the string to the string builder. If the string builder is not emplty add before a separator.
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="textToAdd"></param>
        protected void AddToStringBuilder(StringBuilder sb, string textToAdd)
        {
            if (sb.Length > 0)
                sb.Append(SeparatorHtmlString);
            sb.Append(textToAdd);
        }
    }
}