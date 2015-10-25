<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Default.master" AutoEventWireup="true" EnableEventValidation="true" CodeBehind="WPCommonOfLog.aspx.cs" Inherits="Log4Net.WebFormApp.WebPages.WPCommonOfLog" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="uc" TagName="UCCommonOfLog" Src="../UserControls/UCCommonOfLog.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHH" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHMCID" runat="server">
<uc:UCCommonOfLog id="UCCommonOfLog1" runat="server" />
</asp:Content>