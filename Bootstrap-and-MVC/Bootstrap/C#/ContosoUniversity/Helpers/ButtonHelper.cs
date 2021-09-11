using System.Web.Mvc;
using ContosoUniversity.Helpers.Buttons;

namespace ContosoUniversity.Helpers
{
    public static class ButtonHelper
    {
        public static Button BootstrapButton(this HtmlHelper html, string value)
        {
            return new Button(value);
        }
    }
}