// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Post Pager
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace App_Code.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using BlogEngine.Core;

    using Resources;

    /// <summary>
    /// Post Pager
    /// </summary>
    public class PostPager : PlaceHolder
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the list of posts to display.
        /// </summary>
        public List<IPublishable> Posts { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Sends server control content to a provided <see cref="T:System.Web.UI.HtmlTextWriter"/> object, which writes the content to be rendered on the client.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter"/> object that receives the server control content.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write(this.PagerTag());
        }

        /// <summary>
        /// Pages the index.
        /// </summary>
        /// <returns>The index.</returns>
        private static int PageIndex()
        {
            var retValue = 1;
            var url = HttpContext.Current.Request.RawUrl;
            if (url.Contains("page="))
            {
                url = url.Replace(url.Substring(0, url.IndexOf("page=") + 5), string.Empty);
                try
                {
                    retValue = int.Parse(url);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }

            return retValue;
        }

        /// <summary>
        /// The page list.
        /// </summary>
        /// <param name="total">
        /// The total.
        /// </param>
        /// <param name="current">
        /// The current.
        /// </param>
        /// <returns>
        /// A list of page numbers.
        /// </returns>
        private static IEnumerable<int> PageList(int total, int current)
        {
            var pages = new List<int>();
            var midStack = new List<int>();
            
            // should be more then 4
            const int MaxPages = 12; 
            
            if (MaxPages > total)
            {
                for (var i = 1; i <= total; i++)
                {
                    pages.Add(i);
                }
            }
            else
            {
                const int Midle = (MaxPages - 4) / 2;

                // always show first two
                pages.Add(1);
                pages.Add(2);

                for (var i = current - Midle; i <= (current + Midle); i++)
                {
                    if (i > 2 && i < (total - 1))
                    {
                        midStack.Add(i);
                    }
                }

                // pad to the end if less than needed
                if (midStack.Count < (MaxPages - 2))
                {
                    var last = int.Parse(midStack[midStack.Count - 1].ToString());
                    for (var j = last + 1; j <= (MaxPages - 2); j++)
                    {
                        midStack.Add(j);
                    }
                }

                // pad in the beginning if needed
                if (midStack.Count < (MaxPages - 4))
                {
                    midStack.Clear();
                    for (var k = total - MaxPages + 3; k <= (total - 2); k++)
                    {
                        midStack.Add(k);
                    }
                }

                if (int.Parse(midStack[0].ToString()) > 3)
                {
                    pages.Add(0);
                }

                pages.AddRange(midStack.Select(p => int.Parse(p.ToString())));

                if (int.Parse(midStack[midStack.Count - 1].ToString()) < (total - 2))
                {
                    pages.Add(0);
                }

                // always show last two
                pages.Add(total - 1);
                pages.Add(total);
            }

            return pages;
        }

        /// <summary>
        /// Pages the URL.
        /// </summary>
        /// <returns>The page URL.</returns>
        private static string PageUrl()
        {
            var path = HttpContext.Current.Request.RawUrl.Replace("Default.aspx", string.Empty);
            if (path.Contains("?"))
            {
                if (path.Contains("page="))
                {
                    var index = path.IndexOf("page=");
                    path = path.Substring(0, index);
                }
                else
                {
                    path += "&";
                }
            }
            else
            {
                path += "?";
            }

            return path + "page={0}";
        }

        /// <summary>
        /// Gets the pager tag.
        /// </summary>
        /// <returns>The pager tag.</returns>
        private string PagerTag()
        {
            var retValue = string.Empty;
            var link = string.Format("<li class=\"PagerLink\"><a href=\"{0}\">{{1}}</a></li>", PageUrl());
            const string LinkCurrent = "<li class=\"PagerLinkCurrent\">{0}</li>";
            var linkFirst = string.Format("<li class=\"PagerFirstLink\"><a href=\"{0}\">{{0}}</a></li>", PageUrl());
            const string LinkDisabled = "<li class=\"PagerLinkDisabled\">{0}</li>";

            var postsPerPage = BlogSettings.Instance.PostsPerPage;
            var currentPage = PageIndex();

            var visiblePosts = this.Posts.FindAll(p => p.IsVisible);
            var postCnt = visiblePosts.Count;

            var pagesTotal = postCnt % postsPerPage == 0 ? postCnt / postsPerPage : (postCnt / postsPerPage) + 1;

            if (pagesTotal == 0)
            {
                pagesTotal = 1;
            }

            if (postCnt > 0 && pagesTotal > 1)
            {
                retValue = "<ul id=\"PostPager\">";

                if (currentPage == 1)
                {
                    retValue += string.Format(LinkDisabled, labels.nextPosts);
                }
                else
                {
                    retValue += string.Format(link, currentPage - 1, labels.nextPosts);
                }

                var pages = PageList(pagesTotal, currentPage);
                foreach (var i in pages.Select(page => int.Parse(page.ToString())))
                {
                    if (i == 0)
                    {
                        retValue += "<li class=\"PagerEllipses\">...</li>";
                    }
                    else
                    {
                        if (i == currentPage)
                        {
                            retValue += string.Format(LinkCurrent, i);
                        }
                        else
                        {
                            if (i == 1)
                            {
                                retValue += string.Format(linkFirst, i);
                            }
                            else
                            {
                                retValue += string.Format(link, i, i);
                            }
                        }
                    }
                }

                if (currentPage == pagesTotal)
                {
                    retValue += string.Format(LinkDisabled, labels.previousPosts);
                }
                else
                {
                    retValue += string.Format(link, currentPage + 1, labels.previousPosts);
                }

                retValue += "</ul>";
            }

            return retValue;
        }

        #endregion
    }
}