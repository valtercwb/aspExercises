<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script language="javascript" type="text/javascript">
<!--
// -->
    </script>
    <style type="text/css">
        #Currency
        {
            width: 153px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        Convert: &nbsp;&nbsp;
        <input type="text" id="US" runat="server" />
        &nbsp; U.S dollars to &nbsp;
        <select id="Currency" runat="server" /><!--Drop down list-->
        <input type="submit" value="OK" id="Convert" runat="server" onserverclick="Convert_ServerClick" />
        <input type="submit" value="Show Graph" id="ShowGraph" onserverclick="Convert_ServerClick"
            runat="server" />
        <br />
        <br />
        <img id="Graph" src="" alt="Currency Graph" runat="server" />
        <br />
        <br />
        <input type="image" id="ImgButton" runat="server" src="button.png" onserverclick="ImgButton_ServerClick" />
        <p style="font-weight: bold" id="Result" runat="server">
        </p>
    </div>
    <br />
    <br />
    <br />
    <div>
        First Name:
        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        <br />
        Last Name:
        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button runat="server" ID="cmdPost" PostBackUrl="Products.aspx" Text="Cross-Page Postback" /><br />
    </div>
</asp:Content>
