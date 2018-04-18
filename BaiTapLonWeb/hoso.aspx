<%@ Page Title="" Language="C#" MasterPageFile="~/MasterpageFix.Master" AutoEventWireup="true" CodeBehind="hoso.aspx.cs" Inherits="BaiTapLonWeb.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Hồ sơ</title>
    <style>
        .hoso {
            width:750px;
            height:auto;
            background-color:#444;
            margin:15px auto;  
        }
            .hoso .tenhoso {
                width:100%;
                float:left;
                text-transform:uppercase;
                background-color:#555;
                text-align:center;
                height:45px;
                line-height:45px;
            }
            .hoso .tthoso {
               width:100%;
               height:auto;
               float:left;
               background-color:#444;
            }
                .hoso .tthoso .avatar {
                    width:250px;
                    height:auto;
                    float:left;
                    background-color:#555;
                    margin:5px;
                    text-align:center;
                    padding-bottom:5px;
                    line-height:30px;
                }
                    .hoso .tthoso .avatar img {
                        border:8px solid #555;
                        box-sizing:border-box;
                        width:250px;
                        height:250px;
                        border-bottom:10px solid #444;
                    }
                .hoso .tthoso .thongtin {
                    width:490px;
                    min-height:250px;
                    background-color:#555;
                    float:left;
                    box-sizing:border-box;
                    padding:15px 10px 15px 25px;
                    margin-top:5px;
                }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hoso">
        <div class="tenhoso"><asp:Label ID="lbltenhoso" runat="server" Text="Hồ sơ của "></asp:Label><asp:Label ID="ten" runat="server"></asp:Label></div>
        <div class="tthoso">
            <div class="avatar">
                <asp:Image ID="imgavatar" runat="server" />
                <asp:Label ID="lblthayavatar" runat="server" Text="Thay đổi Avatar"></asp:Label>
                <br />
                <asp:FileUpload ID="upavatar" runat="server" />
                <br />
                
                <asp:Button ID="btnSaveavatar" runat="server" CssClass="btn" Text="Cập nhật Avatar" OnClick="btnSaveavatar_Click" />
            </div>
            <div class="thongtin">
                <table class="bang">
                    <tr>
                        <td><asp:Label ID="lblhovaten" runat="server" Text="Họ và tên"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txthoten" runat="server" Enabled="False"></asp:TextBox> </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblemail" runat="server" Text="Email:" ></asp:Label></td>
                        <td><asp:TextBox ID="txtemail" runat="server" Enabled="False"></asp:TextBox> </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblngaysinh" runat="server" Text="Ngày sinh:" ></asp:Label></td>
                        <td><asp:TextBox ID="txtngaysinh" runat="server" Enabled="False" ></asp:TextBox> </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblgioitinh" runat="server" Text="Giới tính:" ></asp:Label></td>
                        <td>
                            <asp:RadioButtonList ID="rblGioitinh" runat="server" Enabled="False">
                                <asp:ListItem Value="True">Nam</asp:ListItem>
                                <asp:ListItem Selected="True" Value="False">Nữ</asp:ListItem>

                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lbldiachi" runat="server" Text="Địa chỉ:" ></asp:Label></td>
                        <td><asp:TextBox ID="txtdiachi" runat="server" Enabled="False"></asp:TextBox> </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblquyen" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lbllastlogin" runat="server" Text="Đăng nhập lần cuối"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtlastlogin" runat="server" Enabled="false"></asp:TextBox> </td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="btnXoa" runat="server" Text="Xóa tài khoản" CssClass="btn" OnClick="btnXoa_Click" /></td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="btnSua" runat="server" Text="Sửa thông tin tài khoản" CssClass="btn" OnClick="btnSua_Click" /></td>
                        <td>
                            <asp:Button ID="btnLuu" runat="server" Text="Lưu" Visible="False" 
                                CssClass="btn" onclick="btnLuu_Click"/> </td>
                    </tr>
                </table>

            </div>
        </div>
    </div>
</asp:Content>
