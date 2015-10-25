using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using NUnit.Framework;

namespace Log4Net.LinqDALNUnitTest
{
    [TestFixture]
    public class LinqToSqlDataAccessLayerEntityNUnitTestLog
    {

        #region Setup() and TearDown()

        [SetUp()]
        public void Init()
        {
            // some code here, that need to be run
            // at the start of every test case.
        }

        [TearDown()]
        public void Clean()
        {
            // code that will be called after each Test case
        }

        #endregion Setup() and TearDown()

        #region IDataAccessLayerContractBase<Log4Net.DataSourceEntities.LogCollection,Log4Net.DataSourceEntities.Log,Log4Net.DataSourceEntities.LogIdentifier> Members

		[Test]
        public void TestMethodOfInsert()
        {
            Log4Net.DALContracts.DataAccessLayerEntityContractLog _DALInstance = Log4Net.LinqDAL.LinqToSqlDataAccessLayerFactorySingleton.Instance.CreateDALInstanceOfLog();
            Log4Net.DataSourceEntities.Log _TestData = Log4Net.EntityContracts.ILogHelper.GetDefaultValue<Log4Net.DataSourceEntities.Log>();
            _DALInstance.Insert(_TestData);
            //Assert.IsTrue(_TestData.ID != 0);
        }
        [Test]
        public void TestMethodOfUpdate()
        {
            Log4Net.DALContracts.DataAccessLayerEntityContractLog _DALInstance = Log4Net.LinqDAL.LinqToSqlDataAccessLayerFactorySingleton.Instance.CreateDALInstanceOfLog();
            Log4Net.DataSourceEntities.Log _TestData = Log4Net.EntityContracts.ILogHelper.GetDefaultValue<Log4Net.DataSourceEntities.Log>();
            _DALInstance.Insert(_TestData);
            _DALInstance.Update(_TestData);
            Assert.IsTrue(true);
        }
        [Test]
        public void TestMethodOfDelete()
        {
            Log4Net.DALContracts.DataAccessLayerEntityContractLog _DALInstance = Log4Net.LinqDAL.LinqToSqlDataAccessLayerFactorySingleton.Instance.CreateDALInstanceOfLog();
            Log4Net.DataSourceEntities.Log _TestData = Log4Net.EntityContracts.ILogHelper.GetDefaultValue<Log4Net.DataSourceEntities.Log>();
            _DALInstance.Insert(_TestData);
            _DALInstance.Delete(_TestData);
            Assert.IsTrue(true);
        }
        [Test]
        public void TestMethodOfDeleteByIdentifier()
        {
            Log4Net.DALContracts.DataAccessLayerEntityContractLog _DALInstance = Log4Net.LinqDAL.LinqToSqlDataAccessLayerFactorySingleton.Instance.CreateDALInstanceOfLog();
            Log4Net.DataSourceEntities.Log _TestData = Log4Net.EntityContracts.ILogHelper.GetDefaultValue<Log4Net.DataSourceEntities.Log>();
            _DALInstance.Insert(_TestData);
            _DALInstance.DeleteByIdentifier(new Log4Net.DataSourceEntities.LogIdentifier(_TestData));
            Assert.IsTrue(true);
        }
        [Test]
        public void TestMethodOfBatchInsert()
        {
            Log4Net.DALContracts.DataAccessLayerEntityContractLog _DALInstance = Log4Net.LinqDAL.LinqToSqlDataAccessLayerFactorySingleton.Instance.CreateDALInstanceOfLog();
            Log4Net.DataSourceEntities.Log _TestData = Log4Net.EntityContracts.ILogHelper.GetDefaultValue<Log4Net.DataSourceEntities.Log>();
            Log4Net.DataSourceEntities.LogCollection _Collection = new Log4Net.DataSourceEntities.LogCollection();
            _Collection.Add(_TestData);
            _DALInstance.BatchInsert(_Collection);
            //Assert.IsTrue(_TestData.ID != 0);
        }
        [Test]
        public void TestMethodOfBatchDelete()
        {
            Log4Net.DALContracts.DataAccessLayerEntityContractLog _DALInstance = Log4Net.LinqDAL.LinqToSqlDataAccessLayerFactorySingleton.Instance.CreateDALInstanceOfLog();
            Log4Net.DataSourceEntities.Log _TestData = Log4Net.EntityContracts.ILogHelper.GetDefaultValue<Log4Net.DataSourceEntities.Log>();
            Log4Net.DataSourceEntities.LogCollection _Collection = new Log4Net.DataSourceEntities.LogCollection();
            _Collection.Add(_TestData);
            _DALInstance.BatchInsert(_Collection);
            _DALInstance.BatchUpdate(_Collection);
            Assert.IsTrue(true);
        }

        [Test]
        public void TestMethodOfBatchUpdate()
        {
            Log4Net.DALContracts.DataAccessLayerEntityContractLog _DALInstance = Log4Net.LinqDAL.LinqToSqlDataAccessLayerFactorySingleton.Instance.CreateDALInstanceOfLog();
            Log4Net.DataSourceEntities.Log _TestData = Log4Net.EntityContracts.ILogHelper.GetDefaultValue<Log4Net.DataSourceEntities.Log>();
            Log4Net.DataSourceEntities.LogCollection _Collection = new Log4Net.DataSourceEntities.LogCollection();
            _Collection.Add(_TestData);
            _DALInstance.BatchInsert(_Collection);
            _DALInstance.BatchDelete(_Collection);
            Assert.IsTrue(true);
        }

        #endregion
    }
}