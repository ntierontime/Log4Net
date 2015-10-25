<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GenericVerticalMenu.ascx.cs" Inherits="Log4Net.WebFormApp.UserControls.GenericVerticalMenu" %>
<asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1" 
    StaticDisplayLevels="2">
</asp:Menu>
<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />