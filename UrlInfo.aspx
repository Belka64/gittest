<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UrlInfo.aspx.cs" Inherits="Nemetos.BCH.Importers.UrlInfo.UrlInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <style type="text/css">
        .calendar {
             display: inline-block;
            margin: 10px;
        }

    </style>
    <body>
        <form id="form1" runat="server">
            <div>
                URL:
                <asp:textbox ID="urlTextbox" runat="server">/sitecore/service/keepalive.aspx</asp:textbox>
                <br />
                Path to logs: <asp:TextBox ID="pathTextBox" runat="server">C:\inetpub\logs\LogFiles\W3SVC1</asp:TextBox>
                
                <br />
                
                <asp:Calendar ID="startDateCalendar" runat="server" SelectedDate="2014-01-01" CssClass="calendar"></asp:Calendar>
                <asp:Calendar ID="endDateCalendar" runat="server" SelectedDate="06/16/2014 12:12:26" CssClass="calendar"></asp:Calendar>
               
        

                
                
                <br />
               
        

                
                
                <asp:Button ID="getInfoAboutUrlButton" runat="server" Text="Process" OnClick="GetInfoAboutUrlButtonClick" />
            </div>
            <asp:GridView ID="ResultGrid" runat="server">
            </asp:GridView>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </form>
    </body>
</html>