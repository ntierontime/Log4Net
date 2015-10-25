<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GenericHeader.ascx.cs" Inherits="Log4Net.WebFormApp.UserControls.GenericHeader" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" 
    BackColor="#66FF66">
    <span style="font-size:50pt; height:200px; vertical-align:middle;">This is a Header</span>
</asp:Panel>
<cc1:RoundedCornersExtender ID="Panel1_RoundedCornersExtender" runat="server" 
    Enabled="True" TargetControlID="Panel1">
</cc1:RoundedCornersExtender>

</cc1:RoundedCornersExtender>