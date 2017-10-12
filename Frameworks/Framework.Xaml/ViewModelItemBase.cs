using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Framework.Xaml
{
    public abstract class ViewModelItemBase<TSearchCriteria, TItem>
        : GalaSoft.MvvmLight.ViewModelBase, Framework.ViewModels.IViewModelItemBase<TSearchCriteria, TItem>
        where TSearchCriteria : class, new()
        where TItem : class, Framework.EntityContracts.IClone<TItem>, new()
    {
        #region constructor

        public ViewModelItemBase()
            : base()
        {
            this.SuppressMVVMLightEventToCommandMessage = false;

            this.Item = new TItem();
            this.OriginalItem = new TItem();

            this.LaunchCopyViewCommand = new RelayCommand<TItem>(LaunchCopyView);

            this.LaunchDetailsViewCommand = new RelayCommand<TItem>(LaunchDetailsView);
            this.CloseDetailsViewCommand = new RelayCommand(CloseDetailsView);

            this.LaunchEditViewCommand = new RelayCommand<TItem>(LaunchEditView);
            this.CloseEditViewCommand = new RelayCommand(CloseEditView);
            this.SaveCommand = new RelayCommand(Save, CanSave);

            this.LaunchCreateViewCommand = new RelayCommand(LaunchCreateView);
            this.CloseCreateViewCommand = new RelayCommand(CloseCreateView);
            this.AddCommand = new RelayCommand(Add, CanAdd);

            this.LaunchDeleteViewCommand = new RelayCommand<TItem>(LaunchDeleteView);
            this.CloseDeleteViewCommand = new RelayCommand(CloseDeleteView);
            this.DeleteCommand = new RelayCommand(Delete, CanDelete);

            this.RefreshCurrentItemCommand = new RelayCommand(RefreshItem);

            this.LoadItemCommand = new RelayCommand(this.LoadItem);
            this.LoadItemCommandTyped = new RelayCommand<TSearchCriteria>(this.LoadItem);

            this.RaiseItemPropertyChangedEventCommand = new RelayCommand(this.RaiseItemPropertyChangedEvent);
        }

        #endregion constructor

        #region override properties

        protected TSearchCriteria m_Criteria;
        public TSearchCriteria Criteria
        {
            get { return m_Criteria; }
            set
            {
                m_Criteria = value;
                RaisePropertyChanged("Criteria");
            }
        }

        protected TItem m_Item;
        public TItem Item
        {
            get { return m_Item; }
            set
            {
                m_Item = value != null ? value.GetAClone() : new TItem();
                RaisePropertyChanged("Item");
            }
        }

        protected Framework.EntityContracts.ContentData m_ContentData;
        public Framework.EntityContracts.ContentData ContentData
        {
            get { return m_ContentData; }
            set
            {
                m_ContentData = value;
                RaisePropertyChanged("ContentData");
            }
        }

        protected Framework.EntityContracts.SearchStatus m_SearchStatus;
        public Framework.EntityContracts.SearchStatus SearchStatus
        {
            get { return m_SearchStatus; }
            set
            {
                m_SearchStatus = value;
                RaisePropertyChanged("SearchStatus");
            }
        }

        protected string m_StatusMessageOfResult;
        public string StatusMessageOfResult
        {
            get { return m_StatusMessageOfResult; }
            set
            {
                m_StatusMessageOfResult = value;
                RaisePropertyChanged("StatusMessageOfResult");
            }
        }

        protected Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus m_StatusOfResult;
        public Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus StatusOfResult
        {
            get { return m_StatusOfResult; }
            set
            {
                m_StatusOfResult = value;
                RaisePropertyChanged("StatusOfResult");
            }
        }

        protected Framework.UIActionStatusMessage m_UIActionStatusMessage;
        public Framework.UIActionStatusMessage UIActionStatusMessage
        {
            get { return m_UIActionStatusMessage; }
            set
            {
                m_UIActionStatusMessage = value;
                RaisePropertyChanged("UIActionStatusMessage");
            }
        }

        #endregion override properties

        public TItem OriginalItem { get; set; }

        public bool SuppressMVVMLightEventToCommandMessage { get; set; }

        protected virtual void PrepareItem(TItem o)
        {
            if (o != null)
            {
                this.OriginalItem = o;
                this.Item = o;
            }
        }

        #region ViewDetails

        public RelayCommand<TItem> LaunchDetailsViewCommand { get; protected set; }

        protected virtual void LaunchDetailsView(TItem o)
        {
            string viewName = ViewName_Details;
            Framework.UIAction uiAction = Framework.UIAction.ViewDetails;

            PrepareItem(o);

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Launch));
        }

        public RelayCommand CloseDetailsViewCommand { get; protected set; }

        protected void CloseDetailsView()
        {
            string viewName = ViewName_Details;
            Framework.UIAction uiAction = Framework.UIAction.ViewDetails;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Close));
        }

        #endregion ViewDetails

        #region Copy

        public RelayCommand<TItem> LaunchCopyViewCommand { get; protected set; }

        protected virtual void LaunchCopyView(TItem o)
        {
            string viewName = ViewName_Details;
            Framework.UIAction uiAction = Framework.UIAction.Copy;

            PrepareItem(o);

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Launch));
        }

        #endregion Copy

        #region Save

        public RelayCommand<TItem> LaunchEditViewCommand { get; protected set; }

        protected virtual void LaunchEditView(TItem o)
        {
            string viewName = ViewName_Details;
            Framework.UIAction uiAction = Framework.UIAction.Update;

            PrepareItem(o);

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Launch));

            //this.RaiseItemPropertyChangedEvent();
        }

        public RelayCommand CloseEditViewCommand { get; protected set; }

        protected void CloseEditView()
        {
            string viewName = ViewName_Edit;
            Framework.UIAction uiAction = Framework.UIAction.Update;
            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Close));
        }

        public RelayCommand SaveCommand { get; protected set; }

        /// <summary>
        /// update an Entity
        /// </summary>
        protected abstract void Save();

        /// <summary>
        /// Determines whether you can save Entity
        /// </summary>
        /// <returns>
        ///     <c>true</c> if you can; otherwise, <c>false</c>.
        /// </returns>
        protected virtual bool CanSave()
        {
            return this.Item != null;
        }

        #endregion Save

        #region Add

        public RelayCommand LaunchCreateViewCommand { get; protected set; }

        protected void LaunchCreateView()
        {
            string viewName = ViewName_Create;
            Framework.UIAction uiAction = Framework.UIAction.Create;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Launch));
        }

        public RelayCommand CloseCreateViewCommand { get; protected set; }

        protected void CloseCreateView()
        {
            string viewName = ViewName_Create;
            Framework.UIAction uiAction = Framework.UIAction.Create;
            this.Item = new TItem();
            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Close));
        }

        public RelayCommand AddCommand { get; protected set; }

        /// <summary>
        /// Adds a Entity to the list and repo.
        /// </summary>
        protected abstract void Add();

        /// <summary>
        /// Determines whether you can create
        /// </summary>
        /// <returns>
        ///     <c>true</c> if you can; otherwise, <c>false</c>.
        /// </returns>
        protected bool CanAdd()
        {
            return true;
        }

        #endregion Add

        #region Delete

        public RelayCommand<TItem> LaunchDeleteViewCommand { get; protected set; }

        protected void LaunchDeleteView(TItem o)
        {
            string viewName = ViewName_Details;
            Framework.UIAction uiAction = Framework.UIAction.Delete;

            PrepareItem(o);

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Launch));
        }

        public RelayCommand CloseDeleteViewCommand { get; protected set; }

        protected void CloseDeleteView()
        {
            string viewName = ViewName_Delete;
            Framework.UIAction uiAction = Framework.UIAction.Delete;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Close));
        }

        public RelayCommand DeleteCommand { get; protected set; }

        /// <summary>,
        /// delete
        /// </summary>
        protected abstract void Delete();

        /// <summary>
        /// Determines whether you can delete an Entity
        /// </summary>
        /// <returns>
        ///     <c>true</c> if you can; otherwise, <c>false</c>.
        /// </returns>
        protected virtual bool CanDelete()
        {
            return this.Item != null;
        }

        #endregion Delete

        #region LoadItem

        public RelayCommand LoadItemCommand { get; protected set; }
        public RelayCommand<TSearchCriteria> LoadItemCommandTyped { get; protected set; }

        public virtual void LoadItem()
        {
            this.LoadItem(this.Criteria);
        }

        public abstract void LoadItem(TSearchCriteria identifier);

        public abstract void ReLoadItem(TItem o);

        #endregion LoadItem

        #region RefreshCurrentItemCommand

        public RelayCommand RefreshCurrentItemCommand { get; protected set; }

        protected virtual void RefreshItem()
        {
            string viewName = ViewName_Edit;
            Framework.UIAction uiAction = Framework.UIAction.Refresh;

            if (!this.SuppressMVVMLightEventToCommandMessage)
                Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Starting));
            RefreshItemNoMessage();

            if (!this.SuppressMVVMLightEventToCommandMessage)
                Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Success));
        }

        protected abstract void RefreshItemNoMessage();

        #endregion RefreshCurrentItemCommand

        #region string EntityName

        public abstract string EntityName { get; }

        #endregion string EntityName

        public const string ViewName_Edit = "Edit";
        public const string ViewName_Create = "Create";
        public const string ViewName_Delete = "Delete";
        public const string ViewName_Details = "Details";

        public override void Cleanup()
        {
            base.Cleanup();
            this.m_Item = new TItem();
            this.OriginalItem = new TItem();
        }

        public RelayCommand RaiseItemPropertyChangedEventCommand { get; protected set; }

        public void RaiseItemPropertyChangedEvent()
        {
            this.RaisePropertyChanged("Item");
        }
    }
}

