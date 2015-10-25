<%@ Page Language="C#" MasterPageFile="~/MasterPages/Default.master" AutoEventWireup="true" CodeBehind="ForgotYourPasswordWizard.aspx.cs" Inherits="Log4Net.WebFormApp.AccessoryPages.ForgotYourPasswordWizard" Title="ForgotYourPasswordWizard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHH" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHMCID" runat="server">
    <asp:PasswordRecovery ID="PasswordRecovery1" runat="server"
        onanswerlookuperror="PasswordRecovery1_AnswerLookupError" 
        onsendmailerror="PasswordRecovery1_SendMailError" 
        onuserlookuperror="PasswordRecovery1_UserLookupError"
        SubmitButtonText="<%$ Resources:Framework.Resources|UIStringResource, Common_SubmitButtonText %>"
        UserNameLabelText="<%$ Resources:Framework.Resources|UIStringResource, Common_UserNameLabelText %>"
        QuestionLabelText="<%$ Resources:Framework.Resources|UIStringResource, Common_QuestionLabelText %>"
        GeneralFailureText="<%$ Resources:Framework.Resources|UIStringResource, Account_PasswordRecovery_GeneralFailureText %>"
        QuestionFailureText="<%$ Resources:Framework.Resources|UIStringResource, Account_PasswordRecovery_QuestionFailureText %>"
        QuestionInstructionText="<%$ Resources:Framework.Resources|UIStringResource, Account_PasswordRecovery_QuestionInstructionText %>"
        QuestionTitle="<%$ Resources:Framework.Resources|UIStringResource, Account_PasswordRecovery_QuestionTitle %>"
        SuccessText="<%$ Resources:Framework.Resources|UIStringResource, Account_PasswordRecovery_SuccessText %>"
        UserNameFailureText="<%$ Resources:Framework.Resources|UIStringResource, Account_PasswordRecovery_UserNameFailureText %>"
        UserNameInstructionText="<%$ Resources:Framework.Resources|UIStringResource, Account_PasswordRecovery_UserNameInstructionText %>"
        UserNameTitleText="<%$ Resources:Framework.Resources|UIStringResource, Account_PasswordRecovery_UserNameTitleText %>"
        AnswerRequiredErrorMessage="<%$ Resources:Framework.Resources|UIStringResource, Common_AnswerRequiredErrorMessage %>"
        UserNameRequiredErrorMessage="<%$ Resources:Framework.Resources|UIStringResource, Common_UserNameRequiredErrorMessage %>"
        >
</asp:PasswordRecovery>
</asp:Content>