<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminHR.aspx.cs" Inherits="DigitalWorkSpace.Admin.CreateHR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />
    <div align="left" style="background-color:violet">
    Create HR:
   </div>
    <div align="center" style="background-color:gold">
        <table width="100%">
            <tr>
                <th align="right">UserName:</th>
                <td align="left">
                    <asp:TextBox ID="txtUserName" runat="server"  />
                    <asp:RequiredFieldValidator ID="rvUserName" runat="server" ControlToValidate="txtUserName" ValidationGroup="H" ErrorMessage="Please Enter User Name" BorderColor="Red" />
                </td>
            </tr>
            <tr>
                <th align="right">Password:</th>
                <td align="left">
                    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" />
                    <asp:RequiredFieldValidator ID="rvPwd" runat="server" ControlToValidate="txtPwd" ErrorMessage="Please Enter password" BorderColor="Red" ValidationGroup="H" />
                </td>
            </tr>
            <tr>
                <th align="right">Confirm Password:</th>
                <td align="left">
                    <asp:TextBox ID="txtcpwd" runat="server" TextMode="Password" />
                    <asp:CompareValidator ID="cvCPwd" runat="server" ControlToValidate="txtcpwd" ControlToCompare="txtPwd" ErrorMessage="Password and confirm password should be match" ValidationGroup="H" />
                </td>
            </tr>
            <tr>
                <th align="right">Email Id:</th>
                <td align="left">
                    <asp:TextBox ID="txtEmail" runat="server" />
                    <asp:RequiredFieldValidator ID="rvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please Enter Email Id" BorderColor="Red" ValidationGroup="H" />
                </td>
            </tr>
            <tr>
                
                <td align="right" >
                    <asp:Button ID="btnCreateHR" runat="server" Text="Create HR" OnClick="btnCreateUser_Click" ValidationGroup="H" />
                </td>
            </tr>
        </table>
    </div>
    <div align="left" style="background-color:dodgerblue">HR Details</div>
    <asp:GridView ID="gvHRDetails" runat="server" AutoGenerateColumns="false" BackColor="SpringGreen" DataKeyNames="Id" OnRowEditing="gvHRDetails_RowEditing" OnRowCancelingEdit="gvHRDetails_RowCancelingEdit" OnRowDeleting="gvHRDetails_RowDeleting" OnRowUpdating="gvHRDetails_RowUpdating" >
        <Columns>
            <asp:BoundField HeaderText="Hid" DataField="Id" />
            <asp:BoundField HeaderText="User Name" DataField="Username" />
            <asp:BoundField HeaderText="Password" DataField="Password" />
            <asp:BoundField HeaderText="Email Id" DataField="EmailId" />
            <asp:BoundField HeaderText="Created Time" DataField="CreatedTime" />
            <asp:CommandField ShowDeleteButton="true" HeaderText="Action"   />
            <asp:CommandField ShowEditButton="true" />
        </Columns>
        <HeaderStyle BackColor="Violet" />
        <RowStyle BorderColor="MediumBlue" />
        

    </asp:GridView>
</asp:Content>
