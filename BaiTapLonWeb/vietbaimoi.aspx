<%@ Page Title="" Language="C#" MasterPageFile="~/MasterpageFix.Master" AutoEventWireup="true" CodeBehind="vietbaimoi.aspx.cs" Inherits="BaiTapLonWeb.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Viết bài mới</title>
    <link href="css/bang.css" rel="stylesheet" />
    <style>
        .tieudenhom {
            height:34px;
            width:auto;
            line-height:34px;
            background-color:#555;
            text-transform:uppercase;
            box-sizing:border-box;
            padding:0 5px 0 15px;
            font-size:13px;
            margin-bottom:15px;
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="nhom">
         <div class="tieudenhom">Viết Bài Mới</div>
        <table class="bang" border="0">
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text="Chủ đề"></asp:Label></td>
                <td><asp:DropDownList ID="ddldschude" runat="server" CssClass="ddl"></asp:DropDownList></td>
            </tr>
            <tr><td>Tiêu đề</td>
                <td><asp:TextBox ID="txtTenchude" runat="server" CssClass="txt" Width="500"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTenchude" ErrorMessage="(*)"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr><td>nội dung</td>
                <td><asp:TextBox ID="txtNoidung" runat="server" BorderStyle="NotSet" TextMode="MultiLine" CssClass="txt" Rows="6" Width="500"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNoidung" ErrorMessage="(*)"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr><td>Upload File</td>
                <td><asp:RadioButton ID="rdbtnkhong" runat="server" Text="Không" GroupName="rdbtnchon" Checked="True" AutoPostBack="True" CssClass="rdbtn" /><asp:RadioButton ID="rdbtnco" runat="server" Text="Có" GroupName="rdbtnchon" CssClass="rdbtn" AutoPostBack="True" /><br />
                    <asp:FileUpload ID="fupload" runat="server" CssClass="fup" /></td>
            </tr>
            <tr><td colspan="2">
                    <asp:Button ID="btnDongy" runat="server" Text="Đồng ý" CssClass="btn" OnClick="btnDongy_Click" />
                    <asp:Button ID="btnNhaplai" runat="server" Text="Nhập lại" CssClass="btn" OnClick="btnNhaplai_Click"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
