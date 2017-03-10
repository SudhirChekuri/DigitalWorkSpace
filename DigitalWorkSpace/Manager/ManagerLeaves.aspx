<%@ Page Title="" Language="C#" MasterPageFile="~/ManagerMaster.Master" AutoEventWireup="true" CodeBehind="ManagerLeaves.aspx.cs" Inherits="DigitalWorkSpace.Manager.ManagerLeaves" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table width="100%" style="background-color:aqua">
        <tr>
            <h3>Leave Approvals</h3>
            <th align="right">User Id:</th>

            <td align="left">
                <asp:TextBox ID="txtLeavesApprove" runat="server" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="gvLeavesApprove" runat="server" AutoGenerateColumns="false" BackColor="YellowGreen" OnRowCommand="gvLeavesApprove_RowCommand" >
        <Columns>
            <asp:BoundField HeaderText="User Id" DataField="Lid" />
            <asp:BoundField HeaderText="From Date" DataField="FromDate" />
            <asp:BoundField HeaderText="To Date" DataField="ToDate" />
            <asp:BoundField HeaderText="Status" DataField="Status" />
            <asp:ButtonField Text="Approve" />
        </Columns>
    </asp:GridView>
   
</asp:Content>
