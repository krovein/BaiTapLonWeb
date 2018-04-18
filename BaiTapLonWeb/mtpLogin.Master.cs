using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaiTapLonWeb
{
    public partial class masterpage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblonline.Text = Application["demonline"].ToString();
            lbldatruycap.Text = Application["datruycap"].ToString();
            lblloichao.Text = "Chào mừng bạn đến với diễn đàn thảo luận!";
            if (Session["taikhoan"] != null)
            {
                Response.Redirect("index.aspx");
            }
        }
    }
}