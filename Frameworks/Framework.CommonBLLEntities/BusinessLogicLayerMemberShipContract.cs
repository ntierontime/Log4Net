using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;

namespace Framework.CommonBLLEntities
{
    /// <summary>
    /// Contract for BusinessLogicLayerMemberShip
    /// </summary>
    public interface BusinessLogicLayerMemberShipContract
    {
		#region properties

        /// <summary>
        /// Gets or sets the current user GUID.
        /// </summary>
        /// <value>
        /// The current user GUID.
        /// </value>
        Guid CurrentUserGuid { get; set; }

        /// <summary>
        /// Gets or sets the current user Id.
        /// </summary>
        /// <value>
        /// The current user Id.
        /// </value>
        long CurrentUserId { get; set; }

        /// <summary>
        /// Gets or sets the roles of current user.
        /// </summary>
        /// <value>
        /// The roles of current user.
        /// </value>
        string[] RolesOfCurrentUser { get; set; }

		#endregion properties
    }

    /// <summary>
    /// Current user information
    /// </summary>
    public class BusinessLogicLayerMemberShip: BusinessLogicLayerMemberShipContract
    {
		#region properties

        /// <summary>
        /// Gets or sets the current user GUID.
        /// </summary>
        /// <value>
        /// The current user GUID.
        /// </value>
        public Guid CurrentUserGuid { get; set; }

        /// <summary>
        /// Gets or sets the current user Id.
        /// </summary>
        /// <value>
        /// The current user Id.
        /// </value>
        public long CurrentUserId { get; set; }

        /// <summary>
        /// Gets or sets the roles of current user.
        /// </summary>
        /// <value>
        /// The roles of current user.
        /// </value>
        public string[] RolesOfCurrentUser { get; set; }

		#endregion properties
    }
}