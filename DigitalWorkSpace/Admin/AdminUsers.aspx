<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminUsers.aspx.cs" Inherits="DigitalWorkSpace.Admin.AdminUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div align="center"  style="background-color:darkorange" >Approved Users</div>
    <div style="background-color:forestgreen">
    <asp:GridView ID="gvApprovedUsers" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" />
            <asp:BoundField HeaderText="User Name" DataField="UserName" />
            <asp:BoundField HeaderText="Email Id" DataField="EmailId" />
            <asp:BoundField HeaderText="Password" DataField="Password" />
            <asp:BoundField HeaderText="Status" DataField="Status" />
            <asp:BoundField HeaderText="Created Time" DataField="CreatedTime" />
            <asp:BoundField HeaderText="Manager Id" DataField="MId" />
        </Columns>
    </asp:GridView>
    </div>
    <div align="center" style="background-color:blueviolet">Non-Approved Users</div>
    <div style="background-color:darkcyan">
        <asp:GridView ID="gvNonApproveUsers" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="Id" />
            <asp:BoundField HeaderText="User Name" DataField="UserName" />
            <asp:BoundField HeaderText="Email Id" DataField="EmailId" />
            <asp:BoundField HeaderText="Password" DataField="Password" />
            <asp:BoundField HeaderText="Status" DataField="Status" />
            <asp:BoundField HeaderText="Created Time" DataField="CreatedTime" />
            <asp:BoundField HeaderText="Manager Id" DataField="MId" />

            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
