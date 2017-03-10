<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminAttendence.aspx.cs" Inherits="DigitalWorkSpace.Admin.AdminAttendence" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-color:yellowgreen">
<asp:GridView ID="gvAttendence" runat="server" AutoGenerateColumns="false" DataKeyNames="AId" OnRowCancelingEdit="gvAttendence_RowCancelingEdit" OnRowUpdating="gvAttendence_RowUpdating"  OnRowEditing="gvAttendence_RowEditing" OnRowDeleting="gvAttendence_RowDeleting"  BorderColor="ForestGreen">
    <Columns>
        <asp:BoundField HeaderText="AId" DataField="AId" />
        <asp:BoundField HeaderText="Id" DataField="Id" />
        <asp:BoundField HeaderText="MId" DataField="MID" />
        <asp:BoundField HeaderText="Sick Leaves" DataField="SickLeaves" />
        <asp:BoundField HeaderText="Privilege Leaves" DataField="PrivilegeLeaves" />
        <asp:BoundField HeaderText="From Date" DataField="FromDate" />
        <asp:BoundField HeaderText="To Date" DataField="ToDate" />
        <asp:CommandField HeaderText="Action" ShowEditButton="true" />
        <asp:CommandField ShowDeleteButton="true" />
    </Columns>
</asp:GridView>
</div>

</asp:Content>
