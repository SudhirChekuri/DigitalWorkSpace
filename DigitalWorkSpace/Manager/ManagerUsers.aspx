<%@ Page Title="" Language="C#" MasterPageFile="~/ManagerMaster.Master" AutoEventWireup="true" CodeBehind="ManagerUsers.aspx.cs" Inherits="DigitalWorkSpace.Manager.ManagerUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <h3 style="background-color:crimson">Approvals Pending</h3> 
    <asp:GridView ID="GV1_Manager" runat="server" AutoGenerateColumns="false" BackColor="Magenta"  DataKeyNames="Id" OnRowEditing="GV1_Manager_RowEditing"  >      
              <Columns>
            <asp:BoundField HeaderText="User Id" DataField="Id" />
            <asp:BoundField HeaderText="User Name" DataField="Username" />
            <asp:BoundField HeaderText="Email Id" DataField="Emailid" />
            <asp:BoundField HeaderText="Status" DataField="Status" />
            <asp:TemplateField HeaderText="Approve">
                <ItemTemplate>
                    <asp:LinkButton ID="lbApproves" runat="server" CausesValidation="false" CommandName="Edit" Text="Approve"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <h3 style="background-color:darkgoldenrod">Approved User Details</h3>
    <asp:GridView ID="gvApproves" runat="server" AutoGenerateColumns="false" BackColor="#0099ff" >
        <Columns>
            <asp:BoundField HeaderText="User Id" DataField="Id" />
            <asp:BoundField HeaderText="User Name" DataField="Username" />
            <asp:BoundField HeaderText="Email Id" DataField="Emailid" />
            <asp:BoundField HeaderText="Status" DataField="Status" />
            
        </Columns>
    </asp:GridView>
</asp:Content>
