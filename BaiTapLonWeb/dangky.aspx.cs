using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace BaiTapLonWeb
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btndangky_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select * from tblTaikhoan where ID_sTentaikhoan = '" + txttk.Text + "'", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            if (dt.Rows.Count > 0)
            {
                lblerrdk.Text = "Tên tài khoản đã tồn tại!";
            }
            else
            {
                
                /*cnn.Open();
                SqlCommand cmdinsettk = new SqlCommand("insert into tblTaikhoan(ID_sTentaikhoan,sMatkhau,sHoten,FK_iMaquyen) values ('" + txttk.Text + "','" + txtmk.Text + "',N'" + txthoten.Text + "', 2)", cnn);
                cmdinsettk.ExecuteNonQuery();
                cnn.Close();
                Response.Write("<script>alert('Đăng ký thành công! vui lòng đăng nhập!')</script>");*/
                try
                {
                        string sCmd = "themtaikhoan";
                        cnn.Open();
                        using (SqlCommand cm = new SqlCommand(sCmd, cnn))
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.Parameters.Add(new SqlParameter("@tentaikhoan", SqlDbType.VarChar, 20));
                            cm.Parameters.Add(new SqlParameter("@matkhau", SqlDbType.VarChar, 255));
                            cm.Parameters.Add(new SqlParameter("@hoten", SqlDbType.NVarChar, 50));
                            cm.Parameters.Add(new SqlParameter("@gioitinh", SqlDbType.Bit));
                            cm.Parameters.Add(new SqlParameter("@ngaysinh", SqlDbType.Date));
                            cm.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50));
                            cm.Parameters.Add(new SqlParameter("@diachi", SqlDbType.NVarChar, 255));
                            cm.Parameters.Add(new SqlParameter("@maquyen", SqlDbType.Int));
                            
                            cm.Parameters[0].Value = txttk.Text;
                            cm.Parameters[1].Value = txtmk.Text;
                            cm.Parameters[2].Value = txthoten.Text;
                            cm.Parameters[5].Value = txtemail.Text;
                            DateTime dtNgaysinh = DateTime.Parse(txtngaysinh.Text);
                            cm.Parameters[4].Value = dtNgaysinh.ToString("MM/dd/yyyy");
                            cm.Parameters[3].Value = Convert.ToBoolean(rblGioitinh.SelectedValue.ToString());
                            cm.Parameters[6].Value = txtdiachi.Text;
                            cm.Parameters[7].Value = 2;
                            int n = cm.ExecuteNonQuery();
                            cnn.Close();
                            
                            if (n > 0)
                            {
                                Response.Write("<script language='javascript'>alert('Thêm mới thành công');</script>");
                                //Response.Redirect("~/dangky.aspx");
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
}