<%@ Page Title="" Language="C#" MasterPageFile="~/mtpLogin.Master" AutoEventWireup="true" CodeBehind="dangnhap.aspx.cs" Inherits="BaiTapLonWeb.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Đăng nhập vào diễn đàn</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="bang" border="0 px">
        <tr><td colspan="2">Vui lòng đăng nhập để sử dụng diễn đàn</td></tr>
        <tr><td>Tài Khoản</td>
            <td>
                <asp:TextBox ID="txttk" runat="server" CssClass="txt" ></asp:TextBox>
            </td>
        </tr>
        <tr><td>Mật Khẩu</td>
            <td>
                <asp:TextBox ID="txtmk" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr><td colspan="2">
                <asp:Button ID="btndangnhap" runat="server" Text="Đăng Nhập" CssClass="btn" OnClick="btndangnhap_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
