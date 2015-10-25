<%@ Page Language="C#" MasterPageFile="~/MasterPages/Default.master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Log4Net.WebFormApp.AccessoryPages.LogIn" Title="LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHH" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHMCID" runat="server">

    <asp:Login ID="Login2" runat="server" onloggedin="Login2_LoggedIn" 
        PasswordLabelText="<%$ Resources:Framework.Resources|UIStringResource, Common_PasswordLabelText %>"
        UserNameLabelText="<%$ Resources:Framework.Resources|UIStringResource, Common_UserNameLabelText %>"
        PasswordRequiredErrorMessage="<%$ Resources:Framework.Resources|UIStringResource, Common_PasswordRequiredErrorMessage %>"
        UserNameRequiredErrorMessage="<%$ Resources:Framework.Resources|UIStringResource, Common_UserNameRequiredErrorMessage %>"
        FailureText="<%$ Resources:Framework.Resources|UIStringResource, Account_LogIn_FailureText %>"
        InstructionText="<%$ Resources:Framework.Resources|UIStringResource, Account_LogIn_InstructionText %>"
        LoginButtonText="<%$ Resources:Framework.Resources|UIStringResource, Account_LogIn_LoginButtonText %>"
        RememberMeText="<%$ Resources:Framework.Resources|UIStringResource, Account_LogIn_RememberMeText %>"
        TitleText="<%$ Resources:Framework.Resources|UIStringResource, Account_LogIn_TitleText %>"
        onloginerror="Login2_LoginError">
    </asp:Login>

</asp:Content>