using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code.Controls;
using System.Collections.Specialized;

public partial class widgets_AuthorList_edit : WidgetEditBase
{
    public override void Save()
    {
        var settings = new StringDictionary();
        settings.Add("Sample", ShowSample.Checked ? "St. Louis Day .NET" : string.Empty);
        SaveSettings(settings);
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!this.Page.IsPostBack)
        {
            var settings = GetSettings();
            ShowSample.Checked = !string.IsNullOrEmpty(settings["Sample"]);
        }
    }

}