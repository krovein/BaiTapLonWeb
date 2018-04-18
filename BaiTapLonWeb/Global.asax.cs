using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace BaiTapLonWeb
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            int demtruycap = 0;
            //Kiểm tra file count_visit.txt nếu không tồn  tại thì
            if (System.IO.File.Exists(Server.MapPath("demtruycap.txt")) == false)
            {
                demtruycap = 1;
            }
            // Ngược lại thì
            else
            {
                // Đọc dử liều từ file count_visit.txt
                System.IO.StreamReader read = new System.IO.StreamReader(Server.MapPath("demtruycap.txt"));
                demtruycap = int.Parse(read.ReadLine());
                read.Close();
                // Tăng biến count_visit thêm 1
                demtruycap++;
            }
            // khóa website
            Application.Lock();

            // gán biến Application count_visit
            Application["datruycap"] = demtruycap;

            // Mở khóa website
            Application.UnLock();

            // Lưu dử liệu vào file  count_visit.txt
            System.IO.StreamWriter writer = new System.IO.StreamWriter(Server.MapPath("demtruycap.txt"));
            writer.WriteLine(demtruycap);
            writer.Close();
            Application["demonline"] = 0;
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            Session["taikhoan"] = null;
            Session["hoten"] = null;
            Session["avatar"] = null;
            Session["quyen"] = null;
            Session["khoa"] = null;
            Session["truycapcuoi"] = null;
            Application["demonline"] = Int32.Parse(Application["demonline"].ToString()) + 1;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application["demonline"] = Int32.Parse(Application["demonline"].ToString()) - 1;
        }
        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}