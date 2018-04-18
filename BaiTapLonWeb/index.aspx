<%@ Page Title="" Language="C#" MasterPageFile="~/mtpIndex.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="BaiTapLonWeb.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Trang chủ diễn đàn lập thảo luận</title>
    <link href="css/nhomchude.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="nhom">
        <div class="tieudenhom">Tin tức sự kiện</div>
        <div class="danhsachchude">
            <asp:DataList ID="dtladmin" runat="server" RepeatColumns="7">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="chude" 
                        NavigateUrl='<%# "~/danhsachbaiviet.aspx?chude=" + Eval("ID_sMachude") %>' 
                        Text='<%# Bind("sTenchude") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <div class="nhom">
        <div class="tieudenhom">Tài liệu lập trình</div>
        <ul class="danhsachchude"> 
            <asp:DataList ID="dtltailieu" runat="server" RepeatColumns="7">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="chude" NavigateUrl='<%# "~/danhsachbaiviet.aspx?chude=" + Eval("ID_sMachude")%>' Text='<%#Bind("sTenchude") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:DataList>
        </ul>
    </div>
    <div class="nhom">
        <div class="tieudenhom">Hỏi đáp</div>
        <div class="danhsachchude"> 
            <asp:DataList ID="dtlhoidap" runat="server" RepeatColumns="7">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="chude" NavigateUrl='<%# "~/danhsachbaiviet.aspx?chude=" + Eval("ID_sMachude")%>' Text='<%#Bind("sTenchude") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
