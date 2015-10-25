using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Framework
{
    /// <summary>
    /// Logging Options, can find in correspondent classes or methods.
    /// </summary
	public enum LoggingOptions
	{
			Application_Started
			,Session_Started
			,Application_Ended
			,Session_Ended
			,BinaryResourceHandler_Request_Process_Started
			,BinaryResourceHandler_Request_Process_Ended
			,CreateUser_Succeeded
			,CreateUser_Failed
			,PasswordRecovery_AnswerLookupError
			,PasswordRecovery_SendMailError
			,PasswordRecovery_UserLookupError
			,LogIn_Success
			,LogIn_Failed
			,LogIn_Failed_3_Times
			,UI_Process_Started
			,UI_Process_Succeeded
			,UI_Process_Failed
			,UI_Process_Ended
			,Business_Logic_Layer_Process_Started
			,Business_Logic_Layer_Process_Succeeded
			,Business_Logic_Layer_Process_Failed
			,Business_Logic_Layer_Process_Ended
			,Data_Access_Layer_Process_Succeeded
			,Data_Access_Layer_Process_Failed
			,Data_Access_Layer_Process_Started
			,Data_Access_Layer_Process_Ended
	}
}