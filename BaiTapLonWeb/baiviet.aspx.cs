using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;

namespace BaiTapLonWeb
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        DataTable dt;
        string idbaiviet;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                idbaiviet = Request.QueryString["idbaiviet"];
                if (idbaiviet != null)
                {
                    xoabaiviet.Visible = false;
                    if (Session["taikhoan"] == null)
                    {
                        traloi.Visible = false;
                        bangnhapcautraloi.Visible = false;
                    }
                    else
                    {
                        traloi.Visible = true;
                        bangnhapcautraloi.Visible = true;
                    }
                    SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("select ID_iMabaiviet,sTieudebaiviet,sNoidungbaiviet,sAvatar,dtthoigiandang,ID_sTentaikhoan,sLinktai,FK_iMaquyen,iDuyet from tblBaiviet,tbltaikhoan where tblBaiviet.FK_sTentaikhoan = tbltaikhoan.ID_sTentaikhoan and ID_iMabaiviet = '" + idbaiviet + "'", cnn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    cnn.Close();
                    if (dt.Rows.Count > 0)
                    {
                        lbltieudebaiviet.Text = dt.Rows[0]["sTieudebaiviet"].ToString();
                        imgnguoiviet.ImageUrl = dt.Rows[0]["sAvatar"].ToString();
                        linknguoiviet.Text = dt.Rows[0]["ID_sTentaikhoan"].ToString();
                        linknguoiviet.NavigateUrl = "hoso.aspx?id=" + dt.Rows[0]["ID_sTentaikhoan"].ToString();
                        if (dt.Rows[0]["sLinktai"].ToString().Equals(""))
                        {
                            linkfiledinhkem.Visible = false;
                        }
                        else
                        {
                            linkfiledinhkem.NavigateUrl = dt.Rows[0]["sLinktai"].ToString();
                        }
                        if (dt.Rows[0]["iDuyet"].ToString().Equals("0"))
                        {
                            bangnhapcautraloi.Visible = false;
                        }
                        if (Session["quyen"] != null && Session["quyen"].ToString().Equals("1"))
                        {
                            xoabaiviet.Visible = true;
                        }
                        dtlnoidungbaiviet.DataSource = dt;
                        dtlnoidungbaiviet.DataBind();
                        loadcautraloi();
                    }
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
        }
        protected void loadcautraloi()
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
            idbaiviet = Request.QueryString["idbaiviet"];
            cnn.Open();
            SqlCommand cmdlaybaitraloi = new SqlCommand("select ID_iMabaitraloi,sNoidungbaitraloi,FK_iMabaiviet,fk_sNguoiviet,dtThoigiantraloi,sAvatar from tblbaitraloi,tbltaikhoan where FK_iMabaiviet = '" + idbaiviet + "' and tblbaitraloi.fk_sNguoiviet=tbltaikhoan.ID_sTentaikhoan ", cnn);
            SqlDataAdapter dalaybaitraloi = new SqlDataAdapter(cmdlaybaitraloi);
            DataTable dtlaybaitraloi = new DataTable();
            dalaybaitraloi.Fill(dtlaybaitraloi);
            cnn.Close();
            dtlbaitraloi.DataSource = dtlaybaitraloi;
            dtlbaitraloi.DataBind();
        }
        protected void btnThemcautraloi_Click(object sender, EventArgs e)
        {
            if (Session["taikhoan"] != null)
            {
                idbaiviet = Request.QueryString["idbaiviet"];
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
                cnn.Open();
                SqlCommand cmdthembaitraloi = new SqlCommand("insert into tblbaitraloi(sNoidungbaitraloi,FK_iMabaiviet,fk_sNguoiviet,dtThoigiantraloi) values (N'" + txtNoidungcautraloi.Text + "'," + idbaiviet + ",'" + Session["taikhoan"].ToString() + "','" + DateTime.Now.ToString() + "')", cnn);
                try
                {
                    cmdthembaitraloi.ExecuteNonQuery();
                    txtNoidungcautraloi.Text = null;
                    loadcautraloi();
                }
                catch
                {
                    Response.Write("<script>alert('Kích thước tối được nhập vào là 500 kí tự')</script>");
                }
                cnn.Close();
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }
        protected void dtlnoidungbaiviet_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Button btnxoatraloi = (Button)e.Item.FindControl("xoatl");
            if (Session["quyen"] != null && Session["quyen"].ToString().Equals("1"))
            {
                btnxoatraloi.Visible = true;
            }
            else
            {
                btnxoatraloi.Visible = false;
            }
        }
        protected void dtlbaitraloi_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Equals("nutxoatraloi"))
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
                cnn.Open();
                SqlCommand cmdxoabaitraloi = new SqlCommand("delete from tblbaitraloi where ID_iMabaitraloi= '"+e.CommandArgument+"'", cnn);
                cmdxoabaitraloi.ExecuteNonQuery();
                cnn.Close();
                loadcautraloi();
            }
        }
        protected void xoabaiviet_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Bạn muốn xoá bài viết?')</script>");
            if (Session["taikhoan"] != null)
            {
                idbaiviet = Request.QueryString["idbaiviet"];
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
                cnn.Open();
                SqlCommand cmdxoabaitraloi = new SqlCommand("delete from tblbaiviet where ID_iMabaiviet= '" + idbaiviet + "'", cnn);
                cmdxoabaitraloi.ExecuteNonQuery();
                cnn.Close();
            }
            Response.Redirect("index.aspx");
        }
        protected void traloi_Click(object sender, EventArgs e)
        {
            txtNoidungcautraloi.Focus();
        }
    }
}