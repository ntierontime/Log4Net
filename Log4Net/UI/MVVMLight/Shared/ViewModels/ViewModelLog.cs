using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Messaging;

namespace Log4Net.ViewModels
{

    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// After 2014-01-31 is Asyncronized Wcf Method call
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class WPCommonOfLogVM
		: Framework.Xaml.ViewModelBaseWithResultAndUIElement<Log4Net.CommonBLLEntities.BusinessLogicLayerChainedQueryCriteriaEntityLogCommon, Log4Net.DataSourceEntities.LogCollection, Log4Net.DataSourceEntities.Log>
    {
        #region fields and properties

        public const string EntityName_Static = "WPCommonOfLogVM";
		
        #endregion fields and properties
		
        #region Implement abstract EntityName

        public override string EntityName
        {
            get
            {
                return EntityName_Static;
            }
        }

        #endregion Implement abstract EntityName

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ViewModelLog class.
        /// </summary>
        public WPCommonOfLogVM()
        {
            this.RefreshNewItem();
			
			this.EntityCollection = new ObservableCollection<Log4Net.DataSourceEntities.Log>();



            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real": Connect to service, etc...
            ////}
        }

        #endregion Constructor

		#region RefreshCurrentEditingItem

        protected override void RefreshCurrentEditingItem()
        {
            string viewName = ViewName_Edit;
            Framework.UIAction uiAction = Framework.UIAction.Refresh;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Starting));

            if (this.m_Current != null)
            {
                this.CurrentInEditing = this.Current.GetAClone(); //Log4Net.EntityContracts.ILogHelper.Clone<Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.Log>(this.m_Current);
            }
            else
            {
                this.CurrentInEditing = null;
            }

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Success));
        }

		#endregion RefreshCurrentEditingItem

		#region RefreshNewItem

        protected override void RefreshNewItem()
        {
            string viewName = ViewName_Create;
            Framework.UIAction uiAction = Framework.UIAction.Refresh;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Starting));

            this.NewItem = new Log4Net.DataSourceEntities.Log {  };

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Success));
        }

		#endregion RefreshNewItem

        #region ClearSearchResult

        /// <summary>
        /// Clears the search result in this.EntityCollection.
        /// </summary>
        protected override void ClearSearchResult()
        {
			string viewName = ViewName_SearchResult;
			Framework.UIAction uiAction = Framework.UIAction.ClearResult;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Starting));

            this.m_EntityCollection.Clear();

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Success));
        }

        #endregion ClearSearchResult
		
        #region Copy

        protected override void PrepareCopyView()
        {
            this.NewItem = this.Current.GetAClone();
        }

        #endregion Copy

		#region Save
		
        /// <summary>
        /// update a Log4Net.DataSourceEntities.Log.
        /// </summary>
        protected override void Save()
        {
            #region Asyncronized wcf method call

			string viewName = ViewName_Edit;
			Framework.UIAction uiAction = Framework.UIAction.Update;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Starting));

            Log4Net.WcfContracts.WcfServiceContractAsynLog _Instance = Log4Net.WcfContracts.WcfServiceResolverAsyn.ResolveWcfServiceLog();

            AsyncCallback asyncCallback = delegate(IAsyncResult result)
            {
#if WINDOWS_PHONE
				DispatcherHelper.Initialize();
#endif
                try
                {
					DispatcherHelper.CheckBeginInvokeOnUI((Action)delegate()
					{
						var responseMessage = _Instance.EndUpdateEntity(result);
						// reload saved default
	                    this.Search();
						Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Success));
					});
                }
                catch (Exception ex)
                {
					DispatcherHelper.CheckBeginInvokeOnUI((Action)delegate()
					{
						Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Failed, ex.Message));
					});
                }
            };

            try
            {
#if WINDOWS_PHONE
                AssignSelectedValueFromSelectedItemToEntity(this.m_CurrentInEditing);
#endif

                Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog()
				{
					Critieria = new Log4Net.DataSourceEntities.LogCollection(),
					BusinessLogicLayerRequestID = Guid.NewGuid().ToString(),
                    BusinessLogicLayerRequestTypes = Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Update,
				};
                _Request.Critieria.Add(Log4Net.EntityContracts.ILogHelper.Clone<Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.Log>(this.m_CurrentInEditing));
				_Instance.BeginUpdateEntity(_Request, asyncCallback, null);
            }
            catch (Exception ex)
            {
				Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Failed, ex.Message));
            }

            #endregion Asyncronized wcf method call

            #region Syncronized wcf method call -- not in use/WPF only

            /*
            Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.UpdateEntity(this.m_Current);
			*/

            #endregion Syncronized wcf method call -- not in use/WPF only

        }

        /// <summary>
        /// Determines whether you can save Log4Net.DataSourceEntities.Log.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if you can; otherwise, <c>false</c>.
        /// </returns>
        protected override bool CanSave()
        {
            return this.m_Current != null;
        }

		#endregion Save
		
		#region Add

        /// <summary>
        /// Adds a Log4Net.DataSourceEntities.Log to the list and repo.
        /// </summary>
        protected override void Add()
        {
			#region Asyncronized wcf method call

			string viewName = ViewName_Create;
			Framework.UIAction uiAction = Framework.UIAction.Create;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Starting));
			            
			Log4Net.WcfContracts.WcfServiceContractAsynLog _Instance = Log4Net.WcfContracts.WcfServiceResolverAsyn.ResolveWcfServiceLog();

            AsyncCallback asyncCallback = delegate(IAsyncResult result)
            {
#if WINDOWS_PHONE
				DispatcherHelper.Initialize();
#endif
                try
                {
					DispatcherHelper.CheckBeginInvokeOnUI((Action)delegate()
					{
						var responseMessage = _Instance.EndInsertEntity(result);

						//// reload default
						this.Search();

						Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Success));
	                });
                }
                catch (Exception ex)
                {
					DispatcherHelper.CheckBeginInvokeOnUI((Action)delegate()
					{
						Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Failed, ex.Message));
	                });
                }
            };


            try
            {
#if WINDOWS_PHONE
                AssignSelectedValueFromSelectedItemToEntity(this.m_NewItem);
#endif

                Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog()
				{
					Critieria = new Log4Net.DataSourceEntities.LogCollection(),
					BusinessLogicLayerRequestID = Guid.NewGuid().ToString(),
                    BusinessLogicLayerRequestTypes = Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Create,
				};
                _Request.Critieria.Add(Log4Net.EntityContracts.ILogHelper.Clone<Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.Log>(this.m_NewItem));
				_Instance.BeginInsertEntity(_Request, asyncCallback, null);
            }
            catch (Exception ex)
            {
				Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Failed, ex.Message));
            }

            #endregion Asyncronized wcf method call

            #region Syncronized wcf method call -- not in use/WPF only

            /*
            Log4Net.DataSourceEntities.Log _NewItem = new Log4Net.DataSourceEntities.Log();
            this.m_EntityCollection.Add(_NewItem);
            Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.InsertEntity(_NewItemDefault);
			*/

            #endregion Syncronized wcf method call -- not in use/WPF only
        }

		#endregion Add

		#region Delete

        /// <summary>,
        /// delete a Log4Net.DataSourceEntities.Log.
        /// </summary>
        protected override void Delete()
        {
			#region Asyncronized wcf method call

			string viewName = ViewName_Delete;
			Framework.UIAction uiAction = Framework.UIAction.Delete;            

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Starting));

			Log4Net.WcfContracts.WcfServiceContractAsynLog _Instance = Log4Net.WcfContracts.WcfServiceResolverAsyn.ResolveWcfServiceLog();

            AsyncCallback asyncCallback = delegate(IAsyncResult result)
            {
#if WINDOWS_PHONE
				DispatcherHelper.Initialize();
#endif
                try
                {
					DispatcherHelper.CheckBeginInvokeOnUI((Action)delegate()
					{
						var responseMessage = _Instance.EndDeleteEntity(result);

						this.Search();

						Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Success));
	                });
				}
                catch (Exception ex)
                {
					DispatcherHelper.CheckBeginInvokeOnUI((Action)delegate()
					{
						Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Failed, ex.Message));
	                });
                }
            };

            try
            {
#if WINDOWS_PHONE
                AssignSelectedValueFromSelectedItemToEntity(this.m_CurrentInEditing);
#endif

                Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageBuiltInLog()
				{
		            Critieria = new Log4Net.DataSourceEntities.LogCollection(),
					BusinessLogicLayerRequestID = Guid.NewGuid().ToString(),
                    BusinessLogicLayerRequestTypes = Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Delete,
				};
                _Request.Critieria.Add(Log4Net.EntityContracts.ILogHelper.Clone<Log4Net.DataSourceEntities.Log, Log4Net.DataSourceEntities.Log>(this.m_Current));
				_Instance.BeginDeleteEntity(_Request, asyncCallback, null);
            }
            catch (Exception ex)
            {
				Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Failed, ex.Message));
			}

            #endregion Asyncronized wcf method call

            #region Syncronized wcf method call -- not in use/WPF only

            /*
            Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.DeleteEntity(this.m_Current);//
            this.m_EntityCollection.Remove(this.m_Current);
			*/

            #endregion Syncronized wcf method call -- not in use/WPF only
        }

        /// <summary>
        /// Determines whether you can delete a Log4Net.DataSourceEntities.Log.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if you can; otherwise, <c>false</c>.
        /// </returns>
        protected override bool CanDelete()
        {
            return this.m_Current != null;
        }

		#endregion Delete

#if WINDOWS_PHONE
        /// <summary>
        /// Set entity property value from Selected value which parse from selected item.
        /// </summary>
        /// <param name="entity">The entity.</param>
        private void AssignSelectedValueFromSelectedItemToEntity(Log4Net.DataSourceEntities.Log entity)
        {

        }	
#endif


        #region Implement abstract Search

        protected override void Search()
        {
            this.SearchStatus = Framework.EntityContracts.SearchStatus.Searching;

            #region Asyncronized wcf method call

            string viewName = ViewName_SearchResult;
            Framework.UIAction uiAction = Framework.UIAction.Search;

            Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Starting));

            Log4Net.WcfContracts.WcfServiceContractAsynLog _Instance = Log4Net.WcfContracts.WcfServiceResolverAsyn.ResolveWcfServiceLog();

            AsyncCallback asyncCallback = delegate(IAsyncResult result)
            {
#if WINDOWS_PHONE
				DispatcherHelper.Initialize();
#endif
                try
                {
					DispatcherHelper.CheckBeginInvokeOnUI((Action)delegate()
					{
						var responseMessage = _Instance.EndGetCollectionOfEntityOfCommon(result);
						Log4Net.DataSourceEntities.LogCollection collection = responseMessage.Message;

						if (this.m_EntityCollection == null)
						{
							this.m_EntityCollection = new ObservableCollection<Log4Net.DataSourceEntities.Log>();
						}

#if WINDOWS_PHONE
                        if (this.IsToClearExistingCollection)
                        {
                            this.m_EntityCollection.Clear();
                        }
#endif

						if (collection != null)
						{
							foreach (Log4Net.DataSourceEntities.Log item in collection)
							{
								this.m_EntityCollection.Add(item);
						    }
						}


                        if (responseMessage.QueryPagingResult != null)
                        {
                            this.QueryPagingSetting = GetQueryPagingSettingFromQueryPagingResult(responseMessage.QueryPagingResult);

#if WINDOWS_PHONE
                            if (!this.IsToClearExistingCollection && this.QueryPagingSetting.CurrentPage <= this.QueryPagingSetting.CountOfPages)
                            {
                                this.QueryPagingSetting.CurrentPage++;
                            }
#endif
                        }

                        this.SearchStatus = Framework.EntityContracts.SearchStatus.SearchResultLoaded;

						Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Success));
                    });
				}
                catch (Exception ex)
                {
					DispatcherHelper.CheckBeginInvokeOnUI((Action)delegate()
					{
						Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Failed, ex.Message));
                    });
                }
            };

            try
            {

                Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon _Request = new Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon()
				{
					Critieria = this.Criteria,
					QueryPagingSetting = this.QueryPagingSetting,
					QueryOrderBySettingCollection = this.QueryOrderBySettingCollection,
					BusinessLogicLayerRequestID = Guid.NewGuid().ToString(),
                    BusinessLogicLayerRequestTypes = Framework.CommonBLLEntities.BusinessLogicLayerRequestTypes.Search,
				};

                _Instance.BeginGetCollectionOfEntityOfCommon(_Request, asyncCallback, null);
            }
            catch (Exception ex)
            {
				Messenger.Default.Send<Framework.UIActionStatusMessage>(new Framework.UIActionStatusMessage(EntityName, viewName, uiAction, Framework.UIActionStatus.Failed, ex.Message));
            }

            #endregion Asyncronized wcf method call

            #region Syncronized wcf method call -- not in use/WPF only

            /*
            if (this.m_EntityCollection == null)
            {
                this.m_EntityCollection = new ObservableCollection<Log4Net.DataSourceEntities.Log>();
            }

            this.m_EntityCollection.Clear();

            Log4Net.DataSourceEntities.LogCollection collection = Log4Net.CommonBLLIoC.BusinessLogicLayerEntityStaticLog.GetCollectionOfEntityOfCommon(m_CriteriaOfGetCollectionOfEntityOfCommon, this.m_QueryPagingSetting, this.m_QueryOrderBySettingCollection);
            if(collection != null)
            {
                foreach (Log4Net.DataSourceEntities.Log item in collection)
                {
                    this.m_EntityCollection.Add(item);
                }
            }
            */
            #endregion Syncronized wcf method call -- not in use/WPF only
        }

#if WINDOWS_PHONE
        ///// <summary>
        ///// Assigns the selected value from selected item to critieria of get collection of default of common.
		///// -- Please Implement for Windows Phone 71.
        ///// </summary>
        ////private void AssignSelectedValueFromSelectedItemToCritieriaOfGetCollectionOfEntityOfCommon()
        //{
		//	// this.m_CriteriaOfGetCollectionOfEntityOfCommon
        //}
#endif

        #endregion Implement abstract Search



        public override Framework.NameValueCollection GetDefaultListOfQueryOrderBySettingCollecionInString()
        {
            Framework.NameValueCollection list = new Framework.NameValueCollection();
            list.Add("{0}~ASC", "{0} A-Z");
					list.Add("{0}~DESC", "{0} Z-A");
            return list;
        }

    }



}


