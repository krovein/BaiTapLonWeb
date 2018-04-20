<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="quanlychude.aspx.cs" Inherits="BaiTapLonWeb.quanlychude" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
        <div>
            <%--OnRowUpdating="gridAge_RowUpdating"--%>
            <asp:GridView ID="grdV" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_sMachude"  ShowFooter="true" >
                <Columns>
                    <asp:TemplateField HeaderText="Mã chủ đề">
                        <ItemTemplate>
                            <%# Eval("ID_sMachude")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tên chủ đề">
                        <ItemTemplate>
                            <%# Eval("sTenchude")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Mã nhóm chủ đề">
                        <ItemTemplate>
                            <%# Eval("FK_iManhomchude")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ButtonType="Button" ControlStyle-CssClass="buttonSetting" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
