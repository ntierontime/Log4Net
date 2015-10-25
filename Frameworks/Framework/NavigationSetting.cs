using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework
{
    public class NavigationSetting
    {
        #region constructors

        /// <summary>
        /// default constructor
        /// </summary>
        public NavigationSetting()
        {
        }

        public NavigationSetting(
            System.String sourceTypeFullName,
            System.String senderView,
            Framework.UIAction uIAction,
            Framework.UIActionStatus uIActionStatus,
            Framework.UIAction nextUIAction,
            System.String targetUrl,
            System.Type targetPageType)
            : base()
        {
            this.SourceTypeFullName = sourceTypeFullName;
            this.SenderView = senderView;
            this.UIAction = uIAction;
            this.UIActionStatus = uIActionStatus;
            this.NextUIAction = nextUIAction;
            this.TargetUrl = targetUrl;
            this.TargetPageType = targetPageType;
        }

        #endregion constructors

        /// <summary>
        /// Gets or sets the full name of the source type.
        /// </summary>
        /// <value>
        /// The full name of the source type.
        /// </value>
        public string SourceTypeFullName { get; set; }

        /// <summary>
        /// Gets or sets the sender.
        /// </summary>
        /// <value>
        /// The sender.
        /// </value>
        public string SenderView { get; set; }

        /// <summary>
        /// Gets or sets the UI action.
        /// </summary>
        /// <value>
        /// The UI action.
        /// </value>
        public Framework.UIAction UIAction { get; set; }

        /// <summary>
        /// Gets or sets the UI action status.
        /// </summary>
        /// <value>
        /// The UI action status.
        /// </value>
        public Framework.UIActionStatus UIActionStatus { get; set; }

        /// <summary>
        /// Gets or sets the Next UI action.
        /// </summary>
        /// <value>
        /// The UI action.
        /// </value>
        public Framework.UIAction NextUIAction { get; set; }

        /// <summary>
        /// Gets or sets the target URL.
        /// </summary>
        /// <value>
        /// The target URL.
        /// </value>
        public string TargetUrl { get; set; }

        /// <summary>
        /// Gets or sets the type of the target, will navigate to or load, for WinRT
        /// </summary>
        /// <value>
        /// The type of the target.
        /// </value>
        public Type TargetPageType { get; set; }

        #region override string ToString()

        public override string ToString()
        {
            return string.Format("SourceTypeFullName:{0};SenderView:{1};UIAction:{2};UIActionStatus:{3};NextUIAction:{4};TargetUrl:{5};TargetPageType:{6};", this.SourceTypeFullName, this.SenderView, this.UIAction, this.UIActionStatus, this.NextUIAction, this.TargetUrl, this.TargetPageType);
        }

        #endregion override string ToString()
    }

    public class NavigationSettingCollection : List<NavigationSetting>
    {

        #region Add(...)

        public void Add(System.String sourceTypeFullName, System.String senderView, Framework.UIAction uIAction, Framework.UIActionStatus uIActionStatus, Framework.UIAction nextUIAction, System.String targetUrl, System.Type targetPageType)
        {
            NavigationSetting _Item = new NavigationSetting(sourceTypeFullName, senderView, uIAction, uIActionStatus, nextUIAction, targetUrl, targetPageType);

            this.Add(_Item);
        }

        #endregion Add(...)
    }
}