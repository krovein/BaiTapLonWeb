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
    public partial class quanlychude : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
            cnn.Open();
            string strcmd = "select * from tblChude";
            SqlCommand cmd = new SqlCommand(strcmd, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            grdV.DataSource = dt;
            grdV.DataBind();
        }
        public void BindDataGrid()
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
            cnn.Open();
            string strcmd = "select * from tblChude";
            SqlCommand cmd = new SqlCommand(strcmd, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            grdV.DataSource = dt;
            grdV.DataBind();
        }

        protected void gridAge_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdV.PageIndex = e.NewPageIndex;
            BindDataGrid();
        }    

        protected void gridAge_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdV.EditIndex = -1;
            BindDataGrid();
        }

        protected void grdV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdV.EditIndex = (int)e.NewEditIndex;
            BindDataGrid();
        }
    }
   
}