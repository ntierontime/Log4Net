using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Framework
{
    /// <summary>
    /// BinaryFile class is a container of byte array.
    /// </summary>
    [DataContract]
	public class BinaryFile
    {
        #region constructors
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryFile"/> class.
        /// </summary>
        public BinaryFile()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryFile"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public BinaryFile(string fileName)
            : this(fileName, 0, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryFile"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileContent">Content of the file.</param>
        public BinaryFile(string fileName, byte[] fileContent)
            : this(fileName, "application/octet-stream", fileName, fileContent != null ? fileContent.Length : 0, fileContent)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryFile"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="contentLength">Length of the content.</param>
        /// <param name="fileContent">Content of the file.</param>
        public BinaryFile(string fileName, int contentLength, byte[] fileContent)
            : this(fileName, "application/octet-stream", fileName, contentLength, fileContent)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryFile"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="mimeType">Type of the MIME.</param>
        /// <param name="fileContent">Content of the file.</param>
        public BinaryFile(string fileName, string mimeType, byte[] fileContent)
            : this(fileName, mimeType, fileName, fileContent != null ? fileContent.Length : 0, fileContent)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryFile"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="mimeType">Type of the MIME.</param>
        /// <param name="contentLength">Length of the content.</param>
        /// <param name="fileContent">Content of the file.</param>
        public BinaryFile(string fileName, string mimeType, int contentLength, byte[] fileContent)
            : this(fileName, mimeType, fileName, contentLength, fileContent)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryFile"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="mimeType">Type of the MIME.</param>
        /// <param name="physicalFileName">Name of the physical file.</param>
        /// <param name="fileContent">Content of the file.</param>
        public BinaryFile(string fileName, string mimeType, string physicalFileName, byte[] fileContent)
            : this(fileName, mimeType, physicalFileName, fileContent != null ? fileContent.Length : 0, fileContent)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryFile"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="mimeType">Type of the MIME.</param>
        /// <param name="physicalFileName">Name of the physical file.</param>
        /// <param name="contentLength">Length of the content.</param>
        /// <param name="fileContent">Content of the file.</param>
        public BinaryFile(string fileName, string mimeType, string physicalFileName, int contentLength, byte[] fileContent)
        {
            this.FileName = fileName;
            this.MIMEType = mimeType;
            this.PhysicalFileName = physicalFileName;
            this.FileContent = fileContent;
            this.ContentLength = contentLength;
        }

        #endregion constructors

        #region properties


        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        [DataMember]
        public string FileName { get; set; }
        
        /// <summary>
        /// Gets or sets the type of the MIME.
        /// </summary>
        /// <value>
        /// The type of the MIME.
        /// </value>
        [DataMember]
        public string MIMEType { get; set; }

        /// <summary>
        /// Gets or sets the name of the physical file.
        /// </summary>
        /// <value>
        /// The name of the physical file.
        /// </value>
        [DataMember]
        public string PhysicalFileName { get; set; }
		
        /// <summary>
        /// Gets or sets the length of the PhysicalFile content.
        /// </summary>
        /// <value>
        /// The length of the PhysicalFile content.
        /// </value>
        [DataMember]
        public int ContentLength { get; set; }

        /// <summary>
        /// Gets or sets the content of the file.
        /// </summary>
        /// <value>
        /// The content of the file.
        /// </value>
        public byte[] FileContent { get; set; }

        #endregion properties

    }

    /// <summary>
    /// BinaryFileCollection is a collection of BinaryFile
    /// </summary>
    public class BinaryFileCollection : List<BinaryFile>
    {
    }

    /// <summary>
    /// BinaryFileActionTypes is enumeration of BinaryFile Actions
    /// </summary>
	[DataContract(Name = "BinaryFileActionTypes")]
	public enum BinaryFileActionTypes
    {
		[EnumMember]
        Load,
		[EnumMember]
        Save,
		[EnumMember]
        Delete,
    }
	
    /// <summary>
    /// BinaryFileResponseMessage is a message container of BinaryFile
    /// </summary>
    [DataContract]
	public class BinaryFileResponseMessage
    {
		#region properties

        /// <summary>
        /// Gets or sets the type of the binary file action.
        /// </summary>
        /// <value>
        /// The type of the binary file action.
        /// </value>
        [DataMember]
        public BinaryFileActionTypes BinaryFileActionType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is binary file action success.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is binary file action success; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool IsBinaryFileActionSuccess { get; set; }

        /// <summary>
        /// Gets or sets the action logs.
        /// </summary>
        /// <value>
        /// The action logs, e.g. what action to be executed, execution result, fail/success.
        /// </value>
        [DataMember]
        public string[] ActionLogs { get; set; }

        /// <summary>
        /// Gets or sets the binary file.
        /// </summary>
        /// <value>
        /// The binary file.
        /// </value>
        [DataMember]
        public BinaryFile BinaryFile { get; set; }

		#endregion properties

    }
}


