using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Mvc
{
    public class ViewModelEntityRelatedBase<TMasterEntity, TCriteriaOfMasterEntity, TStatusOfLoadMasterEntity> : IViewModelEntityRelatedBase<TMasterEntity, TCriteriaOfMasterEntity, TStatusOfLoadMasterEntity>
        where TMasterEntity : class, new()
        where TCriteriaOfMasterEntity : class, new()
    {
        public ViewModelEntityRelatedBase(TCriteriaOfMasterEntity criteriaOfMasterEntity)
        {
            this.CriteriaOfMasterEntity = criteriaOfMasterEntity;
            this.QueryPagingSetting = new Framework.EntityContracts.QueryPagingSetting(1, 10);
			this.QueryPagingSettingOneRecord = new Framework.EntityContracts.QueryPagingSetting(1, 1);
        }

        public TMasterEntity MasterEntity { get; set; }
        public TCriteriaOfMasterEntity CriteriaOfMasterEntity { get; set; }
		public TStatusOfLoadMasterEntity StatusOfMasterEntity { get; set; }
		public string StatusMessageOfMasterEntity { get; set; }

		public Framework.EntityContracts.QueryPagingSetting QueryPagingSetting { get; set; }
        public Framework.EntityContracts.QueryPagingSetting QueryPagingSettingOneRecord { get; set; }
    }

    interface IViewModelEntityRelatedBase<TMasterEntity, TCriteriaOfMasterEntity, TStatusOfLoadMasterEntity>
        where TMasterEntity : class, new()
        where TCriteriaOfMasterEntity : class, new()
    {
        TMasterEntity MasterEntity { get; set; }
		TCriteriaOfMasterEntity CriteriaOfMasterEntity { get; set; }
		TStatusOfLoadMasterEntity StatusOfMasterEntity { get; set; }
		string StatusMessageOfMasterEntity { get; set; }
        Framework.EntityContracts.QueryPagingSetting QueryPagingSetting { get; set; }
		Framework.EntityContracts.QueryPagingSetting QueryPagingSettingOneRecord { get; set; }
    }
}