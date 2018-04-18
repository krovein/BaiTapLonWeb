<%@ Page Title="" Language="C#" MasterPageFile="~/mtpLogin.Master" AutoEventWireup="true" CodeBehind="dangky.aspx.cs" Inherits="BaiTapLonWeb.WebForm4" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Đăng ký tài khoản </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="bang" border="0 px">
        <tr><td colspan="3">Điền vào form để đăng ký tài khoản</td></tr>
        <tr><td>Tài Khoản</td>
            <td><asp:TextBox ID="txttk" runat="server" CssClass="txt"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txttk" ErrorMessage="(* Tên tài khoản không được để trống!)"></asp:RequiredFieldValidator></td>
        </tr>
        <tr><td>Họ và tên</td>
            <td><asp:TextBox ID="txthoten" runat="server" CssClass="txt"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txthoten" ErrorMessage="(* Họ tên không được để trống)" ></asp:RequiredFieldValidator></td>
        </tr>
        <tr><td>Mật Khẩu</td>
            <td><asp:TextBox ID="txtmk" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtmk" ErrorMessage="(* Mật khẩu không được để trống)"></asp:RequiredFieldValidator></td>
        </tr>
        <tr><td>Nhập lại mật khẩu</td>
            <td><asp:TextBox ID="txtremk" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtremk" ErrorMessage="(* Nhập lại mật khẩu không được để trống)"></asp:RequiredFieldValidator></td>
        </tr>
       
        <tr>
             <td>Email</td>
             <td><asp:TextBox ID="txtemail" runat="server"  CssClass="txt"></asp:TextBox> </td>
        </tr>
        <tr>
            <td>Ngày sinh</td>
            <td><asp:TextBox ID="txtngaysinh" runat="server"  CssClass="txt"></asp:TextBox> </td>
        </tr>
        <tr>
            <td>Giới tính</td>
            <td>
               <asp:RadioButtonList ID="rblGioitinh" runat="server" >
               <asp:ListItem Value="True">Nam</asp:ListItem>
               <asp:ListItem Selected="True" Value="False">Nữ</asp:ListItem>
               </asp:RadioButtonList>
            </td>
         </tr>
         <tr>
             <td>Địa chỉ</td>
             <td><asp:TextBox ID="txtdiachi" runat="server"  CssClass="txt"></asp:TextBox> </td>
        </tr>
        <tr><td colspan="3">
                <!--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="-Tài khoản tối thiểu 6 ký tự-" ControlToValidate="txttk" Display="Dynamic" ValidationExpression="(\d|\w){6,}"></asp:RegularExpressionValidator><br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtmk" Display="Dynamic" ErrorMessage="- Mật khẩu tối thiểu 6 ký tự" ValidationExpression="(\d|\w){6,}"></asp:RegularExpressionValidator><br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtmk" ControlToValidate="txtremk" Display="Dynamic" ErrorMessage="- Nhập lại mật khẩu không trùng-"></asp:CompareValidator><br />-->
                <asp:Label ID="lblerrdk" runat="server" EnableTheming="True"></asp:Label><br />
                <asp:Button ID="btndangky" runat="server" Text="Đăng Ký" CssClass="btn" OnClick="btndangky_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
