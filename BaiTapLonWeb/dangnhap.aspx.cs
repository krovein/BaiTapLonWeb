using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;

namespace BaiTapLonWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
            }
            
        }
        protected void btndangnhap_Click(object sender, EventArgs e)
        {
          
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select * from tblTaikhoan where ID_sTentaikhoan = '" + txttk.Text + "' and sMatkhau = '" + txtmk.Text + "'", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            if (dt.Rows.Count > 0)
            {
                SqlCommand cmdupdatelastlogin = new SqlCommand("capnhatthoigian", cnn);
                cmdupdatelastlogin.CommandType = CommandType.StoredProcedure;
                cmdupdatelastlogin.Parameters.Add("@thoigian", SqlDbType.DateTime);
                cmdupdatelastlogin.Parameters["@thoigian"].Value = DateTime.Now;
                cmdupdatelastlogin.Parameters.Add("@taikhoan", SqlDbType.VarChar,20);
                cmdupdatelastlogin.Parameters["@taikhoan"].Value = dt.Rows[0]["ID_sTentaikhoan"];
                cnn.Open();
                cmdupdatelastlogin.ExecuteNonQuery();
                cnn.Close();
                Session["taikhoan"] = dt.Rows[0]["ID_sTentaikhoan"];
                Session["hoten"] = dt.Rows[0]["sHoten"];
                Session["quyen"] = dt.Rows[0]["FK_iMaquyen"];
                Response.Redirect("index.aspx");
            }
            else
            {
                Response.Write("<script>alert('Tài khoản hoặc mật khẩu không chính xác. Vui lòng kiểm tra lại!')</script>");
            }
        }
        
    }
}