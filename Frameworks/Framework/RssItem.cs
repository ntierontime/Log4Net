using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Framework
{
    /// <summary>
    /// matches Rss schema
    /// </summary>
    [DataContract]
    public class RssItem
    {
		#region properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [DataMember]
#if(WINDOWS_PHONE || SILVERLIGHT)
#else
            [LINQtoCSV.CsvColumn()]
#endif
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [DataMember]
#if(WINDOWS_PHONE || SILVERLIGHT)
#else
            [LINQtoCSV.CsvColumn()]
#endif
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        [DataMember]
#if(WINDOWS_PHONE || SILVERLIGHT)
#else
            [LINQtoCSV.CsvColumn()]
#endif
        public string Author { get; set; }
        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        [DataMember]
#if(WINDOWS_PHONE || SILVERLIGHT)
#else
            [LINQtoCSV.CsvColumn()]
#endif
        public string Comments { get; set; }
        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        [DataMember]
#if(WINDOWS_PHONE || SILVERLIGHT)
#else
            [LINQtoCSV.CsvColumn()]
#endif
        public string Link { get; set; }
        /// <summary>
        /// Gets or sets the pub date.
        /// </summary>
        /// <value>
        /// The pub date.
        /// </value>
        [DataMember]
#if(WINDOWS_PHONE || SILVERLIGHT)
#else
            [LINQtoCSV.CsvColumn()]
#endif
        public DateTime PubDate { get; set; }

        /// <summary>
        /// Gets or sets the identifier in string.
        /// </summary>
        /// <value>
        /// The identifier in string.
        /// </value>
        [DataMember]
#if(WINDOWS_PHONE || SILVERLIGHT)
#else
            [LINQtoCSV.CsvColumn()]
#endif
        public string IdentifierInString { get; set; }
        /// <summary>
        /// Gets or sets the name of the created by user.
        /// </summary>
        /// <value>
        /// The name of the created by user.
        /// </value>
        [DataMember]
#if(WINDOWS_PHONE || SILVERLIGHT)
#else
            [LINQtoCSV.CsvColumn()]
#endif
        public System.String CreatedByUserName { get; set; }
        /// <summary>
        /// Gets or sets the created by identifier.
        /// </summary>
        /// <value>
        /// The created by identifier.
        /// </value>
        [DataMember]
#if(WINDOWS_PHONE || SILVERLIGHT)
#else
            [LINQtoCSV.CsvColumn(OutputFormat = "D")]
#endif
        public System.Guid CreatedByIdentifier { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        [DataMember]
#if(WINDOWS_PHONE || SILVERLIGHT)
#else
            [LINQtoCSV.CsvColumn()]
#endif
        public System.DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the last name of the modified by user.
        /// </summary>
        /// <value>
        /// The last name of the modified by user.
        /// </value>
        [DataMember]
#if(WINDOWS_PHONE || SILVERLIGHT)
#else
            [LINQtoCSV.CsvColumn()]
#endif
        public System.String LastModifiedByUserName { get; set; }
        /// <summary>
        /// Gets or sets the last modified by identifier.
        /// </summary>
        /// <value>
        /// The last modified by identifier.
        /// </value>
        [DataMember]
#if(WINDOWS_PHONE || SILVERLIGHT)
#else
            [LINQtoCSV.CsvColumn(OutputFormat = "D")]
#endif
        public System.Guid LastModifiedByIdentifier { get; set; }
        /// <summary>
        /// Gets or sets the date last modified.
        /// </summary>
        /// <value>
        /// The date last modified.
        /// </value>
        [DataMember]
#if(WINDOWS_PHONE || SILVERLIGHT)
#else
            [LINQtoCSV.CsvColumn()]
#endif
        public System.DateTime DateLastModified { get; set; }

		#endregion properties

	}

	/// <summary>
    /// matches Rss schema
    /// </summary>
    public class RssItemCollection : List< RssItem>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RssItemCollection"/> class.
        /// </summary>
        public RssItemCollection()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RssItemCollection"/> class.
        /// </summary>
        /// <param name="input">The input.</param>
        public RssItemCollection(IEnumerable<RssItem> input)
            : base(input)
        {
        }

        #endregion Constructors

    }
}