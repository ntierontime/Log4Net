//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Web.UI.WebControls;
//
//
//namespace Framework.Web
//{
//    public static class WebFormApplicationPickListWorker
//    {
//        public static void AddAll<TCollection, TItem, TID>(
//            ListBox leftListBox,
//            ListBox rightListBox,
//            string masterID,
//            string masterIDName,
//            string slaveIDName, 
//            Framework.DAL.DataAccessLayerPickListTemplateContract<TCollection> bllHelper,
//            Framework.DAL.DataAccessLayerContractBase<TCollection, TItem, TID> dal)
//            where TCollection : List<TItem>, new()
//            where TItem : class, new()
//        {
//            List<string> _SlaveIDs = GetAllIDStringValueFrom(leftListBox);
//            TCollection _ToBeInsertedEntityList = bllHelper.BuildCollectionFromStringValue(
//                masterIDName, masterID, slaveIDName, _SlaveIDs);
//            dal.BatchInsert(_ToBeInsertedEntityList);
//        }
//
//        public static void AddSelected<TCollection, TItem, TID>(
//            ListBox leftListBox,
//            ListBox rightListBox,
//            string masterID,
//            string masterIDName,
//            string slaveIDName,
//            Framework.DAL.DataAccessLayerPickListTemplateContract<TCollection> bllHelper,
//            Framework.DAL.DataAccessLayerContractBase<TCollection, TItem, TID> dal)
//            where TCollection : List<TItem>, new()
//            where TItem : class, new()
//        {
//            List<string> _SlaveIDs = GetSelectedIDStringValueFrom(leftListBox);
//            TCollection _ToBeInsertedEntityList = bllHelper.BuildCollectionFromStringValue(
//                masterIDName, masterID, slaveIDName, _SlaveIDs);
//            dal.BatchInsert(_ToBeInsertedEntityList);
//        }
//
//        public static void DeleteSelected<TCollection, TItem, TID>(
//            ListBox leftListBox,
//            ListBox rightListBox,
//            string masterID,
//            string masterIDName,
//            string slaveIDName,
//            Framework.DAL.DataAccessLayerPickListTemplateContract<TCollection> bllHelper,
//            Framework.DAL.DataAccessLayerContractBase<TCollection, TItem, TID> dal)
//            where TCollection : List<TItem>, new()
//            where TItem : class, new()
//        {
//            List<string> _SlaveIDs = GetSelectedIDStringValueFrom(rightListBox);
//            TCollection _ToBeDeletedEntityList = bllHelper.BuildCollectionFromStringValueWithSession(
//                masterIDName, masterID, slaveIDName, _SlaveIDs);
//            dal.BatchDelete(_ToBeDeletedEntityList);
//        }
//
//        public static void DeleteAll<TCollection, TItem, TID>(
//            ListBox leftListBox,
//            ListBox rightListBox,
//            string masterID,
//            string masterIDName,
//            string slaveIDName,
//            Framework.DAL.DataAccessLayerPickListTemplateContract<TCollection> bllHelper,
//            Framework.DAL.DataAccessLayerContractBase<TCollection, TItem, TID> dal)
//            where TCollection : List<TItem>, new()
//            where TItem : class, new()
//        {
//            List<string> _SlaveIDs = GetAllIDStringValueFrom(rightListBox);
//            TCollection _ToBeDeletedEntityList = bllHelper.BuildCollectionFromStringValueWithSession(
//                masterIDName, masterID, slaveIDName, _SlaveIDs);
//            dal.BatchDelete(_ToBeDeletedEntityList);
//        }
//
//        public static List<string> GetAllIDStringValueFrom(
//            ListBox listBox)
//        {
//            List<string> _retval;
//
//            if (listBox.Items != null && listBox.Items.Count > 0)
//            {
//                _retval = new List<string>();
//                foreach (ListItem _AListItem in listBox.Items)
//                {
//                    _retval.Add(_AListItem.Value);
//                }
//            }
//            else
//            {
//                _retval = null;
//            }
//
//            return _retval;
//        }
//
//        public static List<string> GetSelectedIDStringValueFrom(
//            ListBox listBox)
//        {
//            List<string> _retval;
//
//            if (listBox.Items != null && listBox.Items.Count > 0)
//            {
//                _retval = new List<string>();
//                foreach (ListItem _AListItem in listBox.Items)
//                {
//                    if (_AListItem.Selected == true)
//                    {
//                        _retval.Add(_AListItem.Value);
//                    }
//                }
//                if (_retval.Count <= 0)
//                {
//                    _retval = null;
//                }
//            }
//            else
//            {
//                _retval = null;
//            }
//
//            return _retval;
//        }
//    }
//}