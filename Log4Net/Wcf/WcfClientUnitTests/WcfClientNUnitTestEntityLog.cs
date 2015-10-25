using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Log4Net.WcfClientUnitTests
{
    [TestClass]
    public class WcfClientNUnitTestEntityLog 
	{
		#region constructors
        
        public WcfClientNUnitTestEntityLog ()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

		#endregion constructors

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        
        #region Framework.DAL.DataAccessLayerContractBase<Log4Net.DataSourceEntities.LogCollection,Log4Net.DataSourceEntities.Log,Log4Net.DataSourceEntities.LogIdentifier> Members

		[TestMethod]
        public void TestMethod_OnInsert()
        {
			Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			_Client.Insert(
				//System.Int64 id
				//, System.DateTime date
				//, System.String thread
				//, System.String level
				//, System.String logger
				//, System.String message
				//, System.String exception
				);
			*/
        }

		[TestMethod]
        public void TestMethod_OnUpdate()
        {
			Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			_Client.Update(
				//System.Int64 id
				//, System.DateTime date
				//, System.String thread
				//, System.String level
				//, System.String logger
				//, System.String message
				//, System.String exception
				);
			*/
        }

		[TestMethod]
        public void TestMethod_OnDelete()
        {
			//Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			_Client.Delete(
				//System.Int64 id
				//, System.DateTime date
				//, System.String thread
				//, System.String level
				//, System.String logger
				//, System.String message
				//, System.String exception
				);
			*/
        }

		[TestMethod]
        public void TestMethod_OnDeleteByIdentifier()
        {
			//Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			_Client.DeleteByIdentifier(
				//System.Int64 id
				);
			*/
        }
	
		[TestMethod]
        public void TestMethod_OnBatchInsert()
        {
			//Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			//Log4Net.DataSourceEntities.LogCollection input = new Log4Net.DataSourceEntities.LogCollection();
			//_Client.BatchInsert(input);
        }

		[TestMethod]
        public void TestMethod_OnBatchDelete()
        {
			//Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			//Log4Net.DataSourceEntities.LogCollection input = new Log4Net.DataSourceEntities.LogCollection();
			//_Client.BatchDelete(input);
        }
		
		[TestMethod]
        public void TestMethod_OnBatchUpdate()
        {
			//Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			//Log4Net.DataSourceEntities.LogCollection input = new Log4Net.DataSourceEntities.LogCollection();
			//_Client.BatchUpdate(input);
        }

        #endregion

		#region Binary Columns



        #endregion Binary Columns

		#region DataQueryPerQuerySettingCollection



        #region Query Methods Of Entity of Common 

		[TestMethod]
        public void TestMethod_OnGetCountOfEntityOfCommon()
        {
			Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Result = _Client.GetCountOfEntityOfCommon(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon request
			);
			*/
        }

		[TestMethod]
        public void TestMethod_OnExistsOfEntityOfCommon()
        {
			Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean _Result = _Client.ExistsOfEntityOfCommon(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon request
			);
			*/
        }

		[TestMethod]
        public void TestMethod_OnGetCollectionOfEntityOfCommon()
        {
			Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Result = _Client.GetCollectionOfEntityOfCommon(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon request
			);
			*/
        }

		[TestMethod]
        public void TestMethod_OnGetSingleOfEntityOfCommon()
        {
			Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Result = _Client.GetSingleOfEntityOfCommon(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfCommon request
			);
			*/
        }

        #endregion Query Methods Of Entity of Common 




        #region Query Methods Of Entity of All 

		[TestMethod]
        public void TestMethod_OnGetCountOfEntityOfAll()
        {
			Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Result = _Client.GetCountOfEntityOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request
			);
			*/
        }

		[TestMethod]
        public void TestMethod_OnExistsOfEntityOfAll()
        {
			Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean _Result = _Client.ExistsOfEntityOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request
			);
			*/
        }

		[TestMethod]
        public void TestMethod_OnGetCollectionOfEntityOfAll()
        {
			Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Result = _Client.GetCollectionOfEntityOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request
			);
			*/
        }

		[TestMethod]
        public void TestMethod_OnGetSingleOfEntityOfAll()
        {
			Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Result = _Client.GetSingleOfEntityOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request
			);
			*/
        }

        #endregion Query Methods Of Entity of All 




        #region Query Methods Of NameValuePair of All 

		[TestMethod]
        public void TestMethod_OnGetCountOfNameValuePairOfAll()
        {
			Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Result = _Client.GetCountOfNameValuePairOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request
			);
			*/
        }

		[TestMethod]
        public void TestMethod_OnExistsOfNameValuePairOfAll()
        {
			Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean _Result = _Client.ExistsOfNameValuePairOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request
			);
			*/
        }

		[TestMethod]
        public void TestMethod_OnGetCollectionOfNameValuePairOfAll()
        {
			Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection _Result = _Client.GetCollectionOfNameValuePairOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request
			);
			*/
        }

		[TestMethod]
        public void TestMethod_OnGetSingleOfNameValuePairOfAll()
        {
			Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageNameValuePairCollection _Result = _Client.GetSingleOfNameValuePairOfAll(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfAll request
			);
			*/
        }

        #endregion Query Methods Of NameValuePair of All 




        #region Query Methods Of Entity of ByIdentifier 

		[TestMethod]
        public void TestMethod_OnGetCountOfEntityOfByIdentifier()
        {
			Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Result = _Client.GetCountOfEntityOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request
			);
			*/
        }

		[TestMethod]
        public void TestMethod_OnExistsOfEntityOfByIdentifier()
        {
			Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean _Result = _Client.ExistsOfEntityOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request
			);
			*/
        }

		[TestMethod]
        public void TestMethod_OnGetCollectionOfEntityOfByIdentifier()
        {
			Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Result = _Client.GetCollectionOfEntityOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request
			);
			*/
        }

		[TestMethod]
        public void TestMethod_OnGetSingleOfEntityOfByIdentifier()
        {
			Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog _Result = _Client.GetSingleOfEntityOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request
			);
			*/
        }

        #endregion Query Methods Of Entity of ByIdentifier 




        #region Query Methods Of KeyInformation of ByIdentifier 

		[TestMethod]
        public void TestMethod_OnGetCountOfKeyInformationOfByIdentifier()
        {
			Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageInteger _Result = _Client.GetCountOfKeyInformationOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request
			);
			*/
        }

		[TestMethod]
        public void TestMethod_OnExistsOfKeyInformationOfByIdentifier()
        {
			Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			Framework.CommonBLLEntities.BusinessLogicLayerResponseMessageBoolean _Result = _Client.ExistsOfKeyInformationOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request
			);
			*/
        }

		[TestMethod]
        public void TestMethod_OnGetCollectionOfKeyInformationOfByIdentifier()
        {
			Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation _Result = _Client.GetCollectionOfKeyInformationOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request
			);
			*/
        }

		[TestMethod]
        public void TestMethod_OnGetSingleOfKeyInformationOfByIdentifier()
        {
			Log4Net.WcfClientBLL.WcfClientEntityLog _Client = new Log4Net.WcfClientBLL.WcfClientEntityLog();
			/*
			Log4Net.CommonBLLEntities.BusinessLogicLayerResponseMessageBuiltInLog.KeyInformation _Result = _Client.GetSingleOfKeyInformationOfByIdentifier(
			Log4Net.CommonBLLEntities.BusinessLogicLayerRequestMessageUserDefinedLogOfByIdentifier request
			);
			*/
        }

        #endregion Query Methods Of KeyInformation of ByIdentifier 




		#endregion DataQueryPerQuerySettingCollection

	}
}