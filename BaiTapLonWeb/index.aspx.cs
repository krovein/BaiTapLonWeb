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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void loaddulieuvaodatalist(string strcmd, DataList dtl)
        {
            if (!IsPostBack)
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strdbmpm"].ToString());
                cnn.Open();
                SqlCommand cmd = new SqlCommand(strcmd, cnn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();
                dtl.DataSource = dt;
                dtl.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loaddulieuvaodatalist("select * from tblchude where FK_iManhomchude = 1 ORDER BY ID_sMachude DESC", dtladmin);
            loaddulieuvaodatalist("select * from tblchude where FK_iManhomchude = 2 ORDER BY ID_sMachude DESC", dtltailieu);
            loaddulieuvaodatalist("select * from tblchude where FK_iManhomchude = 3 ORDER BY ID_sMachude DESC", dtlhoidap);
        }
    }
}