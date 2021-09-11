using System;
using System.Collections;
using System.Web.Services;
using System.Web;
using System.Collections.Generic;
using System.Linq;

using BlogEngine.Core;
using BlogEngine.Core.Json;
using App_Code;

public partial class Notification : System.Web.UI.Page
{    
    [WebMethod]
    public static string GetLatestPostId()
    {
        var post = Post.Posts.Where(t => t.Next == null).FirstOrDefault();
        return post.Id.ToString();
    }
}
