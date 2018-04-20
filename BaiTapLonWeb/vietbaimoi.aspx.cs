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
    public partial class WebForm12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["taikhoan"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                if (rdbtnkhong.Checked)
                {
                    fupload.Visible = false;
                }
                else
                {
                    fupload.Visible = true;
                }
                if (!IsPostBack)
                {
                    ddldschude.Items.Clear();
                    SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("select * from tblchude", cnn);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ListItem itemddl;
                            string txtlist = null;
                            string valuelist = null;
                            if (dr["FK_iManhomchude"].ToString().Equals("2"))
                            {
                                txtlist = "Tài Liệu " + dr["sTenchude"].ToString();
                                valuelist = dr["ID_sMachude"].ToString();
                            }
                            else if (dr["FK_iManhomchude"].ToString().Equals("3"))
                            {
                                txtlist = "Hỏi Đáp " + dr["sTenchude"].ToString();
                                valuelist = dr["ID_sMachude"].ToString();
                            }
                            else
                            {
                                txtlist = dr["sTenchude"].ToString();
                                valuelist = dr["ID_sMachude"].ToString();
                            }
                            itemddl = new ListItem(txtlist, valuelist);
                            ddldschude.Items.Add(itemddl);
                            if (Session["quyen"].ToString() != "1")
                            {
                                ListItem xoaitemthongbao = ddldschude.Items.FindByValue("thongbao");
                                ListItem xoaitemnoiquy = ddldschude.Items.FindByValue("noiquy");
                                ddldschude.Items.Remove(xoaitemthongbao);
                                ddldschude.Items.Remove(xoaitemnoiquy);
                            }
                        }
                    }
                    cnn.Close();
                    string chude = Request.QueryString["chude"];
                    if (chude != null && chude != "")
                    {
                        ddldschude.SelectedValue = chude;
                        ddldschude.Enabled = false;
                    }
                    else
                    {
                        ddldschude.SelectedIndex = 0;
                    }
                }
            }
        }
        protected void btnNhaplai_Click(object sender, EventArgs e)
        {
            txtTenchude.Text = null;
            txtNoidung.Text = null;
            rdbtnkhong.Checked = true;
            rdbtnco.Checked = false;
            fupload.FileContent.Close();
        }
        protected void btnDongy_Click(object sender, EventArgs e)
        {
            string tieudebaiviet = txtTenchude.Text;
            string noidungbaiviet = txtNoidung.Text;
            string machude = ddldschude.SelectedValue;
            int iduyet=0;
            if (Session["quyen"].ToString().Equals("1"))
            {
                iduyet = 1;
            }
            if (rdbtnco.Checked)
            {
                if (fupload.FileName.Equals(""))
                {
                    Response.Write("<script>alert('Bạn chưa chọn file');</script>");
                }
                else
                {
                    string filename = "";
                    string filepath = "";
                    string imagepath = ConfigurationManager.AppSettings["fileuploadpath"];
                    if (fupload.HasFile)
                    {
                        filename = imagepath + fupload.FileName;
                        filepath = MapPath(filename);
                        fupload.SaveAs(filepath);
                    }
                    SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
                    cnn.Open();
                    string querytext = "select * from tblBaiviet where sTieudebaiviet = '" + tieudebaiviet + "'";
                    SqlCommand cmd1 = new SqlCommand(querytext,cnn);
                    var rd=cmd1.ExecuteReader();
                    if (rd.HasRows)
                    {
                        Response.Write("<script>alert('Tiêu đề bài viết đã tồn tại!, vui lòng nhập lại')</script>");
                        cnn.Close();
                        return;
                    }

                    SqlCommand cmd = new SqlCommand("insert into tblBaiviet(sTieudebaiviet,sNoidungbaiviet,FK_sMachude,sLinktai,dtThoigiandang,FK_sTentaikhoan,iDuyet) values (N'" + tieudebaiviet + "',N'" + noidungbaiviet + "','" + machude + "','" + filename + "','" + DateTime.Now.ToString() + "','" + Session["taikhoan"] + "',"+iduyet+")", cnn);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    if (Session["quyen"].ToString().Equals("2"))
                    {
                        Response.Write("<script>alert('Viết bài thành công! vui lòng đợi quản trị viên phê duyệt!')</script>");
                    }
                    else
                    {
                        Response.Redirect("index.aspx");
                    }
                }
            }
            else
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
                cnn.Open();
                string querytext = "select * from tblBaiviet where sTieudebaiviet = '" + tieudebaiviet+"'";
                SqlCommand cmd1 = new SqlCommand(querytext,cnn);
                
                var rd = cmd1.ExecuteReader();
                if (rd.HasRows)
                {
                    Response.Write("<script>alert('Tiêu đề bài viết đã tồn tại!, vui lòng nhập lại')</script>");
                    cnn.Close();
                    return;
                }
                string strcmd = "insert into tblBaiviet(sTieudebaiviet,sNoidungbaiviet,FK_sMachude,dtThoigiandang,FK_sTentaikhoan,iDuyet) values (N'" + tieudebaiviet + "',N'" + noidungbaiviet + "','" + machude + "','" + DateTime.Now.ToString() + "','" + Session["taikhoan"].ToString() + "'," + iduyet + ")";
                SqlCommand cmd = new SqlCommand(strcmd, cnn);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    Response.Write("<script>alert('Kích thước tối được nhập vào là 500 kí tự')</script>");
                }
                cnn.Close();
                if (Session["quyen"].ToString().Equals("2"))
                {
                    Response.Write("<script>alert('Viết bài thành công! vui lòng đợi quản trị viên phê duyệt!')</script>");
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
        }
    }
}