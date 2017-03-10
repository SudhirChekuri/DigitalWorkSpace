<%@ Page Title="" Language="C#" MasterPageFile="~/HRMaster.Master" AutoEventWireup="true" CodeBehind="HRAttendence.aspx.cs" Inherits="DigitalWorkSpace.HR.HRAttendence" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
      <div align="center" style="background-color:magenta">
        <table width="100%">
            <tr>
            <td>
                <asp:GridView ID="GV1_Attendence" runat="server" AutoGenerateSelectButton="True" OnRowCommand="GV1_Attendence_RowCommand"  >
                </asp:GridView>
            </td>
                <td>
                    <asp:GridView ID="GV2_Attendence" runat="server" AutoGenerateSelectButton="True" OnRowCommand="GV2_Attendence_RowCommand" >
                    </asp:GridView>

                </td>
           </tr>
        </table>
    </div>
    <div>
        <table align="center" width="100%" style="background-color:aqua">
            <tr>
                <th align="right">
                   
                    User Id:
                </th>
                <td>
                    <asp:TextBox ID="txtUId" runat="server" ReadOnly="True" />
                </td>
            </tr>
            <tr>
                <th align="right">
                    Manager Id:
                </th>
                <td>
                    <asp:TextBox ID="txtMId" runat="server" ReadOnly="True" />
                </td>
            </tr>
            <tr>
                <th align="right">
                    Sick Leaves*:
                </th>
                <td>
                    <asp:TextBox ID="txtSickLeaves" runat="server" />
                </td>
            </tr>
            <tr>
                <th align="right">
                    Privilize Leaves*:
                </th>
                <td>
                    <asp:TextBox ID="txtPrivilizeleaves" runat="server" />
                </td>
            </tr>
            <tr>
                <th align="right">
                    From Date*:
                </th>
                <td>
                    <asp:TextBox ID="txtFromDate" runat="server" />
                    <asp:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" Enabled="true" TargetControlID="txtFromDate" >
                    </asp:CalendarExtender>
                    
                </td>
            </tr>
            <tr>
                <th align="right">
                    To Date*:
                </th>
                <td>
                    <asp:TextBox ID="txtToDate" runat="server" />
                    <asp:CalendarExtender ID="txtToDate_Callender" runat="server" Enabled="true" TargetControlID="txtToDate" />

                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnCreateLeaves" runat="server" Text="Create Leaves" OnClick="btnCreateLeaves_Click" />
                    <asp:Button ID="btnUpdateLeaves" runat="server" Text="Update Leaves" OnClick="btnUpdateLeaves_Click" />
                </td>
            </tr>
        </table>
    </div>
    
    <asp:GridView ID="GV3_Attendence" runat="server" >

    </asp:GridView>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>


</asp:Content>
