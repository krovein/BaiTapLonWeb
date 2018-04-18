<%@ Page Title="" Language="C#" MasterPageFile="~/MasterpageFix.Master" AutoEventWireup="true" CodeBehind="duyetbai.aspx.cs" Inherits="BaiTapLonWeb.WebForm9" enableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Duyệt bài</title>
    <link href="css/linkbaiviet.css" rel="stylesheet" />
    <style>
        a {
            text-decoration:none;
            color:#f60;
        }
        .ds {
            width:960px;
            height:35px;
            line-height:35px;
            text-align:center;
        }
        .itemtieude {
            width:500px;
            height:auto;
            float:left;
            padding-left:15px;
            box-sizing:border-box;
            border-right:1px dotted #555;
        }
        .itemthoigian {
            width:150px;float:left;
            box-sizing:border-box;
            border-right:1px dotted #555;
        }
        .itemtaikhoan {
            width:150px;float:left;
            box-sizing:border-box;
            border-right:1px dotted #555;
        }
        .itemduyet {
            width:80px;float:left;
            box-sizing:border-box;
            border-right:1px dotted #555;
        }
        .itemxoa {
            width:80px;float:left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tieudenhom">Duyệt bài</div>
        <asp:DataList ID="dtldschuaduyet" runat="server" Width="960px" OnItemCommand="dtldschuaduyet_ItemCommand">
            <ItemTemplate>
                <div class="ds">
                    <div class="itemtieude"><asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" Text='<%# Eval("sTieudebaiviet") %>' NavigateUrl='<%#"~/baiviet.aspx?idbaiviet=" + Eval("ID_iMabaiviet") %>'></asp:HyperLink></div>
                    <div class="itemthoigian"><asp:Label ID="Label2" runat="server" Text='<%# Eval("dtThoigiandang") %>'></asp:Label></div>
                    <div class="itemtaikhoan"><asp:Label ID="Label3" runat="server" Text='<%# Eval("FK_sTentaikhoan") %>'></asp:Label></div>
                    <div class="itemduyet"><asp:Button ID="btnduyet" CommandName="nutduyet" runat="server" CssClass="btn" Text="Duyệt" CommandArgument='<%# Eval("ID_iMabaiviet") %>' /></div>
                    <div class="itemxoa"><asp:Button ID="btnxoa" CommandName="nutxoa" runat="server" CssClass="btn" Text="Xóa" CommandArgument='<%# Eval("ID_iMabaiviet") %>' /></div>
                </div>
            </ItemTemplate>
        </asp:DataList>
</asp:Content>
