using BlogEngine.Core.Web.Controls;
using System;
using BlogEngine.Core;
using System.Text;
using System.Configuration;
using System.Net;
using System.IO;
using System.Web;

[Extension("Write each title to a log.", "1.0", "St. Louis Day of .NET Sample")]
public class LogSample
{
	public LogSample()
	{
		Post.Saving += new EventHandler<SavedEventArgs>(Post_Saving);
	}

	void Post_Saving(object sender, EventArgs e)
	{
		var post = (Post)sender;
		if (!post.New) return;

        var tw = new StreamWriter(HttpContext.Current.Server.MapPath("~/App_Data/LogExtensionSample.txt"), true);
        tw.WriteLine(post.Title);
        tw.Close();		
	}
}