<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminManager.aspx.cs" Inherits="DigitalWorkSpace.Admin.CreateManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />
    <div align="left" style="background-color:coral">
    Create Manager:
   </div>
    <div align="center" style="background-color:chartreuse">
        <table width="100%">
            <tr>
                <th align="right">UserName:</th>
                <td align="left">
                    <asp:TextBox ID="txtUserName" runat="server" />
                    <asp:RequiredFieldValidator ID="rvUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="Please Enter User Name" BorderColor="Red" ValidationGroup="M" />
                </td>
            </tr>
            <tr>
                <th align="right">Password:</th>
                <td align="left">
                    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" />
                    <asp:RequiredFieldValidator ID="rvPwd" runat="server" ControlToValidate="txtPwd" ErrorMessage="Please Enter password" BorderColor="Red" ValidationGroup="M" />
                </td>
            </tr>
            <tr>
                <th align="right">Confirm Password:</th>
                <td align="left">
                    <asp:TextBox ID="txtcpwd" runat="server" TextMode="Password" />
                    <asp:CompareValidator ID="cvCPwd" runat="server" ControlToValidate="txtcpwd" ControlToCompare="txtPwd" ErrorMessage="Password and confirm password should be match" ValidationGroup="M" />
                </td>
            </tr>
            <tr>
                <th align="right">Email Id:</th>
                <td align="left">
                    <asp:TextBox ID="txtEmail" runat="server" />
                    <asp:RequiredFieldValidator ID="rvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please Enter Email Id" BorderColor="Red" ValidationGroup="M" />
                </td>
            </tr>
            <tr>
                
                <td align="right" >
                    <asp:Button ID="btnCreateManager" runat="server" Text="Create Manager" OnClick="btnCreateManager_Click" ValidationGroup="M"  />
                </td>
            </tr>
        </table>
    </div>
    <div align="left" style="background-color:dodgerblue">Manager Details</div>
    <asp:GridView ID="gvManagerDetails" runat="server" AutoGenerateColumns="false" DataKeyNames="Mid" BackColor="PaleVioletRed" OnRowUpdating="gvManagerDetails_RowUpdating"   OnRowEditing="gvManagerDetails_RowEditing" OnRowCancelingEdit="gvManagerDetails_RowCancelingEdit" OnRowDeleting="gvManagerDetails_RowDeleting" >
        <Columns>
            <asp:BoundField HeaderText="Mid" DataField="Mid" />
            <asp:BoundField HeaderText="User Name" DataField="Username" />
            <asp:BoundField HeaderText="Password" DataField="Password" />
            <asp:BoundField HeaderText="Email Id" DataField="EmailId" />
            <asp:BoundField HeaderText="Created Time" DataField="CreatedTime" />

            <asp:CommandField ShowDeleteButton="true" HeaderText="Action" />
            <asp:CommandField ShowEditButton="true" />
            
        </Columns>
        <HeaderStyle BackColor="Violet" />
        <RowStyle BorderColor="MediumBlue" />
        

    </asp:GridView>
</asp:Content>
