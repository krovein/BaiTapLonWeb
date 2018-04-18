using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaiTapLonWeb
{
    public partial class MasterpageFix : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblonline.Text = Application["demonline"].ToString();
            lbldatruycap.Text = Application["datruycap"].ToString();
            if (Session["taikhoan"] != null)
            {
                lblloichao.Text = "Chúc " + Session["taikhoan"] + " online vui vẻ!";
                itemmenuvietbaimoi.Visible = true;
                dangnhap_dangxuat.Text = "Đăng xuất";
                dangnhap_dangxuat.NavigateUrl = "";
                dangnhap_dangxuat.Attributes["onclick"] = "hoidangxuat()";
                dangky_hoso.Text = Session["taikhoan"].ToString();
                dangky_hoso.NavigateUrl = "~/hoso.aspx?id=" + Session["taikhoan"] + "";
            }
            else
            {
                lblloichao.Text = "Chúc bạn online vui vẻ!";
                itemmenuvietbaimoi.Visible = false;
                dangnhap_dangxuat.Text = "Đăng nhập";
                dangnhap_dangxuat.NavigateUrl = "~/dangnhap.aspx";
                dangky_hoso.Text = "Đăng ký";
                dangky_hoso.NavigateUrl = "~/dangky.aspx";
                lblloichao.Text += "<br/>Hãy đăng nhập để có thể sử dụng tối đa diễn đàn!";
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            string[] a = new string[txtsearch.Text.Length];
            string b = "";
            for (int i = 0; i < txtsearch.Text.Length; i++)
            {
                if (txtsearch.Text[i].ToString() == " ")
                {
                    a[i] = "%";
                }
                else
                {
                    a[i] = txtsearch.Text[i].ToString();
                }
            }
            for (int j = 0; j < a.Length; j++)
            {
                b += a[j];
            }
            b = "%" + b + "%";
            Response.Redirect("danhsachbaiviet.aspx?search=" + b + "");
        }
    }
}