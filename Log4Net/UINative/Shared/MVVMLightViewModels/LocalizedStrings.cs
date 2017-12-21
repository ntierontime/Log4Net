namespace Log4Net.MVVMLightViewModels
{
    /// <summary>
    /// http://netprogrammingodyssey.wordpress.com/2011/01/10/localizing-in-silverlight/
    /// </summary>
    public class LocalizedStrings
    {
        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizedStrings"/> class.
        /// </summary>
        public LocalizedStrings()
        {
        }

        #endregion constructor

        #region UIComponentResourceFile_String per solution

        private static Framework.Resx.UIStringResource m_Framework_Resx_UIStringResource = Framework.Resx.ResourceFileFactory.GetUIStringResourceInstance();

        public Framework.Resx.UIStringResource Framework_Resx_UIStringResource { get { return m_Framework_Resx_UIStringResource; } }

        #endregion UIComponentResourceFile_String per solution

        #region UIComponentResourceFile_String_PerApplication per solution

        private static Log4Net.Resx.UIStringResourcePerApp m_Log4Net_Resx_UIStringResourcePerApp = Log4Net.Resx.ResourceFileFactory.GetUIStringResourcePerAppInstance();

        public Log4Net.Resx.UIStringResourcePerApp Log4Net_Resx_UIStringResourcePerApp { get { return m_Log4Net_Resx_UIStringResourcePerApp; } }

        #endregion UIComponentResourceFile_String_PerApplication per solution

        #region UIComponentResourceFile_String per entity

        private static Log4Net.Resx.UIStringResourcePerEntityLog m_Log4Net_Resx_UIStringResourcePerEntityLog = Log4Net.Resx.ResourceFileFactory.GetUIStringResourcePerEntityLog();
        /// <summary>
        /// Gets the UI component resource file of string per entity - Log4Net.Resx.UIStringResourcePerEntityLog.
        /// </summary>
        /// <value>
        /// The UI component resource file of string per entity - Log4Net.Resx.UIStringResourcePerEntityLog.
        /// </value>
        public Log4Net.Resx.UIStringResourcePerEntityLog Log4Net_Resx_UIStringResourcePerEntityLog { get { return m_Log4Net_Resx_UIStringResourcePerEntityLog; } }

        #endregion UIComponentResourceFile_String per entity
    }
}

