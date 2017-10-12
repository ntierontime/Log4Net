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
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RssItem"/> class.
        /// </summary>
        public RssItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RssItem"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        /// <param name="author">The author.</param>
        /// <param name="comments">The comments.</param>
        /// <param name="link">The link.</param>
        /// <param name="pubDate">The pub date.</param>
        /// <param name="identifierInString">The identifier in string.</param>
        /// <param name="createdByUserName">Name of the created by user.</param>
        /// <param name="createdByIdentifier">The created by identifier.</param>
        /// <param name="dateCreated">The date created.</param>
        /// <param name="lastModifiedByUserName">Last name of the modified by user.</param>
        /// <param name="lastModifiedByIdentifier">The last modified by identifier.</param>
        /// <param name="dateLastModified">The date last modified.</param>
        public RssItem(
            System.String title,
            System.String description,
            System.String author,
            System.String comments,
            System.String link,
            System.DateTime pubDate,
            System.String identifierInString,
            System.String createdByUserName,
            System.Guid createdByIdentifier,
            System.DateTime dateCreated,
            System.String lastModifiedByUserName,
            System.Guid lastModifiedByIdentifier,
            System.DateTime dateLastModified)
            : base()
        {
            this.Title=title;
            this.Description=description;
            this.Author=author;
            this.Comments=comments;
            this.Link=link;
            this.PubDate=pubDate;
            this.IdentifierInString=identifierInString;
            this.CreatedByUserName=createdByUserName;
            this.CreatedByIdentifier=createdByIdentifier;
            this.DateCreated=dateCreated;
            this.LastModifiedByUserName=lastModifiedByUserName;
            this.LastModifiedByIdentifier=lastModifiedByIdentifier;
            this.DateLastModified=dateLastModified;
        }

        #endregion constructors

        #region properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [DataMember]
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [DataMember]
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        [DataMember]
        public string Author { get; set; }
        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        [DataMember]
        public string Comments { get; set; }
        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        [DataMember]
        public string Link { get; set; }
        /// <summary>
        /// Gets or sets the pub date.
        /// </summary>
        /// <value>
        /// The pub date.
        /// </value>
        [DataMember]
        public DateTime PubDate { get; set; }

        /// <summary>
        /// Gets or sets the identifier in string.
        /// </summary>
        /// <value>
        /// The identifier in string.
        /// </value>
        [DataMember]
        public string IdentifierInString { get; set; }
        /// <summary>
        /// Gets or sets the name of the created by user.
        /// </summary>
        /// <value>
        /// The name of the created by user.
        /// </value>
        [DataMember]
        public System.String CreatedByUserName { get; set; }
        /// <summary>
        /// Gets or sets the created by identifier.
        /// </summary>
        /// <value>
        /// The created by identifier.
        /// </value>
        [DataMember]
        public System.Guid CreatedByIdentifier { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        [DataMember]
        public System.DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the last name of the modified by user.
        /// </summary>
        /// <value>
        /// The last name of the modified by user.
        /// </value>
        [DataMember]
        public System.String LastModifiedByUserName { get; set; }
        /// <summary>
        /// Gets or sets the last modified by identifier.
        /// </summary>
        /// <value>
        /// The last modified by identifier.
        /// </value>
        [DataMember]
        public System.Guid LastModifiedByIdentifier { get; set; }
        /// <summary>
        /// Gets or sets the date last modified.
        /// </summary>
        /// <value>
        /// The date last modified.
        /// </value>
        [DataMember]
        public System.DateTime DateLastModified { get; set; }

        #endregion properties

        #region override string ToString()

        public override string ToString()
        {
            return string.Format("Title:{0};Description:{1};Author:{2};Comments:{3};Link:{4};PubDate:{5};IdentifierInString:{6};CreatedByUserName:{7};CreatedByIdentifier:{8};DateCreated:{9};LastModifiedByUserName:{10};", this.Title, this.Description, this.Author, this.Comments, this.Link, this.PubDate, this.IdentifierInString, this.CreatedByUserName, this.CreatedByIdentifier, this.DateCreated, this.LastModifiedByUserName);
        }

        #endregion override string ToString()
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

