<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Blog.aspx.cs" Inherits="Blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div>Rows:
<asp:TextBox ID="txtRows" runat="server" />
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


</asp:Content>





