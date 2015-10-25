namespace Log4Net.ViewModels
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

        private static Framework.Resources.UIStringResource m_Framework_Resources_UIStringResource = new Framework.Resources.UIStringResource();

        public Framework.Resources.UIStringResource Framework_Resources_UIStringResource { get { return m_Framework_Resources_UIStringResource; } }

        #endregion UIComponentResourceFile_String per solution

        #region UIComponentResourceFile_String_PerApplication per solution

        private static Log4Net.Resources.UIStringResourcePerApp m_Log4Net_Resources_UIStringResourcePerApp = new Log4Net.Resources.UIStringResourcePerApp();

        public Log4Net.Resources.UIStringResourcePerApp Log4Net_Resources_UIStringResourcePerApp { get { return m_Log4Net_Resources_UIStringResourcePerApp; } }

        #endregion UIComponentResourceFile_String_PerApplication per solution

        #region UIComponentResourceFile_String per entity

        private static Log4Net.Resources.UIStringResourcePerEntityLog m_Log4Net_Resources_UIStringResourcePerEntityLog = new Log4Net.Resources.UIStringResourcePerEntityLog();
        /// <summary>
        /// Gets the UI component resource file of string per entity - Log4Net.Resources.UIStringResourcePerEntityLog.
        /// </summary>
        /// <value>
        /// The UI component resource file of string per entity - Log4Net.Resources.UIStringResourcePerEntityLog.
        /// </value>
        public Log4Net.Resources.UIStringResourcePerEntityLog Log4Net_Resources_UIStringResourcePerEntityLog { get { return m_Log4Net_Resources_UIStringResourcePerEntityLog; } }


        #endregion UIComponentResourceFile_String per entity
    }
}