<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Blog.aspx.cs" Inherits="Blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<br />
<div>Rows:
<asp:TextBox ID="txtRows" runat="server"/>
&nbsp;Cols:
<asp:TextBox ID="txtCols" runat="server" />
<br /><br />
<asp:CheckBox ID="chkBorder" runat="server"
Text="Put Border Around Cells" />
<br /><br />
<asp:Button ID="cmdCreate" OnClick="cmdCreate_Click" runat="server"
Text="Create" />
<br /><br />

<asp:Table ID="tbl" runat= "server">
    <asp:TableRow ID="row" runat="server">
    <asp:TableCell ID="cell" runat="server">A Sample Value</asp:TableCell>
    </asp:TableRow>
</asp:Table>
</div>

<br /><br /><br /><br />
<h2>Regular Expressions</h2>

<asp:Panel ID="Panel1" runat="server">
<asp:TextBox ID="TextBox1" ValidationGroup="Group1" runat="server" />
<asp:RequiredFieldValidator ID="RequiredFieldValidator1"
ErrorMessage="*Required" ValidationGroup="Group1"
runat="server" ControlToValidate="TextBox1" />
<asp:Button ID="Button1" Text="Validate Group1"
ValidationGroup="Group1" runat="server" />
</asp:Panel>
<br />
<asp:Panel ID="Panel2" runat="server">
<asp:TextBox ID="TextBox2" ValidationGroup="Group2"
runat="server" />
<asp:RequiredFieldValidator ID="RequiredFieldValidator2"
ErrorMessage="*Required" ValidationGroup="Group2"
ControlToValidate="TextBox2" runat="server" />
<asp:Button ID="Button2" Text="Validate Group2"
ValidationGroup="Group2" runat="server" />
</asp:Panel>
</asp:Content>





