<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SectionLevelTutorialListing.ascx.cs" Inherits="Log4Net.WebFormApp.UserControls.SectionLevelTutorialListing" %>
<asp:Repeater ID="TutorialList" runat="server" EnableViewState="False">
    <HeaderTemplate><ul></HeaderTemplate>
    <ItemTemplate>
        <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Url") %>' Text='<%# Eval("Title") %>'></asp:HyperLink>
                - <%# Eval("Description") %></li>
    </ItemTemplate>
    <FooterTemplate></ul></FooterTemplate>
</asp:Repeater>