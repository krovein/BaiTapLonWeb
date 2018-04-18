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
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void loadbaivietchuaduyet()
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select * from tblbaiviet where iDuyet = 0", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            dtldschuaduyet.DataSource = dt;
            dtldschuaduyet.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["taikhoan"] != null)
                {
                    if (Session["quyen"].ToString().Equals("1"))
                    {
                        loadbaivietchuaduyet();
                    }
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
        }
        protected void dtldschuaduyet_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Equals("nutduyet"))
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
                cnn.Open();
                SqlCommand cmd = new SqlCommand("update tblbaiviet set iDuyet = 1 where ID_iMabaiviet='"+e.CommandArgument+"'", cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
                loadbaivietchuaduyet();
            }
            if (e.CommandName.Equals("nutxoa"))
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
                cnn.Open();
                SqlCommand cmd = new SqlCommand("delete from tblbaiviet where ID_iMabaiviet='" + e.CommandArgument + "'", cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
                loadbaivietchuaduyet();
            }
        }
    }
}