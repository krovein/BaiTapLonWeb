<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/mtpLogin.Master" CodeBehind="suathongtintaikhoan.aspx.cs" Inherits="BaiTapLonWeb.suathongtintaikhoan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Thông tin tài khoản</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hoso">
        <div class="tenhoso"><asp:Label ID="lbltenhoso" runat="server"></asp:Label></div>
        <div class="tthoso">
            <div class="avatar">
                <asp:Image ID="imgavatar" runat="server" />
                <asp:Label ID="lblthayavatar" runat="server" Text="Thay đổi Avatar"></asp:Label>
                <br />
                <asp:FileUpload ID="upavatar" runat="server" />
                <br />
                
                <asp:Button ID="btnSaveavatar" runat="server" CssClass="btn" 
                    Text="Cập nhật Avatar" onclick="btnSaveavatar_Click"  />
            </div>
            <div class="thongtin">
                <table class="bang">
                    <tr>
                        <td><asp:Label ID="lblhovaten" runat="server" Text=""></asp:Label></td>
                        <td> 
                            <asp:TextBox ID="txthoten" runat="server"></asp:TextBox></td>
                        
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblquyen" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lbllastlogin" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSua" runat="server" Text="Sửa thông tin tài khoản" 
                                CssClass="btn" onclick="btnSua_Click"   />
                        </td>
                    </tr>
                </table>

            </div>
        </div>
    </div>
</asp:Content>
