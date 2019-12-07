<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Doctor.aspx.cs" Inherits="HospitalManagementSystem.AllClass.Doctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 439px; height: 229px">
        <tr>
            <td>
                Doctor Id
            </td>
            <td style="width: 127px">
                <asp:TextBox ID="Txtdoctorid" runat="server" style="margin-left: 0" Width="204px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Doctor Name
            </td>
            <td style="width: 127px">
                <asp:TextBox ID="Txtdoctorname" runat="server" style="margin-left: 0" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Doctor Specification
            </td>
            <td style="width: 127px">
                <asp:TextBox ID="TxtDoctorspecification" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Insert" OnClick="Button1_Click" Width="132px" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="173px" Width="452px" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
        <Columns>
            <asp:TemplateField HeaderText="Doctor_Id">
                
               
                
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Doctor_id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Doctor name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Doctor_name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Doctor_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Doctor_specification">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Doctor_specification") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Doctor_specification") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
</asp:GridView>
</asp:Content>
