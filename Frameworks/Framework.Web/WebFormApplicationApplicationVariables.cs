using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Framework.Web
{
    /// <summary>
    /// container class of known application variables
    /// </summary>
    public static class WebFormApplicationApplicationVariables
    {
        #region properties

        /// <summary>
        /// application key of FileStorageRootFolder
        /// </summary>
        public static string Key_FileStorageRootFolder = "FileStorageRootFolder";
        /// <summary>
        /// Gets or sets the file storage root folder.
        /// </summary>
        /// <value>
        /// The file storage root folder.
        /// </value>
        public static string FileStorageRootFolder
        {
            get
            {
                return (string)HttpContext.Current.Application[Key_FileStorageRootFolder];
            }
            set
            {
                HttpContext.Current.Application[Key_FileStorageRootFolder] = value;
            }
        }

        /// <summary>
        /// application key of BinaryHandlerRootUrl
        /// </summary>
        public static string Key_BinaryHandlerRootUrl = "BinaryHandlerRootUrl";
        /// <summary>
        /// Gets or sets the binary handler root URL.
        /// </summary>
        /// <value>
        /// The binary handler root URL.
        /// </value>
        public static string BinaryHandlerRootUrl
        {
            get
            {
                return (string)HttpContext.Current.Application[Key_BinaryHandlerRootUrl];
            }
            set
            {
                HttpContext.Current.Application[Key_BinaryHandlerRootUrl] = value;
            }
        }

        /// <summary>
        /// application key of WebAppRootUrl
        /// </summary>
        public static string Key_WebAppRootUrl = "WebAppRootUrl";
        /// <summary>
        /// Gets or sets the WebAppRoot root URL.
        /// </summary>
        /// <value>
        /// WebAppRoot root URL.
        /// </value>
        public static string WebAppRootUrl
        {
            get
            {
                return (string)HttpContext.Current.Application[Key_WebAppRootUrl];
            }
            set
            {
                HttpContext.Current.Application[Key_WebAppRootUrl] = value;
            }
        }

        /// <summary>
        /// application key of MIMEContentTypeToFileExtensionMappingCollection
        /// </summary>
        public static string Key_MIMEContentTypeToFileExtensionMappingCollection = "MIMEContentTypeToFileExtensionMappingCollection";
        /// <summary>
        /// Gets or sets the MIME content type to file extension mapping collection.
        /// </summary>
        /// <value>
        /// The MIME content type to file extension mapping collection.
        /// </value>
        public static Framework.MIMEContentTypeToFileExtensionMappingCollection MIMEContentTypeToFileExtensionMappingCollection
        {
            get
            {
                return (Framework.MIMEContentTypeToFileExtensionMappingCollection)HttpContext.Current.Application[Key_MIMEContentTypeToFileExtensionMappingCollection];
            }
            set
            {
                HttpContext.Current.Application[Key_MIMEContentTypeToFileExtensionMappingCollection] = value;
            }
        }

        #endregion properties

        #region GetDefault()

        /// <summary>
        /// Gets the default.
        /// </summary>
        public static void GetDefault()
        {
            FileStorageRootFolder = System.Configuration.ConfigurationManager.AppSettings[Key_FileStorageRootFolder];
            BinaryHandlerRootUrl = System.Configuration.ConfigurationManager.AppSettings[Key_BinaryHandlerRootUrl];
            MIMEContentTypeToFileExtensionMappingCollection = Framework.MIMEContentTypeToFileExtensionMappingCollection.GetDefault();
        }

        #endregion GetDefault()

    }
}

