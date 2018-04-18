using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace BaiTapLonWeb
{
    public partial class suathongtintaikhoan : System.Web.UI.Page
    {
        protected void loadhoso()
        {
            string taikhoan = Request.QueryString["id"];
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select ID_sTentaikhoan,sHoten,sAvatar,sTenquyen,dtLastlogin from tbltaikhoan,tblQuyen where ID_sTentaikhoan = '" + taikhoan + "' and tbltaikhoan.FK_iMaquyen = tblQuyen.ID_iMaquyen", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cnn.Close();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lbltenhoso.Text = "Hồ sơ của: " + dt.Rows[0]["ID_sTentaikhoan"].ToString();
                imgavatar.ImageUrl = dt.Rows[0]["sAvatar"].ToString();
                lblhovaten.Text = "Họ và tên: " + dt.Rows[0]["sHoten"].ToString();
                lblquyen.Text = "Quyền: " + dt.Rows[0]["sTenquyen"].ToString();
                lbllastlogin.Text = "Đăng nhập lần cuối lúc: " + dt.Rows[0]["dtLastlogin"].ToString();
            }
            else
            {
                Response.Write("<script>alert('Người dùng không tồn tại!')</script>");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["taikhoan"] != null)
                {
                    if (HttpContext.Current.Request.Url.Query == "")
                    {
                        Response.Redirect("~/hoso.aspx?id=" + Session["taikhoan"] + "");
                    }
                    if (Session["quyen"].ToString().Equals("2") || Request.QueryString["id"] == Session["taikhoan"].ToString())
                    {
                        
                        btnSaveavatar.Visible = true;
                        upavatar.Visible = true;
                        lblthayavatar.Visible = true;
                        btnSua.Visible = true;
                    }
                    else
                    {
                        
                        btnSaveavatar.Visible = false;
                        upavatar.Visible = false;
                        lblthayavatar.Visible = false;
                        btnSua.Visible = false;
                    }
                    loadhoso();
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
                
            }
        }
        bool ktrafilename(string filename)
        {
            string ext = Path.GetExtension(filename);
            switch (ext.ToLower())
            {
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpge":
                    return true;
                default:
                    return false;
            }
        }
        bool kiemtrakichthuoc(FileUpload filename)
        {
            int kichthuocfile = filename.PostedFile.ContentLength;
            if (kichthuocfile < 102400 && kichthuocfile > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnSaveavatar_Click(object sender, EventArgs e)
        {
            if (upavatar.FileName.Equals(""))
            {
                Response.Write("<script>alert('Bạn chưa chọn ảnh')</script>");
            }
            else if (Page.IsValid && upavatar.HasFile && ktrafilename(upavatar.FileName) && kiemtrakichthuoc(upavatar))
            {
                string avatarpath = ConfigurationManager.AppSettings["avatarpath"];
                string fileavatarname = "";
                string filepath = "";
                if (upavatar.HasFile)
                {
                    fileavatarname = avatarpath + upavatar.FileName;
                    filepath = MapPath(fileavatarname);
                    try
                    {
                        upavatar.SaveAs(filepath);
                        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
                        cnn.Open();
                        SqlCommand cmd = new SqlCommand("update tbltaikhoan set sAvatar = '" + fileavatarname + "' where ID_sTentaikhoan = '" + Session["taikhoan"].ToString() + "'", cnn);
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                        loadhoso();
                    }
                    catch
                    {
                        Response.Write("<script>alert('Upload không thành công! vui lòng kiểm tra tên ảnh, kích thước không quá 1mb và đuôi ảnh dạng jpg,png')</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Upload không thành công! vui lòng kiểm tra tên ảnh, kích thước không quá 1mb và đuôi ảnh dạng jpg,png')</script>");
            }
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {

        }

       

    }
}