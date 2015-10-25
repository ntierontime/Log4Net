using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace Framework
{
    /// <summary>
    /// Some common methods for <see cref="BinaryFile"/>
    /// </summary>
    public class BinaryFileHelper
    {

		#region fields and properties

        /// <summary>
        /// Name in appsetting section in app.config or web.config
        /// </summary>
        static string AppConfigName_RootFolder = "FileRelativeRootFolder";
        /// <summary>
        /// Gets or sets the root folder.
        /// </summary>
        /// <value>
        /// The root folder.
        /// </value>
        public static string RootFolder { get; set; }

		#endregion fields and properties

		#region constructors

        /// <summary>
        /// Initializes the <see cref="BinaryFileHelper"/> class.
        /// </summary>
		static BinaryFileHelper()
        {
            //RootFolder = ConfigurationManager.AppSettings[AppConfigName_RootFolder];
        }

		#endregion constructors


        /// <summary>
        /// Gets the binary file response message when entity not exists.
        /// </summary>
        /// <param name="binaryFileActionType">Type of the binary file action.</param>
        /// <param name="id">The id.</param>
        /// <param name="entityName">Name of the entity.</param>
        /// <returns>a new instance of <see cref="BinaryFileResponseMessage"/></returns>
		public static BinaryFileResponseMessage GetBinaryFileResponseMessageWhenEntityNotExists(
            BinaryFileActionTypes binaryFileActionType
            , string id
            , string entityName)
        {
            BinaryFileResponseMessage _retval = new BinaryFileResponseMessage();

            _retval.IsBinaryFileActionSuccess = false;
            _retval.BinaryFileActionType = binaryFileActionType;
            _retval.ActionLogs = new string[] { string.Format("Entity of Identifier {0} in {1} not exists", id, entityName) };

            return _retval;
        }

        /// <summary>
        /// Builds the binary file response message.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="fileNameWithoutExtension">The file name without extension.</param>
        /// <param name="fileExtension">The file extension.</param>
        /// <param name="_Binary">The _ binary.</param>
        /// <returns>a new instance of <see cref="BinaryFileResponseMessage"/></returns>
		public static BinaryFileResponseMessage BuildBinaryFileResponseMessage(
            string id
            , string entityName
            , string fileName
            , byte[] _Binary)
        {
            return BuildBinaryFileResponseMessage(id, entityName, fileName, "application/octet-stream", _Binary);
        }
		
        /// <summary>
        /// Builds the binary file response message.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="mimeType">Type of the MIME.</param>
        /// <param name="_Binary">The binary.</param>
        /// <returns></returns>
        public static BinaryFileResponseMessage BuildBinaryFileResponseMessage(
            string id
            , string entityName
            , string fileName
            , string mimeType
            , byte[] _Binary)
        {
            return BuildBinaryFileResponseMessage(id, entityName, fileName, mimeType, fileName, _Binary);
        }

        /// <summary>
        /// Builds the binary file response message.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="mimeType">Type of the MIME.</param>
        /// <param name="physicalFileName">Name of the physical file.</param>
        /// <param name="_Binary">The _ binary.</param>
        /// <returns></returns>
        public static BinaryFileResponseMessage BuildBinaryFileResponseMessage(
            string id
            , string entityName
            , string fileName
            , string mimeType
            , string physicalFileName
            , byte[] _Binary)
        {
            BinaryFileResponseMessage _retval;
            _retval = new BinaryFileResponseMessage();
            _retval.BinaryFileActionType = BinaryFileActionTypes.Load;
            _retval.IsBinaryFileActionSuccess = true;
            _retval.BinaryFile = new BinaryFile(fileName, mimeType, physicalFileName, _Binary);
            _retval.ActionLogs = new string[] { string.Format("Database Success when load Entity of Identifier {0} in {1}", id, entityName) };
            return _retval;
        }

        /// <summary>
        /// Gets the binary file response message when database failed.
        /// </summary>
        /// <param name="binaryFileActionType">Type of the binary file action.</param>
        /// <param name="id">The id.</param>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="message">The message.</param>
        /// <returns>a new instance of <see cref="BinaryFileResponseMessage"/></returns>
        public static BinaryFileResponseMessage GetBinaryFileResponseMessageWhenDatabaseFailed(
            BinaryFileActionTypes binaryFileActionType
            , string id
            , string entityName
            , string message)
        {
            BinaryFileResponseMessage _retval = new BinaryFileResponseMessage();

            _retval.IsBinaryFileActionSuccess = false;
            _retval.BinaryFileActionType = binaryFileActionType;
            _retval.ActionLogs = new string[] { string.Format("Database failed when Entity of Identifier {0} in {1}, Details: {2}", id, entityName, message) };

            return _retval;
        }                  

#if WINDOWS_PHONE
#elif NETFX_CORE
#else
        /// <summary>
        /// Loads the binary in file system.
        /// </summary>
        /// <param name="physicalFileFullPath">The physical file full path.</param>
        /// <param name="fileNameWithoutExtention">The file name without extention.</param>
        /// <param name="fileExtension">The file extension.</param>
        /// <returns>a new instance of <see cref="BinaryFileResponseMessage"/></returns>
        public static BinaryFileResponseMessage LoadBinaryInFileSystem(string physicalFileFullPath, string fileName)
        {
            BinaryFileResponseMessage _retval = new BinaryFileResponseMessage();
            _retval.BinaryFileActionType = BinaryFileActionTypes.Load;

            if (File.Exists(physicalFileFullPath) == true)
            {
                _retval.BinaryFile = new BinaryFile(
                    fileName
                    , File.ReadAllBytes(physicalFileFullPath));

                _retval.IsBinaryFileActionSuccess = true;
            }
            else
            {
                _retval.IsBinaryFileActionSuccess = false;
            }

            return _retval;
        }

        /// <summary>
        /// Saves the binary file.
        /// </summary>
        /// <param name="physicalFileFullPath">The physical file full path.</param>
        /// <param name="input">The input.</param>
        /// <returns>a new instance of <see cref="BinaryFileResponseMessage"/></returns>
        public static BinaryFileResponseMessage SaveBinaryFile(string physicalFileFullPath, BinaryFile input)
        {
            BinaryFileResponseMessage _retval = new BinaryFileResponseMessage();

            _retval.BinaryFile = input;
            _retval.BinaryFileActionType = BinaryFileActionTypes.Save;

            List<string> _ActionLog = new List<string>();
            string _Folder = System.IO.Path.GetDirectoryName(physicalFileFullPath);
            if (System.IO.Directory.Exists(_Folder) == false)
            {
                _ActionLog.Add(string.Format(@"New folder ""{0}"" created", _Folder));
            }

            try
            {
                if (File.Exists(physicalFileFullPath) == true)
                {
                    System.IO.File.Delete(physicalFileFullPath);
                    _ActionLog.Add(string.Format(@"Original File ""{0}"" Deleted", physicalFileFullPath));
                }

                System.IO.File.WriteAllBytes(physicalFileFullPath, input.FileContent);

                _ActionLog.Add(string.Format(@"File ""{0}"" Created", physicalFileFullPath));
            }
            catch (Exception exception)
            {
                _ActionLog.Add(string.Format(@"Creation of File ""{0}"" failed, for details: \r\n {1}", physicalFileFullPath, exception.Message));
            }
            _retval.ActionLogs = _ActionLog.ToArray();

            return _retval;
        }
		

        /// <summary>
        /// Deletes the binary file.
        /// </summary>
        /// <param name="physicalFileFullPath">The physical file full path.</param>
        /// <returns>a new instance of <see cref="BinaryFileResponseMessage"/></returns>
        public static BinaryFileResponseMessage DeleteBinaryFile(string physicalFileFullPath)
        {
            BinaryFileResponseMessage _retval = new BinaryFileResponseMessage();

            _retval.BinaryFileActionType = BinaryFileActionTypes.Delete;

            List<string> _ActionLog = new List<string>();

            try
            {
                if (File.Exists(physicalFileFullPath) == true)
                {
                    System.IO.File.Delete(physicalFileFullPath);
                    _ActionLog.Add(string.Format(@"Original File ""{0}"" Deleted", physicalFileFullPath));
                }
            }
            catch (Exception exception)
            {
                _ActionLog.Add(string.Format(@"Deletion of File ""{0}"" failed, for details: \r\n {1}", physicalFileFullPath, exception.Message));
            }
            _retval.ActionLogs = _ActionLog.ToArray();

            return _retval;
        }

#endif

        #region BuildCSharpName(string input)

        /// <summary>
        /// Builds the name of the Csharp, in case of invalid chars for a filename.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>converted CSharpName</returns>
		public static string BuildCSharpName(string input)
        {
            if (string.IsNullOrEmpty(input) == false)
            {
                string _retval = input.Replace(" ", "_");
                _retval = _retval.Replace("\t", "_");
                _retval = _retval.Replace("~", "_");
                _retval = _retval.Replace("`", "_");
                _retval = _retval.Replace("!", "_");
                _retval = _retval.Replace("@", "_");
                _retval = _retval.Replace("#", "_");
                _retval = _retval.Replace("$", "_");
                _retval = _retval.Replace("%", "_");
                _retval = _retval.Replace("^", "_");
                _retval = _retval.Replace("&", "_");
                _retval = _retval.Replace("*", "_");
                _retval = _retval.Replace("(", "_");
                _retval = _retval.Replace(")", "_");
                _retval = _retval.Replace("-", "_");
                _retval = _retval.Replace("+", "_");
                _retval = _retval.Replace("=", "_");
                _retval = _retval.Replace("[", "_");
                _retval = _retval.Replace("]", "_");
                _retval = _retval.Replace("{", "_");
                _retval = _retval.Replace("}", "_");
                _retval = _retval.Replace(";", "_");
                _retval = _retval.Replace(":", "_");
                _retval = _retval.Replace("'", "_");
                _retval = _retval.Replace("\"", "_");
                _retval = _retval.Replace("\\", "_");
                _retval = _retval.Replace("|", "_");
                _retval = _retval.Replace(".", "_");
                _retval = _retval.Replace(",", "_");
                _retval = _retval.Replace("<", "_");
                _retval = _retval.Replace(">", "_");
                _retval = _retval.Replace("/", "_");
                _retval = _retval.Replace("?", "_");
                return _retval;
            }
            else
            {
                return null;
            }
        }

        #endregion BuildCSharpName(string input)

        /// <summary>
        /// Builds the physical file name of binary property setting.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="datetime">The datetime.</param>
        /// <param name="originalFileName">Name of the original file.</param>
        /// <returns></returns>
        public static string BuildPhysicalFileNameOfBinaryPropertySetting(string tableName, string propertyName, string id, DateTime datetime, string originalFileName)
        {
            string retval = string.Format("{0}_{1}_{2}_{3}_{4}", tableName, propertyName, id, datetime.ToString("yyyyMMddHHmmss"), originalFileName);
            return retval;
        }

        /// <summary>
        /// Builds the physical file full path.
        /// </summary>
        /// <param name="relativePath">The relative path.</param>
        /// <param name="fileNameWithoutExtension">The file name without extension.</param>
        /// <param name="fileExtension">The file extension.</param>
        /// <returns>physical file fullpath</returns>
        public static string BuildPhysicalFileFullPath(string relativePath, string fileNameWithoutExtension, string fileExtension)
        {
            string _retval = RootFolder;
            _retval = System.IO.Path.Combine(RootFolder, relativePath);
            _retval = System.IO.Path.Combine(_retval, System.IO.Path.ChangeExtension(BuildCSharpName(fileNameWithoutExtension), fileExtension));
            return _retval;
        }
		
        /// <summary>
        /// Builds the physical file full path.
        /// </summary>
        /// <param name="relativePath">The relative path.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static string BuildPhysicalFileFullPath(string relativePath, string fileName)
        {
            string _retval = RootFolder;
            _retval = System.IO.Path.Combine(RootFolder, relativePath);
            _retval = System.IO.Path.Combine(_retval, fileName);
            return _retval;
        }
    }
}

