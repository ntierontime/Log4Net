namespace Log4Net.ViewModelData
{
    public class OrderByLists
    {

        #region 1.1. Log4Net.Log.WPCommonOfLog

        public static Framework.NameValueCollection WPCommonOfLogVM_GetDefaultListOfQueryOrderBySettingCollecionInString()
        {
            Framework.NameValueCollection list = new Framework.NameValueCollection();
            list.Add("Thread~ASC", "Thread A-Z");
                list.Add("Thread~DESC", "Thread Z-A");
            return list;
        }

        #endregion 1.1. Log4Net.Log.WPCommonOfLog

    }
}

