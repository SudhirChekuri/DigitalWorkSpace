<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.Master" AutoEventWireup="true" CodeBehind="HRPaySlips.aspx.cs" Inherits="DigitalWorkSpace.HR.HRPaySlips" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center" style="background-color:gold">
        <table width="100%">
            <tr>
            <td>
                <asp:GridView ID="GV1_Payslips" runat="server" AutoGenerateSelectButton="True" OnRowCommand="GV1_Payslips_RowCommand"  >
                </asp:GridView>
            </td>
                <td>
                    <asp:GridView ID="GV2_Payslips" runat="server" AutoGenerateSelectButton="True" OnRowCommand="GV2_Payslips_RowCommand" >
                    </asp:GridView>

                </td>
           </tr>
        </table>
    </div>
    
    <table align="center" width="100%" style="background-color:aqua">
            <tr>
                <th align="right">
                    Manager Id:
                </th>
                <td>
                    <asp:TextBox ID="txtMId" runat="server" />
                </td>
            </tr>
            <tr>
                <th align="right">
                    User Id:
                </th>
                <td>
                    <asp:TextBox ID="txtUId" runat="server" />
                </td>
            </tr>
         <tr>
                <th align="right">
                    Year:
                </th>
                <td>
                    <asp:DropDownList ID="ddlYear" runat="server">
                        <asp:ListItem Text="Select"  />
                        <asp:ListItem Text="2012" />
                        <asp:ListItem Text="2013" />
                        <asp:ListItem Text="2014" />
                        <asp:ListItem Text="2015" />
                        <asp:ListItem Text="2016" />
                        <asp:ListItem Text="2017" />
                    </asp:DropDownList>
                </td>
             </tr>>
        <tr>
                <th align="right">
                    Month:
                </th>
                <td>
                    <asp:DropDownList ID="ddlMonth" runat="server">
                        <asp:ListItem Text="Select"  />
                        <asp:ListItem Text="01" />
                        <asp:ListItem Text="02" />
                        <asp:ListItem Text="03" />
                        <asp:ListItem Text="04" />
                        <asp:ListItem Text="05" />
                        <asp:ListItem Text="06" />
                        <asp:ListItem Text="07" />
                        <asp:ListItem Text="08" />
                        <asp:ListItem Text="09" />
                        <asp:ListItem Text="10" />
                        <asp:ListItem Text="11" />
                        <asp:ListItem Text="12" />
                    </asp:DropDownList>
                </td>
             </tr>
        <tr>
            <td></td>
            <td>
        <asp:FileUpload ID="fileupload" runat="server"   />
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
          </td>
      </tr>
        <div style="background-color:greenyellow">
    <asp:GridView ID="GV3_Payslips" runat="server" AutoGenerateSelectButton="True"  >
                    </asp:GridView>
  </div>
</asp:Content>
