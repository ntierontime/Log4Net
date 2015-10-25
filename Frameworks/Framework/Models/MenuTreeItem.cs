using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Framework
{
    /// <summary>
    /// The SampleTreeItem represents a node in the TreeView.  
    /// </summary>
    //[ContentProperty("Items")]
    public class MenuTreeItem
    {
        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuTreeItem"/> class.
        /// </summary>
        public MenuTreeItem()
        {
            MenuTreeItems = new Collection<MenuTreeItem>();
        }

		public MenuTreeItem (
			System.String treeItemName, 
			System.String title, 
			System.String subTitle, 
			System.String description, 
			System.String iconResourceName, 
			System.String iconResourceUrl, 
			System.String sourceTypeFullName, 
			System.String senderView, 
			Framework.UIAction uIAction, 
			Framework.UIActionStatus uIActionStatus)
			: this()
		{
			this.TreeItemName=treeItemName;
			this.Title=title;
			this.SubTitle=subTitle;
			this.Description=description;
			this.IconResourceName=iconResourceName;
			this.IconResourceUrl=iconResourceUrl;
			this.SourceTypeFullName=sourceTypeFullName;
			this.SenderView=senderView;
			this.UIAction=uIAction;
			this.UIActionStatus=uIActionStatus;
		}
		
		#endregion constructor

        #region value type properties

        /// <summary>
        /// Gets or sets the name of the TreeView node.
        /// </summary>
        public string TreeItemName { get; set; }
		
        /// <summary>
        /// Gets or sets the name of the TreeView node.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the name of the TreeView node.
        /// </summary>
        public string SubTitle { get; set; }

        /// <summary>
        /// Gets or sets the name of the TreeView node.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the resource name of the Icon representing this 
        /// node.
        /// </summary>
        public string IconResourceName { get; set; }

        /// <summary>
        /// Gets or sets the resource url of the Icon representing this 
        /// node.
        /// </summary>
        public string IconResourceUrl { get; set; }

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
        public UIAction UIAction { get; set; }

        /// <summary>
        /// Gets or sets the UI action status.
        /// </summary>
        /// <value>
        /// The UI action status.
        /// </value>
        public UIActionStatus UIActionStatus { get; set; }

        #endregion value type properties

        #region Items properties

        /// <summary>
        ///  Gets a collection of MenuTreeItems.
        /// </summary>
        public Collection<MenuTreeItem> MenuTreeItems { get; private set; }

        #endregion Items properties

		#region override string ToString()

        public override string ToString()
        {
            return string.Format("TreeItemName:{0};Title:{1};SubTitle:{2};Description:{3};IconResourceName:{4};IconResourceUrl:{5};SourceTypeFullName:{6};SenderView:{7};UIAction:{8};UIActionStatus:{9};", this.TreeItemName, this.Title, this.SubTitle, this.Description, this.IconResourceName, this.IconResourceUrl, this.SourceTypeFullName, this.SenderView, this.UIAction, this.UIActionStatus);
        }

		#endregion override string ToString()
		
		#region AddSubMenuTreeItem(...)

        public MenuTreeItem AddSubMenuTreeItem(
			System.String treeItemName
			, System.String title
			, System.String subTitle
			, System.String description
			, System.String iconResourceName
			, System.String iconResourceUrl
			, System.String sourceTypeFullName
			, System.String senderView
			, Framework.UIAction uIAction
			, Framework.UIActionStatus uIActionStatus
			)
        {
            if (this.MenuTreeItems == null)
            {
                this.MenuTreeItems = new Collection<MenuTreeItem>();
            }
            MenuTreeItem _Item = new MenuTreeItem(
				treeItemName
                , title
                , subTitle
                , description
				, iconResourceName
				, iconResourceUrl
				, sourceTypeFullName
				, senderView
				, uIAction
				, uIActionStatus
				);
            this.MenuTreeItems.Add(_Item);
			return _Item;
        }

		#endregion AddSubMenuTreeItem(...)
    }
}