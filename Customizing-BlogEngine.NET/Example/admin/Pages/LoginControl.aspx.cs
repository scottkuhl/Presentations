using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class admin_Pages_LoginControl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            TextReader tr = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/LoginControl.txt"));
            ShowUserName.Checked = tr.ReadLine() == "Yes";
            tr.Close();
        }
    }
    protected void Save_Click(object sender, EventArgs e)
    {
        TextWriter tw = new StreamWriter(HttpContext.Current.Server.MapPath("~/App_Data/LoginControl.txt"));
        tw.WriteLine(ShowUserName.Checked ? "Yes" : "No");
        tw.Close();
    }
}