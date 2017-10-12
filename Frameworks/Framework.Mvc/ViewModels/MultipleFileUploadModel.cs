using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Framework.Mvc
{
    public class MultipleFileUploadModel<TMasterEntity, TCriteriaOfMasterEntity> : Framework.ViewModels.ViewModelEntityRelatedBase<TMasterEntity, TCriteriaOfMasterEntity>
        where TMasterEntity : class, new()
        where TCriteriaOfMasterEntity : class, new()
    {
        public MultipleFileUploadModel(TCriteriaOfMasterEntity criteriaOfMasterEntity)
            : base(criteriaOfMasterEntity)
        {
        }
        public string FilesToBeUploaded { get; set; }
        public List<HttpPostedFileBase> FileUploads { get; set; }

    }

}

