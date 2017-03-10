<%@ Page Title="" Language="C#" MasterPageFile="~/UserHome.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DigitalWorkSpace.Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 15px;
            left: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style1" ></asp:TextBox>
    <asp:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" TargetControlID="TextBox1">
    </asp:CalendarExtender>
    <br />
</asp:Content>
