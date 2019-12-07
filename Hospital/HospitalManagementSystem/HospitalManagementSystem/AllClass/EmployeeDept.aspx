<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeDept.aspx.cs" Inherits="HospitalManagementSystem.AllClass.EmployeeDept" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table>
       <tr>
           <td>
               Department ID
           </td>
           <td>
               <asp:TextBox ID="Txtdeptid" runat="server" Height="51px" Width="207px"></asp:TextBox>
           </td>
       </tr>
        <tr>
           <td>
               Department Name
           </td>
           <td>
               <asp:TextBox ID="Txtdname" runat="server" Height="34px" Width="198px"></asp:TextBox>
           </td>
       </tr>
        <tr>
           <td>
               Employee Name
           </td>
           <td>
               <asp:TextBox ID="Txtename" runat="server" Height="47px" Width="199px"></asp:TextBox>
           </td>
       </tr>
        <tr>
           <td>
               salary
           </td>
           <td>
               <asp:TextBox ID="Txtsalary" runat="server" Height="48px" Width="210px"></asp:TextBox>
           </td>
       </tr>

        
        <tr>
          
           <td>
               <asp:Button ID="Button1" runat="server" Text="Add" Width="156px" OnClick="Button1_Click" />
           </td>
       </tr>

   </table>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="181px" Width="533px" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
        <Columns>
            <asp:TemplateField HeaderText="Department Id">
                
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Dept_id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Department Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Dept_Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Dept_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Employee Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="salary">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Salary") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Salary") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
