using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.EntityContracts
{
    /// <summary>
    /// Alphabetical Order Category
    /// </summary>
    public class AlphabeticalOrderCategory
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AlphabeticalOrderCategory"/> class.
        /// </summary>
        public AlphabeticalOrderCategory()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlphabeticalOrderCategory"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        public AlphabeticalOrderCategory(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        #endregion Constructors

        #region properties

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>
        /// The ID.
        /// </value>
        public int ID { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        #endregion properties

        #region override string ToString()

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0}={1};", this.ID, this.Name);
        }

        #endregion override string ToString()
    }

    /// <summary>
    /// collection class of <see cref="AlphabeticalOrderCategory"/>
    /// </summary>
    public class AlphabeticalOrderCategoryCollection : List<AlphabeticalOrderCategory>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AlphabeticalOrderCategoryCollection"/> class.
        /// </summary>
        public AlphabeticalOrderCategoryCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlphabeticalOrderCategoryCollection"/> class.
        /// </summary>
        /// <param name="input">The input.</param>
        public AlphabeticalOrderCategoryCollection(IEnumerable<AlphabeticalOrderCategory> input)
            : base(input)
        {
        }

        #endregion Constructors

        #region Add(int id, string name)

        /// <summary>
        /// Adds the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        public void Add(int id, string name)
        {
            AlphabeticalOrderCategory _Item = new AlphabeticalOrderCategory(id, name);
            this.Add(_Item);
        }

        #endregion Add(int id, string name)

        #region GetDefault...()

        public static AlphabeticalOrderCategoryCollection GetDefaultFirstLetterOnly()
        {
            AlphabeticalOrderCategoryCollection _retval = new AlphabeticalOrderCategoryCollection();
            for (char _Char = 'A'; _Char <= 'Z'; _Char++)
            {
                _retval.Add(_Char - 'A', _Char.ToString());
            }
            return _retval;
        }

        #endregion GetDefault...()

    }
}