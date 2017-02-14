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
   <input type= "submit" value="OK" id="Convert" runat="server" 
   OnServerClick="Convert_ServerClick" />
   <input type="submit" value="Show Graph" ID="ShowGraph" OnServerClick="Convert_ServerClick" runat="server" />
   <br /><br />
   <img ID="Graph" src="" alt="Currency Graph" runat="server" />
   <br /><br />
   <input type="image" ID="ImgButton" runat="server" src="button.png"
OnServerClick="ImgButton_ServerClick" />
   <p style="font-weight:bold" Id= "Result" runat="server"></p>
   </div>
</asp:Content>



