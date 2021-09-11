using System.Web.Mvc;

namespace ContosoUniversity.Helpers.Buttons
{
    public class Button : IButton
    {
        private readonly string _value;
        private ButtonOption _option;
        private bool _submit = false;

        public Button(string value)
        {
            _value = value;
        }

        public string ToHtmlString()
        {
            var button = new TagBuilder(_submit ? "input" : "button");
            button.AddCssClass("btn");
            button.AddCssClass("btn-" + _option.ToString().ToLower());
            if (_submit)
            {
                button.Attributes.Add("type", "submit");
                button.Attributes.Add("value", _value);
            }
            else button.InnerHtml = _value;
            return button.ToString();
        }

        public IButtonFluent Submit()
        {
            _submit = true;
            return new ButtonFluent(this);
        }

        public IButtonFluent Default()
        {
            _option = ButtonOption.Default;
            return new ButtonFluent(this);
        }

        public IButtonFluent Primary()
        {
            _option = ButtonOption.Primary;
            return new ButtonFluent(this);
        }

        public IButtonFluent Success()
        {
            _option = ButtonOption.Success;
            return new ButtonFluent(this);
        }

        public IButtonFluent Info()
        {
            _option = ButtonOption.Info;
            return new ButtonFluent(this);
        }

        public IButtonFluent Warning()
        {
            _option = ButtonOption.Warning;
            return new ButtonFluent(this);
        }

        public IButtonFluent Danger()
        {
            _option = ButtonOption.Danger;
            return new ButtonFluent(this);
        }

        public IButtonFluent Link()
        {
            _option = ButtonOption.Link;
            return new ButtonFluent(this);
        }
    }
}