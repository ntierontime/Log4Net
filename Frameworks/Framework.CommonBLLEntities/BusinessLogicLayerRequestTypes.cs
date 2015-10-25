using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.CommonBLLEntities
{
    /// <summary>
    /// enumeration, Business Logic Layer Request Types
    /// </summary>
    public enum BusinessLogicLayerRequestTypes
    {
        /// <summary>
        /// Create an entity
        /// </summary>
        Create,
        /// <summary>
        /// Update an entity
        /// </summary>
        Update,
        /// <summary>
        /// Delete an entity
        /// </summary>
        Delete,

        /// <summary>
        /// Replace an entity
        /// </summary>
        Replace,
        /// <summary>
        /// Copy an entity
        /// </summary>
        Copy,

        /// <summary>
        /// Search an entity
        /// </summary>
        Search,

    }
}