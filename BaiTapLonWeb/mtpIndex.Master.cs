using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BaiTapLonWeb
{
    public partial class Masterpage2 : System.Web.UI.MasterPage
    {
        protected void laydulieuvaodatalist(string strcmd, DataList dtl)
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
            cnn.Open();
            SqlCommand cmd = new SqlCommand(strcmd, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cnn.Close();
            da.Fill(dt);
            dtl.DataSource = dt;
            dtl.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblonline.Text = Application["demonline"].ToString();
            lbldatruycap.Text = Application["datruycap"].ToString();
            if (Session["taikhoan"] != null)
            {
                lblloichao.Text = "Chúc " + Session["taikhoan"] + " online vui vẻ!";
                itemmenuvietbaimoi.Visible = true;
                dangnhap_dangxuat.Text = "Đăng xuất";
                dangnhap_dangxuat.NavigateUrl = "";
                dangnhap_dangxuat.Attributes["onclick"] = "hoidangxuat()";
                dangky_hoso.Text = Session["taikhoan"].ToString();
                dangky_hoso.NavigateUrl = "~/hoso.aspx?id=" + Session["taikhoan"] + "";
            }
            else
            {
                lblloichao.Text = "Chúc bạn online vui vẻ!";
                itemmenuvietbaimoi.Visible = false;
                dangnhap_dangxuat.Text = "Đăng nhập";
                dangnhap_dangxuat.NavigateUrl = "~/dangnhap.aspx";
                dangky_hoso.Text = "Đăng ký";
                dangky_hoso.NavigateUrl = "~/dangky.aspx";
                lblloichao.Text += "<br/>Hãy đăng nhập để có thể sử dụng tối đa diễn đàn!";
            }
            //truy xuất dữ liệu
            if(!IsPostBack)
            {
                laydulieuvaodatalist("select TOP 10 ID_iMabaiviet,sTieudebaiviet,dtthoigiandang,ID_sTentaikhoan from tblBaiviet,tbltaikhoan where tblBaiviet.FK_sTentaikhoan = tbltaikhoan.ID_sTentaikhoan and iDuyet=1 ORDER BY ID_iMabaiviet DESC", dtlbaivietmoi);
            }
            if (Session["taikhoan"] != null)
            {
                if (Session["quyen"].ToString().Equals("1"))
                {
                    SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("select * from tblbaiviet where iDuyet = 0", cnn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblloichao.Text += "<br/><br/><a href='duyetbai.aspx' style='text-decoration:none;color:#f60'>Hiện có " + dt.Rows.Count + " bài viết chưa được duyệt</a>";
                    }
                }
            }
        }
        protected void ddlsobaiviet_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadddl();
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            string[] a = new string[txtsearch.Text.Length];
            string b="";
            for (int i = 0; i < txtsearch.Text.Length; i++)
            {
                if (txtsearch.Text[i].ToString().Equals(" "))
                {
                    a[i] = "%";
                }
                else
                {
                    a[i] = txtsearch.Text[i].ToString();
                }
            }
            for (int j = 0; j < a.Length; j++)
            {
                b += a[j];
            }
            b = "%" + b + "%";
            Response.Redirect("danhsachbaiviet.aspx?search="+b+"");
        }
        protected void ddlsapxep_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadddl();
        }
        protected void loadddl()
        {
            if (ddlsobaiviet.SelectedIndex.Equals(1))
            {
                if (ddlsapxep.SelectedIndex.Equals(0))
                {
                    laydulieuvaodatalist("select TOP 20 ID_iMabaiviet,sTieudebaiviet,dtThoigiandang,ID_sTentaikhoan from tblBaiviet,tbltaikhoan where tblBaiviet.FK_sTentaikhoan = tbltaikhoan.ID_sTentaikhoan and iDuyet=1 ORDER BY ID_iMabaiviet DESC", dtlbaivietmoi);
                }
                else if (ddlsapxep.SelectedIndex.Equals(1))
                {
                    laydulieuvaodatalist("select TOP 20 ID_iMabaiviet,sTieudebaiviet,dtThoigiandang,ID_sTentaikhoan from tblBaiviet,tbltaikhoan where tblBaiviet.FK_sTentaikhoan = tbltaikhoan.ID_sTentaikhoan and iDuyet=1 ORDER BY sTieudebaiviet ASC", dtlbaivietmoi);
                }
                else
                {
                    laydulieuvaodatalist("select TOP 20 ID_iMabaiviet,sTieudebaiviet,dtThoigiandang,ID_sTentaikhoan from tblBaiviet,tbltaikhoan where tblBaiviet.FK_sTentaikhoan = tbltaikhoan.ID_sTentaikhoan and iDuyet=1 ORDER BY sTieudebaiviet DESC", dtlbaivietmoi);
                }
            }
            else if (ddlsobaiviet.SelectedIndex.Equals(2))
            {
                if (ddlsapxep.SelectedIndex.Equals(0))
                {
                    laydulieuvaodatalist("select TOP 30 ID_iMabaiviet,sTieudebaiviet,dtThoigiandang,ID_sTentaikhoan from tblBaiviet,tbltaikhoan where tblBaiviet.FK_sTentaikhoan = tbltaikhoan.ID_sTentaikhoan and iDuyet=1 ORDER BY ID_iMabaiviet DESC", dtlbaivietmoi);
                }
                else if (ddlsapxep.SelectedIndex.Equals(1))
                {
                    laydulieuvaodatalist("select TOP 30 ID_iMabaiviet,sTieudebaiviet,dtThoigiandang,ID_sTentaikhoan from tblBaiviet,tbltaikhoan where tblBaiviet.FK_sTentaikhoan = tbltaikhoan.ID_sTentaikhoan and iDuyet=1 ORDER BY sTieudebaiviet ASC", dtlbaivietmoi);
                }
                else
                {
                    laydulieuvaodatalist("select TOP 30 ID_iMabaiviet,sTieudebaiviet,dtThoigiandang,ID_sTentaikhoan from tblBaiviet,tbltaikhoan where tblBaiviet.FK_sTentaikhoan = tbltaikhoan.ID_sTentaikhoan and iDuyet=1 ORDER BY sTieudebaiviet DESC", dtlbaivietmoi);
                }
            }
            else
            {
                if (ddlsapxep.SelectedIndex.Equals(0))
                {
                    laydulieuvaodatalist("select TOP 10 ID_iMabaiviet,sTieudebaiviet,dtThoigiandang,ID_sTentaikhoan from tblBaiviet,tbltaikhoan where tblBaiviet.FK_sTentaikhoan = tbltaikhoan.ID_sTentaikhoan and iDuyet=1 ORDER BY ID_iMabaiviet DESC", dtlbaivietmoi);
                }
                else if (ddlsapxep.SelectedIndex.Equals(1))
                {
                    laydulieuvaodatalist("select TOP 10 ID_iMabaiviet,sTieudebaiviet,dtThoigiandang,ID_sTentaikhoan from tblBaiviet,tbltaikhoan where tblBaiviet.FK_sTentaikhoan = tbltaikhoan.ID_sTentaikhoan and iDuyet=1 ORDER BY sTieudebaiviet ASC", dtlbaivietmoi);
                }
                else
                {
                    laydulieuvaodatalist("select TOP 10 ID_iMabaiviet,sTieudebaiviet,dtThoigiandang,ID_sTentaikhoan from tblBaiviet,tbltaikhoan where tblBaiviet.FK_sTentaikhoan = tbltaikhoan.ID_sTentaikhoan and iDuyet=1 ORDER BY sTieudebaiviet DESC", dtlbaivietmoi);
                }
            }
        }
    }
}