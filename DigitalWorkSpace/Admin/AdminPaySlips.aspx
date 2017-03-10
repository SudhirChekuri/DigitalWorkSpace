<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminPaySlips.aspx.cs" Inherits="DigitalWorkSpace.Admin.AdminPaySlips" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-color:springgreen">
    <asp:GridView ID="gvPaySlips" runat="server" AutoGenerateColumns="false" DataKeyNames="PId" OnRowEditing="gvPaySlips_RowEditing" OnRowCancelingEdit="gvPaySlips_RowCancelingEdit" OnRowUpdating="gvPaySlips_RowUpdating" OnRowDeleting="gvPaySlips_RowDeleting">
        <Columns>
            <asp:BoundField HeaderText="PId" DataField="PId" />
            <asp:BoundField HeaderText="Id" DataField="Id" />
            <asp:BoundField HeaderText="MId" DataField="MId" />
            <asp:BoundField HeaderText="Year" DataField="Year" />
            <asp:BoundField HeaderText="Month" DataField="Month" />
            <asp:BoundField HeaderText="Pdf" DataField="Pdf" />
            <asp:CommandField HeaderText="Action" ShowEditButton="true" />
            <asp:CommandField ShowDeleteButton="true" />
        </Columns>
        
    </asp:GridView>
</div>
</asp:Content>
