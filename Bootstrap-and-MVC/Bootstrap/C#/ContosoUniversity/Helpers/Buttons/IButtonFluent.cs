using System.Web;

namespace ContosoUniversity.Helpers.Buttons
{
    public interface IButtonFluent : IHtmlString
    {
        IButtonFluent Submit();
    }
}