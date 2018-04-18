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
    public partial class WebForm10 : System.Web.UI.Page
    {
        
        protected void loaddulieuvaodatalist(string strcmd, DataList dtl)
        {
            string chude = Request.QueryString["chude"];
            string tukhoa = Request.QueryString["search"];
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
            cnn.Open();
            SqlCommand cmd = new SqlCommand(strcmd, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            if (tukhoa != null)
            {
                lbltieude.Text = "Kết quả tìm kiếm từ khóa: " + tukhoa + "";
            }
            if (dt.Rows.Count == 0)
            {
                Response.Write("<script>alert('Không có bài viết nào!')</script>");
            }
            else
            {
                dtl.DataSource = dt;
                dtl.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string chude = Request.QueryString["chude"];
            string tukhoa = Request.QueryString["search"];
            if (chude == null && tukhoa == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                lbltieude.Text = "Danh sách bài viết";
                if (Session["quyen"] == null)
                {
                    btnvietbaimoi.Visible = false;
                }
                else
                {
                    if (chude!=null&&(chude.Equals("thongbao") || chude.Equals("noiquy")))
                    {
                        if (Session["quyen"].ToString().Equals("1"))
                        {
                            btnvietbaimoi.Visible = true;
                        }
                        else
                        {
                            btnvietbaimoi.Visible = false;
                        }
                    }
                    else
                    {
                        btnvietbaimoi.Visible = true;
                    }
                }
                if (chude != null)
                {
                    loaddulieuvaodatalist("select ID_iMabaiviet,sTieudebaiviet,dtThoigiandang,ID_sTentaikhoan from tblBaiviet,tbltaikhoan where tblBaiviet.FK_sTentaikhoan = tbltaikhoan.ID_sTentaikhoan and iDuyet=1 and FK_sMachude='" + chude + "'", dtlbaiviet);
                }
                else if (tukhoa != null)
                {
                    loaddulieuvaodatalist("select ID_iMabaiviet,sTieudebaiviet,dtThoigiandang,ID_sTentaikhoan from tblBaiviet,tbltaikhoan where tblBaiviet.FK_sTentaikhoan = tbltaikhoan.ID_sTentaikhoan and iDuyet=1 and sTieudebaiviet LIKE N'" + tukhoa + "'", dtlbaiviet);
                }
            }
        }
        protected void btnvietbaimoi_Click(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.Query;
            Response.Redirect("vietbaimoi.aspx"+url+"");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadddl();
        }
        protected void loadddl()
        {
            string chude = Request.QueryString["chude"];
            string tukhoa = Request.QueryString["search"];
            if (ddlds.SelectedIndex.Equals(1))
            {
                if(chude!=null)
                {
                    loaddulieuvaodatalist("select TOP 20 ID_iMabaiviet,sTieudebaiviet,dtThoigiandang,ID_sTentaikhoan from tblBaiviet,tbltaikhoan where tblBaiviet.FK_sTentaikhoan = tbltaikhoan.ID_sTentaikhoan and iDuyet=1 and FK_sMachude='" + chude + "'", dtlbaiviet);
                }
                else if (tukhoa != null)
                {
                    loaddulieuvaodatalist("select TOP 20 ID_iMabaiviet,sTieudebaiviet,dtThoigiandang,ID_sTentaikhoan from tblBaiviet,tbltaikhoan where tblBaiviet.FK_sTentaikhoan = tbltaikhoan.ID_sTentaikhoan and iDuyet=1 and sTieudebaiviet LIKE N'" + tukhoa + "'", dtlbaiviet);
                }
            }
            else if (ddlds.SelectedIndex.Equals(2))
            {
                if (chude != null)
                {
                    loaddulieuvaodatalist("select TOP 30 ID_iMabaiviet,sTieudebaiviet,dtThoigiandang,ID_sTentaikhoan from tblBaiviet,tbltaikhoan where tblBaiviet.FK_sTentaikhoan = tbltaikhoan.ID_sTentaikhoan and iDuyet=1 and FK_sMachude='" + chude + "'", dtlbaiviet);
                }
                else if (tukhoa != null)
                {
                    loaddulieuvaodatalist("select TOP 30 ID_iMabaiviet,sTieudebaiviet,dtThoigiandang,ID_sTentaikhoan from tblBaiviet,tbltaikhoan where tblBaiviet.FK_sTentaikhoan = tbltaikhoan.ID_sTentaikhoan and iDuyet=1 and sTieudebaiviet LIKE N'" + tukhoa + "'", dtlbaiviet);
                }
            }
            else
            {
                if (chude != null)
                {
                    loaddulieuvaodatalist("select TOP 10 ID_iMabaiviet,sTieudebaiviet,dtThoigiandang,ID_sTentaikhoan from tblBaiviet,tbltaikhoan where tblBaiviet.FK_sTentaikhoan = tbltaikhoan.ID_sTentaikhoan and iDuyet=1 and FK_sMachude='" + chude + "'", dtlbaiviet);
                }
                else if (tukhoa != null)
                {
                    loaddulieuvaodatalist("select TOP 10 ID_iMabaiviet,sTieudebaiviet,dtThoigiandang,ID_sTentaikhoan from tblBaiviet,tbltaikhoan where tblBaiviet.FK_sTentaikhoan = tbltaikhoan.ID_sTentaikhoan and iDuyet=1 and sTieudebaiviet LIKE N'" + tukhoa + "'", dtlbaiviet);
                }
            }
        }
    }
}