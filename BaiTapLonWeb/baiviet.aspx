<%@ Page Title="" Language="C#" MasterPageFile="~/MasterpageFix.Master" AutoEventWireup="true" CodeBehind="baiviet.aspx.cs" Inherits="BaiTapLonWeb.WebForm11"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Bài viết</title>
    <style>
        .bai
        {
            float:left;
            width:100%;
            height:auto;
            background:#333;
        }
            .bai .tenbaiviet {
                width:100%;
                background-color:#555;
                height:45px;
                line-height:45px;
                text-align:center;
            }
        .bai .noidungbaiviet,.bai .noidungbaitraloi{
            width:100%;
            float:left;
            min-height:120px;
            position:relative;
            
        }
        .bai .noidungbaiviet {
            background-color:#393939;
            border-bottom:1px solid #f60;
        }
        .bai .noidungbaitraloi {
            border-bottom:1px solid #444;
        }
        .noidungbaiviet .noidung, .noidungbaitraloi .noidung  {
            width:860px;
            height:auto;
            float:left;
            padding:0px 15px 5px 15px;
            box-sizing:border-box;
            font-size:13px;
        }
        .nguoiviet {
            width:100px;
            height:auto;
            float:left;
            background-color:#4a4a4a;
            text-align:center;
            padding-bottom:9px;
            box-sizing:border-box;
        }
        .nguoiviet img {
            width:94px;
            height:94px;
            border-radius:50px;
            margin:3px;
        }
        a.tennguoiviet {
            text-align:center;
            color:#f60;
            text-decoration:none;
            font-size:12px;
        }
        .ndtraloi {
            width:500px;
            margin:auto;
        }
        .tieudenhom {
            height:34px;
            width:auto;
            line-height:34px;
            background-color:#555;
            text-transform:uppercase;
            box-sizing:border-box;
            padding:0 5px 0 15px;
            font-size:13px;
            text-align:center;
        }
        .thoigian{
            float:right;
            border-bottom:1px dotted #777;
            font-size:11px;
            margin:5px 0px;
            padding-bottom:3px;
        }
        .linktai {
            margin-top:5px;
            float:left;
            color:#f60;
            padding:0 15px;
            font-size:13px;
            text-decoration:none;
        }
        .suaxoanoidung {
            right:0px;
            border-top:1px dotted #777;
            margin: 5px 15px;
            clear:both;
            position:absolute;
            bottom:0px;
        }
            .suaxoanoidung a {
                color:red;
                text-decoration:none;
                margin:0 5px;
            }
                .suaxoanoidung a:hover {
                    color:#f60;
                }
        .panelnhapcautraloi {
            width:100%;
            background-color:#393939;
        }
        /*.phantrang {
            width:100%;
            text-align:center;
        }*/
    </style>
    <link href="css/bang.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bai">
        
        <div class="tieudenhom">
            <asp:Label ID="lbltieudebaiviet" runat="server" Text="">
            </asp:Label><asp:Button ID="traloi" runat="server" Text="Trả lời" CssClass="btn vebenphai" OnClientClick="focus" OnClick="traloi_Click"/>
        </div>
        <div class="noidungbaiviet">
            <div class="nguoiviet">
                <asp:Image ID="imgnguoiviet" runat="server"/>
                <asp:HyperLink ID="linknguoiviet" runat="server" CssClass="tennguoiviet" Text=""></asp:HyperLink>
            </div>
<%-- Datalist nội dung bài viết --%>
            <asp:DataList ID="dtlnoidungbaiviet" runat="server"><ItemTemplate>
            <div class="noidung">
                <div class="thoigian"><asp:Label ID="lblthoigianviet" runat="server" Text='<%# Eval("dtthoigiandang") %>'></asp:Label></div>
                <p style="clear:both"><%# Eval("sNoidungbaiviet") %></p>
            </div>
            </ItemTemplate></asp:DataList>
<%-- End --%>
            <asp:HyperLink ID="linkfiledinhkem" runat="server" CssClass="linktai" Text="=>Tải File đính kèm"></asp:HyperLink>
            <div class="suaxoanoidung"><asp:Button ID="xoabaiviet" CssClass="btn" runat="server" Text="Xóa" OnClick="xoabaiviet_Click" /></div>
            
        </div>
<%-- Datalist nội dung bài trả lời --%>
        <asp:DataList ID="dtlbaitraloi" runat="server" OnItemCommand="dtlbaitraloi_ItemCommand" OnItemDataBound="dtlnoidungbaiviet_ItemDataBound"><ItemTemplate>
            <div class="noidungbaitraloi">
                <div class="nguoiviet"><img src='<%# Eval("sAvatar") %>' /><asp:HyperLink ID="HyperLink1" runat="server" CssClass="tennguoiviet" NavigateUrl='<%#"hoso.aspx?id=" +Eval("FK_sNguoiviet") %>' Text='<%# Eval("FK_sNguoiviet") %>'></asp:HyperLink></div>
                <div class="noidung">
                    <div class="thoigian"><asp:Label ID="Label3" runat="server" Text='<%# Eval("dtThoigiantraloi") %>'></asp:Label></div>
                    <p style="clear:both"><%# Eval("sNoidungbaitraloi") %></p>
                    <div class="suaxoanoidung"><asp:Button ID="xoatl" CssClass="btn" runat="server" CommandName="nutxoatraloi" CommandArgument='<%# Eval("ID_iMabaitraloi") %>' Text="Xóa"/></div>
                </div>
            </div>
        </ItemTemplate></asp:DataList>
<%-- End --%>
        <%--<div class="phantrang">
            <asp:Button ID="btntrangdau" runat="server" Text="Trang đầu" />
            <asp:Button ID="btntrangtruoc" runat="server" Text="Trước" />
            <asp:TextBox ID="txttrang" runat="server" Text="Trang hiện tại"></asp:TextBox>
            <asp:Button ID="btntrangsau" runat="server" Text="Sau" />
            <asp:Button ID="btntrangcuoi" runat="server" Text="Trang cuối" />
        </div>--%>
        <asp:Panel ID="bangnhapcautraloi" runat="server" CssClass="panelnhapcautraloi">
            <table class="bang">
                <tr><td><asp:Label ID="lblNhapcautraloi" runat="server" Text="Nhập câu trả lời"></asp:Label></td></tr>
                <tr><td><asp:TextBox ID="txtNoidungcautraloi" runat="server" CssClass="txt ndtraloi" Rows="6" TextMode="MultiLine"></asp:TextBox></td></tr>
                <tr><td><asp:Button ID="btnThemcautraloi" runat="server" Text="Trả Lời" CssClass="btn" OnClick="btnThemcautraloi_Click" /></td></tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
