<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<div>
<h1>Controls being monitored for change events:</h1>
<asp:TextBox ID="txt" runat="server" AutoPostBack="true"
OnTextChanged="CtrlChanged" />
<br /><br />
<asp:CheckBox ID="chk" runat="server" AutoPostBack="true"
OnCheckedChanged="CtrlChanged"/>
<br /><br />
<asp:RadioButton ID="opt1" runat="server" GroupName="Sample"
AutoPostBack="true" OnCheckedChanged="CtrlChanged"/>
<asp:RadioButton ID="opt2" runat="server" GroupName="Sample"
AutoPostBack="true" OnCheckedChanged="CtrlChanged"/>
<h1>List of events:</h1>
<asp:ListBox ID="lstEvents" runat="server" Width="355px"
Height="150px" /><br />
<br /><br /><br />
</div>

</asp:Content>

