<%@ Page Language="C#" MasterPageFile="~/MasterPages/Default.master" AutoEventWireup="true" CodeBehind="CreateNewUserWizard.aspx.cs" Inherits="Log4Net.WebFormApp.AccessoryPages.CreateNewUserWizard" Title="CreateNewUserWizard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHH" runat="server">
<style type="text/css">
.barIndicatorBorder {
border:solid 1px #c0c0c0;
width:200px;
}

.barIndicator_poor {
background-color:gray;
}

.barIndicator_weak {
background-color:cyan;
}

.barIndicator_good {
background-color:lightblue;
}

.barIndicator_strong {
background-color:blue;
}

.barIndicator_excellent {
background-color:navy;    
}

.textbox {
border: solid 2px #cccccc;
border-top: solid 2px #a0a0a0;
}

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHMCID" runat="server">
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
        oncreateduser="CreateUserWizard1_CreatedUser" 
        oncreateusererror="CreateUserWizard1_CreateUserError">
    <WizardSteps>
        <asp:CreateUserWizardStep runat="server" >
            <ContentTemplate>
                <table>
                    <tr>
                        <th><asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Framework.Resources|UIStringResource, Account_CreateNewUserWizard_TitleText%>" /></th>
                    </tr>
                    <tr>
                        <td><asp:Literal ID="Literal_Common_UserNameLabelText" runat="server" Text="<%$ Resources:Framework.Resources|UIStringResource, Common_UserNameLabelText %>" /></td>
                        <td>
                            <asp:UpdatePanel runat="server" id="UpdatePanel" updatemode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger controlid="Button_CheckUserNameAvailability" eventname="Click" />
                            </Triggers>
                                <ContentTemplate>
                                    <asp:TextBox runat="server" ID="UserName" />
                                    <asp:Button runat="server" id="Button_CheckUserNameAvailability" onclick="Button_CheckUserNameAvailability_Click" text="<%$ Resources:Framework.Resources|UIStringResource, Account_CreateNewUserWizard_Button_CheckUserNameAvailabilityText %>" CausesValidation="false" />
                                    <asp:Label ID="Label1" runat="server" 
                                        Text="<%$ Resources:Framework.Resources|UIStringResource, Account_CreateNewUserWizard_ThisUserNameIsNotAvailableLabelText %>" Visible="False"></asp:Label>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator9" ControlToValidate="UserName" 
                                        ErrorMessage="<%$ Resources:Framework.Resources|UIStringResource, Common_UserNameRequiredErrorMessage %>" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>Password:</td>
                        <td>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" />

<ajaxToolkit:PasswordStrength runat="server" ID="PasswordStrength1"
TargetControlID="Password"
DisplayPosition="RightSide"
MinimumSymbolCharacters="1"
MinimumUpperCaseCharacters="1"
PreferredPasswordLength="10"
CalculationWeightings="25;25;15;35"
RequiresUpperAndLowerCaseCharacters="true"
TextStrengthDescriptions="Poor; Weak; Good; Strong; Excellent"
HelpStatusLabelID="Label2"
StrengthIndicatorType="BarIndicator"
HelpHandlePosition="AboveLeft"
BarBorderCssClass="barIndicatorBorder"
StrengthStyles="barIndicator_poor; barIndicator_weak; barIndicator_good; barIndicator_strong; barIndicator_excellent">
</ajaxToolkit:PasswordStrength>
<div class="clear"><br /></div>
                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator10" ControlToValidate="Password" 
                                ErrorMessage="<%$ Resources:Framework.Resources|UIStringResource, Common_PasswordRequiredErrorMessage %>" />
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Literal ID="Literal_Common_ConfirmPasswordLabelText" runat="server" Text="<%$ Resources:Framework.Resources|UIStringResource, Common_ConfirmPasswordLabelText %>" /></td>
                        <td>
                            <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
            <asp:CompareValidator id="CompareValidator1" 
             runat="server" ErrorMessage="<%$ Resources:Framework.Resources|UIStringResource, Common_ConfirmPasswordNotMatchErrorMessage %>" 
             ControlToValidate="Password"  
             ControlToCompare="ConfirmPassword" ></asp:CompareValidator>
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator13" ControlToValidate="ConfirmPassword" 
                                ErrorMessage="<%$ Resources:Framework.Resources|UIStringResource, Common_ConfirmPasswordRequiredErrorMessage %>" />
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Literal ID="Literal_Common_EmailLabelText" runat="server" Text="<%$ Resources:Framework.Resources|UIStringResource, Common_EmailLabelText %>" /></td>
                        <td>
                            <asp:TextBox runat="server" ID="Email" />
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator11" ControlToValidate="Email" 
                                ErrorMessage="<%$ Resources:Framework.Resources|UIStringResource, Common_EmailRequiredErrorMessage %>" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="Email" ErrorMessage="<%$ Resources:Framework.Resources|UIStringResource, Common_EmailFormatErrorMessage %>" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Literal ID="Literal_Common_QuestionLabelText" runat="server" Text="<%$ Resources:Framework.Resources|UIStringResource, Common_QuestionLabelText %>" /></td>
                        <td>
                            <asp:TextBox runat="server" ID="Question" />
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator12" ControlToValidate="Question" 
                                ErrorMessage="<%$ Resources:Framework.Resources|UIStringResource, Common_QuestionRequiredErrorMessage %>" />
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Literal ID="Literal_Common_AnswerLabelText" runat="server" Text="<%$ Resources:Framework.Resources|UIStringResource, Common_AnswerLabelText %>" /></td>
                        <td>
                            <asp:TextBox runat="server" ID="Answer" />
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="Answer" 
                                ErrorMessage="<%$ Resources:Framework.Resources|UIStringResource, Common_AnswerRequiredErrorMessage %>" />
                            <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                ControlToCompare="Question" ControlToValidate="Answer" 
                                ErrorMessage="<%$ Resources:Framework.Resources|UIStringResource, Common_AnswerErrorMessage %>" Operator="NotEqual"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                             &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:CreateUserWizardStep>
        <asp:CompleteWizardStep runat="server" />
    </WizardSteps>
</asp:CreateUserWizard></asp:Content>