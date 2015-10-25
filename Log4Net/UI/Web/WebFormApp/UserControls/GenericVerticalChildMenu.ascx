<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GenericVerticalChildMenu.ascx.cs" Inherits="Log4Net.WebFormApp.UserControls.GenericVerticalChildMenu" %>
<asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1">
</asp:Menu>
<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" 
    StartFromCurrentNode="True" />