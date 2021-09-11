namespace ContosoUniversity.Helpers.Buttons
{
    public class ButtonFluent : IButtonFluent
    {
        private readonly Button _button;

        public ButtonFluent(Button button)
        {
            _button = button;
        }

        public string ToHtmlString()
        {
            return _button.ToHtmlString();
        }

        public IButtonFluent Submit()
        {
            return _button.Submit();
        }
    }
}