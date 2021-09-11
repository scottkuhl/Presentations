using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Widgets_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            var tr = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/LoginControl.txt"));
            ShowUserName.Checked = tr.ReadLine() == "Yes";
            tr.Close();
        }
    }
    protected void Save_Click(object sender, EventArgs e)
    {
        var tw = new StreamWriter(HttpContext.Current.Server.MapPath("~/App_Data/LoginControl.txt"));
        tw.WriteLine(ShowUserName.Checked ? "Yes" : "No");
        tw.Close();
    }
}