<%@ Page Title="" Language="C#" MasterPageFile="~/mtpIndex.Master" AutoEventWireup="true" CodeBehind="danhsachbaiviet.aspx.cs" Inherits="BaiTapLonWeb.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Các bài viết</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="nhom nhombaiviet">
        <div class="tieudenhom"><asp:Label ID="lbltieude" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btnvietbaimoi" runat="server" Text="Viết Bài Mới" CssClass="vebenphai btn" OnClick="btnvietbaimoi_Click" />
            <asp:DropDownList ID="ddlds" runat="server" CssClass="ddl" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="danhsachbaiviet">
            <asp:DataList ID="dtlbaiviet" runat="server" RepeatColumns="1" Width="960px">
                <ItemTemplate>
                    <div class="linkbaiviet">
                        <asp:HyperLink ID="HyperLink2" runat="server" Text='<%#Eval("sTieudebaiviet") %>' CssClass="tieudelinkbaiviet" NavigateUrl='<%# "~/baiviet.aspx?idbaiviet=" + Eval("ID_iMabaiviet")%>'></asp:HyperLink>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("dtThoigiandang") %>' CssClass="thoigiandang"></asp:Label>
                        <asp:HyperLink ID="HyperLink8" runat="server" Text='<%#Eval("ID_sTentaikhoan") %>' CssClass="nguoidang" NavigateUrl='<%# "~/hoso.aspx?id=" + Eval("ID_sTentaikhoan")%>'></asp:HyperLink>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
