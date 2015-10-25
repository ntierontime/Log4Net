<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GenericHorizonChildMenu.ascx.cs" Inherits="Log4Net.WebFormApp.UserControls.GenericHorizonChildMenu" %>
<asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" 
    DataSourceID="SiteMapDataSource1" StaticDisplayLevels="2">
</asp:Menu>
<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" 
    StartFromCurrentNode="True" />