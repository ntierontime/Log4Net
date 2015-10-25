using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework
{
    public class UIActionStatusMessage
    {
        #region constructors

        /// <summary>
        /// default constructor
        /// </summary>
        public UIActionStatusMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIActionStatusMessage"/> class.
        /// </summary>
        /// <param name="sourceTypeFullName">Full name of the source type.</param>
        /// <param name="senderView">The sender view.</param>
        /// <param name="uIAction">The u i action.</param>
        /// <param name="uIActionStatus">The u i action status.</param>
        public UIActionStatusMessage(
            System.String sourceTypeFullName,
            System.String senderView,
            UIAction uIAction,
            UIActionStatus uIActionStatus)
            : this(sourceTypeFullName, senderView, uIAction, uIActionStatus, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIActionStatusMessage"/> class.
        /// </summary>
        /// <param name="sourceTypeFullName">Full name of the source type.</param>
        /// <param name="senderView">The sender view.</param>
        /// <param name="uIAction">The u i action.</param>
        /// <param name="uIActionStatus">The u i action status.</param>
        /// <param name="errorMessage">The error message.</param>
        public UIActionStatusMessage(
            System.String sourceTypeFullName,
            System.String senderView,
            UIAction uIAction,
            UIActionStatus uIActionStatus,
            string errorMessage
            )

        {
            this.ErrorMessage = errorMessage;
            this.SourceTypeFullName = sourceTypeFullName;
            this.SenderView = senderView;
            this.UIAction = uIAction;
            this.UIActionStatus = uIActionStatus;
        }

        #endregion constructors

        /// <summary>
        /// Gets or sets the full name of the source type.
        /// </summary>
        /// <value>
        /// The full name of the source type.
        /// </value>
        public string SourceTypeFullName { get; set; }

        /// <summary>
        /// Gets or sets the sender.
        /// </summary>
        /// <value>
        /// The sender.
        /// </value>
		public string SenderView { get; set; }

        /// <summary>
        /// Gets or sets the UI action.
        /// </summary>
        /// <value>
        /// The UI action.
        /// </value>
		public UIAction UIAction { get; set; }

        /// <summary>
        /// Gets or sets the UI action status.
        /// </summary>
        /// <value>
        /// The UI action status.
        /// </value>
        public UIActionStatus UIActionStatus { get; set; }

        public string ErrorMessage { get; set; }

        #region override string ToString()

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("SourceTypeFullName:{0};SenderView:{1};UIAction:{2};UIActionStatus:{3};ErrorMessage:{4}", this.SourceTypeFullName, this.SenderView, this.UIActionStatus, this.UIActionStatus, this.ErrorMessage);
        }

        #endregion override string ToString()
	}
}