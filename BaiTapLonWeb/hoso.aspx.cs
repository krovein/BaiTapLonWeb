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
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void loadhoso()
        {
            string taikhoan = Request.QueryString["id"];
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select ID_sTentaikhoan,sHoten,sAvatar,sEmail,dNgaysinh,bGioitinh,sDiachi,sTenquyen,dtLastlogin from tbltaikhoan,tblQuyen where ID_sTentaikhoan = '" + taikhoan + "' and tbltaikhoan.FK_iMaquyen = tblQuyen.ID_iMaquyen", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cnn.Close();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ten.Text = dt.Rows[0]["ID_sTentaikhoan"].ToString();
                imgavatar.ImageUrl = dt.Rows[0]["sAvatar"].ToString();
                txthoten.Text = dt.Rows[0]["sHoten"].ToString();
                lblquyen.Text = "Quyền: " + dt.Rows[0]["sTenquyen"].ToString();
                txtlastlogin.Text = dt.Rows[0]["dtLastlogin"].ToString();
                txtemail.Text = dt.Rows[0]["sEmail"].ToString();
                DateTime dtNgaysinh = DateTime.Parse(dt.Rows[0]["dNgaysinh"].ToString());
                txtngaysinh.Text = dtNgaysinh.ToString("MM/dd/yyyy");
                txtdiachi.Text = dt.Rows[0]["sDiachi"].ToString();
                rblGioitinh.SelectedIndex = Convert.ToBoolean(dt.Rows[0]["bGioitinh"].ToString()) == true ? 0 : 1;
                
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
                        btnXoa.Visible = false;
                        btnSaveavatar.Visible = true;
                        upavatar.Visible = true;
                        lblthayavatar.Visible = true;
                        btnSua.Visible = true;
                        
                    }
                    else
                    {
                        btnXoa.Visible = true;
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
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            rd.Next(100000,99999999);
            string taikhoan = Request.QueryString["id"];
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
            cnn.Open();
            SqlCommand cmd = new SqlCommand("update tbltaikhoan set ID_sTentaikhoan='null"+taikhoan+"', sHoten = 'null',sAvatar='images/noavatar.png',FK_iMaquyen=2,dtLastlogin='',sMatkhau='"+rd+ "' where ID_sTentaikhoan= '" + taikhoan + "'", cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            Response.Redirect("index.aspx");
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            txthoten.Enabled = true;
            txtemail.Enabled = true;
            txtdiachi.Enabled = true;
            txtngaysinh.Enabled = true;
            rblGioitinh.Enabled = true;
            btnLuu.Visible = true;
            //String sCnnStr = ConfigurationManager.ConnectionStrings["sqlInjectionDemo"].ToString();
            
            
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString()))
                {
                    string sCmd = "updatethongtin";
                    cnn.Open();
                    using (SqlCommand cm = new SqlCommand(sCmd, cnn))
                    {
                        /*cm.CommandType = CommandType.StoredProcedure;
                        DateTime dtNgaysinh = DateTime.Parse(txtngaysinh.Text);
                        cm.Parameters.AddWithValue("@hoten", txthoten.Text);
                        cm.Parameters.AddWithValue("@email", txtemail.Text);
                        cm.Parameters.AddWithValue("@ngaysinh", dtNgaysinh);
                        cm.Parameters.AddWithValue("@gioitinh", Convert.ToBoolean(rblGioitinh.SelectedValue.ToString()));
                        cm.Parameters.AddWithValue("@diachi", txtdiachi);
                        int n = cm.ExecuteNonQuery();
                        cnn.Close();
                        if (n > 0)
                        {
                            Response.Write("<script language='javascript'>alert('Update thành công');</script>");
                            
                        }*/
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.Add(new SqlParameter("@taikhoan", SqlDbType.VarChar,20));
                        cm.Parameters.Add(new SqlParameter("@hoten", SqlDbType.NVarChar, 50));
                        cm.Parameters.Add(new SqlParameter("@gioitinh", SqlDbType.Bit));
                        cm.Parameters.Add(new SqlParameter("@ngaysinh", SqlDbType.Date));
                        cm.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50));
                        cm.Parameters.Add(new SqlParameter("@diachi", SqlDbType.NVarChar, 255));
                        //cm.Parameters.Add(new SqlParameter("@sAnhUrl", SqlDbType.NVarChar, 250));

                        cm.Parameters[0].Value = ten.Text;
                        cm.Parameters[1].Value = txthoten.Text;
                        cm.Parameters[4].Value = txtemail.Text;
                        DateTime dtNgaysinh = DateTime.Parse(txtngaysinh.Text);
                        cm.Parameters[3].Value = dtNgaysinh.ToString("MM/dd/yyyy");
                        cm.Parameters[2].Value = Convert.ToBoolean(rblGioitinh.SelectedValue.ToString());
                        cm.Parameters[5].Value = txtdiachi.Text;
                        //cm.Parameters[5].Value = fulAnh.FileName;
                        int n = cm.ExecuteNonQuery();
                        cnn.Close();
                        
                        if (n > 0)
                        {
                            Response.Write("<script language='javascript'>alert('Update thành công');</script>");

                        }
                        //Response.Redirect("~/hoso.aspx?id=" + Session["taikhoan"] + "");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script language='javascript'>alert('" + ex.Message + "');</script>");
            }
        }
    }
}