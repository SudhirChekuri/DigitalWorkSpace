<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminSignIn.aspx.cs" Inherits="DigitalWorkSpace.Admin.AdminSignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <div align="center" style="background-color:aqua">
            <table  align="center">
                <tr>
                <th>Type:</th>  
       <td>
        <asp:DropDownList ID="ddlType" runat="server" >
            <asp:ListItem Value="Select"></asp:ListItem>
            <asp:ListItem Value="Admin"></asp:ListItem>
            <asp:ListItem Value="Manager"></asp:ListItem>
            <asp:ListItem Value="HR"></asp:ListItem>
            
        </asp:DropDownList>
        </td>
         </tr>
         <tr>
        <th>UserName:</th>
               <td>
        <asp:TextBox ID="txtUserName" runat="server" />
         </td>
        </tr>
         <tr>
        <th>Password:</th>
             <td>
        <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" />&nbsp;
        </td>
        </tr>
         <tr>
             <td></td>
             <th>
        <asp:Button ID="btnSignIn" runat="server" Text="SignIn" OnClick="btnSignIn_Click" />
         </tr>
            </table>
        </div>
    </form>
         
</body>
</html>
