<%@ Page Title="" Language="C#" MasterPageFile="~/MasterpageFix.Master" AutoEventWireup="true" CodeBehind="hotrovalienhe.aspx.cs" Inherits="BaiTapLonWeb.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Hỗ trợ & liên hệ</title>
    <link href="css/bang.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="bang" border="1px">
        <tr>
            <td colspan="2"><asp:Label ID="Label1" runat="server" Text="Liên Hệ"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label2" runat="server" Text="Họ và Tên"></asp:Label></td>
            <td><asp:TextBox ID="TextBox1" runat="server" CssClass="txt"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label3" runat="server" Text="Email"></asp:Label></td>
            <td><asp:TextBox ID="TextBox2" runat="server" CssClass="txt"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label4" runat="server" Text="Nội Dung"></asp:Label></td>
            <td><asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Rows="5" CssClass="txt"></asp:TextBox></td>
        </tr>
        <tr><td colspan="2"><asp:Button ID="Button1" runat="server" Text="Gửi" CssClass="btn" /></td></tr>
    </table>
</asp:Content>
